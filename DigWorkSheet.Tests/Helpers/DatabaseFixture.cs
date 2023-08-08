using DigWorkSheet.WebApi.Database;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.EntityFrameworkCore.Storage;
using Moq;
using System.Threading.Tasks;
using System.Linq;

namespace DigWorkSheet.Tests.Helpers
{
    public sealed class DatabaseFixture
    {
        public DigWorkSheetContext dbContext;
        private DbContextOptions<DigWorkSheetContext> _contextOptions;

        private async Task<DatabaseFixture> InitializeAsync(string dbName)
        {
            _contextOptions = new DbContextOptionsBuilder<DigWorkSheetContext>().UseInMemoryDatabase(databaseName: dbName, new InMemoryDatabaseRoot())
                .ConfigureWarnings(x => x.Ignore(InMemoryEventId.TransactionIgnoredWarning))
                .EnableSensitiveDataLogging(true)
                .Options;

            dbContext = new DigWorkSheetContext(_contextOptions);
            await dbContext.Database.EnsureCreatedAsync();
            return this;
        }

        private static void DetachAllEntities(DigWorkSheetContext context)
        {
            var changedEntriesCopy = context.ChangeTracker.Entries()
            .Where(e => e.State == EntityState.Added ||
                        e.State == EntityState.Modified ||
                        e.State == EntityState.Deleted)
            .ToList();

            foreach (var entry in changedEntriesCopy)
                entry.State = EntityState.Detached;
        }

        public static async Task<DatabaseFixture> CreateAsync(string dbName)
        {
            var instance  = new DatabaseFixture();
            return await instance.InitializeAsync(dbName);
        }

        public async Task CleanDatabaseAsync()
        {
            DetachAllEntities(dbContext);
            await dbContext.Database.EnsureDeletedAsync();
            await dbContext.Database.EnsureCreatedAsync();
        }
    }
}
