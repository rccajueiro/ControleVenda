using ControleVenda.Util.Validations;
using System;
using System.Collections.Generic;
using System.Text;

namespace ControleVenda.Engine.Entities
{
    public class VendaItem
    {
        public const string EXCEPTION_MESSAGE_VENDA_ITEM_PRODUTO_REQUIRED = "Produto é obrigatório";

        public const string EXCEPTION_MESSAGE_VENDA_ITEM_VALOR_UNITARIO_REQUIRED = "Valor unitário é obrigatório";
        public const string EXCEPTION_MESSAGE_VENDA_ITEM_VALOR_UNITARIO_MIN_VALUE = "Valor unitátorio deve ser no mínimo #minDecimalValue#";

        public const string EXCEPTION_MESSAGE_VENDA_ITEM_QUANTIDADE_REQUIRED = "Quantidade é obrigatório";
        public const string EXCEPTION_MESSAGE_VENDA_ITEM_QUANTIDADE_MIN_VALUE = "Quantidade deve ser no mínimo #minIntValue#";

        public int Id { get; private set; }
        public int ProdutoId { get; private set; }
        public decimal ValorUnitario { get; private set; }
        public int Quantidade { get; private set; }
        public int VendaId { get; private set; }

        public virtual Produto Produto { get; private set; }
        public virtual Venda Venda { get; private set; }
        public virtual decimal ValorTotal => Quantidade * ValorUnitario;

        public VendaItem() { }

        public VendaItem(Produto produto, decimal valorUnitario, int quantidade)
        {
            /* Produto */
            GenericValidation.ObjectNotNull(produto, EXCEPTION_MESSAGE_VENDA_ITEM_PRODUTO_REQUIRED);

            /* Valor unitário */
            GenericValidation.ObjectNotNull(valorUnitario, EXCEPTION_MESSAGE_VENDA_ITEM_VALOR_UNITARIO_REQUIRED);
            GenericValidation.DecimalMinValue(valorUnitario, (decimal)0.01, EXCEPTION_MESSAGE_VENDA_ITEM_VALOR_UNITARIO_MIN_VALUE);

            /* Quantidade */
            GenericValidation.ObjectNotNull(quantidade, EXCEPTION_MESSAGE_VENDA_ITEM_QUANTIDADE_REQUIRED);
            GenericValidation.IntMinValue(quantidade, 1, EXCEPTION_MESSAGE_VENDA_ITEM_QUANTIDADE_MIN_VALUE);

            Produto = produto;
            ValorUnitario = valorUnitario;
            Quantidade = quantidade;
        }

        public static VendaItem InstanceVendaItemWithFields(Produto produto, decimal valorUnitario, int quantidade)
        {
            return new VendaItem(produto, valorUnitario, quantidade);
        }

        public decimal GetValorTotal()
        {
            return Quantidade * ValorUnitario;
        }
    }
}
