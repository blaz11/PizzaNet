namespace Pizza.Net.RestAPIAccess
{
    static class WebAPIData
    {
        public static string BASE_ADDRESS = "http://localhost:54432/api/";
        public static string BASE_TOKEN_ADDRESS = "http://localhost:54432/token";
    }

    static class ErrorsMessages
    {
        public static string CONNECTION_TIMEOUT = "Connection timeout.\nPlease check your internet connection.";
        public static string PASSWORDS_DONT_MATCH = "Passwords don't match!";
    }
}