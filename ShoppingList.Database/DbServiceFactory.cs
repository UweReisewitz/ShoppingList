using ShoppingList.Core;

namespace ShoppingList.Database
{
    public class DbServiceFactory : IDbServiceFactory
    {
        private readonly IPlatformSpecialFolder platformSpecialFolder;

        public DbServiceFactory(IPlatformSpecialFolder platformSpecialFolder)
        {
            this.platformSpecialFolder = platformSpecialFolder;
        }

        public IDbService CreateNew()
        {
            return new DbService(platformSpecialFolder);
        }
    }
}
