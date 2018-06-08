using System;
using ControleVenda.Engine.Entities;
using ControleVenda.Infrastructure.Data;
using ControleVenda.Infrastructure.Repositories;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ControleVenda.Infrastructure.Test.Repositories
{
    [TestClass]
    public class ClienteRepositoryTest
    {
        protected readonly ClienteRepository repository; 
        public ClienteRepositoryTest()
        {
            repository = new ClienteRepository();
        }

        [TestMethod]
        public void TestSaveNew()
        {
            repository.Save(Cliente.InstanceClienteWithFields("Ricardo Cajueiro", "04083413000", new DateTime(1986, 2, 5), "ricardo@rcajueiro.eti.br", "(35) 98446-9162"));
        }

        [TestMethod]
        public void TestSaveChange()
        {
            Cliente Cliente = repository.Get(1);
            Cliente.SetNome("Ricardo (alterado)");
            repository.Save(Cliente);
        }

        [TestMethod]
        public void TestGetByCpf()
        {
            string cpf = "32919165810";

            Assert.AreEqual(cpf, repository.GetByCpf(cpf).Cpf);
        }
    }
}
