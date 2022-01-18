using Microsoft.AspNetCore.Http;
using System.Collections.Generic;

namespace Bookstore.Core.Models.ModelsDTO.BookModels
{
    public class CreateNewBookModel
    {
        public string Name { get; set; }
        public double Price { get; set; }
        public string Description { get; set; }
        public List<IFormFile> ImageFiles { get; set; }
        public List<int> GenresOfBookId { get; set; }
        public List<int> AuthorsId { get; set; }
    }
}
