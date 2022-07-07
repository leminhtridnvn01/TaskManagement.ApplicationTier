using Domain.Base;
using Domain.Users;
using System;
using System.Collections.Generic;

namespace Domain.Entities.Tasks
{
    public partial class TaskItem : BaseEntity<int>
    {
        public string Name { get; set; }
        public virtual ICollection<Assignment> Assignees { get; internal set; }
        public virtual User AssigneeInProgress { get; set; }
        public DateTime Deadline { get; set; }
        public string Prioritized { get; set; }
        //public virtual ICollection<Tag> Tags { get; internal set; }
        public string Description { get; set; }
        public bool IsDone { get; set; }
        public virtual ICollection<Attachment> Attachments { get; internal set; }
        //public virtual ICollection<ListTodo> ListTodoes { get; internal set; }
    }
}
