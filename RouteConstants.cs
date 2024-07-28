using System.Runtime.CompilerServices;

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

        #region User Endpoints

        public const string GetUser = "GetUser";

        public const string GetAllUsers = "GetAllUsers";

        public const string CreateUser = "CreateUser";

        public const string UpdateUser = "UpdateUser";

        public const string DeleteUser = "DeleteUser";
        #endregion

        #region Task Endpoints
        public const string GetTask = "GetTask";

        public const string CreateTask = "CreateTask";

        public const string UpdateTask = "UpdateTask";

        public const string DeleteTask = "DeleteTask";
        #endregion

        public const string GenerateToken = "GenerateToken";

        #endregion
    }
}
