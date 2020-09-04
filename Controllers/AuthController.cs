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
        [ValidateAntiForgeryToken]
        [HttpPost("registration")]
        public void RegisterUser(RegisterUserDto userDto)
        {
            User user = RegisterUserMapper.Map(userDto);
            signInManager.UserManager.CreateAsync(user, user.PasswordHash);
        }

        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        [HttpPost("login")]
        public void LoginUser(LoginUserDto loginUser)
        {
            var user = userService.GetByCredentials(loginUser);

            if (user != null)
            {  
                var result = signInManager.PasswordSignInAsync(user, loginUser.PasswordHash, false, false);
                Console.WriteLine(result.Result.Succeeded);
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