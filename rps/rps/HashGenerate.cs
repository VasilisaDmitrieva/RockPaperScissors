using System;
using System.Security.Cryptography;
using System.Text;

namespace rps
{
    class HashGenerate
    {
        private byte[] key;

        public HashGenerate()
        {
            RandomNumberGenerator keyGenerator = RandomNumberGenerator.Create();
            key = new byte[32];
            keyGenerator.GetBytes(key);
        }

        public string getKey()
        {
            return BitConverter.ToString(key).Replace("-", "");
        }

        public string hmac(string str)
        {
            using (HMACSHA256 hmac = new HMACSHA256(key))
            {
                byte[] bstr = Encoding.Default.GetBytes(str);
                return BitConverter.ToString(hmac.ComputeHash(bstr)).Replace("-", "");
            }
        }
    }
}
