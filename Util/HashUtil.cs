using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Util
{
    public static class HashUtil
    {

        public static string Hashear(string contrasenaPlana)
        {
            if (string.IsNullOrWhiteSpace(contrasenaPlana))
                throw new ArgumentException("La contraseña no puede estar vacía.");

            using (SHA256 sha = SHA256.Create())
            {
                byte[] bytes = Encoding.UTF8.GetBytes(contrasenaPlana);
                byte[] hash = sha.ComputeHash(bytes);

                // Convertir bytes a string hexadecimal
                StringBuilder sb = new StringBuilder();
                foreach (byte b in hash)
                    sb.Append(b.ToString("x2")); 

                return sb.ToString();
            }
        }












    }
}
