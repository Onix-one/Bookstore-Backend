using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bookstore.Backend.Models
{
    public class Book
    {
        public string Name { get; set; }
        public int Rating { get; set; }
        public double Price { get; set; }
        public string Summary { get; set; }
    }
}
