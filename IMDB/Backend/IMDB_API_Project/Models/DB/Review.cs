namespace IMDB_API_Project.Models.DB
{
    public class Review : BaseEntity
    {
        public string Message { get; set; }
        public int MovieId { get; set; }
    }
}