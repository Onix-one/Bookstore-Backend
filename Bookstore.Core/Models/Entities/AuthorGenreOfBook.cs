namespace Bookstore.Core.Models.Entities
{
    public class AuthorGenreOfBook : BaseModel
    {
        public int AuthorId { get; set; }
        public Author Author { get; set; }

        public int GenreOfBookId { get; set; }
        public GenreOfBook GenreOfBook { get; set; }
    }
}
