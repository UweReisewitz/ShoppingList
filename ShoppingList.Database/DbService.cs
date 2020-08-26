using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ShoppingList.Core;
using ShoppingList.Database.Model;

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

        public async Task CreateOrMigrateDatabaseAsync()
        {
            using (var dbContext = new LocalDbContext(platformSpecialFolder))
            {
                await dbContext.CreateOrMigrateDatabaseAsync();
            }
        }

        public async Task SaveChangesAsync()
        {
            await localContext!.SaveChangesAsync();
        }

        public void SaveChanges()
        {
            localContext!.SaveChanges();
        }

        public async Task<ObservableCollection<ShoppingItem>> GetShoppingListItemsAsync()
        {
            CreateContext();

            var list = await localContext.ShoppingItem
                .ToListAsync();

            return new ObservableCollection<ShoppingItem>(list);
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

        public void AddShoppingItem(ShoppingItem item)
        {
            localContext.Add(item);
        }
    }
}
