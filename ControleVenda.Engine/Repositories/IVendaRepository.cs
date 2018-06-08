using ControleVenda.Engine.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace ControleVenda.Engine.Repositories
{
    public interface IVendaRepository : IGenericRepository<Venda>, IDisposable
    {
    }
}
