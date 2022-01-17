using System.Collections.Generic;
using Bookstore.Core.Models.Entities;

namespace Bookstore.Core.Models.ModelsDTO.FilterModels
{
    public class BooksForAuthorFilter
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Rating { get; set; }
        public double Price { get; set; }
        public string Summary { get; set; }
        public  List<TypeOfBookForAuthorFiltr> TypesOfBook { get; set; }
        public  List<BookImageDTO> Images { get; set; }
    }
}
