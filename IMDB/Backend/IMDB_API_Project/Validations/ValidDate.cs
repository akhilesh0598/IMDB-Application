using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace IMDB_API_Project.Validations
{
    public class ValidDate : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            var dob = (DateTime)value;
            return dob != default && dob < DateTime.Now;
        }
    }
}