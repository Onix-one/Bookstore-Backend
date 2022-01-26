using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bookstore.Core.Models.ModelsDTO.FilterModels
{
    public class FilterForBookModel
    {
        public List<int> AuthorsId { get; set; }
        public List<int> GenresId { get; set; }
        public List<int> Cost { get; set; }
        public int? Rating { get; set; }
    }
}
