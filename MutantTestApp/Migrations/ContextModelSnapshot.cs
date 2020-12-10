﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using MutantTestApp.Models;

namespace MutantTestApp.Migrations
{
    [DbContext(typeof(Context))]
    partial class ContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("MutantTestApp.Models.Address", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("City")
                        .HasColumnType("text");

                    b.Property<int>("GeolocationId")
                        .HasColumnType("int");

                    b.Property<string>("Street")
                        .HasColumnType("text");

                    b.Property<string>("Suite")
                        .HasColumnType("text");

                    b.Property<string>("Zipcode")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("GeolocationId");

                    b.ToTable("Adresses");
                });

            modelBuilder.Entity("MutantTestApp.Models.Company", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Bs")
                        .HasColumnType("text");

                    b.Property<string>("CatchPhrase")
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Companies");
                });

            modelBuilder.Entity("MutantTestApp.Models.Geolocation", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Lat")
                        .HasColumnType("text");

                    b.Property<string>("Lng")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Geolocations");
                });

            modelBuilder.Entity("MutantTestApp.Models.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("AddressId")
                        .HasColumnType("int");

                    b.Property<int>("CompanyId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.Property<string>("Phone")
                        .HasColumnType("text");

                    b.Property<string>("Username")
                        .HasColumnType("text");

                    b.Property<string>("Website")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("AddressId");

                    b.HasIndex("CompanyId");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("MutantTestApp.Models.Address", b =>
                {
                    b.HasOne("MutantTestApp.Models.Geolocation", "Geolocation")
                        .WithMany("Addresses")
                        .HasForeignKey("GeolocationId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("MutantTestApp.Models.User", b =>
                {
                    b.HasOne("MutantTestApp.Models.Address", "Address")
                        .WithMany("Users")
                        .HasForeignKey("AddressId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MutantTestApp.Models.Company", "Company")
                        .WithMany("Users")
                        .HasForeignKey("CompanyId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
