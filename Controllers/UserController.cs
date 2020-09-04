using System.Linq;
using System.Collections.Generic;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Crowdfunding.Models;
using Crowdfunding.Services;
using System.Threading.Tasks;
using System;
using Microsoft.AspNetCore.Http;
using System.Security.Claims;
using Microsoft.AspNetCore.Identity;

namespace Crowdfunding.Controllers
{
    [ApiController]
    [Route("api/users")]
    public class UserController : Controller
    {
        private UserService userService;
        private SignInManager<User> signInManager;
        public UserController(UserService userService, SignInManager<User> signInManager)
        {
            this.userService = userService;
            this.signInManager = signInManager;
        }

        [HttpGet("{id}")]
        public User GetUserById(long id)
        {
            return userService.GetById(id);
        }

        [HttpGet("me")]
        public User GetMyUser()
        {
            var id = User.FindFirstValue(ClaimTypes.NameIdentifier);
            long userId = Int64.Parse(id);
            
            return userService.GetById(userId);
        }

        [HttpGet]
        public List<User> GetAllUsers()
        {
            return userService.GetAll();
        }

        [HttpDelete("me")]
        public void DeleteMyUser()
        {
            var id = User.FindFirstValue(ClaimTypes.NameIdentifier);
            long userId = Int64.Parse(id);
            
            userService.RemoveById(userId);
        }

        [HttpDelete("{id}")]
        public void RemoveUserById(long id)
        {
            userService.RemoveById(id);
        }
    }
}