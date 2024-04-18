using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Diagnostics.HealthChecks;
using SigningService.Models;
using System.Runtime.Serialization.Formatters.Binary;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
using System.Text.Json;

namespace SigningService.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SigningController : ControllerBase
    {
        [HttpPost]
        [Route("/api/signing")]
        public async Task<ActionResult> SignDocument(Document document, X509Certificate2 certificate)
        {
            RSA publicKey = certificate.GetRSAPublicKey();
            RSA privateKey = certificate.GetRSAPrivateKey();
            byte[] dataToSign;

            dataToSign = JsonSerializer.SerializeToUtf8Bytes(document);

            using (RSA rsa = privateKey)
            {
                byte[] signature = rsa.SignData(dataToSign, HashAlgorithmName.SHA256, RSASignaturePadding.Pkcs1);


            }
        }

    }
}
