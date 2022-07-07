using Domain.Base;
using Domain.ListTasks;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Projects.Events
{
    public class AddListTaskDefaultWhenCreateProjectDomainEvent : BaseDomainEvent
    {
        public Project Project { get; set; }
        public AddListTaskDefaultWhenCreateProjectDomainEvent(Project project)
        {
            Project = project;
        }
    }
}
