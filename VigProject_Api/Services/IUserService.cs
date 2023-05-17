using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VigProject_Api.Services
{
   public interface IUserService
    {
        bool ValidateCredentials(string username, string password);
    }
}
