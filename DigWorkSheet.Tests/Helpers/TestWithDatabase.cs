using DigWorkSheet.WebApi.Database;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace DigWorkSheet.Tests.Helpers
{
    public abstract class TestWithDatabase : IAsyncLifetime
    {
        protected DigWorkSheetContext _dbContext;
        protected DatabaseFixture _databaseFixture;

        public virtual async Task InitializeAsync()
        {
            _databaseFixture = await DatabaseFixture.CreateAsync($"{GetType().Name}DB");
            _dbContext = _databaseFixture.dbContext;
        }

        public async Task DisposeAsync()
        {
            await _databaseFixture.CleanDatabaseAsync();
        }

    }
}
