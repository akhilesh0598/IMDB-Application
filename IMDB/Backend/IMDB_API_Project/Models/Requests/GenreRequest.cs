using System.ComponentModel.DataAnnotations;

namespace IMDB_API_Project.Models.Requests
{
    public class GenreRequest
    {
        [Required]
        [MaxLength(int.MaxValue)]
        public string Name { get; set; }
    }
}