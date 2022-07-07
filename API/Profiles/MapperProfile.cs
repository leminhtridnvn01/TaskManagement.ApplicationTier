using AutoMapper;
using Domain.DTOs.ListTasks.AddListTask;
using Domain.DTOs.Projects.AddProject;
using Domain.ListTasks;
using Domain.Projects;

namespace TaskManagement.ApplicationTier.API.Profiles
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            CreateMap<AddProjectRequest, Project>();
            CreateMap<Project, AddProjectRequest>();

            CreateMap<AddListTaskRequest, ListTask>();
            CreateMap<ListTask, AddListTaskRequest>();
        }
    }
}