using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Entidades;
using Microsoft.EntityFrameworkCore;

namespace Infraestructura.Data
{
    public class Contexto : DbContext
    {
        public Contexto(DbContextOptions<Contexto> options)
        : base(options)
    {
    }
        public DbSet<Villa> Villas{get; set;}



        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Villa>().HasData(
                new Villa(){
                    Id = 1,
                    Nombre="Villa Real",
                    Detalle="Detalle",
                    ImagenUrl="",
                    Ocupantes=5,
                    MetrosCuadrados=20,
                    Tarifa=4,
                    Amenidad="",
                    FechaCreacion=DateTime.Now,
                    FechaActualizacion=DateTime.Now
                },
                new Villa(){
                    Id = 2,
                    Nombre="Villa Atlantis",
                    Detalle="Detalle",
                    ImagenUrl="",
                    Ocupantes=5,
                    MetrosCuadrados=20,
                    Tarifa=4,
                    Amenidad="",
                    FechaCreacion=DateTime.Now,
                    FechaActualizacion=DateTime.Now
                }
            );
        }
    }
}