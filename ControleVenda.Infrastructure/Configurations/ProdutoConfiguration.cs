using ControleVenda.Engine.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleVenda.Infrastructure.Configurations
{
    public class ProdutoConfiguration : EntityTypeConfiguration<Produto>
    {
        public ProdutoConfiguration()
        {
            HasKey(produto => produto.Id);

            Property(produto => produto.Nome)
                .HasMaxLength(Produto.CONFIGURATION_PRODUTO_NOME_MAX_LENGTH)
                .IsRequired();
        }
    }
}
