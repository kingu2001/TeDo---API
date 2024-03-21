
HttpClient client = new HttpClient();


var response = client.GetAsync("http://localhost:5297/api/Document/11").Result;

if(response.IsSuccessStatusCode)
{
    using (var responseStream = await response.Content.ReadAsStreamAsync())
    using (var fileStream = File.Create(@"C:/Users/Bruger/Downloads/DownloadedFile.pdf"))  // Replace with desired path
    {
        await responseStream.CopyToAsync(fileStream);
    }

    Console.WriteLine(response.StatusCode.ToString());
}

var response2 = client.GetAsync("http://localhost:5297/api/Document/9").Result;

if(response.IsSuccessStatusCode)
{
    using (var responseStream = await response2.Content.ReadAsStreamAsync())
    using (var fileStream = File.Create(@"C:/Users/Bruger/Downloads/DownloadedFile.docx"))  // Replace with desired path
    {
        await responseStream.CopyToAsync(fileStream);
    }
    Console.WriteLine(response2.StatusCode.ToString());
}


