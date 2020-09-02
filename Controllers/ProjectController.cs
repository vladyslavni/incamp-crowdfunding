using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Crowdfunding.Models;
using Crowdfunding.Services;
using Crowdfunding.Models.Enums;

namespace Crowdfunding.Controllers
{
    [ApiController]
    [Route("api/")]
    public class ProjectController : Controller
    {
        private ProjectService projectService;

        public ProjectController(ProjectService projectService)
        {
            this.projectService = projectService;
        }

        [HttpGet("projects/{id}")]
        public Project GetProjectById(long id)
        {
            return projectService.GetById(id);
        }

        [HttpGet("projects/")]
        public List<Project> GetAllProjects()
        {
            return projectService.GetAll();
        }

        [HttpPost("projects/")]
        public void CreateNewProject(Project project)
        {
            projectService.CreateNew(project);
        }

        [HttpPatch("projects/{id}")]
        public void UpdateProjectStatus(long id, ProjectStatus status)
        {
            projectService.UpdateStatus(id, status);
        }

        [HttpDelete("projects/{id}")]
        public void RemoveProjectById(long id)
        {
            projectService.RemoveById(id);
        }
    }
}