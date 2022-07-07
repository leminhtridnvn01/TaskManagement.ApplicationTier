using AutoMapper;
using Domain.Base;
using Domain.DTOs.Projects.AddProject;
using Domain.ListTasks;
using Domain.Projects;
using Domain.Interfaces;
using Domain.ListTasks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.DTOs.Projects.AddMember;

namespace Domain.Projects
{
    public class ProjectDomainService : BaseDomainService
    {
        private readonly IProjectRepository _projectRepository;
        private readonly IProjectMemberRepository _projectMemberRepository;
        private readonly IMemberRepository _memberRepository;
        private readonly IMapper _mapper;
        public ProjectDomainService(IProjectRepository projectRepository,
            IProjectMemberRepository projectMemberRepository,
            IMemberRepository memberRepository,
            IMapper mapper)
        {
            _projectRepository = projectRepository;
            _projectMemberRepository = projectMemberRepository;
            _memberRepository = memberRepository;
            _mapper = mapper;
        }
        public async Task CreateProjectWithDefaultListTask(AddProjectRequest projectInput)
        {
            //var project = _mapper.Map<Project>(projectInput);
            
            //newProject.AddListTaskDefault(newProject);
            //project.ListTasks = _mapper.Map<List<ListTask>>(listTaskDefault.ListTasks);
            //await _projectRepository.AddAsync(project);

        }

        public async Task AssignMemberToProject(int memberId, int projectId)
        {
            var member = await _memberRepository.GetAsync(s => s.Id == memberId);
            var project = await _projectRepository.GetAsync(s => s.Id == projectId);
            await _projectMemberRepository.AddAsync(new ProjectMember() { Member = member, Project = project });
        }
    }
}
