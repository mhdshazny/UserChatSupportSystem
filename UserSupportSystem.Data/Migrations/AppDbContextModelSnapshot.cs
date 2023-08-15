﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using UserSupportSystem.Data.DB;

#nullable disable

namespace UserSupportSystem.Data.Migrations
{
    [DbContext(typeof(AppDbContext))]
    partial class AppDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.21")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("UserSupportSystem.Data.DTO.Agent", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("ActiveCount")
                        .HasColumnType("int");

                    b.Property<int?>("AgentTypeId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Status")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("SupportTeamID")
                        .HasColumnType("int");

                    b.Property<string>("Username")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("AgentTypeId");

                    b.HasIndex("SupportTeamID");

                    b.ToTable("Agent");
                });

            modelBuilder.Entity("UserSupportSystem.Data.DTO.AgentRole", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("AgentType")
                        .HasColumnType("int");

                    b.Property<int>("MaxHandleCount")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Role");
                });

            modelBuilder.Entity("UserSupportSystem.Data.DTO.SupportTeams", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"), 1L, 1);

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.Property<int>("TeamType")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.ToTable("SupportTeams");
                });

            modelBuilder.Entity("UserSupportSystem.Data.DTO.Agent", b =>
                {
                    b.HasOne("UserSupportSystem.Data.DTO.AgentRole", "AgentType")
                        .WithMany()
                        .HasForeignKey("AgentTypeId");

                    b.HasOne("UserSupportSystem.Data.DTO.SupportTeams", "SupportTeam")
                        .WithMany()
                        .HasForeignKey("SupportTeamID");

                    b.Navigation("AgentType");

                    b.Navigation("SupportTeam");
                });
#pragma warning restore 612, 618
        }
    }
}
