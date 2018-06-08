using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace ControleVenda.Util.Validations
{
   public class TelefoneValidation
    {
        public const string EXCEPTION_MESSAGE_TELEFONE_IS_NOT_VALID = "Telefone inválido";

        public static void IsValid(string telefoneValue)
        {
            if (string.IsNullOrEmpty(telefoneValue)) { 
                Match match = Regex.Match(telefoneValue, "^1\\d\\d(\\d\\d)?$|^0800 ?\\d{3} ?\\d{4}$|^(\\(0?([1-9a-zA-Z][0-9a-zA-Z])?[1-9]\\d\\) ?|0?([1-9a-zA-Z][0-9a-zA-Z])?[1-9]\\d[ .-]?)?(9|9[ .-])?[2-9]\\d{3}[ .-]?\\d{4}$");

                if (!match.Success) throw new ArgumentException(EXCEPTION_MESSAGE_TELEFONE_IS_NOT_VALID);
            }
        }
    }
}
