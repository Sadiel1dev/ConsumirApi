using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Core.Repositorio
{
    public interface IRepositorio<T> where T :class
    {
        Task Crear(T entidad);
        Task<List<T>> GetAll(Expression<Func<T, bool>> filtro = null);

        Task<T> Get(Expression<Func<T, bool>> filtro = null);

        Task Remove(T entidad);

        Task Grabar();
    }
}