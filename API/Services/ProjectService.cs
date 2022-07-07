using AutoMapper;
using Domain.DTOs.Projects.AddProject;
using Domain.Interfaces;
using Domain.Interfaces.Services;
using Domain.ListTasks;
using Domain.Projects;
using Domain.Projects.Events;
using Infrastructure.Data.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace API.Services
{
    public class ProjectService : IProjectService
    {
        private readonly IProjectRepository _projectRepository;
        private readonly ProjectDomainService _projectDomainService;
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;
        public ProjectService(IProjectRepository projectRepository,
            ProjectDomainService projectDomainService,
            IMediator mediator,
            IMapper mapper,
            IUnitOfWork unitOfWork)
        {
            _projectDomainService = projectDomainService;
            _projectRepository = projectRepository;
            _mediator = mediator;
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        public async Task AddMember(int memberId, int projectId)
        {
            try
            {
                await _projectDomainService.AssignMemberToProject(memberId, projectId);
                await _unitOfWork.SaveChangesAsync();
            }
            catch (Exception e)
            {
                throw new NotImplementedException();
            }
        }

        public async Task CreateProject(AddProjectRequest projectRequest)
        {
            try
            {
                var project = _mapper.Map<Project>(projectRequest);
                var projectId = await _projectRepository.InsertAndGetIdAsync(project);
                var newProject = await _projectRepository.GetAsync(s => s.Id == projectId);
                newProject.AddListTaskDefault(newProject);
                await _unitOfWork.SaveEntitiesAsync();
            }
            catch (Exception e)
            {
                throw new NotImplementedException();
            }
        }
    }
}
