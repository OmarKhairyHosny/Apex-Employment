using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApexTask.DAL
{
    public class Repository<TEntity> : IRepository<TEntity>
        where TEntity : class 
    {
        DbContext ctx;
        DbSet<TEntity> set;
        public Repository(DbContext ctx)
        {
            this.ctx = ctx;
            set = ctx.Set<TEntity>();
        }

        public TEntity Add(TEntity entity)
        {
            set.Add(entity);
            return entity;
        }

        public void Delete(TEntity entity)
        {
           set.Remove(entity);
        }

        public IQueryable<TEntity> GetAll()
        {
            return set;
        }

        public List<TEntity> GetAllBind()
        {
            return set.ToList();
        }

        public TEntity GetById(params object[] id)
        {
            return set.Find(id);
        }

        public void Update(TEntity entity)
        {
            set.Attach(entity);
            ctx.Entry(entity).State = EntityState.Modified;
        }
    }
}
