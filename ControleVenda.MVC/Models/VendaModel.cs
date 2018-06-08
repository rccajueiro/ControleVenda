using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ControleVenda.MVC.Models
{
    public class VendaModel
    {
        public VendaModel()
        {
            VendaItems = new List<VendaItemModel>();
        }

        [Display(Name = "ID")]
        public int Id { get; set; }

        [Display(Name = "Código")]
        public string Codigo { get; set; }

        [Display(Name = "Data")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy-MM-dd hh:mm}")]
        public DateTime DataHora { get; set; }

        [Display(Name = "Cliente")]
        public int ClienteId { get; set; }

        public virtual ClienteModel Cliente { get; set; }
        public virtual ICollection<VendaItemModel> VendaItems { get; set; }

        [Display(Name = "Valor total")]
        public virtual decimal Total => VendaItems.Sum(items => items.ValorTotal);

        [Display(Name = "Quantidade total")]
        public virtual int QuantidadeTotal => VendaItems.Sum(items => items.Quantidade);
    }
}