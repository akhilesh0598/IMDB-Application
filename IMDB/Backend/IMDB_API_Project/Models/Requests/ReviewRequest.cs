using System.ComponentModel.DataAnnotations;

namespace IMDB_API_Project.Models.Requests
{
    public class ReviewRequest
    {
        [Required]
        public string Message { get; set; }
        [Required]
        public int MovieId { get; set; }
    }
}