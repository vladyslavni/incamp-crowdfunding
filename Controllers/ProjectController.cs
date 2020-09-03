using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Crowdfunding.Models;
using Crowdfunding.Services;
using Crowdfunding.Models.Enums;

namespace Crowdfunding.Controllers
{
    [ApiController]
    [Route("api/projects")]
    public class ProjectController : Controller
    {
        private ProjectService projectService;

        public ProjectController(ProjectService projectService)
        {
            this.projectService = projectService;
        }

        [HttpGet("{id}")]
        public Project GetProjectById(long id)
        {
            return projectService.GetById(id);
        }

        [HttpGet]
        public List<Project> GetAllProjects()
        {
            return projectService.GetAll();
        }

        [HttpPost]
        public void CreateNewProject(Project project)
        {
            projectService.CreateNew(project);
        }

        [HttpPatch("{id}")]
        public void UpdateProjectStatus(long id, ProjectStatus status)
        {
            projectService.UpdateStatus(id, status);
        }

        [HttpDelete("{id}")]
        public void RemoveProjectById(long id)
        {
            projectService.RemoveById(id);
        }
    }
}