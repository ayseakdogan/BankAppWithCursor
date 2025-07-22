using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BankingApp.Core.CrossCuttingConcerns.Exceptions.HttpProblemDetails
{
    public class AuthorizationProblemDetails : ProblemDetails
    {
        public AuthorizationProblemDetails(string detail)
        {
            Title = "Authorization Error";
            Status = StatusCodes.Status403Forbidden;
            Detail = detail;
        }
    }
} 