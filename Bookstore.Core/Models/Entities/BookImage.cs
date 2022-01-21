namespace Bookstore.Core.Models.Entities
{
    public class BookImage : BaseModel
    {
        public string ImageUrl { get; set; }
        public virtual Book Book { get; set; }
    }
}
