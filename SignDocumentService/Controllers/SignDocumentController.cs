using Microsoft.AspNetCore.Mvc;
using SignDocumentService.Models;
using System.Reflection.Metadata;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
using System.Text.Json;

namespace SignDocumentService.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SignDocumentController : Controller
    {

        [HttpPost]
        public async Task<SignedDocument> SignUnsignedDocument(Models.Document document, X509Certificate2 x509Certificate, string signee, string comment)
        {
            //create signed document
            SignedDocument signedDocument = new SignedDocument
            {
                Id = document.Id,
                FileName = document.FileName,
                ContentType = document.ContentType,
                FileContent = document.FileContent
            };

            //Sign document
            byte[] dataToSign;
            RSA privatekey = x509Certificate.GetRSAPrivateKey();
            using(MemoryStream ms = new MemoryStream())
            {
                JsonSerializer.Serialize(ms, document);
                dataToSign = ms.ToArray();
            }

            using(RSA rsa = privatekey)
            {
                byte[] signature = rsa.SignData(dataToSign, HashAlgorithmName.SHA256, RSASignaturePadding.Pkcs1);
                Stamp stamp = new Stamp
                {
                    Signature = signature,
                    SigneeName = signee,
                    Comment = comment,
                    Date = DateTime.Now.ToString(),
                    StampIdentity = signedDocument.Stamps.Count + 1,
                    SignedDocument = signedDocument
                };
                signedDocument.Stamps.Add(stamp);
            }


            return signedDocument;
        }

        [HttpPost]
        public async Task<SignedDocument> SignSignedDocument(SignedDocument signedDocument, X509Certificate2 x509Certificate, string signee, string comment)
        {
            byte[] dataToSign;
            RSA privatekey = x509Certificate.GetRSAPrivateKey();
            using(MemoryStream ms = new MemoryStream())
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
                    SignedDocument = signedDocument
                };
                signedDocument.Stamps.Add(stamp);
            }
            return signedDocument;
        }
    }
}
