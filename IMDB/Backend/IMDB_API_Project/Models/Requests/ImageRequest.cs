using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IMDB_API_Project.Models.Requests
{
    public class ImageRequest
    {
        public IFormFile File { get; set; }
    }
}
