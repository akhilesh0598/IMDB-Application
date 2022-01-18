using IMDB_API_Project.Validations;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace IMDB_API_Project.Models.Requests
{
    public class MovieRequest
    {
        [Required]
        [MaxLength(100)]
        public string Name { get; set; }
        [Required]
        [ValidReleaseDate(ErrorMessage = "Release Date should be smaller then Current Date")]
        public DateTime YearOfRelease { get; set; }
        [Required]
        public string Plot { get; set; }
        [Required]
        public int ProducerId { get; set; }
        [Required]
        public List<int> ActorsIds { get; set; }
        [Required]
        public List<int> GenresIds { get; set; }
        [Required]
        public string ImageUrl { get; set; }
    }
}
