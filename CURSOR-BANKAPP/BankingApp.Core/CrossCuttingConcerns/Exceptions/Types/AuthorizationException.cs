using System;

namespace BankingApp.Core.CrossCuttingConcerns.Exceptions.Types
{
    public class AuthorizationException : Exception
    {
        public AuthorizationException(string message) : base(message) { }
        public AuthorizationException(string message, Exception innerException) : base(message, innerException) { }
    }
} 