using ControleVenda.Util.Validations;
using System;
using System.Collections.Generic;
using System.Text;

namespace ControleVenda.Engine.Entities
{
    public class Produto
    {
        public const string EXCEPTION_MESSAGE_PRODUTO_NOME_REQUIRED = "Nome do produto é obrigatório";
        public const string EXCEPTION_MESSAGE_PRODUTO_NOME_MIN_LENGTH = "Nome do produto deve ter no mínimo #minLength# caracteres";
        public const string EXCEPTION_MESSAGE_PRODUTO_NOME_MAX_LENGTH = "Nome do produto deve ter no máximo #maxLength# caracteres";
        public const string EXCEPTION_MESSAGE_PRODUTO_NOME_MIN_MAX_LENGTH = "Nome do produto deve ter no mínimo 3 e no máximo 100 caracteres";
        public const string EXCEPTION_MESSAGE_PRODUTO_NOME_EXISTS = "Nome do produto já existe";

        public const int CONFIGURATION_PRODUTO_NOME_MIN_LENGTH = 3;
        public const int CONFIGURATION_PRODUTO_NOME_MAX_LENGTH = 100;

        public int Id { get; private set; }
        public string Nome { get; private set; }

        public ICollection<VendaItem> VendaItems { get; private set; }

        public Produto() { }

        public Produto(string nome) {
            ValidateNome(nome);

            Nome = nome;
        }

        public static Produto InstanceProdutoWithFields(string nome)
        {
            return new Produto(nome);
        }
        public void SetNome(string nome)
        {
            ValidateNome(nome);
            Nome = nome;
        }
        public void ValidateNome(string nome)
        {
            GenericValidation.StringIsNullOrEmpty(nome, EXCEPTION_MESSAGE_PRODUTO_NOME_REQUIRED);
            GenericValidation.StringMinLength(nome, CONFIGURATION_PRODUTO_NOME_MIN_LENGTH, EXCEPTION_MESSAGE_PRODUTO_NOME_MIN_LENGTH);
            GenericValidation.StringMaxLength(nome, CONFIGURATION_PRODUTO_NOME_MAX_LENGTH, EXCEPTION_MESSAGE_PRODUTO_NOME_MAX_LENGTH);
        }
    }
}
