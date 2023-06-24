﻿// <auto-generated />
using System;
using BeSpoked.Db;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace BeSpoked.Db.Migrations
{
    [DbContext(typeof(BeSpokedDbContext))]
    partial class BeSpokedDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "7.0.8");

            modelBuilder.Entity("BeSpoked.Customers.Entities.Customer", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("StartDate")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Customers", (string)null);
                });

            modelBuilder.Entity("BeSpoked.Products.Entities.Product", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<decimal>("CommissionPercentage")
                        .HasPrecision(1, 2)
                        .HasColumnType("TEXT");

                    b.Property<string>("Manufacturer")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<decimal>("PurchasePrice")
                        .HasPrecision(19, 2)
                        .HasColumnType("TEXT");

                    b.Property<int>("QuantityOnHand")
                        .HasColumnType("INTEGER");

                    b.Property<decimal>("SalePrice")
                        .HasPrecision(19, 2)
                        .HasColumnType("TEXT");

                    b.Property<int>("Style")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.ToTable("Products", (string)null);
                });

            modelBuilder.Entity("BeSpoked.Sales.Entities.Sale", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<decimal>("CommissionAmount")
                        .HasPrecision(19, 2)
                        .HasColumnType("TEXT");

                    b.Property<Guid>("CustomerId")
                        .HasColumnType("TEXT");

                    b.Property<Guid>("ProductId")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("SalesDate")
                        .HasColumnType("TEXT");

                    b.Property<Guid>("SalesPersonId")
                        .HasColumnType("TEXT");

                    b.Property<decimal>("SalesPrice")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex(new[] { "CustomerId" }, "IX_Sales_CustomerId");

                    b.HasIndex(new[] { "ProductId" }, "IX_Sales_ProductId");

                    b.HasIndex(new[] { "SalesPersonId" }, "IX_Sales_SalesPersonId");

                    b.ToTable("Sales", (string)null);
                });

            modelBuilder.Entity("BeSpoked.SalesTeam.Entities.SalesPerson", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Manager")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("StartDate")
                        .HasColumnType("TEXT");

                    b.Property<DateTime?>("TerminationDate")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("SalesTeam", (string)null);
                });

            modelBuilder.Entity("BeSpoked.Sales.Entities.Sale", b =>
                {
                    b.HasOne("BeSpoked.Customers.Entities.Customer", "Customer")
                        .WithMany("Sales")
                        .HasForeignKey("CustomerId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("BeSpoked.Products.Entities.Product", "Product")
                        .WithMany("Sales")
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("BeSpoked.SalesTeam.Entities.SalesPerson", "SalesPerson")
                        .WithMany("Sales")
                        .HasForeignKey("SalesPersonId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("Customer");

                    b.Navigation("Product");

                    b.Navigation("SalesPerson");
                });

            modelBuilder.Entity("BeSpoked.Customers.Entities.Customer", b =>
                {
                    b.Navigation("Sales");
                });

            modelBuilder.Entity("BeSpoked.Products.Entities.Product", b =>
                {
                    b.Navigation("Sales");
                });

            modelBuilder.Entity("BeSpoked.SalesTeam.Entities.SalesPerson", b =>
                {
                    b.Navigation("Sales");
                });
#pragma warning restore 612, 618
        }
    }
}
