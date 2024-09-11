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
    [Migration("20240906140419_secondMigration")]
    partial class secondMigration
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
                    b.Property<int>("PatientId")
                        .HasColumnType("integer")
                        .HasColumnName("patientId");

                    b.Property<int>("DoctorId")
                        .HasColumnType("integer")
                        .HasColumnName("doctorId");

                    b.Property<DateTime>("Booking")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("booking");

                    b.Property<int>("Id")
                        .HasColumnType("integer")
                        .HasColumnName("id");

                    b.HasKey("PatientId", "DoctorId", "Booking")
                        .HasName("PKAppointmentDocPatientBooking");

                    b.ToTable("appointments");

                    b.HasData(
                        new
                        {
                            PatientId = 1,
                            DoctorId = 5,
                            Booking = new DateTime(2025, 7, 13, 19, 48, 28, 614, DateTimeKind.Local).AddTicks(8668),
                            Id = 1
                        },
                        new
                        {
                            PatientId = 2,
                            DoctorId = 7,
                            Booking = new DateTime(2024, 11, 6, 13, 44, 46, 614, DateTimeKind.Local).AddTicks(8707),
                            Id = 2
                        },
                        new
                        {
                            PatientId = 3,
                            DoctorId = 7,
                            Booking = new DateTime(2025, 5, 6, 14, 37, 53, 614, DateTimeKind.Local).AddTicks(8710),
                            Id = 3
                        },
                        new
                        {
                            PatientId = 4,
                            DoctorId = 9,
                            Booking = new DateTime(2024, 9, 23, 4, 8, 25, 614, DateTimeKind.Local).AddTicks(8713),
                            Id = 4
                        },
                        new
                        {
                            PatientId = 5,
                            DoctorId = 10,
                            Booking = new DateTime(2025, 2, 22, 21, 8, 22, 614, DateTimeKind.Local).AddTicks(8715),
                            Id = 5
                        },
                        new
                        {
                            PatientId = 6,
                            DoctorId = 4,
                            Booking = new DateTime(2025, 6, 23, 20, 31, 43, 614, DateTimeKind.Local).AddTicks(8717),
                            Id = 6
                        },
                        new
                        {
                            PatientId = 7,
                            DoctorId = 4,
                            Booking = new DateTime(2024, 12, 1, 6, 36, 8, 614, DateTimeKind.Local).AddTicks(8719),
                            Id = 7
                        },
                        new
                        {
                            PatientId = 8,
                            DoctorId = 9,
                            Booking = new DateTime(2025, 7, 27, 8, 36, 10, 614, DateTimeKind.Local).AddTicks(8721),
                            Id = 8
                        },
                        new
                        {
                            PatientId = 9,
                            DoctorId = 4,
                            Booking = new DateTime(2024, 12, 16, 5, 58, 41, 614, DateTimeKind.Local).AddTicks(8723),
                            Id = 9
                        },
                        new
                        {
                            PatientId = 10,
                            DoctorId = 4,
                            Booking = new DateTime(2025, 8, 17, 6, 46, 18, 614, DateTimeKind.Local).AddTicks(8726),
                            Id = 10
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
                        .HasColumnName("fullName");

                    b.HasKey("Id");

                    b.ToTable("doctors");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            FullName = "NeoWinfrey"
                        },
                        new
                        {
                            Id = 2,
                            FullName = "FelixSchwarzenegger"
                        },
                        new
                        {
                            Id = 3,
                            FullName = "MickeyWinslow"
                        },
                        new
                        {
                            Id = 4,
                            FullName = "ArnoldMouse"
                        },
                        new
                        {
                            Id = 5,
                            FullName = "ElvisObama"
                        },
                        new
                        {
                            Id = 6,
                            FullName = "FelixMathiasson"
                        },
                        new
                        {
                            Id = 7,
                            FullName = "MickeyPresley"
                        },
                        new
                        {
                            Id = 8,
                            FullName = "ArnoldWinslow"
                        },
                        new
                        {
                            Id = 9,
                            FullName = "DonaldSchwarzenegger"
                        },
                        new
                        {
                            Id = 10,
                            FullName = "OprahPresley"
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
                        .HasColumnName("fullName");

                    b.HasKey("Id");

                    b.ToTable("patients");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            FullName = "AdamPresley"
                        },
                        new
                        {
                            Id = 2,
                            FullName = "ArnoldLothbrok"
                        },
                        new
                        {
                            Id = 3,
                            FullName = "OprahDuck"
                        },
                        new
                        {
                            Id = 4,
                            FullName = "DonaldDuck"
                        },
                        new
                        {
                            Id = 5,
                            FullName = "DonaldPresley"
                        },
                        new
                        {
                            Id = 6,
                            FullName = "NeoXavier"
                        },
                        new
                        {
                            Id = 7,
                            FullName = "ArnoldSchwarzenegger"
                        },
                        new
                        {
                            Id = 8,
                            FullName = "KateSchwarzenegger"
                        },
                        new
                        {
                            Id = 9,
                            FullName = "AdamSchwarzenegger"
                        },
                        new
                        {
                            Id = 10,
                            FullName = "ArnoldDuck"
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
