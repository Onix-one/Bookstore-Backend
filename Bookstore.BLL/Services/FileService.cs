using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bookstore.BLL.Services
{
    public class FileService : IFileService
    {
        public string GetBookUrl(string name, int id)
        {
            var bookUrl = Path.Combine($"{id}", $"{name}{id}.pdf");
            return bookUrl;
        }

        public string GetImageUrl(int bookId , int imageId)
        {
            var imageUrl = Path.Combine($"{bookId}", $"{imageId}.pdf");
            return imageUrl;
        }

        public string CreateNewFolderForBook(string rootPath, int Id)
        {
            var fullPath = Path.Combine(rootPath,"Books", Id.ToString());

            if (!Directory.Exists(fullPath))
            {
                Directory.CreateDirectory(fullPath);
            }

            return fullPath;
        }
    }

    public interface IFileService
    {
        public string GetBookUrl(string name, int id);
        public string CreateNewFolderForBook(string rootPath, int Id);
        public string GetImageUrl(int bookId, int imageId);
    }
}
