using System;
using System.Collections.Generic;

namespace BankingApp.Core.CrossCuttingConcerns.Exceptions.Types
{
    public class ValidationException : Exception
    {
        public IEnumerable<ValidationExceptionModel> Errors { get; }

        public ValidationException(IEnumerable<ValidationExceptionModel> errors)
            : base("Validation error(s)")
        {
            Errors = errors;
        }
    }

    public class ValidationExceptionModel
    {
        public string Property { get; set; }
        public string Error { get; set; }

        public ValidationExceptionModel(string property, string error)
        {
            Property = property;
            Error = error;
        }
    }
}
