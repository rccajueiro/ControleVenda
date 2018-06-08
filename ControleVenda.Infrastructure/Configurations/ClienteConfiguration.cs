using ControleVenda.Engine.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Infrastructure.Annotations;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleVenda.Infrastructure.Configurations
{
    public class ClienteConfiguration : EntityTypeConfiguration<Cliente>
    {
        public ClienteConfiguration()
        {
            HasKey(cliente => cliente.Id);

            Property(cliente => cliente.Nome)
                .HasMaxLength(Cliente.CONFIGURATION_CLIENTE_NOME_MAX_LENGTH)
                .IsRequired();

            Property(cliente => cliente.Cpf)
                .HasMaxLength(Cliente.CONFIGURATION_CLIENTE_CPF_MAX_LENGTH)
                .HasColumnAnnotation(
                    IndexAnnotation.AnnotationName,
                    new IndexAnnotation(new IndexAttribute("Cpf_idx", 1) { IsUnique = true }))
                .IsRequired();

            Property(cliente => cliente.DataNascimento);

            Property(cliente => cliente.Email)
                .HasMaxLength(Cliente.CONFIGURATION_CLIENTE_EMAIL_MAX_LENGTH);

            Property(cliente => cliente.Telefone)
                .HasMaxLength(Cliente.CONFIGURATION_CLIENTE_TELEFONE_MAX_LENGTH);

        }
    }
}
