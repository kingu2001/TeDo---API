using Microsoft.AspNetCore.Mvc;
using SignDocumentService.Models;
using System.Reflection.Metadata;
using System.Security.Cryptography.X509Certificates;

namespace SignDocumentService.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SignDocumentController : Controller
    {

        [HttpPost]
        public async Task<SignedDocument> SignDocument(Models.Document? document, X509Certificate2 x509Certificate)
        {
            SignedDocument signedDocument = new SignedDocument
            {
                Id = document.Id,
                FileName = document.FileName,
                ContentType = document.ContentType,
                FileContent = document.FileContent
            };
            return signedDocument;
        }
    }
}
