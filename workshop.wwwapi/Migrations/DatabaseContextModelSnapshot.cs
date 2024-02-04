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
                    b.Property<int>("DoctorId")
                        .HasColumnType("integer");

                    b.Property<int>("PatientId")
                        .HasColumnType("integer");

                    b.Property<DateTime>("Booking")
                        .HasColumnType("Date")
                        .HasColumnName("date");

                    b.Property<int>("Appointmenttype")
                        .HasColumnType("integer")
                        .HasColumnName("appointment type");

                    b.HasKey("DoctorId", "PatientId", "Booking");

                    b.HasIndex("PatientId");

                    b.ToTable("appointment");

                    b.HasData(
                        new
                        {
                            DoctorId = 1,
                            PatientId = 2,
                            Booking = new DateTime(1999, 10, 12, 12, 0, 0, 0, DateTimeKind.Unspecified),
                            Appointmenttype = 1
                        },
                        new
                        {
                            DoctorId = 1,
                            PatientId = 1,
                            Booking = new DateTime(1998, 10, 12, 12, 0, 0, 0, DateTimeKind.Unspecified),
                            Appointmenttype = 0
                        },
                        new
                        {
                            DoctorId = 2,
                            PatientId = 2,
                            Booking = new DateTime(1997, 10, 12, 12, 0, 0, 0, DateTimeKind.Unspecified),
                            Appointmenttype = 1
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
                            FullName = "TIKOKAS"
                        },
                        new
                        {
                            Id = 2,
                            FullName = "INSTRAAS"
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
                        .HasColumnName("fullname");

                    b.HasKey("Id");

                    b.ToTable("patient");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            FullName = "GoogleP"
                        },
                        new
                        {
                            Id = 2,
                            FullName = "WIKIP"
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
