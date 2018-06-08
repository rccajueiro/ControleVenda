using System;
using ControleVenda.Util.Validations;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ControleVenda.Util.Test.Validations
{
    [TestClass]
    public class CpfValidationTest
    {
        [TestMethod]
        public void TestCpfValid()
        {
            CpfValidation.IsValid("329.191.658-10");
        }
        [TestMethod]
        [ExpectedException(typeof(ArgumentException), CpfValidation.EXECEPTION_MESSAGE_CPF_IS_NOT_VALID)]
        public void TestCpfInvalid()
        {
            CpfValidation.IsValid("123.123.123-12");
        }
    }
}
