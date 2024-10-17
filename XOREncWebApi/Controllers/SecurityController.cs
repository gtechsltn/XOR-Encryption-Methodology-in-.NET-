using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections;
using System.Security.Cryptography.X509Certificates;
using System.Security.Cryptography.Xml;
using System.Text;
using XOREncWebApi.Models;
using XOREncWebApi.Services;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace XOREncWebApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class SecurityController : ControllerBase
    {
        private readonly XorEncryption _xorEncryption;
        private readonly TokenService _tokenService;
        private readonly TokenValidator _tokenValidator;
        public SecurityController(XorEncryption xorEncryption,
            TokenService tokenService,
            TokenValidator tokenValidator)
        {
            _xorEncryption = xorEncryption;
            _tokenService = tokenService;
            _tokenValidator = tokenValidator;

        }

        [HttpPost]
        public IActionResult GenerateToken(RequestMsg requestMsg)
        {
            string token = _tokenService.GenerateToken(requestMsg.data, requestMsg.secretKey);
            Console.WriteLine("Generated Token: " + token);
            byte[] encryptedBytes = Encoding.UTF8.GetBytes(token);

            // Convert to Base64 to make it web-safe
            return Ok(Convert.ToBase64String(encryptedBytes));
        }


        [HttpPost]
        public IActionResult ValidateToken(RequestValidate requestMsg)
        {
            bool isValid = _tokenValidator.ValidateToken(requestMsg.enc_token, requestMsg.data, requestMsg.secretKey);
            Console.WriteLine("Is Token Valid? " + isValid);

            return Ok(isValid);
        }

    }
}
