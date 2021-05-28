using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using planoTestTwo.Models;
using planoTestTwo.Repositories;
using System.Resources;
using System.Reflection;
using System.Globalization;
using System.Net.Http;

namespace planoTestTwo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {

        private UserRepository _users = new UserRepository();

        [HttpGet("{Id}")]
        public ActionResult<UserResponse> GetBookByID(int Id)
        {
            var user = _users.GetUserInfoByID(Id);
            var _userResponse = new UserResponse();
            try
            {
                if (user == null)
                {
                    return NotFound();
                }
                ResourceManager rm = new ResourceManager("planoTestTwo.Resource", Assembly.GetExecutingAssembly());
                String message = rm.GetString(user.Language, CultureInfo.CurrentCulture);

                _userResponse.FullName = user.FullName;
                _userResponse.Message = message;
                return _userResponse;
            }
            catch (Exception)
            {

                throw;
            }
        }

        [HttpPost]
        public ActionResult<Response> Create(UserRequest _userReq)
        {
            try
            {
                var newUser = _users.CreateNewUser(_userReq);
                return newUser;
            }
            catch (Exception)
            {
                throw;
            }         
        }
    }
}
