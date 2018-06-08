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
    public class ClienteRepository : IClienteRepository, IDisposable
    {
        private readonly DataContext context;

        public ClienteRepository()
        {
            context = new DataContext();
        }

        public void Add(Cliente entity)
        {
            context.Cliente.Add(entity);
        }

        public int Count()
        {
            return context.Cliente.Count();
        }

        public bool CpfExists(string cpf)
        {
            return GetByCpf(cpf) != null;
        }

        public void Delete(Cliente entity)
        {
            context.Cliente.Remove(entity);
        }

        public void Dispose()
        {
            context.Dispose();
        }

        public void Edit(Cliente entity)
        {
            context.Entry<Cliente>(entity).State = EntityState.Modified;
        }

        public Cliente Get(int id)
        {
            return context.Cliente.Find(id);
        }

        public List<Cliente> GetAll()
        {
            return context.Cliente.ToList();
        }

        public Cliente GetByCpf(string cpf)
        {
            var match = from cliente in context.Cliente
                        where cliente.Cpf == cpf
                        select cliente;
            
            return match.Count() > 0 ? match.First() : null;
        }

        public void Save(Cliente entity)
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
            Dispose();
        }

        public List<Cliente> SearchByNome(string nome)
        {
            var match = from cliente in context.Cliente
                        where cliente.Nome.StartsWith(nome)
                        orderby cliente.Nome ascending
                        select cliente;

            return match.ToList();
        }
    }
}
