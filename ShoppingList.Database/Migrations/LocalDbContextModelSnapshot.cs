﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ShoppingList.Database;

namespace ShoppingList.Database.Migrations
{
    [DbContext(typeof(LocalDbContext))]
    partial class LocalDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.7");

            modelBuilder.Entity("ShoppingList.Database.Model.ShoppingItem", b =>
                {
                    b.Property<string>("Name")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("LastBought")
                        .HasColumnType("TEXT");

                    b.Property<int>("State")
                        .HasColumnType("int");

                    b.HasKey("Name");

                    b.ToTable("ShoppingItem");
                });
#pragma warning restore 612, 618
        }
    }
}