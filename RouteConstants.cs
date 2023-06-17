namespace BasicAPI
{
    public static class RouteConstants
    {
        #region Controller Routes

        public const string MainController = "api/Main";

        public const string TokenController = "api/JWT";

        #endregion

        #region Action Routes

        public const string GlobalExceptionHandler = "GlobalExceptionHandler";

        public const string GetBreakfast = "GetBreakfast";

        public const string CreateBreakfast = "CreateBreakfast";

        public const string UpdateBreakfast = "UpdateBreakfast";

        public const string DeleteBreakfast = "DeleteBreakfast";

        public const string GenerateToken = "GenerateToken";

        #endregion
    }
}
