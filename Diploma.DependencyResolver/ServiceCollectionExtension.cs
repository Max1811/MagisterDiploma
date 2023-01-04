using Diploma.BL.Services;
using Diploma.BL.Services.Contracts;
using Diploma.DataAccess.Repositories;
using Diploma.DataAccess.Repositories.Contracts;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Diploma.DependencyResolver
{
    public static class ServiceCollectionExtension
    {
        public static void RegisterDependencies(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

            services.AddScoped<ICurrentUserAware, CurrentUserAware>();
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IEmailSendingService, EmailSendingService>();
            services.AddScoped<IPublicationService, PublicationService>();
            
            services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IPublicationRepository, PublicationRepository>();
            services.AddScoped<IPublicationTypeRepository, PublicationTypeRepository>();
        }
    }
}
