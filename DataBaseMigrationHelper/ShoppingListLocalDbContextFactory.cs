using Microsoft.EntityFrameworkCore.Design;
using ShoppingList.Core;
using ShoppingList.Database;

namespace DatabaseMigrationHelper
{
    internal class ShoppingListLocalDbContextFactory : IDesignTimeDbContextFactory<LocalDbContext>
    {
        public LocalDbContext CreateDbContext(string[] args)
        {
            return new LocalDbContext(new PlatformSpecialFolder());
        }
    }
}
