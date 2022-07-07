using Domain.Projects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Data.Repositories
{
    public class ProjectMemberRepository : Repository<ProjectMember>, IProjectMemberRepository
    {
        public ProjectMemberRepository(EFContext dbContext) : base(dbContext)
        {
        }

        public Task AddMember(int memberId, int projectId)
        {
            throw new NotImplementedException();
        }
    }
}
