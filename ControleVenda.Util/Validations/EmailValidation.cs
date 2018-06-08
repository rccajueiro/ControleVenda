using System;
using System.Collections.Generic;
using System.Net.Mail;
using System.Text;

namespace ControleVenda.Util.Validations
{
    public class EmailValidation
    {
        public const string EXCEPTION_MESSAGE_EMAIL_IS_NOT_VALID = "E-mail inválido";

        public static void IsValid(string emailValue)
        {
            if (!string.IsNullOrEmpty(emailValue)) { 
                try
                {
                    var addr = new MailAddress(emailValue);
                }
                catch
                {
                    throw new ArgumentException(EXCEPTION_MESSAGE_EMAIL_IS_NOT_VALID);
                }
            }
        }
    }
}
