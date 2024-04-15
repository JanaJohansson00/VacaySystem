﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using VacaySystem.Data;

#nullable disable

namespace VacaySystem.Migrations
{
    [DbContext(typeof(VacaySystemDbContext))]
    partial class VacaySystemDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("VacaySystem.Models.Employee", b =>
                {
                    b.Property<int>("EmployeeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("EmployeeId"));

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("EmployeeId");

                    b.ToTable("Employees");

                    b.HasData(
                        new
                        {
                            EmployeeId = 8,
                            FirstName = "Nour",
                            LastName = "Wilson"
                        },
                        new
                        {
                            EmployeeId = 9,
                            FirstName = "Liza",
                            LastName = "Folson"
                        });
                });

            modelBuilder.Entity("VacaySystem.Models.VacayApplication", b =>
                {
                    b.Property<int>("VacayApplicationId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("VacayApplicationId"));

                    b.Property<DateTime>("ApplicationDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("EndDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("FkEmployeeId")
                        .HasColumnType("int");

                    b.Property<DateTime>("StartDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("Type")
                        .HasColumnType("int");

                    b.HasKey("VacayApplicationId");

                    b.HasIndex("FkEmployeeId");

                    b.ToTable("vacayApplications");

                    b.HasData(
                        new
                        {
                            VacayApplicationId = 3,
                            ApplicationDate = new DateTime(2024, 4, 10, 18, 51, 47, 71, DateTimeKind.Local).AddTicks(9470),
                            EndDate = new DateTime(24, 8, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            FkEmployeeId = 3,
                            StartDate = new DateTime(24, 7, 15, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Type = 0
                        },
                        new
                        {
                            VacayApplicationId = 4,
                            ApplicationDate = new DateTime(2024, 4, 10, 18, 51, 47, 71, DateTimeKind.Local).AddTicks(9546),
                            EndDate = new DateTime(24, 6, 20, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            FkEmployeeId = 2,
                            StartDate = new DateTime(24, 6, 15, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Type = 0
                        });
                });

            modelBuilder.Entity("VacaySystem.Models.VacayApplication", b =>
                {
                    b.HasOne("VacaySystem.Models.Employee", "Employee")
                        .WithMany("VacayApplications")
                        .HasForeignKey("FkEmployeeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Employee");
                });

            modelBuilder.Entity("VacaySystem.Models.Employee", b =>
                {
                    b.Navigation("VacayApplications");
                });
#pragma warning restore 612, 618
        }
    }
}
