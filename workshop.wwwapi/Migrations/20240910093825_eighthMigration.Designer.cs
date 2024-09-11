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
    [Migration("20240910093825_eighthMigration")]
    partial class eighthMigration
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
                    b.Property<int>("DoctorId")
                        .HasColumnType("integer")
                        .HasColumnName("doctorId");

                    b.Property<int>("PatientId")
                        .HasColumnType("integer")
                        .HasColumnName("patientId");

                    b.Property<DateTime>("Booking")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("booking");

                    b.Property<int>("Id")
                        .HasColumnType("integer")
                        .HasColumnName("id");

                    b.HasKey("DoctorId", "PatientId");

                    b.ToTable("appointments");

                    b.HasData(
                        new
                        {
                            DoctorId = 10,
                            PatientId = 1,
                            Booking = new DateTime(2025, 2, 5, 16, 20, 35, 123, DateTimeKind.Utc).AddTicks(703),
                            Id = 1
                        },
                        new
                        {
                            DoctorId = 1,
                            PatientId = 2,
                            Booking = new DateTime(2025, 6, 7, 15, 2, 54, 123, DateTimeKind.Utc).AddTicks(793),
                            Id = 2
                        },
                        new
                        {
                            DoctorId = 2,
                            PatientId = 3,
                            Booking = new DateTime(2024, 12, 11, 12, 0, 38, 123, DateTimeKind.Utc).AddTicks(800),
                            Id = 3
                        },
                        new
                        {
                            DoctorId = 7,
                            PatientId = 4,
                            Booking = new DateTime(2024, 12, 9, 11, 12, 34, 123, DateTimeKind.Utc).AddTicks(804),
                            Id = 4
                        },
                        new
                        {
                            DoctorId = 2,
                            PatientId = 5,
                            Booking = new DateTime(2024, 11, 1, 3, 15, 0, 123, DateTimeKind.Utc).AddTicks(807),
                            Id = 5
                        },
                        new
                        {
                            DoctorId = 7,
                            PatientId = 6,
                            Booking = new DateTime(2025, 3, 12, 23, 6, 33, 123, DateTimeKind.Utc).AddTicks(811),
                            Id = 6
                        },
                        new
                        {
                            DoctorId = 2,
                            PatientId = 7,
                            Booking = new DateTime(2025, 1, 27, 21, 41, 7, 123, DateTimeKind.Utc).AddTicks(814),
                            Id = 7
                        },
                        new
                        {
                            DoctorId = 7,
                            PatientId = 8,
                            Booking = new DateTime(2025, 2, 9, 10, 1, 12, 123, DateTimeKind.Utc).AddTicks(818),
                            Id = 8
                        },
                        new
                        {
                            DoctorId = 9,
                            PatientId = 9,
                            Booking = new DateTime(2024, 12, 23, 13, 17, 17, 123, DateTimeKind.Utc).AddTicks(820),
                            Id = 9
                        },
                        new
                        {
                            DoctorId = 3,
                            PatientId = 10,
                            Booking = new DateTime(2025, 7, 16, 19, 41, 28, 123, DateTimeKind.Utc).AddTicks(824),
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
                            FullName = "Arnold Winslow"
                        },
                        new
                        {
                            Id = 2,
                            FullName = "Elvis Mouse"
                        },
                        new
                        {
                            Id = 3,
                            FullName = "Mickey Andersson"
                        },
                        new
                        {
                            Id = 4,
                            FullName = "Adam Sandler"
                        },
                        new
                        {
                            Id = 5,
                            FullName = "Neo Obama"
                        },
                        new
                        {
                            Id = 6,
                            FullName = "Donald Andersson"
                        },
                        new
                        {
                            Id = 7,
                            FullName = "Barack Sandler"
                        },
                        new
                        {
                            Id = 8,
                            FullName = "Felix Sandler"
                        },
                        new
                        {
                            Id = 9,
                            FullName = "Neo Duck"
                        },
                        new
                        {
                            Id = 10,
                            FullName = "Elvis Mouse"
                        });
                });

            modelBuilder.Entity("workshop.wwwapi.Models.Medicine", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Instruction")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("instructions");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("name");

                    b.Property<int>("Quantity")
                        .HasColumnType("integer")
                        .HasColumnName("quantity");

                    b.HasKey("Id");

                    b.ToTable("medicines");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Instruction = "Swallow without anything added.",
                            Name = "Ultra Pills",
                            Quantity = 92
                        },
                        new
                        {
                            Id = 2,
                            Instruction = "Snort before tequila shot.",
                            Name = "Super Leaves",
                            Quantity = 18
                        },
                        new
                        {
                            Id = 3,
                            Instruction = "Swallow with water.",
                            Name = "Yummy Heroin",
                            Quantity = 94
                        },
                        new
                        {
                            Id = 4,
                            Instruction = "Hide in cabinet and let the placebo effect do it's job.",
                            Name = "Dangerous Xanax",
                            Quantity = 2
                        },
                        new
                        {
                            Id = 5,
                            Instruction = "Put in coworker's food.",
                            Name = "Dangerous Aspirin",
                            Quantity = 6
                        },
                        new
                        {
                            Id = 6,
                            Instruction = "Swallow with water.",
                            Name = "Stupid Pills",
                            Quantity = 12
                        },
                        new
                        {
                            Id = 7,
                            Instruction = "Disolve into drink of your choice.",
                            Name = "Ultra Mushrooms",
                            Quantity = 91
                        },
                        new
                        {
                            Id = 8,
                            Instruction = "Consume with any meal.",
                            Name = "Blazing Pills",
                            Quantity = 54
                        },
                        new
                        {
                            Id = 9,
                            Instruction = "Insert into rectum.",
                            Name = "Not Pills",
                            Quantity = 99
                        },
                        new
                        {
                            Id = 10,
                            Instruction = "Snort before tequila shot.",
                            Name = "Super Mushrooms",
                            Quantity = 98
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
                            FullName = "Oprah Andersson"
                        },
                        new
                        {
                            Id = 2,
                            FullName = "Felix Mathiasson"
                        },
                        new
                        {
                            Id = 3,
                            FullName = "Charles Sandler"
                        },
                        new
                        {
                            Id = 4,
                            FullName = "Donald Winfrey"
                        },
                        new
                        {
                            Id = 5,
                            FullName = "Arnold Lothbrok"
                        },
                        new
                        {
                            Id = 6,
                            FullName = "Kate Xavier"
                        },
                        new
                        {
                            Id = 7,
                            FullName = "Barack Mathiasson"
                        },
                        new
                        {
                            Id = 8,
                            FullName = "Arnold Mathiasson"
                        },
                        new
                        {
                            Id = 9,
                            FullName = "Charles Winslow"
                        },
                        new
                        {
                            Id = 10,
                            FullName = "Charles Xavier"
                        });
                });

            modelBuilder.Entity("workshop.wwwapi.Models.Prescription", b =>
                {
                    b.Property<int>("appointmentId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("appointmentId");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("appointmentId"));

                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.HasKey("appointmentId");

                    b.ToTable("prescriptions");

                    b.HasData(
                        new
                        {
                            appointmentId = 10,
                            Id = 1
                        },
                        new
                        {
                            appointmentId = 9,
                            Id = 2
                        },
                        new
                        {
                            appointmentId = 8,
                            Id = 3
                        },
                        new
                        {
                            appointmentId = 7,
                            Id = 4
                        },
                        new
                        {
                            appointmentId = 6,
                            Id = 5
                        },
                        new
                        {
                            appointmentId = 5,
                            Id = 6
                        },
                        new
                        {
                            appointmentId = 4,
                            Id = 7
                        },
                        new
                        {
                            appointmentId = 3,
                            Id = 8
                        },
                        new
                        {
                            appointmentId = 2,
                            Id = 9
                        },
                        new
                        {
                            appointmentId = 1,
                            Id = 10
                        });
                });

            modelBuilder.Entity("workshop.wwwapi.Models.PrescriptionMedicine", b =>
                {
                    b.Property<int>("PrescriptionId")
                        .HasColumnType("integer")
                        .HasColumnName("prescription_id");

                    b.Property<int>("MedicineId")
                        .HasColumnType("integer")
                        .HasColumnName("medicine_id");

                    b.HasKey("PrescriptionId", "MedicineId");

                    b.HasIndex("MedicineId");

                    b.ToTable("prescription_medicines");

                    b.HasData(
                        new
                        {
                            PrescriptionId = 7,
                            MedicineId = 1
                        },
                        new
                        {
                            PrescriptionId = 9,
                            MedicineId = 1
                        },
                        new
                        {
                            PrescriptionId = 5,
                            MedicineId = 1
                        },
                        new
                        {
                            PrescriptionId = 7,
                            MedicineId = 2
                        },
                        new
                        {
                            PrescriptionId = 6,
                            MedicineId = 2
                        },
                        new
                        {
                            PrescriptionId = 2,
                            MedicineId = 2
                        },
                        new
                        {
                            PrescriptionId = 1,
                            MedicineId = 3
                        },
                        new
                        {
                            PrescriptionId = 5,
                            MedicineId = 3
                        },
                        new
                        {
                            PrescriptionId = 3,
                            MedicineId = 3
                        },
                        new
                        {
                            PrescriptionId = 1,
                            MedicineId = 4
                        },
                        new
                        {
                            PrescriptionId = 2,
                            MedicineId = 4
                        },
                        new
                        {
                            PrescriptionId = 9,
                            MedicineId = 4
                        },
                        new
                        {
                            PrescriptionId = 6,
                            MedicineId = 5
                        },
                        new
                        {
                            PrescriptionId = 2,
                            MedicineId = 5
                        },
                        new
                        {
                            PrescriptionId = 3,
                            MedicineId = 5
                        },
                        new
                        {
                            PrescriptionId = 9,
                            MedicineId = 6
                        },
                        new
                        {
                            PrescriptionId = 7,
                            MedicineId = 6
                        },
                        new
                        {
                            PrescriptionId = 5,
                            MedicineId = 6
                        },
                        new
                        {
                            PrescriptionId = 10,
                            MedicineId = 7
                        },
                        new
                        {
                            PrescriptionId = 4,
                            MedicineId = 7
                        },
                        new
                        {
                            PrescriptionId = 6,
                            MedicineId = 7
                        },
                        new
                        {
                            PrescriptionId = 2,
                            MedicineId = 8
                        },
                        new
                        {
                            PrescriptionId = 4,
                            MedicineId = 8
                        },
                        new
                        {
                            PrescriptionId = 1,
                            MedicineId = 8
                        },
                        new
                        {
                            PrescriptionId = 3,
                            MedicineId = 9
                        },
                        new
                        {
                            PrescriptionId = 2,
                            MedicineId = 9
                        },
                        new
                        {
                            PrescriptionId = 9,
                            MedicineId = 9
                        },
                        new
                        {
                            PrescriptionId = 2,
                            MedicineId = 10
                        },
                        new
                        {
                            PrescriptionId = 5,
                            MedicineId = 10
                        },
                        new
                        {
                            PrescriptionId = 7,
                            MedicineId = 10
                        });
                });

            modelBuilder.Entity("workshop.wwwapi.Models.PrescriptionMedicine", b =>
                {
                    b.HasOne("workshop.wwwapi.Models.Medicine", "Medicine")
                        .WithMany("PrescriptionMedicines")
                        .HasForeignKey("MedicineId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("workshop.wwwapi.Models.Prescription", "Prescription")
                        .WithMany("PrescriptionMedicines")
                        .HasForeignKey("PrescriptionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Medicine");

                    b.Navigation("Prescription");
                });

            modelBuilder.Entity("workshop.wwwapi.Models.Medicine", b =>
                {
                    b.Navigation("PrescriptionMedicines");
                });

            modelBuilder.Entity("workshop.wwwapi.Models.Prescription", b =>
                {
                    b.Navigation("PrescriptionMedicines");
                });
#pragma warning restore 612, 618
        }
    }
}