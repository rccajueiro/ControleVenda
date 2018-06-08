using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ControleVenda.Engine.Entities
{
    public class Venda
    {
        public const int CONFIGURATION_VENDA_CODIGO_MAX_LENGTH = 20;

        public int Id { get; private set; }
        public string Codigo { get; private set; }
        public DateTime DataHora { get; private set; }
        public int ClienteId { get; private set; }

        public virtual Cliente Cliente { get; private set; }
        public virtual ICollection<VendaItem> VendaItems { get; private set; }
        public virtual decimal Total => VendaItems.Sum(items => items.ValorTotal);
        public virtual int QuantidadeTotal => VendaItems.Sum(items => items.Quantidade);

        public Venda() {}

        public Venda(string codigo, Cliente cliente)
        {
            Codigo = codigo;
            DataHora = DateTime.Now;
            Cliente = cliente;
            VendaItems = new List<VendaItem>();
        }

        public void SetDataHora(DateTime dataHora)
        {
            DataHora = dataHora;
        }

        public void AddVendaItem(VendaItem vendaItem)
        {
            VendaItems.Add(vendaItem);
        }

        public void RemoveVendaItem(VendaItem vendaItem)
        {
            VendaItems.Remove(vendaItem);
        }

        public decimal GetTotal()
        {
            decimal Total = 0;

            foreach ( VendaItem vendaItem in VendaItems)
            {
                Total += vendaItem.GetValorTotal();
            }

            return Total;
        }
    }
}
