using System.Collections.Generic;

namespace Bookstore.Core.Entities
{
    public class Book: BaseModel
    {
        public string Name { get; set; }
        public int Rating { get; set; }
        public double Price { get; set; }
        public string Summary { get; set; }
        public virtual List<TypeOfBook> TypesOfBook { get; set; }
        public virtual List<Author> Authors { get; set; }
        public virtual List<BookImage> Images { get; set; }
        public virtual List<UserInformation> Buyers { get; set; }
        public virtual List<UserInformation> ReadyToPay { get; set; }
        public virtual List<UserInformation> Fans { get; set; }
    }
}
