using System;
using Microsoft.AspNetCore.Mvc;
using Crowdfunding.Models.Dto;
using Crowdfunding.Models;
using Crowdfunding.Models.Mappers;
using Crowdfunding.Services;
using Microsoft.AspNetCore.Authorization;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;

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
        public async Task<IActionResult> RegisterUser(RegisterUserDto userDto)
        {
            User user = RegisterUserMapper.Map(userDto);
            IdentityResult result = await signInManager.UserManager.CreateAsync(user, user.PasswordHash);
            
            if (result.Succeeded) {
                return Ok();
            } else {
                return Unauthorized();
            }
        }

        [AllowAnonymous]
        [HttpPost("login")]
        public async Task<IActionResult> LoginUser(LoginUserDto loginUser)
        {
            var user = userService.GetByCredentials(loginUser);

            if (user != null)
            {  
                Microsoft.AspNetCore.Identity.SignInResult result = await signInManager.PasswordSignInAsync(user, loginUser.PasswordHash, true, false);
                // return result.Succeeded ? Ok() : Unauthorized();
                
                if (result.Succeeded) {
                    return Ok();
                } else {
                    return Unauthorized();
                }
            }  
            return Unauthorized();
        }

        [Authorize]
        [HttpPost("logout")]
        public void Logout()
        {
            signInManager.SignOutAsync();
        }
    }
}