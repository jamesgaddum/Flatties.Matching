﻿// <auto-generated />
using System;
using Flatties.Matching.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Flatties.Matching.Persistence.Migrations
{
    [DbContext(typeof(FlattiesDbContext))]
    partial class FlattiesDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.10")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Flatties.Matching.Domain.Flat", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("ResidenceId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("ResidenceId");

                    b.ToTable("Flats");
                });

            modelBuilder.Entity("Flatties.Matching.Domain.Flatmate", b =>
                {
                    b.Property<Guid>("FlatId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("FlatId", "UserId");

                    b.HasIndex("UserId");

                    b.ToTable("Flatmates");
                });

            modelBuilder.Entity("Flatties.Matching.Domain.Residence", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.ToTable("Residences");
                });

            modelBuilder.Entity("Flatties.Matching.Domain.Room", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("ResidenceId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("ResidenceId");

                    b.ToTable("Rooms");
                });

            modelBuilder.Entity("Flatties.Matching.Domain.User", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("DateOfBirth")
                        .HasColumnType("datetime2");

                    b.Property<string>("FirebaseUid")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("Flatties.Matching.Domain.Flat", b =>
                {
                    b.HasOne("Flatties.Matching.Domain.Residence", "Residence")
                        .WithMany()
                        .HasForeignKey("ResidenceId");

                    b.Navigation("Residence");
                });

            modelBuilder.Entity("Flatties.Matching.Domain.Flatmate", b =>
                {
                    b.HasOne("Flatties.Matching.Domain.Flat", "Flat")
                        .WithMany("Flatmates")
                        .HasForeignKey("FlatId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Flatties.Matching.Domain.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Flat");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Flatties.Matching.Domain.Residence", b =>
                {
                    b.OwnsOne("Flatties.Matching.Domain.StreetAddress", "StreetAddress", b1 =>
                        {
                            b1.Property<Guid>("ResidenceId")
                                .HasColumnType("uniqueidentifier");

                            b1.Property<string>("City")
                                .HasColumnType("nvarchar(max)");

                            b1.Property<string>("Country")
                                .HasColumnType("nvarchar(max)");

                            b1.Property<string>("State")
                                .HasColumnType("nvarchar(max)");

                            b1.Property<string>("Street")
                                .HasColumnType("nvarchar(max)");

                            b1.Property<string>("ZipCode")
                                .HasColumnType("nvarchar(max)");

                            b1.HasKey("ResidenceId");

                            b1.ToTable("Residences");

                            b1.WithOwner()
                                .HasForeignKey("ResidenceId");
                        });

                    b.Navigation("StreetAddress");
                });

            modelBuilder.Entity("Flatties.Matching.Domain.Room", b =>
                {
                    b.HasOne("Flatties.Matching.Domain.Residence", null)
                        .WithMany("Rooms")
                        .HasForeignKey("ResidenceId");
                });

            modelBuilder.Entity("Flatties.Matching.Domain.Flat", b =>
                {
                    b.Navigation("Flatmates");
                });

            modelBuilder.Entity("Flatties.Matching.Domain.Residence", b =>
                {
                    b.Navigation("Rooms");
                });
#pragma warning restore 612, 618
        }
    }
}
