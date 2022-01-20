using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bookstore.Core.Models.Entities;

namespace Bookstore.Core.Models.ModelsDTO.BookModels
{
    public class BookByIdModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Rating { get; set; }
        public double Price { get; set; }
        public string Description { get; set; }
        public virtual List<GenreOfBook> GenresOfBook { get; set; }
        public virtual List<Author> Authors { get; set; }
        public virtual List<BookImage> Images { get; set; }
    }
}
