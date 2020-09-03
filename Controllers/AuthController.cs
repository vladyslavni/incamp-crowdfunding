using System.Security.AccessControl;
using Microsoft.AspNetCore.Mvc;
using Crowdfunding.Models.Dto;
using Crowdfunding.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;

namespace Crowdfunding.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/account")]
    public class AuthController
    {
        private UserService userService;
        private IHttpContextAccessor accessor;
        public AuthController(UserService userService, IHttpContextAccessor accessor)
        {
            this.userService = userService;
            this.accessor = accessor;
        }

        [AllowAnonymous]
        [HttpPost("registration")]
        public void RegisterUser(RegisterUserDto user)
        { 
            userService.CreateNew(user);
        }

        [HttpPost("login")]
        public ActionResult LoginUser(LoginUserDto loginUser)
        {
            var user = userService.GetByCredentials(loginUser);
            if (user != null)  
            {  
                var httpContext = accessor.HttpContext;
                httpContext.Session.SetString("UserID", user.Id.ToString());  
                httpContext.Session.SetString("UserName", user.UserName);  
                //TODO Переадресация
                return null;
            }  
            //TODO Переадресация
            return null;
        }
    }
}