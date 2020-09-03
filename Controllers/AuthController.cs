using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Session;
using Crowdfunding.Models;
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

        [HttpPost("registration")]
        public void RegisterUser(RegisterUserDto user)
        { 
            userService.CreateNew(user);
        }

        [HttpPost("login")]
        public ActionResult LoginUser(LoginUserDto user)
        {
            var obj = userService.GetByCredentials(user);
            if (obj != null)  
            {  
                var httpContext = accessor.HttpContext;
                httpContext.Session.SetString("UserID", obj.Id);  
                httpContext.Session.SetString("UserName", obj.UserName);  
                //TODO Переадресация
                return null;
            }  
            //TODO Переадресация
            return null;
        }
    }
}