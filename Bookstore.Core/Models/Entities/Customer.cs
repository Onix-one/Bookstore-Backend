using System.Collections.Generic;

namespace Bookstore.Core.Models.Entities
{
    public class Customer : BaseModel
    {
        public int Bonuses { get; set; }
        public virtual ICollection<Book> BroughtBooks { get; set; }
        public virtual ICollection<Book> BooksReadyToBuy { get; set; }
        public virtual ICollection<Book> FavoriteBooks { get; set; }
        public virtual ICollection<GenreOfBook> FavoriteTypes { get; set; }
    }
}
