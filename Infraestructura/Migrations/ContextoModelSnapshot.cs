﻿// <auto-generated />
using System;
using Infraestructura.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Infraestructura.Migrations
{
    [DbContext(typeof(Contexto))]
    partial class ContextoModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.7")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            MySqlModelBuilderExtensions.AutoIncrementColumns(modelBuilder);

            modelBuilder.Entity("Core.Entidades.Villa", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Amenidad")
                        .HasColumnType("longtext");

                    b.Property<string>("Detalle")
                        .HasColumnType("longtext");

                    b.Property<DateTime>("FechaActualizacion")
                        .HasColumnType("datetime(6)");

                    b.Property<DateTime>("FechaCreacion")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("ImagenUrl")
                        .HasColumnType("longtext");

                    b.Property<double>("MetrosCuadrados")
                        .HasColumnType("double");

                    b.Property<string>("Nombre")
                        .HasColumnType("longtext");

                    b.Property<int>("Ocupantes")
                        .HasColumnType("int");

                    b.Property<double>("Tarifa")
                        .HasColumnType("double");

                    b.HasKey("Id");

                    b.ToTable("Villas");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Amenidad = "",
                            Detalle = "Detalle",
                            FechaActualizacion = new DateTime(2024, 7, 10, 22, 39, 41, 727, DateTimeKind.Local).AddTicks(6190),
                            FechaCreacion = new DateTime(2024, 7, 10, 22, 39, 41, 727, DateTimeKind.Local).AddTicks(6116),
                            ImagenUrl = "",
                            MetrosCuadrados = 20.0,
                            Nombre = "Villa Real",
                            Ocupantes = 5,
                            Tarifa = 4.0
                        },
                        new
                        {
                            Id = 2,
                            Amenidad = "",
                            Detalle = "Detalle",
                            FechaActualizacion = new DateTime(2024, 7, 10, 22, 39, 41, 727, DateTimeKind.Local).AddTicks(6207),
                            FechaCreacion = new DateTime(2024, 7, 10, 22, 39, 41, 727, DateTimeKind.Local).AddTicks(6201),
                            ImagenUrl = "",
                            MetrosCuadrados = 20.0,
                            Nombre = "Villa Atlantis",
                            Ocupantes = 5,
                            Tarifa = 4.0
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
