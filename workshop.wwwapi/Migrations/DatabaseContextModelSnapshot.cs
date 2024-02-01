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

            modelBuilder.Entity("workshop.wwwapi.Models.Appointment", b =>
                {
                    b.Property<int>("PatientId")
                        .HasColumnType("integer")
                        .HasColumnName("patient_id");

                    b.Property<int>("DoctorId")
                        .HasColumnType("integer")
                        .HasColumnName("doctor_id");

                    b.Property<DateTime>("Booking")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("booking");

                    b.HasKey("PatientId", "DoctorId");

                    b.HasIndex("DoctorId");

                    b.ToTable("appointments", (string)null);

                    b.HasData(
                        new
                        {
                            PatientId = 1,
                            DoctorId = 1,
                            Booking = new DateTime(2024, 1, 31, 15, 40, 6, 405, DateTimeKind.Utc).AddTicks(3253)
                        },
                        new
                        {
                            PatientId = 5,
                            DoctorId = 2,
                            Booking = new DateTime(2024, 1, 31, 15, 40, 6, 405, DateTimeKind.Utc).AddTicks(3253)
                        },
                        new
                        {
                            PatientId = 4,
                            DoctorId = 3,
                            Booking = new DateTime(2024, 1, 31, 15, 40, 6, 405, DateTimeKind.Utc).AddTicks(3253)
                        },
                        new
                        {
                            PatientId = 2,
                            DoctorId = 1,
                            Booking = new DateTime(2024, 2, 1, 15, 40, 6, 405, DateTimeKind.Utc).AddTicks(3347)
                        },
                        new
                        {
                            PatientId = 4,
                            DoctorId = 2,
                            Booking = new DateTime(2024, 2, 1, 15, 40, 6, 405, DateTimeKind.Utc).AddTicks(3347)
                        },
                        new
                        {
                            PatientId = 3,
                            DoctorId = 3,
                            Booking = new DateTime(2024, 2, 1, 15, 40, 6, 405, DateTimeKind.Utc).AddTicks(3347)
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

                    b.ToTable("doctors", (string)null);

                    b.HasData(
                        new
                        {
                            Id = 1,
                            FullName = "Old Beardo"
                        },
                        new
                        {
                            Id = 2,
                            FullName = "Dr Strangelove"
                        },
                        new
                        {
                            Id = 3,
                            FullName = "Krieger"
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

                    b.ToTable("patients", (string)null);

                    b.HasData(
                        new
                        {
                            Id = 1,
                            FullName = "Victor Adamson"
                        },
                        new
                        {
                            Id = 2,
                            FullName = "Name Namesson"
                        },
                        new
                        {
                            Id = 3,
                            FullName = "John Smith"
                        },
                        new
                        {
                            Id = 4,
                            FullName = "Person MacPersonface"
                        },
                        new
                        {
                            Id = 5,
                            FullName = "Phill Collins"
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
