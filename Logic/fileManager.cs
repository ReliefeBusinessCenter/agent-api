using System;
using System.IO;
using System.Threading.Tasks;
using Azure.Storage.Blobs;
using broker.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
// using AzureBlob.Api.Models;

namespace AzureBlob.Api.Logics
{
    public class FileManagerLogic : IFileManagerLogic
    {
        private readonly BlobServiceClient _blobServiceClient;
        public FileManagerLogic(BlobServiceClient blobServiceClient)
        {
            _blobServiceClient = blobServiceClient;
        }

        public async Task Upload([FromForm] IFormFile model)
        {   
            // FileUpload1.PostedFile.SaveAs(Server.MapPath(filePath));
            var blobContainer = _blobServiceClient.GetBlobContainerClient("upload");

            var blobClient = blobContainer.GetBlobClient(model.FileName);


            Console.WriteLine("+++++++++++++Creating images" + blobClient);
            await blobClient.UploadAsync(model.OpenReadStream());
        }
        public async Task<byte[]> Get(string imageName)
        {
            var blobContainer = _blobServiceClient.GetBlobContainerClient("upload");

            var blobClient = blobContainer.GetBlobClient(imageName);
            var downloadContent = await blobClient.DownloadAsync();
            using (MemoryStream ms = new MemoryStream())
            {
                await downloadContent.Value.Content.CopyToAsync(ms);
                return ms.ToArray();
            }
        }
    }
}
