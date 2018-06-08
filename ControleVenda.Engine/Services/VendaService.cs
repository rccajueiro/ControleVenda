using ControleVenda.Engine.Entities;
using ControleVenda.Engine.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace ControleVenda.Engine.Services
{
    public class VendaService
    {
        public readonly IVendaRepository _repository;

        public VendaService(IVendaRepository repository)
        {
            _repository = repository;
        }

        public List<Venda> List()
        {
            return _repository.GetAll();
        }

        public object Get(int id)
        {
            return _repository.Get(id);
        }

        public void Save(Venda Venda)
        {
            _repository.Save(Venda);
        }
    }
}
