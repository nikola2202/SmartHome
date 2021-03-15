﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SmartHome.DBContexts;

namespace SmartHome.Migrations
{
    [DbContext(typeof(SmartHomeDBContext))]
    [Migration("20210315122211_Device type added")]
    partial class Devicetypeadded
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 64)
                .HasAnnotation("ProductVersion", "5.0.0");

            modelBuilder.Entity("SmartHome.Models.Device", b =>
                {
                    b.Property<long>("DeviceId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    b.Property<string>("DeviceName")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<long>("DeviceTypeId")
                        .HasColumnType("bigint");

                    b.Property<long>("HomeId")
                        .HasColumnType("bigint");

                    b.HasKey("DeviceId");

                    b.HasIndex("DeviceTypeId");

                    b.HasIndex("HomeId");

                    b.ToTable("Device");
                });

            modelBuilder.Entity("SmartHome.Models.DeviceType", b =>
                {
                    b.Property<long>("DeviceTypeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    b.Property<string>("DeviceTypeName")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.HasKey("DeviceTypeId");

                    b.ToTable("DeviceType");
                });

            modelBuilder.Entity("SmartHome.Models.Home", b =>
                {
                    b.Property<long>("HomeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    b.Property<string>("Adress")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.HasKey("HomeId");

                    b.ToTable("Homes");
                });

            modelBuilder.Entity("SmartHome.Models.User", b =>
                {
                    b.Property<long>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    b.Property<string>("Name")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("Password")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("Surname")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("Username")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.HasKey("UserId");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("SmartHome.Models.UserHome", b =>
                {
                    b.Property<long>("UserId")
                        .HasColumnType("bigint");

                    b.Property<long>("HomeId")
                        .HasColumnType("bigint");

                    b.Property<long>("Id")
                        .HasColumnType("bigint");

                    b.Property<bool>("IsOwner")
                        .HasColumnType("tinyint(1)");

                    b.HasKey("UserId", "HomeId");

                    b.HasIndex("HomeId");

                    b.ToTable("UserHomes");
                });

            modelBuilder.Entity("SmartHome.Models.Device", b =>
                {
                    b.HasOne("SmartHome.Models.DeviceType", "deviceType")
                        .WithMany("Devices")
                        .HasForeignKey("DeviceTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SmartHome.Models.Home", "Home")
                        .WithMany("Devices")
                        .HasForeignKey("HomeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("deviceType");

                    b.Navigation("Home");
                });

            modelBuilder.Entity("SmartHome.Models.UserHome", b =>
                {
                    b.HasOne("SmartHome.Models.Home", "Home")
                        .WithMany("UserHomes")
                        .HasForeignKey("HomeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SmartHome.Models.User", "User")
                        .WithMany("UserHomes")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Home");

                    b.Navigation("User");
                });

            modelBuilder.Entity("SmartHome.Models.DeviceType", b =>
                {
                    b.Navigation("Devices");
                });

            modelBuilder.Entity("SmartHome.Models.Home", b =>
                {
                    b.Navigation("Devices");

                    b.Navigation("UserHomes");
                });

            modelBuilder.Entity("SmartHome.Models.User", b =>
                {
                    b.Navigation("UserHomes");
                });
#pragma warning restore 612, 618
        }
    }
}
