using ControleVenda.Engine.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleVenda.Infrastructure.Configurations
{
    public class VendaConfiguration : EntityTypeConfiguration<Venda>
    {
        public VendaConfiguration()
        {
            HasKey(venda => venda.Id);

            Property(venda => venda.Codigo)
                .HasMaxLength(Venda.CONFIGURATION_VENDA_CODIGO_MAX_LENGTH)
                .IsRequired();

            Property(venda => venda.DataHora)
                .IsRequired();

            HasRequired(venda => venda.Cliente)
                .WithMany(venda => venda.Vendas)
                .HasForeignKey(venda => venda.ClienteId);
        }
    }
}
