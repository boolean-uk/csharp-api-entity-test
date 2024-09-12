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
    [Migration("20240207135700_Clinic")]
    partial class Clinic
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
                        .HasColumnName("doctor_id");

                    b.Property<int>("PatientId")
                        .HasColumnType("integer")
                        .HasColumnName("patient_id");

                    b.Property<DateTime>("Booking")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("appointment_time");

                    b.HasKey("DoctorId", "PatientId");

                    b.HasIndex("PatientId");

                    b.ToTable("appointment");

                    b.HasData(
                        new
                        {
                            DoctorId = 1,
                            PatientId = 1,
                            Booking = new DateTime(2024, 2, 7, 13, 56, 59, 953, DateTimeKind.Utc).AddTicks(3690)
                        },
                        new
                        {
                            DoctorId = 2,
                            PatientId = 2,
                            Booking = new DateTime(2024, 2, 7, 13, 56, 59, 953, DateTimeKind.Utc).AddTicks(3692)
                        },
                        new
                        {
                            DoctorId = 3,
                            PatientId = 3,
                            Booking = new DateTime(2024, 2, 7, 13, 56, 59, 953, DateTimeKind.Utc).AddTicks(3693)
                        },
                        new
                        {
                            DoctorId = 4,
                            PatientId = 4,
                            Booking = new DateTime(2024, 2, 7, 13, 56, 59, 953, DateTimeKind.Utc).AddTicks(3693)
                        },
                        new
                        {
                            DoctorId = 5,
                            PatientId = 5,
                            Booking = new DateTime(2024, 2, 7, 13, 56, 59, 953, DateTimeKind.Utc).AddTicks(3694)
                        },
                        new
                        {
                            DoctorId = 6,
                            PatientId = 6,
                            Booking = new DateTime(2024, 2, 7, 13, 56, 59, 953, DateTimeKind.Utc).AddTicks(3695)
                        },
                        new
                        {
                            DoctorId = 7,
                            PatientId = 7,
                            Booking = new DateTime(2024, 2, 7, 13, 56, 59, 953, DateTimeKind.Utc).AddTicks(3695)
                        },
                        new
                        {
                            DoctorId = 8,
                            PatientId = 8,
                            Booking = new DateTime(2024, 2, 7, 13, 56, 59, 953, DateTimeKind.Utc).AddTicks(3695)
                        },
                        new
                        {
                            DoctorId = 9,
                            PatientId = 9,
                            Booking = new DateTime(2024, 2, 7, 13, 56, 59, 953, DateTimeKind.Utc).AddTicks(3696)
                        },
                        new
                        {
                            DoctorId = 10,
                            PatientId = 10,
                            Booking = new DateTime(2024, 2, 7, 13, 56, 59, 953, DateTimeKind.Utc).AddTicks(3696)
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

                    b.ToTable("doctor");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            FullName = "Elvis Winfrey"
                        },
                        new
                        {
                            Id = 2,
                            FullName = "Kate Windsor"
                        },
                        new
                        {
                            Id = 3,
                            FullName = "Kate Middleton"
                        },
                        new
                        {
                            Id = 4,
                            FullName = "Mick Middleton"
                        },
                        new
                        {
                            Id = 5,
                            FullName = "Oprah Winfrey"
                        },
                        new
                        {
                            Id = 6,
                            FullName = "Elvis Hepburn"
                        },
                        new
                        {
                            Id = 7,
                            FullName = "Donald Jagger"
                        },
                        new
                        {
                            Id = 8,
                            FullName = "Charles Windsor"
                        },
                        new
                        {
                            Id = 9,
                            FullName = "Jimi Hendrix"
                        },
                        new
                        {
                            Id = 10,
                            FullName = "Elvis Jagger"
                        });
                });

            modelBuilder.Entity("workshop.wwwapi.Models.Medicine", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("MedName")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("medname");

                    b.HasKey("Id");

                    b.ToTable("Medicines");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            MedName = "Paracetamol"
                        },
                        new
                        {
                            Id = 2,
                            MedName = "Zyrtec"
                        },
                        new
                        {
                            Id = 3,
                            MedName = "Hyrimoz"
                        });
                });

            modelBuilder.Entity("workshop.wwwapi.Models.MedicinePrescription", b =>
                {
                    b.Property<int>("MedId")
                        .HasColumnType("integer")
                        .HasColumnName("med_id");

                    b.Property<int>("PrescriptionId")
                        .HasColumnType("integer")
                        .HasColumnName("prescription_id");

                    b.Property<int>("MedAmount")
                        .HasColumnType("integer")
                        .HasColumnName("amount");

                    b.HasKey("MedId", "PrescriptionId");

                    b.ToTable("MedPrescription");

                    b.HasData(
                        new
                        {
                            MedId = 2,
                            PrescriptionId = 1,
                            MedAmount = 5
                        },
                        new
                        {
                            MedId = 1,
                            PrescriptionId = 2,
                            MedAmount = 4
                        },
                        new
                        {
                            MedId = 1,
                            PrescriptionId = 3,
                            MedAmount = 4
                        },
                        new
                        {
                            MedId = 1,
                            PrescriptionId = 4,
                            MedAmount = 7
                        },
                        new
                        {
                            MedId = 2,
                            PrescriptionId = 5,
                            MedAmount = 1
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

                    b.ToTable("patient");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            FullName = "Jimi Hepburn"
                        },
                        new
                        {
                            Id = 2,
                            FullName = "Charles Trump"
                        },
                        new
                        {
                            Id = 3,
                            FullName = "Barack Hendrix"
                        },
                        new
                        {
                            Id = 4,
                            FullName = "Mick Hepburn"
                        },
                        new
                        {
                            Id = 5,
                            FullName = "Charles Trump"
                        },
                        new
                        {
                            Id = 6,
                            FullName = "Audrey Obama"
                        },
                        new
                        {
                            Id = 7,
                            FullName = "Elvis Middleton"
                        },
                        new
                        {
                            Id = 8,
                            FullName = "Mick Hendrix"
                        },
                        new
                        {
                            Id = 9,
                            FullName = "Donald Winfrey"
                        },
                        new
                        {
                            Id = 10,
                            FullName = "Oprah Obama"
                        });
                });

            modelBuilder.Entity("workshop.wwwapi.Models.Prescription", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("DoctorId")
                        .HasColumnType("integer")
                        .HasColumnName("doctor_id");

                    b.Property<int>("PatientId")
                        .HasColumnType("integer")
                        .HasColumnName("patient_id");

                    b.HasKey("Id");

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
                            DoctorId = 3,
                            PatientId = 3
                        },
                        new
                        {
                            Id = 4,
                            DoctorId = 4,
                            PatientId = 4
                        },
                        new
                        {
                            Id = 5,
                            DoctorId = 5,
                            PatientId = 5
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