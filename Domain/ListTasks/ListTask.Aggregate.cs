using Domain.Base;
using Domain.Projects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.ListTasks
{
    public partial class ListTask : IAggregateRoot
    {
        public ListTask(string name)
        {
            Name = name;
        }

        public void AddProject(Project project)
        {
            Project = project;
        }
    }
}
