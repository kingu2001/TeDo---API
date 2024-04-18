using Microsoft.AspNetCore.Mvc;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;

namespace TeDoSignDocumentService.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SignDocumentController : ControllerBase
    {
        private readonly X509Certificate2 _certificate;
        private readonly RSA _publickey;
        public SignDocumentController() 
        {

            _certificate = new X509Certificate2("example.com.pem");
        }
    }
}
