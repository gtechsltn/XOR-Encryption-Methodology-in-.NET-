using System.Security.Cryptography;
using System.Text;

namespace XOREncWebApi.Services
{
    public class XorEncryption
    {
        public string EncryptDecrypt(string input, string key)
        {
            StringBuilder output = new StringBuilder();

            for (int i = 0; i < input.Length; i++)
            {
                // XOR each character of the input with the key
                char c = (char)(input[i] ^ key[i % key.Length]);
                output.Append(c);
            }

            return output.ToString();
        }
    }
}
