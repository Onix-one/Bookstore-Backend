using System;
using System.Collections.Generic;

namespace Bookstore.Core.Models.Entities
{
    public class Author : BaseModel
    {
        public string FirstName { get; set; }
        public string SecondName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Biografy { get; set; }
        public string Nationality { get; set; }
        public virtual ICollection<Book> Books { get; set; }
        public virtual ICollection<GenreOfBook> GenreOfBooks { get; set; }
    }
}
