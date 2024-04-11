using System.Net.Mime;
using System.Runtime.InteropServices.Marshalling;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Formatters;
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
            // Save the file content from document to a stream for later converting
            using (MemoryStream orgByteStream = new MemoryStream(document.FileContent))
            {
                // Because the ConvertToPfd needs a WordDocument datatype, we create one with the original data
                WordDocument wordDocument = new WordDocument(orgByteStream, Syncfusion.DocIO.FormatType.Docx, XHTMLValidationType.None);

                // New render obejct for the conversion
                DocIORenderer render = new DocIORenderer();

                // Converting the word document to pfd and saving it as a PdfDocument datatype, because thats what the method returns
                PdfDocument pdfDocument = render.ConvertToPDF(wordDocument);

                // Copying the new convertet Pdf data stream to a new stream and setting our document FilContent byte[] to the new stram
                using (MemoryStream ms2 = new MemoryStream())
                {

                    pdfDocument.Save(ms2);
                    document.FileContent = ms2.ToArray();
                }
                 
                // Setting new appropriate ContentType
                document.ContentType = MediaTypeNames.Application.Pdf;
                
                // Changing file extension to .pfd 
                document.FileName = Path.ChangeExtension(document.FileName, MediaTypeNames.Application.Pdf);

                // Releasing ressources
                render.Dispose();
                wordDocument.Dispose();
            }
            // Calling main document service to save the newly convertet document
            var response = await client.PostAsJsonAsync(baseUrl + uploadFileEndpoint, document);

            if(response.IsSuccessStatusCode)
            {
                Console.WriteLine("--> Converted document saved in database");
            }
            else
            {
                Console.WriteLine("--> Could not save converted document in database");
            }
            
            // Returning the convertet document
            return File(document.FileContent, document.ContentType, document.FileName, true);
        }
    }
}
