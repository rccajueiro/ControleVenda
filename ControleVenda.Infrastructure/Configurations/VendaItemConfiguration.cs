using ControleVenda.Engine.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleVenda.Infrastructure.Configurations
{
    public class VendaItemConfiguration : EntityTypeConfiguration<VendaItem>
    {
        public VendaItemConfiguration()
        {
            HasKey(vendaItem => vendaItem.Id);

            Property(vendaItem => vendaItem.Quantidade)
                .IsRequired();

            Property(vendaItem => vendaItem.ValorUnitario)
                .HasPrecision(10, 2)
                .IsRequired();

            HasRequired(vendaItem => vendaItem.Produto)
                .WithMany(vendaItem => vendaItem.VendaItems)
                .HasForeignKey(vendaItem => vendaItem.ProdutoId);

            HasRequired(vendaItem => vendaItem.Venda)
                .WithMany(vendaItem => vendaItem.VendaItems)
                .HasForeignKey(vendaItem => vendaItem.VendaId);
        }
    }
}
