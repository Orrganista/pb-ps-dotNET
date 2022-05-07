using People.Interfaces;
using People.Repositories;
using People.Services;

namespace People
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddProjectService(this
        IServiceCollection services)
        {
            services.AddTransient<IPersonService, PersonService>();
            services.AddTransient<IPersonRepository, PersonRepository>();
            return services;
        }
    }

}
