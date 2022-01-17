using System.Collections.Generic;
using Bookstore.Core.Enums;

namespace Bookstore.Core.Models.Entities
{
    public class TypeOfBook: BaseModel
    {
        public string Type { get; set; }
        public string Description { get; set; }
        public virtual List<Book> Books { get; set; }
        public virtual List<Customer> FansOfTypes { get; set; }
        public virtual List<Author> Authors { get; set; }
    }
}
