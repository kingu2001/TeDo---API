using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SignDocumentService.Dtos;
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
        private readonly HttpClient _client;
        private readonly IMapper _mapper;
        private readonly IConfiguration _configuration;

        public SignDocumentController(HttpClient httpClient, IMapper mapper, IConfiguration configuration)
        {
            _configuration = configuration;
            _client = httpClient;
            _mapper = mapper;
        }

        [HttpPost("SignUnsignedDocument/{id}")]
        public async Task<ActionResult<string>> SignUnsignedDocument(DocumentCreateDto documentCreateDto, string signee, string comment, int id)
        {
            //create signed document
            SignedDocument signedDocument = new SignedDocument
            {
                FileName = "signed_" + documentCreateDto.FileName,
                ContentType = documentCreateDto.ContentType,
                FileContent = documentCreateDto.FileContent,
                Stamps = new List<Stamp>()
            };

            Certificate cert = await _client.GetFromJsonAsync<Certificate>($"{_certificateServiceBaseUrl}+{id}");
            X509Certificate2 certificate = new X509Certificate2(cert.CertificateData, "12345");
            //Sign document
            byte[] dataToSign;
            RSA privatekey = certificate.GetRSAPrivateKey();
            using (MemoryStream ms = new MemoryStream())
            {
                JsonSerializer.Serialize(ms, documentCreateDto);
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

            var signedDocumentCreateDto = _mapper.Map<SignedDocumentCreateDto>(signedDocument);

            var result = await _client.PostAsJsonAsync($"{_configuration["FileService"]}", signedDocumentCreateDto);
            if (result.IsSuccessStatusCode)
            {
                return Ok("Signing was succesfull");
            }
            else return StatusCode(500, $"It no worky... {result.StatusCode}");
        }

        [HttpPost("SignSignedDocument/{id}")]
        public async Task<ActionResult<string>> SignSignedDocument(SignedDocumentReadDto signedDocumentReadDto, string signee, string comment, string testType, int id)
        {
            Certificate cert = await _client.GetFromJsonAsync<Certificate>($"{_certificateServiceBaseUrl}+{id}");
            X509Certificate2 certificate = new X509Certificate2(cert.CertificateData, "12345");
            byte[] dataToSign;
            RSA privatekey = certificate.GetRSAPrivateKey();
            using (MemoryStream ms = new MemoryStream())
            {
                JsonSerializer.Serialize(ms, signedDocumentReadDto);
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
                    StampIdentity = signedDocumentReadDto.Stamps.Count + 1,
                    TestType = testType,
                };
                signedDocumentReadDto.Stamps.Add(stamp);
            }
            var result = await _client.PostAsJsonAsync($"{_configuration["FileService"]}/UpdateSignedDocument/{signedDocumentReadDto.Id}", signedDocumentReadDto);
            Console.WriteLine(result.StatusCode.ToString());
            if (result.IsSuccessStatusCode)
            {
                return Ok("Signing was succesfull");
            }
            else return StatusCode(500, $"It no worky...{result.StatusCode}, {signedDocumentReadDto.Id}");

        }
    }
}
