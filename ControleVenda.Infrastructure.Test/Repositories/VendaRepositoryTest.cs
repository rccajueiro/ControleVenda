using System;
using ControleVenda.Engine.Entities;
using ControleVenda.Infrastructure.Repositories;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ControleVenda.Infrastructure.Test.Repositories
{
    [TestClass]
    public class VendaRepositoryTest
    {
        protected readonly VendaRepository repository;

        public VendaRepositoryTest()
        {
            repository = new VendaRepository();
        }

        [TestMethod]
        public void TestAdd()
        {
            Venda venda = new Venda("00000000001", Cliente.InstanceClienteWithFields("Cliente novo", "21109414056", new DateTime(1988, 9,12), "email@empresa.com", "(35) 98417-9253"));
            venda.AddVendaItem(VendaItem.InstanceVendaItemWithFields(Produto.InstanceProdutoWithFields("Produto 1"), (decimal)10.00, 5));
            venda.AddVendaItem(VendaItem.InstanceVendaItemWithFields(Produto.InstanceProdutoWithFields("Produto 2"), (decimal)20.00, 6));
            venda.AddVendaItem(VendaItem.InstanceVendaItemWithFields(Produto.InstanceProdutoWithFields("Produto 3"), (decimal)30.00, 7));
            venda.AddVendaItem(VendaItem.InstanceVendaItemWithFields(Produto.InstanceProdutoWithFields("Produto 4"), (decimal)40.00, 8));

            repository.Save(venda);
        }
    }
}
