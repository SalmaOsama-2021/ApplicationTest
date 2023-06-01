using SchoolApplication.Client.Services.serviceAllParent;
using SchoolApplication.Server.IPschoolsRepository;
using SchoolApplication.Server.PschoolsRepository;

namespace SchoolApplication.Server.InjectServices
{
    public static class ServiceBinding
    {
        public static IServiceCollection InjectServices(this IServiceCollection services)
        {
            services.AddScoped<IParentRepository,ParentRepository>();
            services.AddScoped<IStudentRepository, StudentRepository>();


            return services;
        }
    }
}
