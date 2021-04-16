using DataAccess;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Repository
{
    public class Repository<T> : IRepository<T> where T : BaseEntity
    {
        readonly ApplicationContext context;
        readonly DbSet<T> entities;

        public Repository(ApplicationContext context)
        {
            this.context = context;
            this.entities = context.Set<T>();
        }

        public T Get(int id)
        {
            return entities.SingleOrDefault(e => e.Id == id);
        }

        public IEnumerable<T> GetAll()
        {
            return entities.AsEnumerable();
        }
    }
}
