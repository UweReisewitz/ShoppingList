using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ShoppingList.Core;

namespace ShoppingList.Database
{
    public class DbService : IDbService, IDisposable
    {
        private readonly IPlatformSpecialFolder platformSpecialFolder;
        private LocalDbContext localContext;

        public DbService(IPlatformSpecialFolder platformSpecialFolder)
        {
            this.platformSpecialFolder = platformSpecialFolder;
        }

        public void CreateOrUpdateDatabase()
        {
            using (var dbContext = new LocalDbContext(platformSpecialFolder))
            { }
        }

        public async Task<List<IShoppingItem>> GetShoppingListItemsAsync()
        {
            CreateContext();

            return await localContext.ShoppingItem
                .Cast<IShoppingItem>()
                .ToListAsync();
        }


        private void CreateContext()
        {
            if (localContext == null)
            {
                localContext = new LocalDbContext(platformSpecialFolder);
            }
        }


        private bool isDisposed;

        protected virtual void Dispose(bool disposing)
        {
            if (!isDisposed)
            {
                if (disposing)
                {
                    if (localContext != null)
                    {
                        localContext.Dispose();
                        localContext = null;
                    }
                }

                // TODO: free unmanaged resources (unmanaged objects) and override finalizer
                // TODO: set large fields to null
                isDisposed = true;
            }
        }

        public void Dispose()
        {
            // Do not change this code. Put cleanup code in 'Dispose(bool disposing)' method
            Dispose(disposing: true);
            GC.SuppressFinalize(this);
        }
    }
}
