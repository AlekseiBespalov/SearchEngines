﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SearchEngines.Data;

namespace SearchEngines.Migrations
{
    [DbContext(typeof(SearchEnginesDbContext))]
    [Migration("20200307093547_Initial")]
    partial class Initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("SearchEngines.Data.DataModels.SearchEngineDto", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("NameOfSearchEngine")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("SearchEngines");
                });

            modelBuilder.Entity("SearchEngines.Data.DataModels.SearchResultDto", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ResultName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ResultUrl")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("SearchEngineId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("SearchEngineId");

                    b.ToTable("SearchResults");
                });

            modelBuilder.Entity("SearchEngines.Data.DataModels.SearchResultDto", b =>
                {
                    b.HasOne("SearchEngines.Data.DataModels.SearchEngineDto", "SearchEngine")
                        .WithMany("SearchResults")
                        .HasForeignKey("SearchEngineId");
                });
#pragma warning restore 612, 618
        }
    }
}
