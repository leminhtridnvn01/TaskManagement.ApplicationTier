using AutoMapper;
using Domain.Interfaces;
using Domain.ListTasks;
using Domain.Projects;
using Domain.Projects.Events;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace API.Services.Events
{
    public class AddListTaskDefaultWhenCreateProjectDomainEventHandler : INotificationHandler<AddListTaskDefaultWhenCreateProjectDomainEvent>
    {
        private readonly IProjectRepository _projectRepository;
        private readonly IListTaskRepository _listTaskRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public AddListTaskDefaultWhenCreateProjectDomainEventHandler(IProjectRepository projectRepository,
            IListTaskRepository listTaskRepository,
            IUnitOfWork unitOfWork,
            IMapper mapper)
        {
            _listTaskRepository = listTaskRepository;
            _projectRepository = projectRepository;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task Handle(AddListTaskDefaultWhenCreateProjectDomainEvent addListTaskDefaultEvent, CancellationToken cancellationToken)
        {
            var listTaskDefault = new ListTaskDefault();
            foreach (var listTask in listTaskDefault.ListTasks)
            {
                var listTaskMapper = _mapper.Map<ListTask>(listTask);   
                listTaskMapper.AddProject(addListTaskDefaultEvent.Project);
                await _listTaskRepository.AddAsync(listTaskMapper);
            }
            await _unitOfWork.SaveChangesAsync();
        }
    }
}
