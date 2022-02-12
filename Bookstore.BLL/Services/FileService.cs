using Microsoft.AspNetCore.Http;
using System.IO;
using System.Threading.Tasks;

namespace Bookstore.BLL.Services
{
    public class FileService : IFileService
    {
        public string GetFullPathToBook(string booName, int bookId)
        {
            return Path.Combine("books", $"{bookId}", $"{booName}#{bookId}.pdf");
        }

        public string GetFullPathToImage(string booName, int bookId, int imageId)
        {
            return Path.Combine("books", $"{bookId}", $"{booName}#{imageId}.jpg");
        }

        public void CreateNewFolderForBook(string rootPath, int bookId)
        {
            var fullPath = Path.Combine(rootPath, "Books", bookId.ToString());

            if (!Directory.Exists(fullPath))
            {
                Directory.CreateDirectory(fullPath);
            }
        }

        public async Task SaveFileInFolderAsync(IFormFile file, string fullPath)
        {
            if (file ==null)
            {
                return;
            }
            await using (var stream = new FileStream(fullPath, FileMode.OpenOrCreate))
            {
                await file.CopyToAsync(stream);
            }
        }
    }

    public interface IFileService
    {
        public void CreateNewFolderForBook(string rootPath, int bookId);
        public Task SaveFileInFolderAsync(IFormFile file, string fullPath);
        public string GetFullPathToBook(string booName, int bookId);
        public string GetFullPathToImage(string booName, int bookId, int imageId);
    }
}
