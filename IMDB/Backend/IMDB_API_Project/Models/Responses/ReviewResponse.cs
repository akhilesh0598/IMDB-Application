namespace IMDB_API_Project.Models.Responses
{
    public class ReviewResponse
    {
        public int Id { get; set; }
        public string Message { get; set; }
        public MovieResponse Movie { get; set; }
    }
}