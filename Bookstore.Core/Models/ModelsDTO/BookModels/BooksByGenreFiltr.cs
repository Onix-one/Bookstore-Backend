using Bookstore.Core.Models.ModelsDTO.AuthorModels;
using System.Collections.Generic;

namespace Bookstore.Core.Models.ModelsDTO.BookModels
{
    public class BooksByGenreFiltr
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Rating { get; set; }
        public double Price { get; set; }
        public string Description { get; set; }
        public List<AuthorsForGenreFiltr> GenresOfBook { get; set; }
        public List<BookImageDTO> Images { get; set; }
    }
}
