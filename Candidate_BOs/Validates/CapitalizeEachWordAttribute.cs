using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Candidate_BOs.Validates
{
    public class CapitalizeEachWordAttribute : ValidationAttribute
    {
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            if (value is string fullName)
            {
                var words = fullName.Split(' ');
                if (words.All(word => char.IsUpper(word[0])))
                {
                    return ValidationResult.Success;
                }
                else
                {
                    return new ValidationResult("Each word must start with an uppercase letter");
                }
            }
            return ValidationResult.Success;
        }
    }
}
