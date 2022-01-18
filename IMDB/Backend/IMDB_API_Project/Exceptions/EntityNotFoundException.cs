using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IMDB_API_Project.Exceptions
{
    public class EntityNotFoundException : Exception
    {
        public EntityNotFoundException(string s) : base(s)
        {
        }
    }
}