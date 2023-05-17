using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VigProject_Api.Services
{
    public class UserService : IUserService 
    {
        public bool ValidateCredentials(string username, string password)
        {
            return username.Equals("studyadmin") && password.Equals("TECHSTD$$EpAnJ");
        }
    }
}
