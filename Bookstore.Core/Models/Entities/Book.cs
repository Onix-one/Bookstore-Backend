using System.Collections.Generic;

namespace Bookstore.Core.Models.Entities
{
    public class Book : BaseModel
    {
        public string Name { get; set; }
        public int Rating { get; set; }
        public double Price { get; set; }
        public string Description { get; set; }
        public virtual List<GenreOfBook> GenresOfBook { get; set; }
        public virtual List<Author> Authors { get; set; }
        public virtual List<BookImage> Images { get; set; }
        public virtual List<Customer> Buyers { get; set; }
        public virtual List<Customer> CustomersWantedToBuy { get; set; }
        public virtual List<Customer> Fans { get; set; }
    }
}
