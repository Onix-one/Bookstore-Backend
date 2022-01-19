using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bookstore.Core.Models.Entities
{
    public class BookGenreOfBook : BaseModel
    {
        public int BookId { get; set; }
        public Book Book { get; set; }

        public int GenreOfBookId { get; set; }
        public GenreOfBook GenreOfBook { get; set; }
    }
}
