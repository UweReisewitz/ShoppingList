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
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var dbPath = Path.Combine(iSpecialFolder.ApplicationData, "ShoppingList.db3");

            optionsBuilder.UseSqlite($"Filename={dbPath}");
        }
    }
}
