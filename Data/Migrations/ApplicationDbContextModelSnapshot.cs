﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using RegistroDeCompetencia2019.Data;

namespace RegistroDeCompetencia2019.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.0.1");

            modelBuilder.Entity("RegistroDeCompetencia2019.Models.Estudiante", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("TEXT");

                    b.Property<string>("ApellidoMaterno")
                        .HasColumnType("TEXT");

                    b.Property<string>("ApellidoPaterno")
                        .HasColumnType("TEXT");

                    b.Property<string>("Email")
                        .HasColumnType("TEXT");

                    b.Property<string>("Nombre")
                        .HasColumnType("TEXT");

                    b.Property<int>("RecintoId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("RecintoId");

                    b.ToTable("Estudiantes");
                });

            modelBuilder.Entity("RegistroDeCompetencia2019.Models.Recinto", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Nombre")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Recintos");
                });

            modelBuilder.Entity("RegistroDeCompetencia2019.Models.Estudiante", b =>
                {
                    b.HasOne("RegistroDeCompetencia2019.Models.Recinto", "Recinto")
                        .WithMany()
                        .HasForeignKey("RecintoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}