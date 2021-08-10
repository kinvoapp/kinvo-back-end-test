using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using Aliquota.Persistence.Configurations.DataInitializer;
using Aliquota.Persistence.Contexts;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Aliquota.Test.Application.Base
{
    public class TestingBaseFixture : IDisposable
    {
        private static IServiceScopeFactory _scopeFactory;

        public TestingBaseFixture()
        {
            DataInitializerControl.SkipSeedingData = true;

            var configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", true)
                .AddEnvironmentVariables()
                .Build();

            var startup = new Startup(configuration);

            var services = new ServiceCollection();

            startup.ConfigureServices(services);

            _scopeFactory = services.BuildServiceProvider().GetService<IServiceScopeFactory>();

            EnsureCreated();
        }

        private void EnsureCreated()
        {
            _scopeFactory.CreateScope().ServiceProvider.GetService<ApplicationDbContext>().Database.EnsureDeleted();
            _scopeFactory.CreateScope().ServiceProvider.GetService<ApplicationDbContext>().Database.EnsureCreated();
        }

        public static async Task<IEnumerable<TEntity>> AddAsync<TEntity>(IEnumerable<TEntity> entities)
            where TEntity : class
        {
            using var scope = _scopeFactory.CreateScope();

            var context = scope.ServiceProvider.GetService<ApplicationDbContext>();

            context.Set<TEntity>().AddRange(entities);

            await context.SaveChangesAsync();

            return await context.Set<TEntity>().ToListAsync();
        }

        public static async Task DeleteAsync<TEntity>(TEntity entity)
            where TEntity : class
        {
            using var scope = _scopeFactory.CreateScope();

            var context = scope.ServiceProvider.GetService<ApplicationDbContext>();

            context.Set<TEntity>().Remove(entity);

            await context.SaveChangesAsync();
        }


        public static async Task<TEntity> FindAsync<TEntity>(params object[] keyValues) where TEntity : class
        {
            using var scope = _scopeFactory.CreateScope();

            var context = scope.ServiceProvider.GetService<ApplicationDbContext>();

            return await context.Set<TEntity>().FindAsync(keyValues);
        }

        public static async Task<TResponse> SendAsync<TResponse>(IRequest<TResponse> request)
        {
            var scope = _scopeFactory.CreateScope();

            var mediator = scope.ServiceProvider.GetService<IMediator>();

            return await mediator.Send(request);
        }

        public void Dispose()
        {
        }
    }
}