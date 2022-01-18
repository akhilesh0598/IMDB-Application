using IMDB_API_Project.Validations;
using System;
using System.ComponentModel.DataAnnotations;

namespace IMDB_API_Project.Models.Requests
{
    public class ActorRequest
    {
        [Required]
        [MaxLength(100)]
        public string Name { get; set; }
        [Required]
        [MaxLength(int.MaxValue)]
        public string Bio { get; set; }
        [Required]
        [ValidDate(ErrorMessage = "DOB should be smaller then Current Date")]
        public DateTime DOB { get; set; }
        [Required]
        [RegularExpression("Male|Female", ErrorMessage = "The Gender must be either 'Male' or 'Female' only.")]

        public string Gender { get; set; }
    }
}