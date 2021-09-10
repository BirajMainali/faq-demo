using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace FAQ.Infrastructure.Helper.Interface
{
    public interface IImageHelper
    {
        string ResizeImage(string filePath);
        Task<string> UploadImageAndResize(IFormFile formFile, string tempDirectory);
        void Remove(string directory, string name);
    }
}