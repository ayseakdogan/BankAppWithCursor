using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BankingApp.Core.CrossCuttingConcerns.Exceptions.HttpProblemDetails
{
    public class NotFoundProblemDetails : ProblemDetails
    {
        public NotFoundProblemDetails(string detail)
        {
            Title = "Not Found";
            Status = StatusCodes.Status404NotFound;
            Detail = detail;
        }
    }
} 