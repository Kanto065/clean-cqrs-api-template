using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Contracts;
using Domain.Entities;
using Infrastructure.Context;
using Infrastructure.MongoDb;
using Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using Shared.Contracts;

namespace Infrastructure.Extensions
{
    public static class ConfigureServiceContainer
    {
        public static void AddPersistenceDbContext(this IServiceCollection services, IConfiguration configuration, string connectionString)
        {
            services.AddDbContext<ApplicationContext>(options =>
            {
                options.UseNpgsql(connectionString);
            });  
        }

        public static void AddNosqlDbContext(this IServiceCollection services, string mongoConnectionString, string mongoDatabaseName)
        {
            // Register MongoDB client using the provided connection string
            services.AddSingleton<IMongoClient>(sp => new MongoClient(mongoConnectionString));

            // Register Database using the provided database name
            services.AddScoped(sp =>
            {
                var client = sp.GetRequiredService<IMongoClient>();
                return client.GetDatabase(mongoDatabaseName);
            });
        }

        public static void AddPersistenceRepositories(this IServiceCollection services)
        {
            services.AddScoped(typeof(IRepositoryAsync<>), typeof(RepositoryAsync<>));
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<IFileManagementRepository, FileManagementRepository>();
            
        }

        public static void AddNosqlRepositories(this IServiceCollection services)
        {
            services.AddScoped(typeof(IMongoRepository<>), typeof(MongoRepository<>));
            services.AddScoped<IMongoUnitOfWork, MongoUnitOfWork>();
            //services
        }
    }
}
