using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application;
using Infrastructure.Extensions;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Presentation.Extentions
{
    public static class ConfigureServiceContainer
    {
        public static void AddFramework(this IServiceCollection services, IConfiguration configuration, string connectionString, string mongoConnectionString, string mongoDatabaseName)
        {

            services.AddPersistenceDbContext(configuration, connectionString);
            services.AddPersistenceRepositories();
            services.AddApplicationLayer();
            services.AddNosqlDbContext(mongoConnectionString, mongoDatabaseName);

            //services.AddSharedInfrastructure();
            //services.AddHttpContextAccessor();

        }

        /*public static void AddApiVersioningExtension(this IServiceCollection services)
        {

            #region API Versioning
            // Add API Versioning to the Project
            services.AddApiVersioning(config =>
            {
                // Specify the default API Version as 1.0
                config.DefaultApiVersion = new ApiVersion(1, 0);
                // If the client hasn't specified the API version in the request, use the default API version number 
                config.AssumeDefaultVersionWhenUnspecified = true;
                // Advertise the API versions supported for the particular endpoint
                config.ReportApiVersions = true;
            });
            #endregion
        }*/
    }
}
