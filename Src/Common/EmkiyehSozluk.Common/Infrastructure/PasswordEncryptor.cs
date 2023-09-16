
using System.Security.Cryptography;
using System.Text;


namespace EmkiyehSozluk.Common.Infrastructure
{
    public  class PasswordEncryptor
    {
        public static string Encrpt(string pass)
        {
            using var md5 = MD5.Create();

            byte[] inputBytes =Encoding.ASCII.GetBytes(pass);
            byte[] hashBytes=md5.ComputeHash(inputBytes);

            return Convert.ToHexString(hashBytes);
        }
    }
}
