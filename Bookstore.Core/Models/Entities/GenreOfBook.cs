using System.Collections.Generic;

namespace Bookstore.Core.Models.Entities
{
    public class GenreOfBook : BaseModel
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public virtual ICollection<Book> Books { get; set; }
        public virtual ICollection<Customer> FansOfGenres { get; set; }
    }
}
