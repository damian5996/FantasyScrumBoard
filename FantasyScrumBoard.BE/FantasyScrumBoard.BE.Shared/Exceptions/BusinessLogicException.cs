using System;
using FantasyScrumBoard.BE.Shared.Enums;

namespace FantasyScrumBoard.BE.Shared.Exceptions
{
    public class BusinessLogicException : Exception
    {
        public ExceptionType ExceptionType;

        public BusinessLogicException() : this(Constants.ErrorMessage.Default)
        {
        }
        public BusinessLogicException(string errorMessage) : this(errorMessage, ExceptionType.InternalServerError)
        {
        }

        public BusinessLogicException(string errorMessage, ExceptionType exceptionType) : base(errorMessage)
        {
            ExceptionType = exceptionType;
        }

        public BusinessLogicException(Exception ex) : this(ex.Message, ExceptionType.InternalServerError, ex)
        {
        }

        public BusinessLogicException(string errorMessage, ExceptionType exceptionType, Exception ex) : base(errorMessage, ex)
        {
            ExceptionType = exceptionType;
        }
    }
}
