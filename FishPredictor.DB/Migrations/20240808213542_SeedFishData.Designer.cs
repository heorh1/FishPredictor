﻿// <auto-generated />
using FishPredictor.DB;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace FishPredictor.DB.Migrations
{
    [DbContext(typeof(FishContext))]
    [Migration("20240808213542_SeedFishData")]
    partial class SeedFishData
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.7")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("FishPredictor.DB.Fish", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("PressureMax")
                        .HasColumnType("float");

                    b.Property<double>("PressureMin")
                        .HasColumnType("float");

                    b.Property<double>("TemperatureMax")
                        .HasColumnType("float");

                    b.Property<double>("TemperatureMin")
                        .HasColumnType("float");

                    b.HasKey("Id");

                    b.ToTable("Fishes");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Bream",
                            PressureMax = 800.0,
                            PressureMin = 700.0,
                            TemperatureMax = 30.0,
                            TemperatureMin = -25.0
                        },
                        new
                        {
                            Id = 2,
                            Name = "Carp",
                            PressureMax = 800.0,
                            PressureMin = 750.0,
                            TemperatureMax = 30.0,
                            TemperatureMin = 0.0
                        },
                        new
                        {
                            Id = 3,
                            Name = "Roach",
                            PressureMax = 800.0,
                            PressureMin = 720.0,
                            TemperatureMax = 30.0,
                            TemperatureMin = -20.0
                        },
                        new
                        {
                            Id = 4,
                            Name = "Perch",
                            PressureMax = 800.0,
                            PressureMin = 760.0,
                            TemperatureMax = 30.0,
                            TemperatureMin = -20.0
                        },
                        new
                        {
                            Id = 5,
                            Name = "Catfish",
                            PressureMax = 780.0,
                            PressureMin = 750.0,
                            TemperatureMax = 30.0,
                            TemperatureMin = 15.0
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
