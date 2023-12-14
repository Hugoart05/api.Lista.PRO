using api.Lista.PRO.Context;
using api.Lista.PRO.Interfaces;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;

namespace api.Lista.PRO.Repository
{
    public class RepositoryBase<T> : IBaseReposiory<T> where T : class
    {
        private readonly ContextData _context;

        public RepositoryBase(ContextData context)
        {
            _context = context;
        }

        public List<T> PegarTodos()
        {
            var lista = _context.Set<T>().AsNoTracking().ToList();
            return lista ;
        }

        public T PegarUm(int id)
        {
            var entity = _context.Set<T>().Find(id);
            return entity;
        }
        public bool Criar(T entity)
        {
            try
            {
                _context.Entry(entity).State = EntityState.Added;
                _context.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool Deletar(T entity)
        {
            try
            {
                _context.Entry(entity).State = EntityState.Deleted;
                _context.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool Editar(T entity)
        {
            try
            {
                _context.Entry(entity).State = EntityState.Modified;
                _context.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

    }
}
