using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using planoTestTwo.Models;

namespace planoTestTwo.Interfaces
{
    interface IUserRepository
    {        
        User GetUserInfoByID(long Id);

        Response CreateNewUser(UserRequest userReq);
    }
}
