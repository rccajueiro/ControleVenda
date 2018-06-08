using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ControleVenda.MVC.Models
{
    public class VendaItemModel
    {
        
        public int Id { get; set; }
        public int ProdutoId { get; set; }
        public decimal ValorUnitario { get; set; }
        public int Quantidade { get; set; }
        public int VendaId { get; set; }

        public virtual ProdutoModel Produto { get; set; }
        public virtual VendaModel Venda { get; set; }
        public virtual decimal ValorTotal => Quantidade * ValorUnitario;
    }
}