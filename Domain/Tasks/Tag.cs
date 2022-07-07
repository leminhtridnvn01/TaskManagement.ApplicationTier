using Domain.Base;
using System.Collections.Generic;

namespace Domain.Entities.Tasks
{
    public partial class Tag : BaseEntity<int>
    {
        public string Name { get; set; }
        public string Color { get; set; }
        public virtual ICollection<TagMapping> TaskItems { get; set; }
    }
}
