namespace Bookstore.Core.Models.Entities
{
    public class BookImage: BaseModel
    {
        public byte[] Image { get; set; }
        public int BookId { get; set; }
    }
}
