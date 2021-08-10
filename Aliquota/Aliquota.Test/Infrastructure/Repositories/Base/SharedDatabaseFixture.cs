using System;
using System.Data.Common;
using Aliquota.Persistence.Configurations.DataInitializer;
using Aliquota.Persistence.Contexts;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace Aliquota.Test.Infrastructure.Repositories.Base
{
    public class SharedDatabaseFixture : IDisposable
    {
        private static readonly object _lock = new();
        private static bool _databaseInitialized;

        public SharedDatabaseFixture()
        {
            DataInitializerControl.SkipSeedingData = true;

            Connection =
                new SqlConnection(@"Server=(localdb)\mssqllocaldb;Database=kinvo-tests-repositories;Trusted_Connection=True");

            Create();

            Connection.Open();
        }

        public DbConnection Connection { get; }

        public ApplicationDbContext CreateContext(DbTransaction transaction = null)
        {
            var context = new ApplicationDbContext(new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseSqlServer(Connection).Options);

            if (transaction != null) context.Database.UseTransaction(transaction);

            return context;
        }

        private void Create()
        {
            lock (_lock)
            {
                if (!_databaseInitialized)
                {
                    using (var context = CreateContext())
                    {
                        context.Database.EnsureDeleted();
                        context.Database.EnsureCreated();
                    }

                    _databaseInitialized = true;
                }
            }
        }

        public void Dispose()
        {
            Connection.Dispose();
        }
    }
}