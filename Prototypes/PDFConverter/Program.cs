using Syncfusion.DocIO.DLS;
using Syncfusion.DocIORenderer;
using Syncfusion.Pdf;

Syncfusion.Licensing.SyncfusionLicenseProvider.RegisterLicense("Mgo+DSMBPh8sVXJwS0d+WFBPd11dXmJWd1p/THNYflR1fV9DaUwxOX1dQl9nSX1SckVgXXxdcHRUQ2A=;Mgo+DSMBMAY9C3t2UVhhQlVFfV5AQmBIYVp/TGpJfl96cVxMZVVBJAtUQF1hTX5Qd0FjWntdc3RVRWBa;MzE1ODgzOUAzMjM0MmUzMDJlMzBTcjVlZTMvVTBURitwWUJtVjJ2WHJ5MUhKcUxvTWp2bmpCZmd5VDhIclBNPQ==");

//Creates a new Word document.
// WordDocument wordDocument = new WordDocument();
// //Add a section & a paragraph in the empty document.
// wordDocument.EnsureMinimal();
// //Append text to the last paragraph of the document.
// wordDocument.LastParagraph.AppendText("Hello World...!");
//Create instance for DocIORenderer for Word to PDF conversion

HttpClient httpClient = new HttpClient();

var response = await httpClient.GetStreamAsync("http://localhost:5297/api/Document/7");

MemoryStream ms = new MemoryStream{ Position = 0 };
response.CopyTo(ms);

WordDocument wordDocument = new WordDocument(ms, Syncfusion.DocIO.FormatType.Docx, XHTMLValidationType.None);

DocIORenderer render = new DocIORenderer();
//Converts Word document to PDF.
PdfDocument pdfDocument = render.ConvertToPDF(wordDocument);
//Release the resources used by the Word document and DocIO Renderer objects.
render.Dispose();
wordDocument.Dispose();
//Saves the PDF file.
FileStream outputStream = new FileStream(@"Ouput.pdf", FileMode.CreateNew, FileAccess.Write);
pdfDocument.Save(outputStream);
//Closes the instance of PDF document object.
pdfDocument.Close();
//Dispose the instance of FileStream.
outputStream.Dispose();
