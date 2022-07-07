using Domain.ListTasks;
using Domain.Projects;
using Domain.Entities.Tasks;
using Domain.Users;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using System.Threading;
using MediatR;
using Infrastructure.Extensions;

namespace Infrastructure.Data
{
    public partial class EFContext : DbContext
    {
        private readonly IMediator _mediator;
        public EFContext()
        {
        }

        public EFContext(DbContextOptions<EFContext> options, IMediator mediator)
            : base(options)
        {
            _mediator = mediator;
        }
        public DbSet<User> Users { get; set; }
        public DbSet<Project> Projects { get; set; }
        public DbSet<ListTask> ListTasks { get; set; }
        public DbSet<TaskItem> TaskItems { get; set; }
        public DbSet<Attachment> Attachments { get; set; }
        public DbSet<Tag> Tags { get; set; }
        public DbSet<ListTodo> ListTodoes { get; set; }
        public DbSet<TodoItem> TodoItems { get; set; }
        public DbSet<Assignment> Assignments { get; set; }
        public DbSet<ProjectMember> ProjectMembers { get; set; }
        public DbSet<TagMapping> TagMappings { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("server=ADMIN\\MINHTRI;database=TaskManagement;user id=sa;password=123456;");
        }

        public async Task<bool> SaveEntitiesAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            // Dispatch Domain Events collection. 
            // Choices:
            // A) Right BEFORE committing data (EF SaveChanges) into the DB will make a single transaction including  
            // side effects from the domain event handlers which are using the same DbContext with "InstancePerLifetimeScope" or "scoped" lifetime
            // B) Right AFTER committing data (EF SaveChanges) into the DB will make multiple transactions. 
            // You will need to handle eventual consistency and compensatory actions in case of failures in any of the Handlers. 
            await _mediator.DispatchDomainEventsAsync(this);

            // After executing this line all the changes (from the Command Handler and Domain Event Handlers) 
            // performed through the DbContext will be committed
            var result = await base.SaveChangesAsync(cancellationToken);

            return true;
        }
    }
}
