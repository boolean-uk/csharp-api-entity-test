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
    [Migration("20240208100635_firstMigrate")]
    partial class firstMigrate
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
                        .HasColumnOrder(2);

                    b.Property<int>("DoctorId")
                        .HasColumnType("integer")
                        .HasColumnOrder(1);

                    b.Property<DateTime>("Booking")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("bookingDate");

                    b.HasKey("PatientId", "DoctorId");

                    b.HasIndex("DoctorId");

                    b.ToTable("appointments");

                    b.HasData(
                        new
                        {
                            PatientId = 1,
                            DoctorId = 1,
                            Booking = new DateTime(2024, 2, 8, 10, 6, 34, 886, DateTimeKind.Utc).AddTicks(6702)
                        },
                        new
                        {
                            PatientId = 2,
                            DoctorId = 1,
                            Booking = new DateTime(2024, 2, 8, 10, 6, 34, 886, DateTimeKind.Utc).AddTicks(6716)
                        },
                        new
                        {
                            PatientId = 2,
                            DoctorId = 2,
                            Booking = new DateTime(2024, 2, 8, 10, 6, 34, 886, DateTimeKind.Utc).AddTicks(6725)
                        },
                        new
                        {
                            PatientId = 1,
                            DoctorId = 2,
                            Booking = new DateTime(2024, 2, 8, 10, 6, 34, 886, DateTimeKind.Utc).AddTicks(6734)
                        });
                });

            modelBuilder.Entity("workshop.wwwapi.Models.Doctor", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

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
                            FullName = "Do Little"
                        },
                        new
                        {
                            Id = 2,
                            FullName = "Manhatten"
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
                        .HasColumnType("text")
                        .HasColumnName("name");

                    b.HasKey("Id");

                    b.ToTable("medicine");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Aduvanz"
                        },
                        new
                        {
                            Id = 2,
                            Name = "M&M"
                        });
                });

            modelBuilder.Entity("workshop.wwwapi.Models.Patient", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

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
                            FullName = "Donald Trump"
                        },
                        new
                        {
                            Id = 2,
                            FullName = "Homer Simpson"
                        });
                });

            modelBuilder.Entity("workshop.wwwapi.Models.Prescription", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("DoctorId")
                        .HasColumnType("integer");

                    b.Property<int>("PatientId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("DoctorId");

                    b.HasIndex("PatientId");

                    b.ToTable("prescription");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            DoctorId = 1,
                            PatientId = 1
                        },
                        new
                        {
                            Id = 2,
                            DoctorId = 2,
                            PatientId = 2
                        },
                        new
                        {
                            Id = 3,
                            DoctorId = 2,
                            PatientId = 1
                        });
                });

            modelBuilder.Entity("workshop.wwwapi.Models.PrescriptionMedicine", b =>
                {
                    b.Property<int>("PrescriptionId")
                        .HasColumnType("integer")
                        .HasColumnName("prescriptionId");

                    b.Property<int>("MedicineId")
                        .HasColumnType("integer")
                        .HasColumnName("medicineId");

                    b.Property<int>("Id")
                        .HasColumnType("integer");

                    b.Property<string>("Instruction")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("instruction");

                    b.Property<int>("Quantity")
                        .HasColumnType("integer")
                        .HasColumnName("quantity");

                    b.HasKey("PrescriptionId", "MedicineId");

                    b.HasIndex("MedicineId");

                    b.ToTable("PrescriptionMedicine");

                    b.HasData(
                        new
                        {
                            PrescriptionId = 1,
                            MedicineId = 1,
                            Id = 1,
                            Instruction = "Take each morning",
                            Quantity = 100
                        },
                        new
                        {
                            PrescriptionId = 2,
                            MedicineId = 1,
                            Id = 2,
                            Instruction = "Take each morning",
                            Quantity = 20
                        },
                        new
                        {
                            PrescriptionId = 1,
                            MedicineId = 2,
                            Id = 3,
                            Instruction = "Take each morning",
                            Quantity = 50
                        });
                });

            modelBuilder.Entity("workshop.wwwapi.Models.Appointment", b =>
                {
                    b.HasOne("workshop.wwwapi.Models.Doctor", null)
                        .WithMany("Appointments")
                        .HasForeignKey("DoctorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("workshop.wwwapi.Models.Patient", null)
                        .WithMany("Appointments")
                        .HasForeignKey("PatientId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("workshop.wwwapi.Models.Prescription", b =>
                {
                    b.HasOne("workshop.wwwapi.Models.Doctor", "Doctor")
                        .WithMany("Prescriptions")
                        .HasForeignKey("DoctorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("workshop.wwwapi.Models.Patient", "Patient")
                        .WithMany("Prescriptions")
                        .HasForeignKey("PatientId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Doctor");

                    b.Navigation("Patient");
                });

            modelBuilder.Entity("workshop.wwwapi.Models.PrescriptionMedicine", b =>
                {
                    b.HasOne("workshop.wwwapi.Models.Medicine", "Medicine")
                        .WithMany()
                        .HasForeignKey("MedicineId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("workshop.wwwapi.Models.Prescription", "Prescription")
                        .WithMany()
                        .HasForeignKey("PrescriptionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Medicine");

                    b.Navigation("Prescription");
                });

            modelBuilder.Entity("workshop.wwwapi.Models.Doctor", b =>
                {
                    b.Navigation("Appointments");

                    b.Navigation("Prescriptions");
                });

            modelBuilder.Entity("workshop.wwwapi.Models.Patient", b =>
                {
                    b.Navigation("Appointments");

                    b.Navigation("Prescriptions");
                });
#pragma warning restore 612, 618
        }
    }
}