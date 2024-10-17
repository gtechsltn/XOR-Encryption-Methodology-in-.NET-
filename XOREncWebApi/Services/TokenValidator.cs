using System.Security.Cryptography;
using System.Text;

namespace XOREncWebApi.Services
{
    public class TokenValidator
    {
        private readonly TokenService _tokenService;

        public TokenValidator(TokenService tokenService)
        {
            _tokenService = tokenService;
        }

        public bool ValidateToken(string enc_token, string expectedData, string key)
        {
            // Convert Base64 back to original string
            byte[] encryptedBytes = Convert.FromBase64String(enc_token);
            string token = Encoding.UTF8.GetString(encryptedBytes);

            // Decrypt the token
            string decryptedData = _tokenService.GenerateToken(token, key);

            return decryptedData == expectedData;
        }
    }
}
