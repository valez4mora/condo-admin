using BLL;
using DTO;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace UI.Forms
{
    public partial class FrmBitacora : Form
    {
        private readonly BitacoraBLL bitacoraBLL = new BitacoraBLL();
        private List<BitacoraDTO> registros = new List<BitacoraDTO>();
        private bool cargandoFiltros;

        public FrmBitacora()
        {
            InitializeComponent();
        }

        private void FrmBitacora_Load(object sender, EventArgs e)
        {
            dtpDesde.Value = DateTime.Today.AddMonths(-1);
            dtpHasta.Value = DateTime.Today;
            dtpDesde.Checked = false;
            dtpHasta.Checked = false;
            CargarBitacora();
        }

        private void CargarBitacora()
        {
            try
            {
                UseWaitCursor = true;

                bool filtrarPorFecha = dtpDesde.Checked || dtpHasta.Checked;
                if (filtrarPorFecha)
                {
                    DateTime desde = dtpDesde.Checked ? dtpDesde.Value.Date : DateTime.Today.AddYears(-1);
                    DateTime hasta = dtpHasta.Checked ? dtpHasta.Value.Date : DateTime.Today;
                    registros = bitacoraBLL.ObtenerPorFecha(desde, hasta);
                }
                else
                {
                    registros = bitacoraBLL.ObtenerTodas();
                }

                CargarUsuarios();
                AplicarFiltros();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "No fue posible consultar la bitácora.\n\n" + ex.Message,
                    "Bitácora",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
            finally
            {
                UseWaitCursor = false;
            }
        }

        private void CargarUsuarios()
        {
            string seleccionActual = cmbUsuario.SelectedItem == null
                ? "Todos los usuarios"
                : cmbUsuario.SelectedItem.ToString();

            List<string> usuarios = registros
                .Select(x => string.IsNullOrWhiteSpace(x.NombreUsuario)
                    ? "Usuario no disponible"
                    : x.NombreUsuario.Trim())
                .Distinct(StringComparer.OrdinalIgnoreCase)
                .OrderBy(x => x)
                .ToList();

            usuarios.Insert(0, "Todos los usuarios");

            cargandoFiltros = true;
            cmbUsuario.DataSource = usuarios;

            int indice = usuarios.FindIndex(x =>
                string.Equals(x, seleccionActual, StringComparison.OrdinalIgnoreCase));
            cmbUsuario.SelectedIndex = indice >= 0 ? indice : 0;
            cargandoFiltros = false;
        }

        private void AplicarFiltros()
        {
            IEnumerable<BitacoraDTO> consulta = registros;
            string usuario = cmbUsuario.SelectedItem == null
                ? string.Empty
                : cmbUsuario.SelectedItem.ToString();
            string texto = txtBuscar.Text.Trim();

            if (!string.IsNullOrWhiteSpace(usuario) && usuario != "Todos los usuarios")
            {
                consulta = consulta.Where(x => string.Equals(
                    string.IsNullOrWhiteSpace(x.NombreUsuario) ? "Usuario no disponible" : x.NombreUsuario.Trim(),
                    usuario,
                    StringComparison.OrdinalIgnoreCase));
            }

            if (!string.IsNullOrWhiteSpace(texto))
            {
                consulta = consulta.Where(x =>
                    Contiene(x.Evento, texto) ||
                    Contiene(x.NombreUsuario, texto) ||
                    x.IdBitacora.ToString().Contains(texto) ||
                    x.IdUsuario.ToString().Contains(texto));
            }

            List<BitacoraDTO> resultado = consulta
                .OrderByDescending(x => x.Fecha)
                .ThenByDescending(x => x.IdBitacora)
                .ToList();

            dgvBitacora.DataSource = null;
            dgvBitacora.DataSource = resultado;
            lblResultados.Text = resultado.Count == 1
                ? "1 evento encontrado"
                : resultado.Count + " eventos encontrados";

            if (resultado.Count == 0)
            {
                LimpiarDetalle();
            }
            else
            {
                dgvBitacora.ClearSelection();
                dgvBitacora.Rows[0].Selected = true;
                MostrarDetalle(resultado[0]);
            }
        }

        private static bool Contiene(string valor, string texto)
        {
            return !string.IsNullOrWhiteSpace(valor) &&
                   valor.IndexOf(texto, StringComparison.OrdinalIgnoreCase) >= 0;
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            CargarBitacora();
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            dtpDesde.Checked = false;
            dtpHasta.Checked = false;
            txtBuscar.Clear();
            cmbUsuario.SelectedIndex = cmbUsuario.Items.Count > 0 ? 0 : -1;
            CargarBitacora();
            txtBuscar.Focus();
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            CargarBitacora();
        }

        private void cmbUsuario_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!cargandoFiltros && registros != null)
                AplicarFiltros();
        }

        private void txtBuscar_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                AplicarFiltros();
                e.SuppressKeyPress = true;
            }
        }

        private void dgvBitacora_SelectionChanged(object sender, EventArgs e)
        {
            BitacoraDTO seleccionado = dgvBitacora.CurrentRow == null
                ? null
                : dgvBitacora.CurrentRow.DataBoundItem as BitacoraDTO;

            if (seleccionado == null)
                LimpiarDetalle();
            else
                MostrarDetalle(seleccionado);
        }

        private void MostrarDetalle(BitacoraDTO registro)
        {
            lblDetalleFecha.Text = registro.Fecha.ToString("dd/MM/yyyy hh:mm:ss tt");
            lblDetalleUsuario.Text = string.IsNullOrWhiteSpace(registro.NombreUsuario)
                ? "Usuario no disponible"
                : registro.NombreUsuario;
            lblDetalleId.Text = registro.IdBitacora.ToString();
            txtDetalleEvento.Text = registro.Evento ?? string.Empty;
        }

        private void LimpiarDetalle()
        {
            lblDetalleFecha.Text = "—";
            lblDetalleUsuario.Text = "—";
            lblDetalleId.Text = "—";
            txtDetalleEvento.Clear();
        }

        private void dgvBitacora_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dgvBitacora.Columns[e.ColumnIndex].Name == "colFecha" && e.Value is DateTime)
            {
                e.Value = ((DateTime)e.Value).ToString("dd/MM/yyyy hh:mm:ss tt");
                e.FormattingApplied = true;
            }

            if (e.RowIndex >= 0 && e.RowIndex % 2 != 0)
                dgvBitacora.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.FromArgb(248, 250, 252);
        }
    }
}
