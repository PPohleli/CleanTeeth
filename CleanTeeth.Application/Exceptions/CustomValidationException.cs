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
        public List<string> ValidationErrors { get; set; } = [];

        public CustomValidationException(ValidationResult validationsResult)
        {
            foreach (var error in validationsResult.Errors)
            {
                ValidationErrors.Add(error.ErrorMessage);
            }
        }
    }
}
