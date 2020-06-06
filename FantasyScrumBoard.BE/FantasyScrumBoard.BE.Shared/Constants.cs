namespace FantasyScrumBoard.BE.Shared
{
    public static class Constants
    {
        public static class ErrorMessage
        {
            public const string Default = "Something went wrong!";
            public const string Fatal = "A fatal error occured!";
            public const string Unauthorized = "You don't have the required permissions for this action!";

            public const string ExpiredRefreshToken = "Expired refresh token";
            public const string InvalidRefreshToken = "Invalid refresh token";

            public const string ProjectInvalidStartDate = "The project cannot start earlier than today!";

            public const string NotFoundTemplate = "{0} [{1}] not found!";
            public const string IsRequiredTemplate = "{0} is required!";
            public const string SprintNotInProjectTemplate = "Sprint [{0}] is not in Project [{1}]";
        }

        public static class Database
        {
            public const string DefaultConnectionString = "Default";
        }

        public static class Configuration
        {
            public const string JwtRoot = "jwt-configuration";

            public const string FacebookAuthRoot = "facebook-auth";
            public const string FacebookApiConfigurationRoot = "facebook-api-configuration";
        }
    }
}
