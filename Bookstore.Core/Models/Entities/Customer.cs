using System.Collections.Generic;

namespace Bookstore.Core.Models.Entities
{
    public class Customer : BaseModel
    {
        public int Bonuses { get; set; }
        public virtual List<Book> BroughtBooks { get; set; }
        public virtual List<Book> BooksReadyToBuy { get; set; }
        public virtual List<Book> FavoriteBooks { get; set; }
        public virtual List<GenreOfBook> FavoriteTypes { get; set; }
    }
}
