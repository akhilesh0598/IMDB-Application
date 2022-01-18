using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace IMDB_API_Project.Validations
{
    public class ValidReleaseDate : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            var releaseDae = (DateTime)value;
            return releaseDae != default && releaseDae <= DateTime.Now;
        }
    }
}