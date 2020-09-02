using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Crowdfunding.Models;
using Crowdfunding.Services;

namespace Crowdfunding.Controllers
{
    [ApiController]
    [Route("api/")]
    public class TeamController : Controller
    {
        private TeamService teamService;

        public TeamController(TeamService teamService)
        {
            this.teamService = teamService;
        }

        [HttpGet("teams/{id}")]
        public Team GetTeamById(int id)
        {
            return teamService.GetById(id);
        }

        [HttpGet("teams/")]
        public List<Team> GetAllTeam()
        {
            return teamService.GetAll();
        }

        [HttpPost("teams/")]
        public void CreateNewTeam(Team team)
        {
            teamService.CreateNew(team);
        }

        [HttpPatch("teams/{id}")]
        public void UpdateTeamName(int id, string name)
        {
            teamService.UpdateName(id, name);
        }

        [HttpDelete("teams/{id}")]
        public void RemoveTeamById(int id)
        {
            teamService.RemoveById(id);
        }
    }
}