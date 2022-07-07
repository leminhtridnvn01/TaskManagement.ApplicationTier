using Domain.Base;
using System.Collections.Generic;

namespace Domain.Entities.Tasks
{
    public partial class ListTodo : BaseEntity<int>
    {
        public string Name { get; set; }
        public bool IsDone { get; set; }
        public virtual TaskItem TaskItem { get; set; }
        public virtual ICollection<TodoItem> TodoItems { get; set; }
    }
}
