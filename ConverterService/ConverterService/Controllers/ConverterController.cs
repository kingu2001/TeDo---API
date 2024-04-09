using System.Runtime.InteropServices.Marshalling;
using Microsoft.AspNetCore.Mvc;
using Syncfusion.DocIO.DLS;
using Syncfusion.DocIORenderer;
using Syncfusion.Pdf;

namespace ConverterService
{
    [Route("api/[controller]")]
    [ApiController]
    public class ConverterController : ControllerBase
    {
        private readonly HttpClient client;
        private readonly string baseUrl;
        private readonly string uploadFileEndpoint;

        public ConverterController(HttpClient httpClient)
        {
            client = httpClient;
            baseUrl = "http://localhost:5297";
            uploadFileEndpoint = "/api/Document/UploadFileJson";
        }

        [HttpPost]
        public async Task<ActionResult<Document>> ConvertDocxToPdf(Document document)
        {
            using (MemoryStream ms = new MemoryStream(document.FileContent))
            {
                WordDocument wordDocument = new WordDocument(ms, Syncfusion.DocIO.FormatType.Docx, XHTMLValidationType.None);

                DocIORenderer render = new DocIORenderer();

                PdfDocument pdfDocument = render.ConvertToPDF(wordDocument);

                using (MemoryStream ms2 = new MemoryStream())
                {

                    pdfDocument.Save(ms2);
                    document.FileContent = ms2.ToArray();
                }

                document.ContentType = "application/pdf";
                document.FileName = Path.ChangeExtension(document.FileName, ".pdf");

                render.Dispose();
                wordDocument.Dispose();
            }
            
            var response = await client.PostAsJsonAsync(baseUrl + uploadFileEndpoint, document);

            if(response.IsSuccessStatusCode)
            {
                Console.WriteLine("--> Converted document saved in database");
            }
            else
            {
                Console.WriteLine("--> Could not save converted document in database");
            }

            return File(document.FileContent, document.ContentType, document.FileName, true);
        }
    }
}
