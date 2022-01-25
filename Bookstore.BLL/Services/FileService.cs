using Microsoft.AspNetCore.Http;
using System.IO;
using System.Threading.Tasks;

namespace Bookstore.BLL.Services
{
    public class FileService : IFileService
    {
        public string GetBookUrl(string booName, int bookId)
        {
            return Path.Combine($"{bookId}", $"{booName}#{bookId}.pdf");
        }

        public string GetImageUrl(int bookId, int imageId)
        {
            return Path.Combine($"{bookId}", $"{imageId}.pdf");
        }

        public string CreateNewFolderForBook(string rootPath, int Id)
        {
            var fullPath = Path.Combine(rootPath, "Books", Id.ToString());

            if (!Directory.Exists(fullPath))
            {
                Directory.CreateDirectory(fullPath);
            }

            return fullPath;
        }

        public async Task SaveFileInFolderAsync(IFormFile file, string fullPath)
        {
            await using (var stream = new FileStream(fullPath, FileMode.OpenOrCreate))
            {
                await file.CopyToAsync(stream);
            }
        }
    }

    public interface IFileService
    {
        public string GetBookUrl(string booName, int bookId);
        public string CreateNewFolderForBook(string rootPath, int Id);
        public string GetImageUrl(int bookId, int imageId);
        public Task SaveFileInFolderAsync(IFormFile file, string fullPath);

    }
}
