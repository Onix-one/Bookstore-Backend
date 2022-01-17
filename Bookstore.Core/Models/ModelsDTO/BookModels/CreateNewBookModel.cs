using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace Bookstore.Core.Models.ModelsDTO.BookModels
{
    public class CreateNewBookModel
    {
        public string Name { get; set; }
        public double Price { get; set; }
        public string Summary { get; set; }
        public List<IFormFile> Images { get; set; }
        public List<int> TypesOfBookId { get; set; }
        public List<int> AuthorsId { get; set; }
    }
}
