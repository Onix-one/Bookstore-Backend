using System;
using System.Collections.Generic;

namespace Bookstore.Core.Models.ModelsDTO
{
    public class AuthorDTO
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string SecondName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Biografy { get; set; }
        public string Nationality { get; set; }
        public List<BookDTO> Books { get; set; }
    }
}
