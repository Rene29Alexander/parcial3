﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using WebAPI.Data;

namespace WebAPI.Migrations
{
    [DbContext(typeof(DatabaseContext))]
    [Migration("20211212221201_initial")]
    partial class initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .UseIdentityByDefaultColumns()
                .HasAnnotation("Relational:MaxIdentifierLength", 63)
                .HasAnnotation("ProductVersion", "5.0.0");

            modelBuilder.Entity("WebAPI.Buyer", b =>
                {
                    b.Property<int>("BuyerID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .UseIdentityByDefaultColumn();

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.Property<string>("Payment")
                        .HasColumnType("text");

                    b.Property<string>("part")
                        .HasColumnType("text");

                    b.HasKey("BuyerID");

                    b.ToTable("Buyers");
                });

            modelBuilder.Entity("WebAPI.ShoesShop", b =>
                {
                    b.Property<int>("ShoesID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .UseIdentityByDefaultColumn();

                    b.Property<string>("Brand")
                        .HasColumnType("text");

                    b.Property<int>("BuyerID")
                        .HasColumnType("integer");

                    b.Property<string>("Color")
                        .HasColumnType("text");

                    b.Property<decimal>("price")
                        .HasColumnType("numeric");

                    b.Property<int>("quantity")
                        .HasColumnType("integer");

                    b.HasKey("ShoesID");

                    b.HasIndex("BuyerID");

                    b.ToTable("ShoesShops");
                });

            modelBuilder.Entity("WebAPI.ShoesShop", b =>
                {
                    b.HasOne("WebAPI.Buyer", "Buyer")
                        .WithMany()
                        .HasForeignKey("BuyerID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Buyer");
                });
#pragma warning restore 612, 618
        }
    }
}
