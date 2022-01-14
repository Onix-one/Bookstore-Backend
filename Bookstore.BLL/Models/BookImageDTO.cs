using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bookstore.Core.Entities;

namespace Bookstore.BLL.Models
{
    public class BookImageDTO
    {
        public int Id { get; set; }
        public byte[] Image { get; set; }
    }
}
