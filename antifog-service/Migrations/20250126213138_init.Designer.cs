﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using antifog_service.Models;
using antifog_service.Models.Primary;

#nullable disable

namespace antifog_service.Migrations
{
    [DbContext(typeof(AntifogDBContext))]
    [Migration("20250126213138_init")]
    partial class init
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasDefaultSchema("default")
                .HasAnnotation("ProductVersion", "9.0.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("Grizhla.UtilitiesCore.EF.Basic.GrizhlaHistory", b =>
                {
                    b.Property<Guid>("HistoryId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<int>("DBMethod")
                        .HasColumnType("integer");

                    b.Property<string>("ModelName")
                        .IsRequired()
                        .HasColumnType("varchar(63)");

                    b.Property<string>("NewState")
                        .HasColumnType("jsonb");

                    b.Property<string>("OldState")
                        .HasColumnType("jsonb");

                    b.Property<DateTime>("OnTime")
                        .HasColumnType("timestamp");

                    b.Property<string>("PrimaryKey")
                        .IsRequired()
                        .HasColumnType("varchar(63)");

                    b.HasKey("HistoryId");

                    b.ToTable("GrizhlaHistory", "default");
                });

            modelBuilder.Entity("antifog_service.Models.Basics.FoggyInformation", b =>
                {
                    b.Property<Guid>("FoggyInformationId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("timestamp");

                    b.Property<string>("InformationText")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTime?>("LastModified")
                        .HasColumnType("timestamp");

                    b.Property<FoggyInformationTagInfo>("TagInfo")
                        .HasColumnType("jsonb");

                    b.HasKey("FoggyInformationId");

                    b.ToTable("FoggyInformation", "default");
                });

            modelBuilder.Entity("antifog_service.Models.Basics.FoggyTag", b =>
                {
                    b.Property<Guid>("FoggyTagId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("timestamp");

                    b.Property<FoggyTagDataStructure>("FoggyTagDataStructure")
                        .HasColumnType("jsonb");

                    b.Property<DateTime?>("LastModified")
                        .HasColumnType("timestamp");

                    b.Property<string>("TagName")
                        .IsRequired()
                        .HasColumnType("varchar(127)");

                    b.HasKey("FoggyTagId");

                    b.ToTable("FoggyTag", "default");
                });
#pragma warning restore 612, 618
        }
    }
}
