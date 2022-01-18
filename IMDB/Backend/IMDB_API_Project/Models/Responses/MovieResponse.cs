﻿using System;
using System.Collections.Generic;

namespace IMDB_API_Project.Models.Responses
{
    public class MovieResponse
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime YearOfRelease { get; set; }
        public string Plot { get; set; }
        public ProducerResponse Producer { get; set; }
        public List<ActorResponse> Actors { get; set; }
        public List<GenreResponse> Genres { get; set; }
        public string ImageUrl { get; set; }
    }
}