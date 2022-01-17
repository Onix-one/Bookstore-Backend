using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bookstore.Core.Models.ModelsDTO.AuthorModels
{
    public class CreateNewAuthorModel
    {
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string SecondName { get; set; }
        public DateTime? DateOfBirth { get; set; }
        [Required]
        public string Biografy { get; set; }
        [Required]
        public string Nationality { get; set; }
        [Required]
        public List<int> TypesOfBookId { get; set; }
    }
}
