using System.Collections.Generic;

namespace Bookstore.Core.Models.Entities
{
    public class GenreOfBook : BaseModel
    {
        public string Genre { get; set; }
        public string Description { get; set; }
        public virtual ICollection<Book> Books { get; set; }
        public virtual ICollection<Customer> FansOfGenres { get; set; }
        public virtual ICollection<Author> Authors { get; set; }
    }
}
