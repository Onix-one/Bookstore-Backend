using System.Collections.Generic;
using Bookstore.Core.Models.ModelsDTO.FilterModels;

namespace Bookstore.Core.Models.ModelsDTO.BookModels
{
    public class BooksForAuthorFilter
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Rating { get; set; }
        public double Price { get; set; }
        public string Description { get; set; }
        public List<GenreOfBookForAuthorFiltr> GenresOfBook { get; set; }
        public List<BookImageDTO> Images { get; set; }
    }
}
