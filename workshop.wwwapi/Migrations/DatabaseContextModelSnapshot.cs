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
                .HasAnnotation("ProductVersion", "8.0.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("MedicinePrescription", b =>
                {
                    b.Property<int>("MedicinesId")
                        .HasColumnType("integer");

                    b.Property<int>("PrescriptionsId")
                        .HasColumnType("integer");

                    b.HasKey("MedicinesId", "PrescriptionsId");

                    b.HasIndex("PrescriptionsId");

                    b.ToTable("MedicinePrescription");

                    b.HasData(
                        new
                        {
                            MedicinesId = 1,
                            PrescriptionsId = 1
                        },
                        new
                        {
                            MedicinesId = 2,
                            PrescriptionsId = 1
                        },
                        new
                        {
                            MedicinesId = 4,
                            PrescriptionsId = 1
                        },
                        new
                        {
                            MedicinesId = 3,
                            PrescriptionsId = 2
                        },
                        new
                        {
                            MedicinesId = 1,
                            PrescriptionsId = 2
                        },
                        new
                        {
                            MedicinesId = 2,
                            PrescriptionsId = 3
                        });
                });

            modelBuilder.Entity("workshop.wwwapi.Models.Appointment", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("Booking")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("booking");

                    b.Property<int>("DoctorId")
                        .HasColumnType("integer")
                        .HasColumnName("doctor_id");

                    b.Property<string>("Location")
                        .HasColumnType("text");

                    b.Property<int>("PatientId")
                        .HasColumnType("integer")
                        .HasColumnName("patient_id");

                    b.HasKey("Id");

                    b.HasAlternateKey("Booking", "PatientId", "DoctorId");

                    b.HasIndex("DoctorId");

                    b.HasIndex("PatientId");

                    b.ToTable("appointments");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Booking = new DateTime(2024, 2, 9, 10, 12, 47, 78, DateTimeKind.Utc).AddTicks(6629),
                            DoctorId = 1,
                            Location = "InPerson",
                            PatientId = 2
                        },
                        new
                        {
                            Id = 2,
                            Booking = new DateTime(2024, 2, 9, 10, 12, 47, 78, DateTimeKind.Utc).AddTicks(6636),
                            DoctorId = 2,
                            Location = "InPerson",
                            PatientId = 1
                        },
                        new
                        {
                            Id = 3,
                            Booking = new DateTime(2024, 2, 9, 10, 12, 47, 78, DateTimeKind.Utc).AddTicks(6637),
                            DoctorId = 2,
                            Location = "Online",
                            PatientId = 2
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
                            FullName = "Doctor Bob"
                        },
                        new
                        {
                            Id = 2,
                            FullName = "Doctor Lisa"
                        });
                });

            modelBuilder.Entity("workshop.wwwapi.Models.Medicine", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Note")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("Quantity")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.ToTable("Medicines");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Ibuprofen",
                            Note = "Against Pain, take twice",
                            Quantity = 5
                        },
                        new
                        {
                            Id = 2,
                            Name = "Melatonin",
                            Note = "For sleep, take 2 hour before bed",
                            Quantity = 100
                        },
                        new
                        {
                            Id = 3,
                            Name = "Treo",
                            Note = "For fever and pain, take every 4-6 hours",
                            Quantity = 50
                        },
                        new
                        {
                            Id = 4,
                            Name = "Pencillin",
                            Note = "Antibiotic for infection, take three times a day",
                            Quantity = 30
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
                        .HasColumnName("full_name");

                    b.HasKey("Id");

                    b.ToTable("patients");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            FullName = "Joe"
                        },
                        new
                        {
                            Id = 2,
                            FullName = "Jane"
                        });
                });

            modelBuilder.Entity("workshop.wwwapi.Models.Prescription", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int?>("AppointmentId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("AppointmentId")
                        .IsUnique();

                    b.ToTable("Prescriptions");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            AppointmentId = 1
                        },
                        new
                        {
                            Id = 2,
                            AppointmentId = 2
                        },
                        new
                        {
                            Id = 3,
                            AppointmentId = 3
                        });
                });

            modelBuilder.Entity("MedicinePrescription", b =>
                {
                    b.HasOne("workshop.wwwapi.Models.Medicine", null)
                        .WithMany()
                        .HasForeignKey("MedicinesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("workshop.wwwapi.Models.Prescription", null)
                        .WithMany()
                        .HasForeignKey("PrescriptionsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
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

            modelBuilder.Entity("workshop.wwwapi.Models.Prescription", b =>
                {
                    b.HasOne("workshop.wwwapi.Models.Appointment", "Appointment")
                        .WithOne("Prescription")
                        .HasForeignKey("workshop.wwwapi.Models.Prescription", "AppointmentId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.Navigation("Appointment");
                });

            modelBuilder.Entity("workshop.wwwapi.Models.Appointment", b =>
                {
                    b.Navigation("Prescription");
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
