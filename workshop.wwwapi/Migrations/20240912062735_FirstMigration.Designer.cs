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
    [Migration("20240912062735_FirstMigration")]
    partial class FirstMigration
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("Prescription", b =>
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

                    b.ToTable("Prescriptions");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            DoctorId = 1,
                            PatientId = 2
                        },
                        new
                        {
                            Id = 2,
                            DoctorId = 1,
                            PatientId = 1
                        },
                        new
                        {
                            Id = 3,
                            DoctorId = 1,
                            PatientId = 3
                        },
                        new
                        {
                            Id = 4,
                            DoctorId = 2,
                            PatientId = 1
                        });
                });

            modelBuilder.Entity("workshop.wwwapi.Models.Appointment", b =>
                {
                    b.Property<int>("PatientId")
                        .HasColumnType("integer");

                    b.Property<int>("DoctorId")
                        .HasColumnType("integer");

                    b.Property<DateTime>("Booking")
                        .HasColumnType("timestamp with time zone");

                    b.HasKey("PatientId", "DoctorId", "Booking");

                    b.HasIndex("DoctorId");

                    b.ToTable("appointments");

                    b.HasData(
                        new
                        {
                            PatientId = 1,
                            DoctorId = 1,
                            Booking = new DateTime(2024, 9, 14, 12, 30, 0, 0, DateTimeKind.Utc)
                        },
                        new
                        {
                            PatientId = 2,
                            DoctorId = 2,
                            Booking = new DateTime(2024, 9, 14, 13, 30, 0, 0, DateTimeKind.Utc)
                        },
                        new
                        {
                            PatientId = 3,
                            DoctorId = 3,
                            Booking = new DateTime(2024, 9, 14, 14, 30, 0, 0, DateTimeKind.Utc)
                        },
                        new
                        {
                            PatientId = 3,
                            DoctorId = 1,
                            Booking = new DateTime(2024, 9, 14, 13, 30, 0, 0, DateTimeKind.Utc)
                        },
                        new
                        {
                            PatientId = 3,
                            DoctorId = 2,
                            Booking = new DateTime(2024, 9, 14, 13, 30, 0, 0, DateTimeKind.Utc)
                        },
                        new
                        {
                            PatientId = 1,
                            DoctorId = 3,
                            Booking = new DateTime(2024, 9, 14, 14, 30, 0, 0, DateTimeKind.Utc)
                        },
                        new
                        {
                            PatientId = 2,
                            DoctorId = 1,
                            Booking = new DateTime(2024, 9, 14, 14, 30, 0, 0, DateTimeKind.Utc)
                        },
                        new
                        {
                            PatientId = 1,
                            DoctorId = 2,
                            Booking = new DateTime(2024, 9, 14, 14, 30, 0, 0, DateTimeKind.Utc)
                        },
                        new
                        {
                            PatientId = 2,
                            DoctorId = 3,
                            Booking = new DateTime(2024, 9, 14, 14, 30, 0, 0, DateTimeKind.Utc)
                        });
                });

            modelBuilder.Entity("workshop.wwwapi.Models.Doctor", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("doctors");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            FirstName = "Hannibal",
                            LastName = "Lecter"
                        },
                        new
                        {
                            Id = 2,
                            FirstName = "Henry",
                            LastName = "Jones Jr."
                        },
                        new
                        {
                            Id = 3,
                            FirstName = "Davy",
                            LastName = "Jones"
                        });
                });

            modelBuilder.Entity("workshop.wwwapi.Models.Medicine", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("Mg")
                        .HasColumnType("integer");

                    b.Property<string>("Name")
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
                            Mg = 10,
                            Name = "Bugfixol",
                            Quantity = 50
                        },
                        new
                        {
                            Id = 2,
                            Mg = 30,
                            Name = "Patchorix",
                            Quantity = 90
                        },
                        new
                        {
                            Id = 3,
                            Mg = 15,
                            Name = "Syntaxol",
                            Quantity = 100
                        },
                        new
                        {
                            Id = 4,
                            Mg = 500,
                            Name = "Compilex",
                            Quantity = 20
                        },
                        new
                        {
                            Id = 5,
                            Mg = 5,
                            Name = "PolyMorphix",
                            Quantity = 40
                        },
                        new
                        {
                            Id = 6,
                            Mg = 32,
                            Name = "LambdaRelief",
                            Quantity = 90
                        },
                        new
                        {
                            Id = 7,
                            Mg = 100,
                            Name = "Inheritex",
                            Quantity = 60
                        },
                        new
                        {
                            Id = 8,
                            Mg = 1000,
                            Name = "Reactabool Forte",
                            Quantity = 10
                        });
                });

            modelBuilder.Entity("workshop.wwwapi.Models.Patient", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("patients");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            FirstName = "John",
                            LastName = "Doe"
                        },
                        new
                        {
                            Id = 2,
                            FirstName = "Jane",
                            LastName = "Dough"
                        },
                        new
                        {
                            Id = 3,
                            FirstName = "Hughie",
                            LastName = "Dodson"
                        });
                });

            modelBuilder.Entity("workshop.wwwapi.Models.PrescribedMedicine", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("Amount")
                        .HasColumnType("integer");

                    b.Property<string>("Instructions")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("MedicineName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("PrescriptionId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("PrescriptionId");

                    b.ToTable("PrescribedMedicines");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Amount = 2,
                            Instructions = "Take 1 before each TestRun",
                            MedicineName = "Patchorix",
                            PrescriptionId = 1
                        },
                        new
                        {
                            Id = 2,
                            Amount = 1,
                            Instructions = "Take 2 before and 5 after deploying patch. Double amount if its friday",
                            MedicineName = "Syntaxol",
                            PrescriptionId = 1
                        },
                        new
                        {
                            Id = 3,
                            Amount = 1,
                            Instructions = "Take as needed",
                            MedicineName = "Compilex",
                            PrescriptionId = 1
                        });
                });

            modelBuilder.Entity("Prescription", b =>
                {
                    b.HasOne("workshop.wwwapi.Models.Doctor", "Doctor")
                        .WithMany()
                        .HasForeignKey("DoctorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("workshop.wwwapi.Models.Patient", "Patient")
                        .WithMany()
                        .HasForeignKey("PatientId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Doctor");

                    b.Navigation("Patient");
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

            modelBuilder.Entity("workshop.wwwapi.Models.PrescribedMedicine", b =>
                {
                    b.HasOne("Prescription", "Prescription")
                        .WithMany("PrescribedMedicineList")
                        .HasForeignKey("PrescriptionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Prescription");
                });

            modelBuilder.Entity("Prescription", b =>
                {
                    b.Navigation("PrescribedMedicineList");
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
