using ControleVenda.Engine.Entities;
using ControleVenda.Engine.Repositories;
using ControleVenda.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleVenda.Infrastructure.Repositories
{
    public class ProdutoRepository : IProdutoRepository, IDisposable
    {
        protected readonly DataContext context;

        public ProdutoRepository()
        {
            context = new DataContext();
        }

        public void Add(Produto entity)
        {
            context.Produto.Add(entity);
        }

        public int Count()
        {
            return context.Produto.Count();
        }

        public void Delete(Produto entity)
        {
            context.Produto.Remove(entity);
        }

        public void Dispose()
        {
            context.Dispose();
        }

        public void Edit(Produto entity)
        {
            context.Entry<Produto>(entity).State = EntityState.Modified;
        }

        public Produto Get(int id)
        {
            return context.Produto.Find(id);
        }

        public List<Produto> GetAll()
        {
            return context.Produto.ToList();
        }

        public Produto GetByNome(string nome)
        {
            var match = from produto in context.Produto
                        where produto.Nome == nome
                        select produto;

            return match.Count() > 0 ? match.First() : null;
        }

        public bool NomeExists(string nome)
        {
            return GetByNome(nome) != null;
        }

        public void Save(Produto entity)
        {
            if(entity.Id > 0)
            {
                Edit(entity);
            }
            else
            {
                Add(entity);
            }

            context.SaveChanges();
        }

        public List<Produto> SearchByNome(string nome)
        {
            var match = from produto in context.Produto
                        where produto.Nome.StartsWith(nome)
                        orderby produto.Nome ascending
                        select produto;

            return match.ToList();
        }
    }
}
