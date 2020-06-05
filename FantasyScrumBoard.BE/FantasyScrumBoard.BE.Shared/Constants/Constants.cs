namespace FantasyScrumBoard.BE.Shared.Constants
{
    public static class Constants
    {
        public static class ErrorMessage
        {
            public const string Default = "Something went wrong!";
            public const string Fatal = "A fatal error occured!";
            public const string Unauthorized = "You don't have the required permissions for this action!";
        }

        public static class Database
        {
            public const string DefaultConnectionString = "Default";
        }
    }
}
