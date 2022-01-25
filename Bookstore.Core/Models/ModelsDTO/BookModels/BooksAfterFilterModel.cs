using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bookstore.Core.Models.Entities;

namespace Bookstore.Core.Models.ModelsDTO.BookModels
{
    public class BooksAfterFilterModel
    {
        public string Name { get; set; }
        public int Rating { get; set; }
        public double Price { get; set; }
        public string Description { get; set; }
        public string BookUrl { get; set; }
        public virtual ICollection<GenreOfBook> GenreOfBooks { get; set; }
        public virtual ICollection<Author> Authors { get; set; }
        public virtual ICollection<BookImage> Images{ get; set; }

    }
}
