using Domain.ListTasks;
using Domain.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Projects.Events;

namespace Domain.Projects
{
    public partial class Project
    {
        //public Project()
        //{
        //    ListTasks = new HashSet<ListTask>();
        //    Members = new HashSet<ProjectMember>();
        //}

        public Project(string name
            , string description) : this()
        {
            this.Update(name, description);
        }

        public void Update(string name,
            string description)
        {
            Name = name;
            Description = description;
        }

        public void AddListTaskDefault(Project project)
        {
            var addListTaskDefaultDomainEvent = new AddListTaskDefaultWhenCreateProjectDomainEvent(project);
            this.AddEvent(addListTaskDefaultDomainEvent);
        }
    }
}
