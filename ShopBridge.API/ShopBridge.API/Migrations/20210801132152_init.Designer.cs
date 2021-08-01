﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ShopBridge.API.Data;

namespace ShopBridge.API.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20210801132152_init")]
    partial class init
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.8")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("ShopBridge.API.Model.Item", b =>
                {
                    b.Property<Guid>("item_id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime?>("created_on")
                        .HasColumnType("datetime2");

                    b.Property<string>("hsn_code")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("is_active")
                        .HasColumnType("bit");

                    b.Property<string>("item_category")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("item_code")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("item_desc")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("modified_on")
                        .HasColumnType("datetime2");

                    b.Property<float>("sales_price")
                        .HasColumnType("real");

                    b.Property<string>("unit_of_measurement")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("item_id");

                    b.ToTable("Items");
                });
#pragma warning restore 612, 618
        }
    }
}