using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;

namespace Aloti.Forms.Prims.Helpers
{
    public class Encrypt
    {
        public static string GetSHA256(string str)
        {
            SHA256 sHA256 = SHA256Managed.Create();
            ASCIIEncoding aSCIIEncoding = new ASCIIEncoding();
            byte[] stream = null;
            StringBuilder stringBuilder = new StringBuilder();
            stream = sHA256.ComputeHash(aSCIIEncoding.GetBytes(str));

            for (int i = 0; i < stream.Length; i++)
            {
                stringBuilder.AppendFormat("{0:x2}", stream[i]);
            }

            return $"{stringBuilder}";
        }
    }
}
