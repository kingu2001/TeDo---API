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
        public ConverterController()
        {
        
        }

        [HttpPost]
        public async Task<IActionResult<Document>> ConvertDocxToPdf(Document document)
        {
            
            Stream stream = new MemoryStream(document.FileContent);

            WordDocument wordDocument = new WordDocument(stream, Syncfusion.DocIO.FormatType.Docx, XHTMLValidationType.None);

            DocIORenderer render = new DocIORenderer();
            //Converts Word document to PDF.
            PdfDocument pdfDocument = render.ConvertToPDF(wordDocument);
            //Release the resources used by the Word document and DocIO Renderer objects.

            
            render.Dispose();
            wordDocument.Dispose();
        }
    }
}
