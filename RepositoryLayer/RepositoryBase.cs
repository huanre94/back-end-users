using Microsoft.EntityFrameworkCore;
using RepositoryLayer.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryLayer
{
    public abstract class RepositoryBase<T> : IRepositoryBase<T> where T : class
    {
        protected PetStoreContext PetStoreContext;

        protected RepositoryBase(PetStoreContext petStoreContext)
        {
            PetStoreContext = petStoreContext;
        }

        public void Create(T entity) => PetStoreContext.Set<T>().Add(entity);

        public void Delete(T entity) => PetStoreContext.Set<T>().Remove(entity);

        public void Update(T entity) => PetStoreContext.Set<T>().Update(entity);

        public IQueryable<T> FindAll(bool trackChanges = false)
        {
            return !trackChanges ? PetStoreContext.Set<T>().AsNoTracking() : PetStoreContext.Set<T>();
        }

        public IQueryable<T> FindByCondition(Expression<Func<T, bool>> expression, bool trackChanges= false)
        {
            return !trackChanges ? PetStoreContext.Set<T>().Where(expression).AsNoTracking() : PetStoreContext.Set<T>().Where(expression);
        }

    }
}
