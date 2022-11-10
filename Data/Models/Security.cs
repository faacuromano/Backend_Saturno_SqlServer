using System.Security.Cryptography;
using System.Text;

namespace Saturno_Backend.Data.Models
{
    public class Security
    {
        public string CreateSHA512(string strData)
        {
            var message = System.Text.Encoding.UTF8.GetBytes(strData);
            using (var alg = SHA512.Create())
            {
                string hex = "";

                var hashValue = alg.ComputeHash(message);
                foreach (byte x in hashValue)
                {
                    hex += String.Format("{0:x2}", x);
                }
                return hex;
            }
      }
    }
}