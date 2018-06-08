using ControleVenda.Engine.Entities;
using ControleVenda.Engine.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace ControleVenda.Engine.Services
{
    public class ProdutoService
    {
        public readonly IProdutoRepository _repository;

        public ProdutoService(IProdutoRepository repository)
        {
            _repository = repository;
        }

        public List<Produto> List()
        {
            return _repository.GetAll();
        }

        public object Get(int id)
        {
            return _repository.Get(id);
        }

        public void Save(Produto produto)
        {
            _repository.Save(produto);
        }

        public bool ValidateNome(string nome, int id)
        {
            Produto produto = _repository.GetByNome(nome);

            return produto == null || produto.Id == id;
        }

        public List<Produto> SearchByNome(string nome)
        {
            return _repository.SearchByNome(nome);
        }
    }
}
