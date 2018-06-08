using ControleVenda.Engine.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ControleVenda.MVC.Models
{
    public class ProdutoModel
    {
        [Display(Name = "ID")]
        public int Id { get; set; }

        [Display(Name = "Nome")]
        [Required(ErrorMessage = Produto.EXCEPTION_MESSAGE_PRODUTO_NOME_REQUIRED)]
        [StringLength(Produto.CONFIGURATION_PRODUTO_NOME_MAX_LENGTH, MinimumLength = Produto.CONFIGURATION_PRODUTO_NOME_MIN_LENGTH, ErrorMessage = Produto.EXCEPTION_MESSAGE_PRODUTO_NOME_MIN_MAX_LENGTH)]
        public string Nome { get; set; }

        public ICollection<VendaItem> VendaItems { get; private set; }
    }
}