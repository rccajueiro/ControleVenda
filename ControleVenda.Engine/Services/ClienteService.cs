using ControleVenda.Engine.Entities;
using ControleVenda.Engine.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace ControleVenda.Engine.Services
{
    public class ClienteService
    {
        public readonly IClienteRepository _repository;

        public ClienteService(IClienteRepository repository)
        {
            _repository = repository;
        }

        public Cliente Get(int id)
        {
            return _repository.Get(id);
        }

        public List<Cliente> List()
        {
            return _repository.GetAll();
        }

        public void Save(Cliente cliente)
        {
            _repository.Save(cliente);
        }

        public bool CpfExists(string cpf)
        {
            return _repository.CpfExists(cpf);
        }

        public bool ValidateCpf(string cpf, int id)
        {
            Cliente cliente = _repository.GetByCpf(cpf);
            return cliente == null || cliente.Id == id;
        }
    }
}
