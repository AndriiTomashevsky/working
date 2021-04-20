using DataAccess;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Repository
{
    public class Repository<T> : IRepository<T> where T : BaseEntity, new()
    {
        readonly ApplicationContext context;
        readonly DbSet<T> entities;

        public Repository(ApplicationContext context)
        {
            this.context = context;
            this.entities = context.Set<T>();
        }

        public void Add(T entity)
        {
            context.Add(entity);
            context.SaveChanges();
        }

        public virtual T Get(int id)
        {
            return entities.SingleOrDefault(e => e.Id == id);
        }

        public virtual IEnumerable<T> GetAll()
        {
            return entities.AsEnumerable();
        }

        public virtual IEnumerable<T> GetAll(Func<T, bool> predicate)
        {
            return entities.Where(predicate).AsEnumerable();
        }

        public void Update(T entity)
        {
            context.Entry(entity).State = EntityState.Modified;
            context.SaveChanges();
        }

        public void Remove(int id)
        {
            context.Remove(new T { Id = id });
            context.SaveChanges();
        }
    }
}
