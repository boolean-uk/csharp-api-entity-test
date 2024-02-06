﻿// <auto-generated />
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
    [Migration("20240206084756_PGSSQL")]
    partial class PGSSQL
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
                        .HasColumnType("integer");

                    b.Property<int>("DoctorId")
                        .HasColumnType("integer");

                    b.Property<string>("Booking")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("appointmentDate");

                    b.Property<int>("Id")
                        .HasColumnType("integer")
                        .HasColumnName("id");

                    b.HasKey("PatientId", "DoctorId");

                    b.HasIndex("DoctorId");

                    b.ToTable("appointments");

                    b.HasData(
                        new
                        {
                            PatientId = 2,
                            DoctorId = 1,
                            Booking = "06/12/2024 09:50:10",
                            Id = 1
                        },
                        new
                        {
                            PatientId = 1,
                            DoctorId = 2,
                            Booking = "06/12/2024 09:50:10",
                            Id = 2
                        },
                        new
                        {
                            PatientId = 16,
                            DoctorId = 3,
                            Booking = "07/18/2024 10:50:00",
                            Id = 3
                        },
                        new
                        {
                            PatientId = 18,
                            DoctorId = 4,
                            Booking = "09/16/2024 08:10:00",
                            Id = 4
                        },
                        new
                        {
                            PatientId = 9,
                            DoctorId = 5,
                            Booking = "12/01/2024 11:00:00",
                            Id = 5
                        },
                        new
                        {
                            PatientId = 36,
                            DoctorId = 6,
                            Booking = "02/01/2024 09:40:00",
                            Id = 6
                        },
                        new
                        {
                            PatientId = 32,
                            DoctorId = 7,
                            Booking = "08/06/2024 10:20:00",
                            Id = 7
                        },
                        new
                        {
                            PatientId = 38,
                            DoctorId = 8,
                            Booking = "12/20/2024 09:00:00",
                            Id = 8
                        },
                        new
                        {
                            PatientId = 38,
                            DoctorId = 9,
                            Booking = "07/25/2024 08:00:00",
                            Id = 9
                        },
                        new
                        {
                            PatientId = 31,
                            DoctorId = 10,
                            Booking = "11/18/2024 10:00:00",
                            Id = 10
                        },
                        new
                        {
                            PatientId = 39,
                            DoctorId = 11,
                            Booking = "12/23/2024 08:30:00",
                            Id = 11
                        },
                        new
                        {
                            PatientId = 5,
                            DoctorId = 12,
                            Booking = "03/09/2024 11:50:00",
                            Id = 12
                        },
                        new
                        {
                            PatientId = 11,
                            DoctorId = 13,
                            Booking = "11/21/2024 10:50:00",
                            Id = 13
                        },
                        new
                        {
                            PatientId = 34,
                            DoctorId = 14,
                            Booking = "05/12/2024 09:20:00",
                            Id = 14
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
                            FullName = "Arne Arnesen"
                        },
                        new
                        {
                            Id = 2,
                            FullName = "Endre Endresen"
                        },
                        new
                        {
                            Id = 3,
                            FullName = "Emma Windsor"
                        },
                        new
                        {
                            Id = 4,
                            FullName = "Jimi Hepburn"
                        },
                        new
                        {
                            Id = 5,
                            FullName = "Arthur Hendrix"
                        },
                        new
                        {
                            Id = 6,
                            FullName = "Audrey Jagger"
                        },
                        new
                        {
                            Id = 7,
                            FullName = "Barack Presley"
                        },
                        new
                        {
                            Id = 8,
                            FullName = "Audrey Jacobsen"
                        },
                        new
                        {
                            Id = 9,
                            FullName = "Arthur Hepburn"
                        },
                        new
                        {
                            Id = 10,
                            FullName = "Mick Winfrey"
                        },
                        new
                        {
                            Id = 11,
                            FullName = "Oprah Olsen"
                        },
                        new
                        {
                            Id = 12,
                            FullName = "Kate Jacobsen"
                        },
                        new
                        {
                            Id = 13,
                            FullName = "Jimi Obama"
                        },
                        new
                        {
                            Id = 14,
                            FullName = "Jimi Winslet"
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
                        .HasColumnName("name");

                    b.HasKey("Id");

                    b.ToTable("patients");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            FullName = "Ole Olsen"
                        },
                        new
                        {
                            Id = 2,
                            FullName = "Sigrid Furukongle"
                        },
                        new
                        {
                            Id = 3,
                            FullName = "Audrey Hendrix"
                        },
                        new
                        {
                            Id = 4,
                            FullName = "Donald Jagger"
                        },
                        new
                        {
                            Id = 5,
                            FullName = "Donald Obama"
                        },
                        new
                        {
                            Id = 6,
                            FullName = "Kate Hendrix"
                        },
                        new
                        {
                            Id = 7,
                            FullName = "Mick Jacobsen"
                        },
                        new
                        {
                            Id = 8,
                            FullName = "Kate Winfrey"
                        },
                        new
                        {
                            Id = 9,
                            FullName = "Donald Presley"
                        },
                        new
                        {
                            Id = 10,
                            FullName = "Oprah Obama"
                        },
                        new
                        {
                            Id = 11,
                            FullName = "Jimi Obama"
                        },
                        new
                        {
                            Id = 12,
                            FullName = "Emma Winslet"
                        },
                        new
                        {
                            Id = 13,
                            FullName = "Arthur Trump"
                        },
                        new
                        {
                            Id = 14,
                            FullName = "Mick Winfrey"
                        },
                        new
                        {
                            Id = 15,
                            FullName = "Arthur Windsor"
                        },
                        new
                        {
                            Id = 16,
                            FullName = "Barack Winfrey"
                        },
                        new
                        {
                            Id = 17,
                            FullName = "Donald Presley"
                        },
                        new
                        {
                            Id = 18,
                            FullName = "Kate Windsor"
                        },
                        new
                        {
                            Id = 19,
                            FullName = "Jimi Jagger"
                        },
                        new
                        {
                            Id = 20,
                            FullName = "Jimi Hendrix"
                        },
                        new
                        {
                            Id = 21,
                            FullName = "Arthur Hepburn"
                        },
                        new
                        {
                            Id = 22,
                            FullName = "Donald Middleton"
                        },
                        new
                        {
                            Id = 23,
                            FullName = "Arthur Jagger"
                        },
                        new
                        {
                            Id = 24,
                            FullName = "Elvis Olsen"
                        },
                        new
                        {
                            Id = 25,
                            FullName = "Barack Winfrey"
                        },
                        new
                        {
                            Id = 26,
                            FullName = "Barack Winfrey"
                        },
                        new
                        {
                            Id = 27,
                            FullName = "Jimi Obama"
                        },
                        new
                        {
                            Id = 28,
                            FullName = "Arthur Hepburn"
                        },
                        new
                        {
                            Id = 29,
                            FullName = "Jimi Middleton"
                        },
                        new
                        {
                            Id = 30,
                            FullName = "Arthur Jagger"
                        },
                        new
                        {
                            Id = 31,
                            FullName = "Barack Presley"
                        },
                        new
                        {
                            Id = 32,
                            FullName = "Elvis Winfrey"
                        },
                        new
                        {
                            Id = 33,
                            FullName = "Audrey Winfrey"
                        },
                        new
                        {
                            Id = 34,
                            FullName = "Jimi Hepburn"
                        },
                        new
                        {
                            Id = 35,
                            FullName = "Kate Hepburn"
                        },
                        new
                        {
                            Id = 36,
                            FullName = "Oprah Windsor"
                        },
                        new
                        {
                            Id = 37,
                            FullName = "Kate Winslet"
                        },
                        new
                        {
                            Id = 38,
                            FullName = "Arthur Jacobsen"
                        },
                        new
                        {
                            Id = 39,
                            FullName = "Mick Hepburn"
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
