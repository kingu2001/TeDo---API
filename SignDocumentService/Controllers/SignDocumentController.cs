using Microsoft.AspNetCore.Mvc;
using SignDocumentService.Models;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
using System.Text.Json;

namespace SignDocumentService.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SignDocumentController : ControllerBase
    {
        private readonly string _fileServiceBaseUrl;
        private readonly string _certificateServiceBaseUrl;
        private readonly HttpClient _client;

        public SignDocumentController(HttpClient httpClient)
        {
            _fileServiceBaseUrl = "http://localhost:5297/api/SignedDocument";
            _certificateServiceBaseUrl = "http://localhost:5297/api/Certificate/2";
            _client = httpClient;
        }

        [HttpPost]
        public async Task<ActionResult<string>> SignUnsignedDocument(Document document, string signee, string comment)
        {
            //create signed document
            SignedDocument signedDocument = new SignedDocument
            {
                Id = document.Id,
                FileName = "signed_" + document.FileName,
                ContentType = document.ContentType,
                FileContent = document.FileContent,
                Stamps = new List<Stamp>()
            };

            Certificate cert = await _client.GetFromJsonAsync<Certificate>(_certificateServiceBaseUrl);
            X509Certificate2 certificate = new X509Certificate2(cert.CertificateData, "12345");
            //Sign document
            byte[] dataToSign;
            RSA privatekey = certificate.GetRSAPrivateKey();
            using (MemoryStream ms = new MemoryStream())
            {
                JsonSerializer.Serialize(ms, document);
                dataToSign = ms.ToArray();
            }

            using (RSA rsa = privatekey)
            {
                byte[] signature = rsa.SignData(dataToSign, HashAlgorithmName.SHA256, RSASignaturePadding.Pkcs1);
                Stamp stamp = new Stamp
                {
                    Signature = signature,
                    SigneeName = signee,
                    Comment = comment,
                    Date = DateTime.Now.ToString(),
                    StampIdentity = 1,
                    SignedDocumentId = signedDocument.Id,
                };
                signedDocument.Stamps.Add(stamp);
            }

            var result = await _client.PostAsJsonAsync(_fileServiceBaseUrl, signedDocument);
            if (result.IsSuccessStatusCode)
            {
                return Ok("Signing was succesfull");
            }
            else return StatusCode(500, $"It no worky... {result.StatusCode}");
        }

        [HttpPost]
        [Route("SignSignedDocument")]
        public async Task<ActionResult<string>> SignSignedDocument(SignedDocument signedDocument, string signee, string comment, string testType)
        {
            Certificate cert = await _client.GetFromJsonAsync<Certificate>(_certificateServiceBaseUrl);
            X509Certificate2 certificate = new X509Certificate2(cert.CertificateData, "12345");
            byte[] dataToSign;
            RSA privatekey = certificate.GetRSAPrivateKey();
            using (MemoryStream ms = new MemoryStream())
            {
                JsonSerializer.Serialize(ms, signedDocument);
                dataToSign = ms.ToArray();
            }
            using (RSA rsa = privatekey)
            {
                byte[] signature = rsa.SignData(dataToSign, HashAlgorithmName.SHA256, RSASignaturePadding.Pkcs1);
                Stamp stamp = new Stamp
                {
                    Signature = signature,
                    SigneeName = signee,
                    Comment = comment,
                    Date = DateTime.Now.ToString(),
                    StampIdentity = signedDocument.Stamps.Count + 1,
                    TestType = testType,
                };
                signedDocument.Stamps.Add(stamp);
            }
            var result = await _client.PostAsJsonAsync($"{_fileServiceBaseUrl}" + "/update", signedDocument);
            Console.WriteLine(result.StatusCode.ToString());
            if (result.IsSuccessStatusCode)
            {
                return Ok("Signing was succesfull");
            }
            else return StatusCode(500, $"It no worky...{result.StatusCode}, {signedDocument.Id}");

        }
    }
}
