using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Crowdfunding.Models;
using Crowdfunding.Services;

namespace Crowdfunding.Controllers
{
    [ApiController]
    [Route("api/")]
    public class UserController : Controller
    {
        private UserService userService;

        public UserController(UserService userService)
        {
            this.userService = userService;
        }

        [HttpGet("users/{id}")]
        public User GetUserById(int id)
        {
            return userService.GetById(id);
        }

        [HttpGet("users/")]
        public List<User> GetAllUsers()
        {
            return userService.GetAll();
        }

        [HttpPost("users/")]
        public void CreateNewUser(User user)
        {
            userService.CreateNew(user);
        }

        [HttpDelete("users/{id}")]
        public void RemoveUserById(int id)
        {
            userService.RemoveById(id);
        }
    }
}