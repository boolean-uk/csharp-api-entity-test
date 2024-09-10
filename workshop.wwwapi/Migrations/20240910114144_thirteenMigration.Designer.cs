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
    [Migration("20240910114144_thirteenMigration")]
    partial class thirteenMigration
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

                    b.Property<int?>("PrescriptionId")
                        .HasColumnType("integer")
                        .HasColumnName("prescription_id");

                    b.Property<DateTime>("Booking")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("booking");

                    b.Property<int>("Id")
                        .HasColumnType("integer")
                        .HasColumnName("id");

                    b.Property<int?>("type")
                        .HasColumnType("integer")
                        .HasColumnName("AppointmentType");

                    b.HasKey("DoctorId", "PatientId", "PrescriptionId");

                    b.ToTable("appointments");

                    b.HasData(
                        new
                        {
                            DoctorId = 2,
                            PatientId = 1,
                            PrescriptionId = 1,
                            Booking = new DateTime(2025, 5, 19, 7, 30, 35, 297, DateTimeKind.Utc).AddTicks(7011),
                            Id = 1,
                            type = 0
                        },
                        new
                        {
                            DoctorId = 9,
                            PatientId = 2,
                            PrescriptionId = 2,
                            Booking = new DateTime(2025, 5, 22, 13, 7, 40, 297, DateTimeKind.Utc).AddTicks(7138),
                            Id = 2,
                            type = 1
                        },
                        new
                        {
                            DoctorId = 7,
                            PatientId = 3,
                            PrescriptionId = 3,
                            Booking = new DateTime(2025, 5, 30, 0, 51, 14, 297, DateTimeKind.Utc).AddTicks(7145),
                            Id = 3,
                            type = 1
                        },
                        new
                        {
                            DoctorId = 7,
                            PatientId = 4,
                            PrescriptionId = 4,
                            Booking = new DateTime(2025, 8, 12, 21, 22, 45, 297, DateTimeKind.Utc).AddTicks(7175),
                            Id = 4,
                            type = 0
                        },
                        new
                        {
                            DoctorId = 9,
                            PatientId = 5,
                            PrescriptionId = 5,
                            Booking = new DateTime(2025, 8, 12, 18, 7, 54, 297, DateTimeKind.Utc).AddTicks(7185),
                            Id = 5,
                            type = 0
                        },
                        new
                        {
                            DoctorId = 7,
                            PatientId = 6,
                            PrescriptionId = 6,
                            Booking = new DateTime(2024, 12, 23, 22, 48, 57, 297, DateTimeKind.Utc).AddTicks(7191),
                            Id = 6,
                            type = 1
                        },
                        new
                        {
                            DoctorId = 3,
                            PatientId = 7,
                            PrescriptionId = 7,
                            Booking = new DateTime(2025, 6, 4, 21, 36, 42, 297, DateTimeKind.Utc).AddTicks(7196),
                            Id = 7,
                            type = 0
                        },
                        new
                        {
                            DoctorId = 4,
                            PatientId = 8,
                            PrescriptionId = 8,
                            Booking = new DateTime(2024, 9, 26, 22, 56, 29, 297, DateTimeKind.Utc).AddTicks(7206),
                            Id = 8,
                            type = 0
                        },
                        new
                        {
                            DoctorId = 6,
                            PatientId = 9,
                            PrescriptionId = 9,
                            Booking = new DateTime(2025, 1, 17, 11, 39, 32, 297, DateTimeKind.Utc).AddTicks(7210),
                            Id = 9,
                            type = 0
                        },
                        new
                        {
                            DoctorId = 10,
                            PatientId = 10,
                            PrescriptionId = 10,
                            Booking = new DateTime(2024, 11, 2, 1, 41, 13, 297, DateTimeKind.Utc).AddTicks(7215),
                            Id = 10,
                            type = 0
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
                            FullName = "Mickey Mathiasson"
                        },
                        new
                        {
                            Id = 2,
                            FullName = "Oprah Winfrey"
                        },
                        new
                        {
                            Id = 3,
                            FullName = "Kate Winslow"
                        },
                        new
                        {
                            Id = 4,
                            FullName = "Kate Winslow"
                        },
                        new
                        {
                            Id = 5,
                            FullName = "Adam Duck"
                        },
                        new
                        {
                            Id = 6,
                            FullName = "Arnold Obama"
                        },
                        new
                        {
                            Id = 7,
                            FullName = "Mickey Mathiasson"
                        },
                        new
                        {
                            Id = 8,
                            FullName = "Adam Mathiasson"
                        },
                        new
                        {
                            Id = 9,
                            FullName = "Barack Xavier"
                        },
                        new
                        {
                            Id = 10,
                            FullName = "Ragnar Mathiasson"
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
                            Instruction = "Inject with needle into the bloodstream.",
                            Name = "Ultra Aspirin",
                            Quantity = 98
                        },
                        new
                        {
                            Id = 2,
                            Instruction = "Lick over a long period of time.",
                            Name = "Ultra Aspirin",
                            Quantity = 2
                        },
                        new
                        {
                            Id = 3,
                            Instruction = "Inject with needle into the bloodstream.",
                            Name = "Yummy Drugs",
                            Quantity = 80
                        },
                        new
                        {
                            Id = 4,
                            Instruction = "Insert into rectum.",
                            Name = "Crazy Potion",
                            Quantity = 6
                        },
                        new
                        {
                            Id = 5,
                            Instruction = "Swallow with water.",
                            Name = "Good Potion",
                            Quantity = 17
                        },
                        new
                        {
                            Id = 6,
                            Instruction = "Swallow without anything added.",
                            Name = "Crazy Blue Pills",
                            Quantity = 40
                        },
                        new
                        {
                            Id = 7,
                            Instruction = "Lick over a long period of time.",
                            Name = "Crazy Mushrooms",
                            Quantity = 71
                        },
                        new
                        {
                            Id = 8,
                            Instruction = "Mix with chicken noodle soup.",
                            Name = "Super Couch drops",
                            Quantity = 69
                        },
                        new
                        {
                            Id = 9,
                            Instruction = "Put in coworker's food.",
                            Name = "Super Xanax",
                            Quantity = 20
                        },
                        new
                        {
                            Id = 10,
                            Instruction = "Hide in cabinet and let the placebo effect do it's job.",
                            Name = "Not Xanax",
                            Quantity = 65
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
                            FullName = "Felix Mathiasson"
                        },
                        new
                        {
                            Id = 2,
                            FullName = "Neo Obama"
                        },
                        new
                        {
                            Id = 3,
                            FullName = "Oprah Lothbrok"
                        },
                        new
                        {
                            Id = 4,
                            FullName = "Kate Andersson"
                        },
                        new
                        {
                            Id = 5,
                            FullName = "Donald Duck"
                        },
                        new
                        {
                            Id = 6,
                            FullName = "Charles Mouse"
                        },
                        new
                        {
                            Id = 7,
                            FullName = "Oprah Mouse"
                        },
                        new
                        {
                            Id = 8,
                            FullName = "Neo Presley"
                        },
                        new
                        {
                            Id = 9,
                            FullName = "Oprah Andersson"
                        },
                        new
                        {
                            Id = 10,
                            FullName = "Donald Andersson"
                        });
                });

            modelBuilder.Entity("workshop.wwwapi.Models.Prescription", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.HasKey("Id");

                    b.ToTable("prescriptions");

                    b.HasData(
                        new
                        {
                            Id = 1
                        },
                        new
                        {
                            Id = 2
                        },
                        new
                        {
                            Id = 3
                        },
                        new
                        {
                            Id = 4
                        },
                        new
                        {
                            Id = 5
                        },
                        new
                        {
                            Id = 6
                        },
                        new
                        {
                            Id = 7
                        },
                        new
                        {
                            Id = 8
                        },
                        new
                        {
                            Id = 9
                        },
                        new
                        {
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
                            PrescriptionId = 9,
                            MedicineId = 1
                        },
                        new
                        {
                            PrescriptionId = 4,
                            MedicineId = 1
                        },
                        new
                        {
                            PrescriptionId = 1,
                            MedicineId = 1
                        },
                        new
                        {
                            PrescriptionId = 1,
                            MedicineId = 2
                        },
                        new
                        {
                            PrescriptionId = 3,
                            MedicineId = 2
                        },
                        new
                        {
                            PrescriptionId = 4,
                            MedicineId = 2
                        },
                        new
                        {
                            PrescriptionId = 1,
                            MedicineId = 3
                        },
                        new
                        {
                            PrescriptionId = 10,
                            MedicineId = 3
                        },
                        new
                        {
                            PrescriptionId = 3,
                            MedicineId = 3
                        },
                        new
                        {
                            PrescriptionId = 6,
                            MedicineId = 4
                        },
                        new
                        {
                            PrescriptionId = 5,
                            MedicineId = 4
                        },
                        new
                        {
                            PrescriptionId = 7,
                            MedicineId = 4
                        },
                        new
                        {
                            PrescriptionId = 6,
                            MedicineId = 5
                        },
                        new
                        {
                            PrescriptionId = 8,
                            MedicineId = 5
                        },
                        new
                        {
                            PrescriptionId = 10,
                            MedicineId = 5
                        },
                        new
                        {
                            PrescriptionId = 1,
                            MedicineId = 6
                        },
                        new
                        {
                            PrescriptionId = 10,
                            MedicineId = 6
                        },
                        new
                        {
                            PrescriptionId = 5,
                            MedicineId = 6
                        },
                        new
                        {
                            PrescriptionId = 1,
                            MedicineId = 7
                        },
                        new
                        {
                            PrescriptionId = 5,
                            MedicineId = 7
                        },
                        new
                        {
                            PrescriptionId = 3,
                            MedicineId = 7
                        },
                        new
                        {
                            PrescriptionId = 7,
                            MedicineId = 8
                        },
                        new
                        {
                            PrescriptionId = 3,
                            MedicineId = 8
                        },
                        new
                        {
                            PrescriptionId = 4,
                            MedicineId = 8
                        },
                        new
                        {
                            PrescriptionId = 10,
                            MedicineId = 9
                        },
                        new
                        {
                            PrescriptionId = 2,
                            MedicineId = 9
                        },
                        new
                        {
                            PrescriptionId = 3,
                            MedicineId = 9
                        },
                        new
                        {
                            PrescriptionId = 8,
                            MedicineId = 10
                        },
                        new
                        {
                            PrescriptionId = 1,
                            MedicineId = 10
                        },
                        new
                        {
                            PrescriptionId = 6,
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
