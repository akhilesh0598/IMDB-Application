using System;

namespace IMDB_API_Project.Models.DB
{
    public class Movie : BaseEntity
    {
        public string Name { get; set; }
        public DateTime YearOfRelease { get; set; }
        public string Plot { get; set; }
        public int ProducerId { get; set; }
        public string ImageUrl { get; set; }
    }
}