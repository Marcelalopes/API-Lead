﻿// <auto-generated />
using System;
using API.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace api.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20220127125507_initialsTables")]
    partial class initialsTables
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 64)
                .HasAnnotation("ProductVersion", "5.0.12");

            modelBuilder.Entity("API.Models.Address", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<string>("City")
                        .IsRequired()
                        .HasColumnType("varchar(50)");

                    b.Property<string>("District")
                        .IsRequired()
                        .HasColumnType("varchar(50)");

                    b.Property<string>("Number")
                        .IsRequired()
                        .HasColumnType("varchar(10)");

                    b.Property<string>("State")
                        .IsRequired()
                        .HasColumnType("varchar(3)");

                    b.Property<string>("Street")
                        .IsRequired()
                        .HasColumnType("varchar(50)");

                    b.Property<bool>("isActive")
                        .HasColumnType("tinyint(1)");

                    b.HasKey("Id")
                        .HasName("Pk_AddressId");

                    b.ToTable("Adresses");
                });

            modelBuilder.Entity("API.Models.Collaborator", b =>
                {
                    b.Property<string>("CPF")
                        .HasColumnType("varchar(255)");

                    b.Property<Guid>("AddressId")
                        .HasColumnType("char(36)");

                    b.Property<DateTime>("BirthDate")
                        .HasColumnType("datetime");

                    b.Property<string>("Gender")
                        .IsRequired()
                        .HasColumnType("varchar(2)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("varchar(50)");

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasColumnType("varchar(14)");

                    b.Property<bool>("isActive")
                        .HasColumnType("tinyint(1)");

                    b.HasKey("CPF")
                        .HasName("Pk_CollaboratorCpf");

                    b.HasIndex("AddressId");

                    b.ToTable("Contributors");
                });

            modelBuilder.Entity("API.Models.Collaborator", b =>
                {
                    b.HasOne("API.Models.Address", "Address")
                        .WithMany("Collaborator")
                        .HasForeignKey("AddressId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Address");
                });

            modelBuilder.Entity("API.Models.Address", b =>
                {
                    b.Navigation("Collaborator");
                });
#pragma warning restore 612, 618
        }
    }
}
