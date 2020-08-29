﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ShoppingList.Database;

namespace ShoppingList.Database.Migrations
{
    [DbContext(typeof(LocalDbContext))]
    [Migration("20200826181740_UserInterface6")]
    partial class UserInterface6
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.7");

            modelBuilder.Entity("ShoppingList.Database.Model.ShoppingItem", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<byte[]>("ImageData")
                        .HasColumnType("BLOB");

                    b.Property<DateTime>("LastBought")
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .HasColumnType("TEXT");

                    b.Property<int>("State")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("ShoppingItem");
                });
#pragma warning restore 612, 618
        }
    }
}