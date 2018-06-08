using System;
using ControleVenda.Util.Validations;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ControleVenda.Util.Test.Validations
{
    [TestClass]
    public class EmailValidationTest
    {
        [TestMethod]
        public void TestEmailValid()
        {
            EmailValidation.IsValid("ricardo@rcajueiro.eti.br");
            EmailValidation.IsValid("ricardo.cajueiro@gmail.com");
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException), EmailValidation.EXCEPTION_MESSAGE_EMAIL_IS_NOT_VALID)]
        public void TestEmailInvalid()
        {
            EmailValidation.IsValid("ricardo.rcajueiro.eti.br");
        }
    }
}
