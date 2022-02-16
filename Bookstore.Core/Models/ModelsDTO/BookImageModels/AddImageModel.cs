using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace Bookstore.Core.Models.ModelsDTO.BookImageModels
{
    public class AddImageModel
    {
        public List<IFormFile> Images { get; set; }
        public int BookId { get; set; }
    }
}
