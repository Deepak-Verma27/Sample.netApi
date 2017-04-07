using SampleApp.Base.Repositories;
using SampleApp.BusinessLogic.Repositories;
using SampleApp.DataAccess;
using SampleApp.DataAccess.Tables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class SampleServiceRepositoryCollectionExtension
    {
        public static IServiceCollection AddSampleServiceRepositories(this IServiceCollection services)
        {
            services.AddScoped<IRoleRepository, RoleRepository<Role>>();
            services.AddScoped<IStudentRepository, StudentRepository<Student>>();

            return services;
        }
    }
}
