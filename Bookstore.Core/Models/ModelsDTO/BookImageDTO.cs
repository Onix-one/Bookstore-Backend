using Microsoft.AspNetCore.Http;

namespace Bookstore.Core.Models.ModelsDTO
{
    public class BookImageDTO
    {
        public int Id { get; set; }
        public IFormFile Image { get; set; }
    }
}
