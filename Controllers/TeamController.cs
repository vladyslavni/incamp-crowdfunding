using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Crowdfunding.Models;
using Crowdfunding.Services;

namespace Crowdfunding.Controllers
{
    [ApiController]
    [Route("api/teams")]
    public class TeamController : Controller
    {
        private TeamService teamService;

        public TeamController(TeamService teamService)
        {
            this.teamService = teamService;
        }

        [HttpGet("{id}")]
        public Team GetTeamById(long id)
        {
            return teamService.GetById(id);
        }

        [HttpGet]
        public List<Team> GetAllTeam()
        {
            return teamService.GetAll();
        }

        [HttpGet("{id}")]
        public List<User> GetAllMembers(long id)
        {
            return teamService.GetAllMembers(id);
        }

        [HttpPost]
        public void CreateNewTeam(Team team)
        {
            teamService.CreateNew(team);
        }

        [HttpPatch("{id}")]
        public void UpdateTeamName(long id, string name)
        {
            teamService.UpdateName(id, name);
        }

        [HttpPatch("{id}/members/{userId}")]
        public void JoinTheTeam(long id, long userId)
        {
            teamService.AddMember(id, userId);
        }

        [HttpDelete("{id}/members/{userId}")]
        public void LeaveTheTeam(long id, long userId)
        {
            teamService.RemoveMember(id, userId);
        }

        [HttpDelete("{id}")]
        public void RemoveTeamById(long id)
        {
            teamService.RemoveById(id);
        }
    }
}