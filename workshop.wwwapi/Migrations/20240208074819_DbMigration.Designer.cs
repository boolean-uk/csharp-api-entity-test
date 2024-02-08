﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using workshop.wwwapi.Data;

#nullable disable

namespace workshop.wwwapi.Migrations
{
    [DbContext(typeof(DatabaseContext))]
    [Migration("20240208074819_DbMigration")]
    partial class DbMigration
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("workshop.wwwapi.Models.Appointment", b =>
                {
                    b.Property<DateTime>("Booking")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("booking");

                    b.Property<int>("PatientId")
                        .HasColumnType("integer")
                        .HasColumnName("patient_id");

                    b.Property<int>("DoctorId")
                        .HasColumnType("integer")
                        .HasColumnName("doctor_id");

                    b.HasKey("Booking", "PatientId", "DoctorId");

                    b.HasIndex("DoctorId");

                    b.HasIndex("PatientId");

                    b.ToTable("appointments");

                    b.HasData(
                        new
                        {
                            Booking = new DateTime(2024, 2, 8, 7, 48, 19, 502, DateTimeKind.Utc).AddTicks(8313),
                            PatientId = 1,
                            DoctorId = 1
                        },
                        new
                        {
                            Booking = new DateTime(2024, 2, 8, 7, 48, 19, 502, DateTimeKind.Utc).AddTicks(8313),
                            PatientId = 2,
                            DoctorId = 1
                        },
                        new
                        {
                            Booking = new DateTime(2024, 2, 8, 8, 48, 19, 502, DateTimeKind.Utc).AddTicks(8313),
                            PatientId = 1,
                            DoctorId = 3
                        },
                        new
                        {
                            Booking = new DateTime(2024, 2, 8, 9, 18, 19, 502, DateTimeKind.Utc).AddTicks(8313),
                            PatientId = 2,
                            DoctorId = 1
                        },
                        new
                        {
                            Booking = new DateTime(2024, 2, 8, 9, 48, 19, 502, DateTimeKind.Utc).AddTicks(8313),
                            PatientId = 1,
                            DoctorId = 2
                        },
                        new
                        {
                            Booking = new DateTime(2024, 2, 8, 10, 18, 19, 502, DateTimeKind.Utc).AddTicks(8313),
                            PatientId = 3,
                            DoctorId = 3
                        },
                        new
                        {
                            Booking = new DateTime(2024, 2, 8, 10, 48, 19, 502, DateTimeKind.Utc).AddTicks(8313),
                            PatientId = 2,
                            DoctorId = 2
                        },
                        new
                        {
                            Booking = new DateTime(2024, 2, 8, 11, 18, 19, 502, DateTimeKind.Utc).AddTicks(8313),
                            PatientId = 3,
                            DoctorId = 2
                        });
                });

            modelBuilder.Entity("workshop.wwwapi.Models.Doctor", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("FullName")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("name");

                    b.HasKey("Id");

                    b.ToTable("doctors");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            FullName = "Doctor Phil"
                        },
                        new
                        {
                            Id = 2,
                            FullName = "Doctor Jim"
                        },
                        new
                        {
                            Id = 3,
                            FullName = "Doctor R2D2"
                        });
                });

            modelBuilder.Entity("workshop.wwwapi.Models.Patient", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("FullName")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("name");

                    b.HasKey("Id");

                    b.ToTable("patients");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            FullName = "Nigel"
                        },
                        new
                        {
                            Id = 2,
                            FullName = "AJ"
                        },
                        new
                        {
                            Id = 3,
                            FullName = "Kevin"
                        });
                });

            modelBuilder.Entity("workshop.wwwapi.Models.Appointment", b =>
                {
                    b.HasOne("workshop.wwwapi.Models.Doctor", "Doctor")
                        .WithMany("Appointments")
                        .HasForeignKey("DoctorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("workshop.wwwapi.Models.Patient", "Patient")
                        .WithMany("Appointments")
                        .HasForeignKey("PatientId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Doctor");

                    b.Navigation("Patient");
                });

            modelBuilder.Entity("workshop.wwwapi.Models.Doctor", b =>
                {
                    b.Navigation("Appointments");
                });

            modelBuilder.Entity("workshop.wwwapi.Models.Patient", b =>
                {
                    b.Navigation("Appointments");
                });
#pragma warning restore 612, 618
        }
    }
}
