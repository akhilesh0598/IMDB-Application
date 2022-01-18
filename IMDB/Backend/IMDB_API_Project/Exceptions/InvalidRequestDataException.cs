using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IMDB_API_Project.Exceptions
{
    public class InvalidRequestDataException : Exception
    {
        public InvalidRequestDataException(string message) : base(message)
        {
        }
    }
}
