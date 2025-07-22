using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BankingApp.Core.CrossCuttingConcerns.Exceptions.HttpProblemDetails
{
    public class BusinessProblemDetails : ProblemDetails
    {
        public BusinessProblemDetails(string detail)
        {
            Title = "Business Rule Violation";
            Status = StatusCodes.Status400BadRequest;
            Detail = detail;
        }
    }
} 