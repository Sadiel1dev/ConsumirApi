using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Core.Repositorio;
using Infraestructura.Data;
using Microsoft.EntityFrameworkCore;

namespace Infraestructura
{
    public class Repositorio<T> : IRepositorio<T> where T : class
    {

        private readonly Contexto contexto;
        internal DbSet<T> dbSet;

        public Repositorio(Contexto contexto)
        {
            this.contexto = contexto;
            this.dbSet = contexto.Set<T>();
        }

        public async Task Crear(T entidad)
        {
            await dbSet.AddAsync(entidad);
            await Grabar();
        }

        public async Task<T> Get(Expression<Func<T, bool>> filtro = null)
        {
            IQueryable<T> query = dbSet;
            if (filtro!=null)
            {
                query=query.Where(filtro);
            }

            return await query.FirstOrDefaultAsync();
        }

        public async Task<List<T>> GetAll(Expression<Func<T, bool>> filtro = null)
        {
            IQueryable<T> query = dbSet;
            if (filtro!=null)
            {
                query=query.Where(filtro);
            }

            return await query.ToListAsync();
        }

        public async Task Grabar()
        {
            await contexto.SaveChangesAsync();
        }

        public async Task Remove(T entidad)
        {
            dbSet.Remove(entidad);
            await Grabar();
        }
    }
}