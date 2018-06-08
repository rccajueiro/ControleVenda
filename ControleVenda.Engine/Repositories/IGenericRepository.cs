using System;
using System.Collections.Generic;
using System.Text;

namespace ControleVenda.Engine.Repositories
{
    public interface IGenericRepository<TEntity> where TEntity : class
    {
        TEntity Get(int id);
        int Count();
        List<TEntity> GetAll();
        void Add(TEntity entity);
        void Delete(TEntity entity);
        void Edit(TEntity entity);
        void Save(TEntity entity);
    }
}
