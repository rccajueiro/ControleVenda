using ControleVenda.Engine.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ControleVenda.MVC.Models
{
    public class ClienteModel
    {
        [Display(Name = "ID")]
        public int Id { get; set; }

        [Display(Name = "Nome")]
        [Required(ErrorMessage = Cliente.EXCEPTION_MESSAGE_CLIENTE_NOME_REQUIRED)]
        [StringLength(Cliente.CONFIGURATION_CLIENTE_NOME_MAX_LENGTH, MinimumLength = Cliente.CONFIGURATION_CLIENTE_NOME_MIN_LENGTH, ErrorMessage=Cliente.EXCEPTION_MESSAGE_CLIENTE_NOME_MIN_MAX_LENGTH)]
        public string Nome { get; set; }

        [Display(Name = "CPF")]
        [Required(ErrorMessage = Cliente.EXCEPTION_MESSAGE_CLIENTE_CPF_REQUIRED)]
        public string Cpf { get; set; }

        [Display(Name = "Data de nascimento")]
        [Required(ErrorMessage = Cliente.EXCEPTION_MESSAGE_CLIENTE_DATA_NASCIMENTO_REQUIRED)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy-MM-dd}")]
        [DataType(DataType.Date, ErrorMessage = "Data em formato inválido")]//
        public DateTime? DataNascimento { get; set; }

        [Display(Name = "E-mail")]
        [Required(ErrorMessage = Cliente.EXCEPTION_MESSAGE_CLIENTE_EMAIL_REQUIRED)]
        public string Email { get; set; }

        [Display(Name = "Nº telefone")]
        [Required(ErrorMessage = Cliente.EXCEPTION_MESSAGE_CLIENTE_TELEFONE_REQUIRED)]
        public string Telefone { get; set; }

        public virtual List<Venda> Vendas { get; private set; }
    }
}