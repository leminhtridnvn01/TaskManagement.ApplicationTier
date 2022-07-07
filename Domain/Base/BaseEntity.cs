using MediatR;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Base
{
    public abstract class BaseEntity
    {
        public BaseEntity()
        {
            _events = new List<BaseDomainEvent>();
        }

        [NotMapped]
        private List<BaseDomainEvent> _events;
        [NotMapped]
        public IReadOnlyList<BaseDomainEvent> Events => _events.AsReadOnly();

        protected void AddEvent(BaseDomainEvent @event)
        {
            _events.Add(@event);
        }

        protected void RemoveEvent(BaseDomainEvent @event)
        {
            _events.Remove(@event);
        }

        public void ClearDomainEvents()
        {
            _events?.Clear();
        }
    }

    public abstract class BaseEntity<TKey> : BaseEntity
    {
        public BaseEntity() 
        {
            IsDeleted = false;
            CreatedByUserId = null;
            CreatedDate = DateTime.Now;
            UpdatedByUserId = null;
            UpdatedDate = DateTime.Now;
        }
        public TKey Id { get; set; }
        public bool? IsDeleted { get; set; }
        public DateTime? CreatedDate { get; set; }
        public int? CreatedByUserId { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public int? UpdatedByUserId { get; set; }
    }
}
