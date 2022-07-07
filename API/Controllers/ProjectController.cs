using Domain.DTOs.Projects.AddProject;
using Domain.Projects;
using Domain.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using TaskManagement.ApplicationTier.API.Controllers;

namespace API.Controllers
{
    public class ProjectController : BaseApiController
    {
        [HttpPost]
        [Route("AddProject")]
        public async Task Create([FromServices] IProjectService _projectService, AddProjectRequest projectRequest)
        {
            await _projectService.CreateProject(projectRequest);
        }

        [HttpPost]
        [Route("AddMember")]
        public async Task AddMember([FromServices] IProjectService _projectService, int memberId, int projectId)
        {
            await _projectService.AddMember(memberId, projectId);
        }
    }
}
