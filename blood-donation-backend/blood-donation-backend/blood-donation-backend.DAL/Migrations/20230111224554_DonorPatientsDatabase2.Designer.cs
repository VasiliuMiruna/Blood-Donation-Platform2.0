﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using blood_donation_backend.Data;

#nullable disable

namespace blooddonationbackend.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20230111224554_DonorPatientsDatabase2")]
    partial class DonorPatientsDatabase2
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("blood_donation_backend.Entities.Donor", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("Age")
                        .HasColumnType("int");

                    b.Property<string>("BloodType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("Date")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DateModified")
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnType("datetime2");

                    b.Property<string>("FirstName")
                        .HasMaxLength(70)
                        .HasColumnType("nvarchar(70)");

                    b.Property<string>("Gender")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .HasMaxLength(70)
                        .HasColumnType("nvarchar(70)");

                    b.HasKey("Id");

                    b.ToTable("Donors");
                });

            modelBuilder.Entity("blood_donation_backend.Entities.Patient", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("Age")
                        .HasColumnType("int");

                    b.Property<string>("BloodType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid?>("CurrentDonorId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("Date")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DateModified")
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnType("datetime2");

                    b.Property<string>("FirstName")
                        .HasMaxLength(70)
                        .HasColumnType("nvarchar(70)");

                    b.Property<string>("Gender")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .HasMaxLength(70)
                        .HasColumnType("nvarchar(70)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("CurrentDonorId");

                    b.ToTable("Patients");
                });

            modelBuilder.Entity("blood_donation_backend.Entities.Patient", b =>
                {
                    b.HasOne("blood_donation_backend.Entities.Donor", "Donor")
                        .WithMany("Patients")
                        .HasForeignKey("CurrentDonorId");

                    b.Navigation("Donor");
                });

            modelBuilder.Entity("blood_donation_backend.Entities.Donor", b =>
                {
                    b.Navigation("Patients");
                });
#pragma warning restore 612, 618
        }
    }
}