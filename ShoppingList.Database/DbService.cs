using System;
using ShoppingList.Core;

namespace ShoppingList.Database
{
    public class DbService : IDbService
    {
        private readonly IPlatformSpecialFolder platformSpecialFolder;

        public DbService(IPlatformSpecialFolder platformSpecialFolder)
        {
            this.platformSpecialFolder = platformSpecialFolder;
        }

        public void CreateOrUpdateDatabase()
        {
            using (var dbContext = new LocalDbContext(platformSpecialFolder))
            {

            }
        }
    }
}
