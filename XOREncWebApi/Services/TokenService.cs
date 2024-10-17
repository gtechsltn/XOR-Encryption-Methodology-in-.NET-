using System.Security.Cryptography;

namespace XOREncWebApi.Services
{
    public class TokenService
    {
        private readonly XorEncryption _xorEncryption;

        public TokenService(XorEncryption xorEncryption)
        {
            _xorEncryption = xorEncryption;
        }

        public string GenerateToken(string data, string _key)
        {
            return _xorEncryption.EncryptDecrypt(data, _key);
        }
    }
}
