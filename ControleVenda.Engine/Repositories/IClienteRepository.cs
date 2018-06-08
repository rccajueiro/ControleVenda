using ControleVenda.Engine.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace ControleVenda.Engine.Repositories
{
    public interface IClienteRepository : IGenericRepository<Cliente>, IDisposable
    {
        List<Cliente> SearchByNome(string nome);
        Cliente GetByCpf(string cpf);
        bool CpfExists(string cpf);
    }
}
