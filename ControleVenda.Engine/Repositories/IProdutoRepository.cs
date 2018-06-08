using ControleVenda.Engine.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace ControleVenda.Engine.Repositories
{
    public interface IProdutoRepository : IGenericRepository<Produto>, IDisposable
    {
        Produto GetByNome(string nome);
        bool NomeExists(string nome);

        List<Produto> SearchByNome(string nome);
    }
}
