using System.Threading.Tasks;
// using AzureBlob.Api.Models;
using broker.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AzureBlob.Api.Logics
{
    public interface IFileManagerLogic
    {
        Task Upload([FromForm] IFormFile file);
        Task<byte[]> Get(string imageName);
    }
}