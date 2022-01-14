using System.Collections.Generic;

namespace Bookstore.Core.Entities
{
    public class UserInformation: BaseModel
    {
        public int Bonuses { get; set; }
        public virtual List<Book> BroughtBooks { get; set; }
        public virtual List<Book> BooksReadyToBuy { get; set; }
        public virtual List<Book> FavoriteBooks { get; set; }
        public virtual List<TypeOfBook> FavoriteTypes { get; set; }
    }
}
