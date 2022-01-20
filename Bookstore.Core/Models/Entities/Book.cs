using System.Collections.Generic;

namespace Bookstore.Core.Models.Entities
{
    public class Book : BaseModel
    {
        public string Name { get; set; }
        public int Rating { get; set; }
        public double Price { get; set; }
        public string Description { get; set; }
        public virtual ICollection<GenreOfBook> GenreOfBooks { get; set; }
        public virtual ICollection<Author> Authors { get; set; }
        public virtual ICollection<BookImage> Images { get; set; }
        public virtual ICollection<Customer> Buyers { get; set; }
        public virtual ICollection<Customer> CustomersWantedToBuy { get; set; }
        public virtual ICollection<Customer> Fans { get; set; }
    }
}
