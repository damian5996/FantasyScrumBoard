namespace FantasyScrumBoard.BE.Shared
{
    public static class Constants
    {
        public static class ErrorMessage
        {
            public const string Default = "Something went wrong!";
            public const string Fatal = "A fatal error occured!";
            public const string Unauthorized = "You don't have the required permissions for this action!";
            public const string NotFoundTemplate = "{0} [{1}] not found!";
        }

        public static class Database
        {
            public const string DefaultConnectionString = "Default";
        }
    }
}
