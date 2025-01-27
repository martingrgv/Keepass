using Keepass.Application.Contracts;
using System.Security.Cryptography;
using System.Text;

namespace Keepass.Infrastructure.Data.Services
{
    public class CyptographerService : ICryptography
    {
        private byte[] _key;
        private byte[] _iv;

        public void SetKey(string key)
        {
            using var sha256 = SHA256.Create();

            byte[] keyBytes = Encoding.UTF8.GetBytes(key);
            _key = sha256.ComputeHash(keyBytes);

            _iv = new byte[16];
            Array.Copy(_key, _iv, _iv.Length);
        }

        public string Encrypt(string plainText)
        {
            if (_key is null)
            {
                throw new ArgumentNullException($"Key cannot be null!");
            }

            if (plainText == null)
            {
                throw new ArgumentNullException($"No {plainText} passed throught method!");
            }

            using (var aes = Aes.Create())
            {
                aes.Key = _key;
                aes.IV = _iv;

                var encryptor = aes.CreateEncryptor(aes.Key, aes.IV);

                using (var ms = new MemoryStream())
                {
                    using (var cs = new CryptoStream(ms, encryptor, CryptoStreamMode.Write))
                    using (var sw = new StreamWriter(cs))
                    {
                        sw.Write(plainText);
                    }

                    return Convert.ToBase64String(ms.ToArray());
                }
            }
        }

        public string Decrypt(string cypher) 
        {
            if (_key is null)
            {
                throw new ArgumentNullException($"Key cannot be null!");
            }

            if (cypher == null)
            {
                throw new ArgumentNullException($"No {cypher} passed throught method!");
            }

            byte[] cypherBytes = Convert.FromBase64String(cypher);

            using (var aes = Aes.Create())
            {
                aes.Key = _key;
                aes.IV = _iv;

                var decryptor = aes.CreateDecryptor(aes.Key, aes.IV);

                using (var ms = new MemoryStream(cypherBytes))
                {
                    using (var cs = new CryptoStream(ms, decryptor, CryptoStreamMode.Read))
                    using (var sr = new StreamReader(cs))
                    {
                        string plainText = sr.ReadToEnd();

                        return plainText;
                    }
                }
            }
        }
    }
}
