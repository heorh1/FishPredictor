﻿// <auto-generated />
using FishPredictor.DB;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace FishPredictor.DB.Migrations
{
    [DbContext(typeof(FishContext))]
    partial class FishContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
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
                            PressureMax = 1010.0,
                            PressureMin = 1005.0,
                            TemperatureMax = 30.0,
                            TemperatureMin = -25.0
                        },
                        new
                        {
                            Id = 2,
                            Name = "Carp",
                            PressureMax = 1007.0,
                            PressureMin = 1003.0,
                            TemperatureMax = 30.0,
                            TemperatureMin = 0.0
                        },
                        new
                        {
                            Id = 3,
                            Name = "Roach",
                            PressureMax = 1015.0,
                            PressureMin = 1001.0,
                            TemperatureMax = 30.0,
                            TemperatureMin = -20.0
                        },
                        new
                        {
                            Id = 4,
                            Name = "Perch",
                            PressureMax = 1010.0,
                            PressureMin = 1007.0,
                            TemperatureMax = 30.0,
                            TemperatureMin = -20.0
                        },
                        new
                        {
                            Id = 5,
                            Name = "Catfish",
                            PressureMax = 1014.0,
                            PressureMin = 1000.0,
                            TemperatureMax = 30.0,
                            TemperatureMin = 15.0
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
