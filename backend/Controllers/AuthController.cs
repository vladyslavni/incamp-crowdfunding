using System.Data.Common;
using System.Security.Claims;
using System;
using Microsoft.AspNetCore.Mvc;
using Crowdfunding.Models.Dto;
using Crowdfunding.Models;
using Crowdfunding.Models.Mappers;
using Crowdfunding.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Identity;

namespace Crowdfunding.Controllers
{

    [ApiController]
    [Route("api/account")]
    public class AuthController : Controller
    {
        private UserService userService;
        private SignInManager<User> signInManager;
        public AuthController(UserService userService, SignInManager<User> signInManager)
        {
            this.userService = userService;
            this.signInManager = signInManager;
        }

        [AllowAnonymous]
        [HttpPost("registration")]
        public void RegisterUser(RegisterUserDto userDto)
        {
            User user = RegisterUserMapper.Map(userDto);
            userService.CreateNew(user);
            signInManager.UserManager.UpdateSecurityStampAsync(user);
            signInManager.UserManager.CreateAsync(user, user.PasswordHash);
        }

        [AllowAnonymous]
        [HttpPost("login")]
        public void LoginUser(LoginUserDto loginUser)
        {
            var user = userService.GetByCredentials(loginUser);
            
            if (user != null)
            {  
                var result = signInManager.PasswordSignInAsync(user, loginUser.PasswordHash, false, false);
            }  
        }

        [Authorize]
        [ValidateAntiForgeryToken]
        [HttpPost("logout")]
        public void Logout()
        {
            signInManager.SignOutAsync();
        }
    }
}