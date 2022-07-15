using gwl_voices.Application.Contracts.Services;
using gwl_voices.Application.Services;
using gwl_voices.ApplicationContracts.Services;
using gwl_voices.DataAccess;
using gwl_voices.DataAccess.Contracts;
using gwl_voices.DataAccess.Contracts.Repositories;
using gwl_voices.DataAccess.Repositories;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;


namespace gwl_voices.CrossCutting.Configuration
{
    public static class IoC
    {
        public static IServiceCollection Register(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddTransient<IUnitOfWork, UnitOfWork>();
            services.AddTransient<IWorkingGroupRepository, WorkingGroupRepository>();
            services.AddTransient<IWorkingGroupService, WorkingGroupService>();
            services.AddTransient<IUserRepository, UserRepository>();
            services.AddTransient<IUserService, UserService>();
            services.AddTransient<ILoginRepository, LoginRepository>();
            services.AddTransient<ILoginService, loginService>();
            services.AddTransient<ImailService, mailService>();




            return services;
        }




    }
}
