using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace Bookstore.Core.Models.ModelsDTO.BookModels
{
    public class UpdateBookModel
    {
        public int id { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public string Description { get; set; }
        public List<IFormFile> ImageFiles { get; set; }
        public IFormFile book { get; set; }
        public List<int> GenresOfBookId { get; set; }
        public List<int> AuthorsId { get; set; }
    }
}
