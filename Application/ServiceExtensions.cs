using Microsoft.Extensions.DependencyInjection;
using System.Reflection;
using MediatR;
using Application.MongoServices;
using Application.Interfaces;

namespace Application
{
    public static class ServiceExtensions
    {
        public static void AddApplicationLayer(this IServiceCollection services)
        {
            services.AddMediatR(Assembly.GetExecutingAssembly());
            services.AddScoped<IUserService, UserService>();
        }
    }
}
