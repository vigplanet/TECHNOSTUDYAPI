using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VigProject_Api.Global
{
    public class ResponseStatus
    {
        public const string SUCCESS = "Success";
        public const string FAILED = "Failed";
        public const string FAILED_MSG = "Failed";

        public const string AUTH_FAILED = "Authentication Failed";
        public const string AUTH_TOKEN_MISSING = "Authentication Token Missing";
        public const string AUTH_TOKEN_EXPIRED = "Authentication Token Expired";
        public const string AUTH_UNAUTHORIZED = "Authorization Failed";

        public const string SYSTEM_ERROR = "System Error";
        public const string NOTFOUND = "Data Not Found";
    }
}
