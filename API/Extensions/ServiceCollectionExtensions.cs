using API.Services;
using API.Services.Events;
using Domain.Interfaces;
using Domain.Interfaces.Services;
using Domain.ListTasks;
using Domain.Projects;
using Domain.Projects.Events;
using Domain.Users;
using Infrastructure.Data;
using Infrastructure.Data.Repositories;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using TaskManagement.ApplicationTier.API.Profiles;

namespace API.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddRepositories(this IServiceCollection services)
        {
            return services
                .AddScoped(typeof(IAsyncRepository<>), typeof(Repository<>))
                .AddScoped<IMemberRepository, MemberRepository>()
                .AddScoped<IUserRepository, UserRepository>()
                .AddScoped<IProjectMemberRepository, ProjectMemberRepository>()
                .AddScoped<IListTaskRepository, ListTaskRepository>()
                .AddScoped<IProjectRepository, ProjectRepository>();
        }

        public static IServiceCollection AddUnitOfWork(this IServiceCollection services)
        {
            return services
                .AddScoped<IUnitOfWork, UnitOfWork>();
        }

        public static IServiceCollection AddDatabase(this IServiceCollection services
            , IConfiguration configuration)
        {
            return services.AddDbContext<EFContext>(options =>
                     options.UseSqlServer("server=ADMIN\\MINHTRI;database=TaskManagement;user id=sa;password=123456;"));
        }
        public static IServiceCollection AddBusinessServices(this IServiceCollection services
           )
        {
            services.AddMediatR(typeof(AddListTaskDefaultWhenCreateProjectDomainEventHandler).Assembly);
            services.AddAutoMapper(typeof(MapperProfile).Assembly);
            services.AddScoped<IProjectService, ProjectService>();
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<ITokenService, TokenService>();
            services.AddScoped<ProjectDomainService>();
            return services;
        }
        //public static IServiceCollection AddBusinessServices(this IServiceCollection services
        //   )
        //{
        //    return services
        //        .AddScoped<UserService>();
        //}
    }
}
