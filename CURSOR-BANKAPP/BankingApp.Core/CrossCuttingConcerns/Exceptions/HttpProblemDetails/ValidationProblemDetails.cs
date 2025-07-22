using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using BankingApp.Core.CrossCuttingConcerns.Exceptions.Types;
using Microsoft.AspNetCore.Http;

namespace BankingApp.Core.CrossCuttingConcerns.Exceptions.HttpProblemDetails
{
    public class ValidationProblemDetails : ProblemDetails
    {
        public IEnumerable<ValidationExceptionModel> Errors { get; }

        public ValidationProblemDetails(IEnumerable<ValidationExceptionModel> errors)
        {
            Title = "Validation Error";
            Status = StatusCodes.Status400BadRequest;
            Detail = "One or more validation errors occurred.";
            Errors = errors;
        }
    }
} 