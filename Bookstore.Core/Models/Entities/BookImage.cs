namespace Bookstore.Core.Models.Entities
{
    public class BookImage : BaseModel
    {
        public byte[] Image { get; set; }
        public virtual Book Book { get; set; }
    }
}
