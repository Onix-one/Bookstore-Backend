using System.Collections.Generic;

namespace Bookstore.Core.Models.Entities
{
    public class GenreOfBook : BaseModel
    {
        public string Genre { get; set; }
        public string Description { get; set; }
        public virtual List<Book> Books { get; set; }
        public virtual List<Customer> FansOfGenres { get; set; }
        public virtual List<Author> Authors { get; set; }
    }
}
