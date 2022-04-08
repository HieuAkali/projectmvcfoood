using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Web;

namespace hkrestaurant.Controllers
{
    public class MD5
    {
        public string MD5Hash(string input)
        {
            using (MD5CryptoServiceProvider MD5 = new MD5CryptoServiceProvider())
            {
                byte[] b = System.Text.Encoding.UTF8.GetBytes(input);
                b = MD5.ComputeHash(b);
                System.Text.StringBuilder sb = new System.Text.StringBuilder();
                foreach (byte x in b)
                    sb.Append(x.ToString("x2"));
                return sb.ToString();
            }
        }
    }

}