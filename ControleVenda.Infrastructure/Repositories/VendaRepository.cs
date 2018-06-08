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
    public class VendaRepository : IVendaRepository, IDisposable
    {
        protected readonly DataContext context;

        public VendaRepository()
        {
            context = new DataContext();
        }

        public void Add(Venda entity)
        {
            context.Venda.Add(entity);
        }

        public int Count()
        {
            return context.Venda.Count();
        }

        public void Delete(Venda entity)
        {
            context.Venda.Remove(entity);
        }

        public void Dispose()
        {
            context.Dispose();
        }

        public void Edit(Venda entity)
        {
            context.Entry<Venda>(entity).State = EntityState.Modified;
        }

        public Venda Get(int id)
        {
            return context.Venda
                .Include(vendaItem => vendaItem.VendaItems)
                .Include(cliente => cliente.Cliente)
                .Include(vendaItem => vendaItem.VendaItems.Select(produto => produto.Produto))
                .FirstOrDefault(venda=>venda.Id == id);
        }

        public List<Venda> GetAll()
        {
            return context.Venda
                .Include(vendaItem => vendaItem.VendaItems)
                .Include(cliente => cliente.Cliente)
                .Include(vendaItem => vendaItem.VendaItems.Select(produto => produto.Produto))
                .ToList();
        }

        public void Save(Venda entity)
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
    }
}
