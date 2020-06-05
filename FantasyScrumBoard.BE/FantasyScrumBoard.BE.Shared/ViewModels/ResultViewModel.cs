using FantasyScrumBoard.BE.Shared.Enums;

namespace FantasyScrumBoard.BE.Shared.ViewModels
{
    public class ResultViewModel<T>
    {
        public T Data { get; set; }
        public string Error { get; set; }

        public ExceptionType? ExceptionType;

        public bool IsValid => string.IsNullOrWhiteSpace(Error);
    }
}
