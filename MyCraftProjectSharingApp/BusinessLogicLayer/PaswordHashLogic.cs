using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;

namespace BusinessLogicLayer
{
    public class PaswordHashLogic
    {
        public string HashPassword(string passwordToHash)
        {
            MD5 md5 = MD5.Create();
            byte[] inputBytes = Encoding.ASCII.GetBytes(passwordToHash);
            byte[] hashedBytes = md5.ComputeHash(inputBytes);
            StringBuilder newPassword = new StringBuilder();
            for (int i = 0; i < hashedBytes.Length; i++)
            {
                newPassword.Append(hashedBytes[i].ToString("X2"));
            }
            return newPassword.ToString();
        } //hashes password and returns it
    }
}
