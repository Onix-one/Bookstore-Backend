using System.Collections.Generic;
using Bookstore.Core.Enums;

namespace Bookstore.Core.Entities
{
    public class TypeOfBook: BaseModel
    {
        public TypesOfBook Type { get; set; }
        public string Description { get; set; }
        public virtual List<Book> Books { get; set; }
        public virtual List<UserInformation> FansOfTypes { get; set; }
    }
}
