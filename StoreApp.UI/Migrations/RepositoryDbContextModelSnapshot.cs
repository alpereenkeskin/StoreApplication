﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using StoreApp.Repositories;

#nullable disable

namespace StoreApp.UI.Migrations
{
    [DbContext(typeof(RepositoryDbContext))]
    partial class RepositoryDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "6.0.0");

            modelBuilder.Entity("StoreApp.Entites.Category", b =>
                {
                    b.Property<int>("CategoryId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("CategoryName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("CategoryId");

                    b.ToTable("Categories");

                    b.HasData(
                        new
                        {
                            CategoryId = 1,
                            CategoryName = "Deneme Kategori"
                        },
                        new
                        {
                            CategoryId = 2,
                            CategoryName = "Deneme Kategori 2"
                        },
                        new
                        {
                            CategoryId = 3,
                            CategoryName = "Deneme Kategori 3"
                        },
                        new
                        {
                            CategoryId = 4,
                            CategoryName = "Deneme Kategori 4"
                        });
                });

            modelBuilder.Entity("StoreApp.Entites.Product", b =>
                {
                    b.Property<int>("ProductId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("CategoryId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("ImagePath")
                        .HasColumnType("TEXT");

                    b.Property<decimal>("Price")
                        .HasColumnType("TEXT");

                    b.Property<string>("ProductName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Summary")
                        .HasColumnType("TEXT");

                    b.HasKey("ProductId");

                    b.HasIndex("CategoryId");

                    b.ToTable("Products");

                    b.HasData(
                        new
                        {
                            ProductId = 4,
                            CategoryId = 1,
                            ImagePath = "/images/1.jpg",
                            Price = 0m,
                            ProductName = "deneme2"
                        },
                        new
                        {
                            ProductId = 5,
                            CategoryId = 2,
                            ImagePath = "/images/2.jpg",
                            Price = 0m,
                            ProductName = "deneme3"
                        },
                        new
                        {
                            ProductId = 6,
                            CategoryId = 3,
                            ImagePath = "/images/3.jpg",
                            Price = 0m,
                            ProductName = "deneme4"
                        },
                        new
                        {
                            ProductId = 7,
                            CategoryId = 1,
                            ImagePath = "/images/4.jpg",
                            Price = 0m,
                            ProductName = "deneme5"
                        },
                        new
                        {
                            ProductId = 8,
                            CategoryId = 2,
                            ImagePath = "/images/5.jpg",
                            Price = 0m,
                            ProductName = "deneme6"
                        });
                });

            modelBuilder.Entity("StoreApp.Entites.Product", b =>
                {
                    b.HasOne("StoreApp.Entites.Category", "Category")
                        .WithMany("Products")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Category");
                });

            modelBuilder.Entity("StoreApp.Entites.Category", b =>
                {
                    b.Navigation("Products");
                });
#pragma warning restore 612, 618
        }
    }
}
