using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Entidades;
using Core.Repositorio;
using Infraestructura.Data;

namespace Infraestructura
{
    public class VillaRepositorio : Repositorio<Villa>, IVillaRepositorio
    {
        private readonly Contexto contexto;

        public VillaRepositorio(Contexto contexto):base(contexto)
        {
            this.contexto = contexto;
        }


        public async Task<Villa> Actualizar(Villa entidad)
        {
            entidad.FechaActualizacion=DateTime.Now;
            contexto.Villas.Update(entidad);
            await contexto.SaveChangesAsync();
            return entidad;
        }
    }
}