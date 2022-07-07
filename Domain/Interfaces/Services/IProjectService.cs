using Domain.DTOs.Projects.AddProject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces.Services
{
    public interface IProjectService
    {
        Task CreateProject(AddProjectRequest projectRequest);
        Task AddMember(int memberId, int projectId);
    }
}
