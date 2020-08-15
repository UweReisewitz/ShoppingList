using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.CompilerServices;
using System.Text;
using Microsoft.EntityFrameworkCore;
using ShoppingList.Core;
using ShoppingList.Database.Model;
using Xamarin.Essentials;

[assembly: InternalsVisibleToAttribute("DataBaseMigrationHelper")]

namespace ShoppingList.Database
{
    internal class LocalDbContext : DbContext
    {
        public DbSet<ShoppingItem> ShoppingItem { get; set; }

        private readonly IPlatformSpecialFolder iSpecialFolder;

        public LocalDbContext(IPlatformSpecialFolder iSpecialFolder)
        {
            this.iSpecialFolder = iSpecialFolder;

            this.Database.Migrate();

            if (dbIsNew)
            {
                var item1 = new ShoppingItem()
                {
                    Name = "Test1",
                    State = ShoppingItemState.Open
                };
                var item2 = new ShoppingItem()
                {
                    Name = "Test2",
                    State = ShoppingItemState.Open
                };
                var item3 = new ShoppingItem()
                {
                    Name = "Test3",
                    State = ShoppingItemState.Bought
                };
                var item4 = new ShoppingItem()
                {
                    Name = "Test4",
                    State = ShoppingItemState.ShoppingComplete,
                    LastBought = DateTime.Now
                };
                ShoppingItem.Add(item1);
                ShoppingItem.Add(item2);
                ShoppingItem.Add(item3);
                ShoppingItem.Add(item4);
                SaveChanges();
            }
        }

        private bool dbIsNew;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var dbPath = Path.Combine(iSpecialFolder.ApplicationData, "ShoppingList.db3");

            dbIsNew = !File.Exists(dbPath);

            optionsBuilder.UseSqlite($"Filename={dbPath}");
        }
    }
}
