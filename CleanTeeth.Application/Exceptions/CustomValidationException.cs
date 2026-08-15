using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanTeeth.Application.Exceptions
{
    public class CustomValidationException : Exception
    {
        public List<string> ValidationError { get; set; } = [];

        public CustomValidationException(ValidationResult validationResult)
        {
            foreach (var validationError in validationResult.Errors)
            {
                ValidationError.Add(validationError.ErrorMessage);
            }
        }
    }
}
