using System;
using ControleVenda.Util.Validations;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ControleVenda.Util.Test.Validations.Test
{
    [TestClass]
    public class TelefoneValidationTest
    {
        [TestMethod]
        public void TestTelefoneValid()
        {
            TelefoneValidation.IsValid("035 99135-4700"); // Meu celular
            TelefoneValidation.IsValid("0800 891 3294"); // MasterCard/Atendimento ao cliente
            TelefoneValidation.IsValid("190"); // Emergência - SSP-SP
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException), TelefoneValidation.EXCEPTION_MESSAGE_TELEFONE_IS_NOT_VALID)]
        public void TestTelefoneInvalid()
        {
            TelefoneValidation.IsValid("555 5555");
        }
    }
}
