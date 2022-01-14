using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bookstore.BLL.Models
{
    public class BookDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Rating { get; set; }
        public double Price { get; set; }
        public string Summary { get; set; }
    }
}
