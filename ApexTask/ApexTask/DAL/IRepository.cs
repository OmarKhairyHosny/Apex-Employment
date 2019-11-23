using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApexTask.DAL
{
    public interface IRepository<TEntity>
    {
        TEntity Add(TEntity entity);
        IQueryable<TEntity> GetAll();
        List<TEntity> GetAllBind();
        TEntity GetById(params object[] id);
        void Update(TEntity entity);
        void Delete(TEntity entity);
    }
}
