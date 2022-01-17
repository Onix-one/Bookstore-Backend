using System.Collections.Generic;
using Bookstore.Core.Models.Entities;
using Microsoft.AspNetCore.Http;


namespace Bookstore.Core.Models.ModelsDTO
{
    public class BookDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Rating { get; set; }
        public double Price { get; set; }
        public string Summary { get; set; }
        public List<IFormFile> Images { get; set; }
        public List<int> TypesOfBookId { get; set; }
        public List<int> AuthorsId { get; set; }
    }
}
