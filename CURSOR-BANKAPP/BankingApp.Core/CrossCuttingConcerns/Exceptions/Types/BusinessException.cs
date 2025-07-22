using System;
using System.Collections.Generic;

namespace BankingApp.Core.CrossCuttingConcerns.Exceptions.Types
{
    public class BusinessException : Exception
    {
        public BusinessException(string message) : base(message) { }
        public BusinessException(string message, Exception innerException) : base(message, innerException) { }
    }

    public class ValidationErrorModel
    {
        public List<ValidationErrorItem> Errors { get; set; }
    }

    public class ValidationErrorItem
    {
        public string Property { get; set; }
        public string Error { get; set; }
    }
} 