using Domain.Base;
using System.Collections.Generic;

namespace Domain.Entities.Tasks
{
    public partial class TodoItem : BaseEntity<int>
    {
        public string Name { get; set; }
        public bool IsDone { get; set; }
        public ListTodo ListTodo { get; set; }
        public virtual TodoItem TodoParrent { get; set; }
        public virtual ICollection<TodoItem> SubTodoItems { get; set; }
    }
}
