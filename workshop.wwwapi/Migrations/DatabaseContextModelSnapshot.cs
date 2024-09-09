﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using workshop.wwwapi.Data;

#nullable disable

namespace workshop.wwwapi.Migrations
{
    [DbContext(typeof(DatabaseContext))]
    partial class DatabaseContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.6")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("workshop.wwwapi.Models.Appointment", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("Booking")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("bookings");

                    b.Property<int>("DoctorId")
                        .HasColumnType("integer")
                        .HasColumnName("doctor_id");

                    b.Property<int>("PatientId")
                        .HasColumnType("integer")
                        .HasColumnName("patient_id");

                    b.HasKey("Id");

                    b.HasIndex("DoctorId");

                    b.HasIndex("PatientId");

                    b.ToTable("appointments");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Booking = new DateTime(2024, 6, 13, 8, 53, 23, 699, DateTimeKind.Utc).AddTicks(2871),
                            DoctorId = 1,
                            PatientId = 1
                        },
                        new
                        {
                            Id = 2,
                            Booking = new DateTime(2024, 6, 13, 8, 53, 23, 699, DateTimeKind.Utc).AddTicks(2876),
                            DoctorId = 2,
                            PatientId = 2
                        },
                        new
                        {
                            Id = 3,
                            Booking = new DateTime(2024, 6, 13, 8, 53, 23, 699, DateTimeKind.Utc).AddTicks(2877),
                            DoctorId = 3,
                            PatientId = 3
                        },
                        new
                        {
                            Id = 4,
                            Booking = new DateTime(2024, 6, 13, 8, 53, 23, 699, DateTimeKind.Utc).AddTicks(2878),
                            DoctorId = 4,
                            PatientId = 4
                        },
                        new
                        {
                            Id = 5,
                            Booking = new DateTime(2024, 6, 13, 8, 53, 23, 699, DateTimeKind.Utc).AddTicks(2880),
                            DoctorId = 1,
                            PatientId = 4
                        },
                        new
                        {
                            Id = 6,
                            Booking = new DateTime(2024, 6, 13, 8, 53, 23, 699, DateTimeKind.Utc).AddTicks(2881),
                            DoctorId = 2,
                            PatientId = 3
                        },
                        new
                        {
                            Id = 7,
                            Booking = new DateTime(2024, 6, 13, 8, 53, 23, 699, DateTimeKind.Utc).AddTicks(2882),
                            DoctorId = 3,
                            PatientId = 2
                        },
                        new
                        {
                            Id = 8,
                            Booking = new DateTime(2024, 6, 13, 8, 53, 23, 699, DateTimeKind.Utc).AddTicks(2883),
                            DoctorId = 4,
                            PatientId = 1
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
                        .HasColumnName("full_name");

                    b.HasKey("Id");

                    b.ToTable("doctors");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            FullName = "John Doe"
                        },
                        new
                        {
                            Id = 2,
                            FullName = "Jane Doe"
                        },
                        new
                        {
                            Id = 3,
                            FullName = "John Smith"
                        },
                        new
                        {
                            Id = 4,
                            FullName = "Jane Smith"
                        });
                });

            modelBuilder.Entity("workshop.wwwapi.Models.Patient", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("email");

                    b.Property<string>("FullName")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("full_name");

                    b.Property<string>("Gender")
                        .HasColumnType("text")
                        .HasColumnName("gender");

                    b.HasKey("Id");

                    b.ToTable("patients");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Email = "annadrijver.nl",
                            FullName = "Anna Drijver",
                            Gender = "A"
                        },
                        new
                        {
                            Id = 2,
                            Email = "tomcruise.nl",
                            FullName = "Tom Cruise",
                            Gender = "A"
                        },
                        new
                        {
                            Id = 3,
                            Email = "georginaverbaan.nl",
                            FullName = "Gerogina Verbaan",
                            Gender = "A"
                        },
                        new
                        {
                            Id = 4,
                            Email = "daanschuurmans.nl",
                            FullName = "Daan Schuurmans",
                            Gender = "A"
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
