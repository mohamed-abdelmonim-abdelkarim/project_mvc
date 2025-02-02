﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using task1.data;

#nullable disable

namespace task1.Migrations
{
    [DbContext(typeof(dbcontext))]
    [Migration("20240904223705_d1")]
    partial class d1
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("task1.Models.department", b =>
                {
                    b.Property<int?>("dept_Id")
                        .HasColumnType("int");

                    b.Property<int?>("StudentsId")
                        .HasColumnType("int");

                    b.Property<string>("dept_Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("dept_Id");

                    b.HasIndex("StudentsId");

                    b.ToTable("departments");
                });

            modelBuilder.Entity("task1.Models.student", b =>
                {
                    b.Property<int>("Id")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("address")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("dept_id")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("students");
                });

            modelBuilder.Entity("task1.Models.department", b =>
                {
                    b.HasOne("task1.Models.student", "Students")
                        .WithMany("departments")
                        .HasForeignKey("StudentsId");

                    b.Navigation("Students");
                });

            modelBuilder.Entity("task1.Models.student", b =>
                {
                    b.Navigation("departments");
                });
#pragma warning restore 612, 618
        }
    }
}
