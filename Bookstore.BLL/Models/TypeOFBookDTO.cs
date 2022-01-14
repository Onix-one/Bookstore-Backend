using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bookstore.Core.Enums;

namespace Bookstore.BLL.Models
{
    public class TypeOFBookDTO
    {
        public TypesOfBook Type { get; set; }
        public string Description { get; set; }
        public int Id { get; set; }
    }
}
