using System;
using FantasyScrumBoard.BE.Shared.Enums;

namespace FantasyScrumBoard.BE.Shared.Exceptions
{
    public class BusinessLogicException : Exception
    {
        public ExceptionType ExceptionType;

        public BusinessLogicException(string message, ExceptionType exceptionType) : base(message)
        {
            ExceptionType = exceptionType;
        }
    }
}
