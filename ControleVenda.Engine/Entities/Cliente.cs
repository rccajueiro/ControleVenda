using ControleVenda.Util.Validations;
using System;
using System.Collections.Generic;
using System.Text;

namespace ControleVenda.Engine.Entities
{
    public class Cliente
    {
        public const string EXCEPTION_MESSAGE_CLIENTE_NOME_REQUIRED = "Nome do cliente é obrigatório";
        public const string EXCEPTION_MESSAGE_CLIENTE_NOME_MIN_LENGTH = "Nome do cliente deve ter no mínimo #minLength# caracteres";
        public const string EXCEPTION_MESSAGE_CLIENTE_NOME_MAX_LENGTH = "Nome do cliente deve ter no máximo #maxLength# caracteres";
        public const string EXCEPTION_MESSAGE_CLIENTE_NOME_MIN_MAX_LENGTH = "Nome do cliente deve ter no mínimo 3 e no máximo 100 caracteres";


        public const string EXCEPTION_MESSAGE_CLIENTE_CPF_REQUIRED = "CPF é obrigatório";
        public const string EXCEPTION_MESSAGE_CLIENTE_CPF_EXISTS = "CPF já cadastrado";

        public const string EXCEPTION_MESSAGE_CLIENTE_DATA_NASCIMENTO_REQUIRED = "Data de nascimento é obrigatório";

        public const string EXCEPTION_MESSAGE_CLIENTE_EMAIL_REQUIRED = "E-mail é obrigatório";

        public const string EXCEPTION_MESSAGE_CLIENTE_TELEFONE_REQUIRED = "Telefone é obrigatório";

        public const int CONFIGURATION_CLIENTE_NOME_MIN_LENGTH = 3;
        public const int CONFIGURATION_CLIENTE_NOME_MAX_LENGTH = 100;

        public const int CONFIGURATION_CLIENTE_CPF_MAX_LENGTH = 11;

        public const int CONFIGURATION_CLIENTE_EMAIL_MAX_LENGTH = 100;

        public const int CONFIGURATION_CLIENTE_TELEFONE_MAX_LENGTH = 15;

        public int Id { get; private set; }
        public string Nome { get; private set; }
        public string Cpf { get; private set; }
        public DateTime DataNascimento { get; private set; }
        public string Email { get; private set; }
        public string Telefone { get; private set; }

        public virtual List<Venda> Vendas { get; private set; }

        public Cliente() { }

        public Cliente(string nome, string cpf, DateTime dataNascimento, string email, string telefone)
        {
            ValidateNome(nome);
            ValidateCpf(cpf);
            ValidateDataNascimento(dataNascimento);
            ValidateEmail(email);
            ValidateTelefone(telefone);

            Nome = nome;
            Cpf = cpf;
            DataNascimento = dataNascimento;
            Email = email;
            Telefone = telefone;
            Vendas = new List<Venda>();
        }

        public void SetNome(string nome)
        {
            ValidateNome(nome);
            Nome = nome;
        }

        public void SetCpf(string cpf)
        {
            ValidateCpf(cpf);
            Cpf = cpf;
        }

        public void SetDataNascimento(DateTime dataNascimento)
        {
            ValidateDataNascimento(dataNascimento);
            DataNascimento = dataNascimento;
        }

        public void SetEmail(string email)
        {
            ValidateEmail(email);
            Email = email;
        }

        public void SetTelefone(string telefone)
        {
            ValidateTelefone(telefone);
            Telefone = telefone;
        }

        protected void ValidateNome(string nome)
        {
            GenericValidation.StringIsNullOrEmpty(nome, EXCEPTION_MESSAGE_CLIENTE_NOME_REQUIRED);
            GenericValidation.StringMinLength(nome, CONFIGURATION_CLIENTE_NOME_MIN_LENGTH, EXCEPTION_MESSAGE_CLIENTE_NOME_MIN_LENGTH);
            GenericValidation.StringMaxLength(nome, CONFIGURATION_CLIENTE_NOME_MAX_LENGTH, EXCEPTION_MESSAGE_CLIENTE_NOME_MAX_LENGTH);
        }

        protected void ValidateCpf(string cpf)
        {
            GenericValidation.StringIsNullOrEmpty(cpf, Cliente.EXCEPTION_MESSAGE_CLIENTE_CPF_REQUIRED);
            CpfValidation.IsValid(cpf);
        }

        protected void ValidateDataNascimento(DateTime dataNascimento)
        {
            GenericValidation.ObjectNotNull(dataNascimento, Cliente.EXCEPTION_MESSAGE_CLIENTE_DATA_NASCIMENTO_REQUIRED);
        }

        protected void ValidateEmail(string email)
        {
            GenericValidation.StringIsNullOrEmpty(email, Cliente.EXCEPTION_MESSAGE_CLIENTE_EMAIL_REQUIRED);
            EmailValidation.IsValid(email);
        }

        protected void ValidateTelefone(string telefone)
        {
            GenericValidation.StringIsNullOrEmpty(telefone, Cliente.EXCEPTION_MESSAGE_CLIENTE_TELEFONE_REQUIRED);
            TelefoneValidation.IsValid(telefone);
        }

        public static Cliente InstanceClienteWithFields(string nome, string cpf, DateTime dataNascimento, string email, string telefone)
        {
            return new Cliente(nome, cpf, dataNascimento, email, telefone);
        }
    }
}
