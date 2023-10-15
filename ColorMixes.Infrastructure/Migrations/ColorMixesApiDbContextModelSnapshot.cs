﻿// <auto-generated />
using System;
using ColorMixes.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace ColorMixes.Infrastructure.Migrations
{
    [DbContext(typeof(ColorMixesApiDbContext))]
    partial class ColorMixesApiDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .UseCollation("Modern_Spanish_CI_AS")
                .HasAnnotation("ProductVersion", "7.0.12")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("ColorMixes.Infrastructure.Models.Color", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnOrder(1);

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.ToTable("Colors");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Azul"
                        },
                        new
                        {
                            Id = 2,
                            Name = "Rojo"
                        });
                });

            modelBuilder.Entity("ColorMixes.Infrastructure.Models.Combination", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int?>("FirstColorId")
                        .HasColumnType("int");

                    b.Property<string>("Result")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<int?>("SecondColorId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("FirstColorId");

                    b.HasIndex("SecondColorId");

                    b.ToTable("Combinations");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            FirstColorId = 1,
                            Result = "Morado",
                            SecondColorId = 2
                        });
                });

            modelBuilder.Entity("ColorMixes.Infrastructure.Models.Combination", b =>
                {
                    b.HasOne("ColorMixes.Infrastructure.Models.Color", "FirstColor")
                        .WithMany()
                        .HasForeignKey("FirstColorId");

                    b.HasOne("ColorMixes.Infrastructure.Models.Color", "SecondColor")
                        .WithMany()
                        .HasForeignKey("SecondColorId");

                    b.Navigation("FirstColor");

                    b.Navigation("SecondColor");
                });
#pragma warning restore 612, 618
        }
    }
}
