using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

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
    }
}
