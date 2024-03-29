﻿// <auto-generated />
using System;
using BRTS_System.Date;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace BRTS_System.Migrations
{
    [DbContext(typeof(SystemDbContext))]
    [Migration("20240110124808_FM")]
    partial class FM
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.13")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("BRTS_System.Models.Admin", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<string>("FullName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("username")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("ID");

                    b.HasIndex("username")
                        .IsUnique();

                    b.ToTable("admin");
                });

            modelBuilder.Entity("BRTS_System.Models.Bus", b =>
                {
                    b.Property<int>("BusID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("BusID"));

                    b.Property<int>("AdminID")
                        .HasColumnType("int");

                    b.Property<int>("NumberofSeats")
                        .HasColumnType("int");

                    b.Property<string>("captainname")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("BusID");

                    b.HasIndex("AdminID");

                    b.HasIndex("captainname")
                        .IsUnique();

                    b.ToTable("bus");
                });

            modelBuilder.Entity("BRTS_System.Models.Trip", b =>
                {
                    b.Property<int>("TripID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("TripID"));

                    b.Property<int>("AdminId")
                        .HasColumnType("int");

                    b.Property<int?>("BusID")
                        .HasColumnType("int");

                    b.Property<string>("BusNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Destination")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("EndData")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("StartData")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("TripID");

                    b.HasIndex("AdminId");

                    b.HasIndex("BusID");

                    b.ToTable("trip");
                });

            modelBuilder.Entity("BRTS_System.Models.User", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Gender")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.HasIndex("Username")
                        .IsUnique();

                    b.ToTable("user");
                });

            modelBuilder.Entity("BRTS_System.Models.User_Trip", b =>
                {
                    b.Property<int>("BookingID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("BookingID"));

                    b.Property<int>("TripId")
                        .HasColumnType("int");

                    b.Property<int>("passengerID")
                        .HasColumnType("int");

                    b.HasKey("BookingID");

                    b.HasIndex("TripId");

                    b.HasIndex("passengerID");

                    b.ToTable("user_trip");
                });

            modelBuilder.Entity("BRTS_System.Models.Bus", b =>
                {
                    b.HasOne("BRTS_System.Models.Admin", "Admin")
                        .WithMany("bus")
                        .HasForeignKey("AdminID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Admin");
                });

            modelBuilder.Entity("BRTS_System.Models.Trip", b =>
                {
                    b.HasOne("BRTS_System.Models.Admin", "Admin")
                        .WithMany("trip")
                        .HasForeignKey("AdminId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BRTS_System.Models.Bus", null)
                        .WithMany("trip")
                        .HasForeignKey("BusID");

                    b.Navigation("Admin");
                });

            modelBuilder.Entity("BRTS_System.Models.User_Trip", b =>
                {
                    b.HasOne("BRTS_System.Models.Trip", "trip")
                        .WithMany("User_trip")
                        .HasForeignKey("TripId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BRTS_System.Models.User", "user")
                        .WithMany("user_trip")
                        .HasForeignKey("passengerID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("trip");

                    b.Navigation("user");
                });

            modelBuilder.Entity("BRTS_System.Models.Admin", b =>
                {
                    b.Navigation("bus");

                    b.Navigation("trip");
                });

            modelBuilder.Entity("BRTS_System.Models.Bus", b =>
                {
                    b.Navigation("trip");
                });

            modelBuilder.Entity("BRTS_System.Models.Trip", b =>
                {
                    b.Navigation("User_trip");
                });

            modelBuilder.Entity("BRTS_System.Models.User", b =>
                {
                    b.Navigation("user_trip");
                });
#pragma warning restore 612, 618
        }
    }
}
