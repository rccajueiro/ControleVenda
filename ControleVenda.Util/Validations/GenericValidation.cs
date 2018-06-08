using System;
using System.Collections.Generic;
using System.Text;

namespace ControleVenda.Util.Validations
{
    public class GenericValidation
    {
        public static void StringIsNullOrEmpty(string stringValue, string message)
        {
            if (string.IsNullOrEmpty(stringValue)) throw new ArgumentNullException(message + ": " + stringValue);
        }

        public static void StringMinLength(string stringValue, int minLength, string message)
        {
            if (stringValue.Length < minLength) throw new ArgumentOutOfRangeException(message.Replace("#minLength#", minLength.ToString()) + ": " + stringValue);
        }

        public static void StringMaxLength(string stringValue, int maxLength, string message)
        {
            if (stringValue.Length > maxLength) throw new ArgumentOutOfRangeException(message.Replace("#maxLength#", maxLength.ToString()) + ": " + stringValue);
        }

        public static void ObjectNotNull(object objectValue, string message)
        {
            if (objectValue == null) throw new ArgumentNullException(message + ": null");
        }

        public static void DecimalMinValue(decimal decimalValue, decimal minDecimalValue, string message)
        {
            if (decimalValue < minDecimalValue) throw new ArgumentOutOfRangeException(message.Replace("#minDecimalValue#", minDecimalValue.ToString()) + ": " + decimalValue);
        }

        public static void IntMinValue(int intValue, int minIntValue, string message)
        {
            if (intValue < minIntValue) throw new ArgumentOutOfRangeException(message.Replace("#minIntValue#", minIntValue.ToString()) + ": " + intValue);
        }
    }
}
