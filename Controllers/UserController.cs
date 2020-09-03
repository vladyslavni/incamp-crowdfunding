using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Crowdfunding.Models;
using Crowdfunding.Services;

namespace Crowdfunding.Controllers
{
    [ApiController]
    [Route("api/users")]
    public class UserController : Controller
    {
        private UserService userService;

        public UserController(UserService userService)
        {
            this.userService = userService;
        }

        [HttpGet("{id}")]
        public User GetUserById(long id)
        {
            return userService.GetById(id);
        }

        [HttpGet]
        public List<User> GetAllUsers()
        {
            return userService.GetAll();
        }

        [HttpDelete("{id}")]
        public void RemoveUserById(long id)
        {
            userService.RemoveById(id);
        }
    }
}