using System;

namespace IMDB_API_Project.Models.DB
{
    public class Actor : BaseEntity
    {
        public string Name { get; set; }
        public string Bio { get; set; }
        public DateTime DOB { get; set; }
        public string Gender { get; set; }
    }
}