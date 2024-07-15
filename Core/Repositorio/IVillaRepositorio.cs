using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Entidades;

namespace Core.Repositorio
{
    public interface IVillaRepositorio:IRepositorio<Villa>
    {
        Task<Villa> Actualizar(Villa entidad);
    }
}