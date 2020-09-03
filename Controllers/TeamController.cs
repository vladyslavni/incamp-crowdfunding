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

        [HttpDelete("{id}")]
        public void RemoveTeamById(long id)
        {
            teamService.RemoveById(id);
        }
    }
}