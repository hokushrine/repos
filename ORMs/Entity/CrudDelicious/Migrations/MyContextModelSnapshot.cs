﻿// <auto-generated />
using System;
using CrudDelicious.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace CrudDelicious.Migrations
{
    [DbContext(typeof(MyContext))]
    partial class MyContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.8-servicing-32085")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("CrudDelicious.Models.Dish", b =>
                {
                    b.Property<int>("DishID")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("Calories");

                    b.Property<string>("Chef");

                    b.Property<DateTime>("CreatedAt");

                    b.Property<string>("Description");

                    b.Property<string>("Name");

                    b.Property<int>("Tastiness");

                    b.Property<DateTime>("UpdatedAt");

                    b.HasKey("DishID");

                    b.ToTable("Dishes");
                });
#pragma warning restore 612, 618
        }
    }
}
