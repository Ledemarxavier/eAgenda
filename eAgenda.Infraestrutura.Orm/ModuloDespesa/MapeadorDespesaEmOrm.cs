using eAgenda.Dominio.ModuloDespesa;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eAgenda.Infraestrutura.Orm.ModuloDespesa
{
    public class MapeadorDespesaEmOrm : IEntityTypeConfiguration<Despesa>
    {
        public void Configure(EntityTypeBuilder<Despesa> builder)
        {
            builder.ToTable("TBDespesa");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Descricao)
                   .HasMaxLength(200)
                   .IsRequired();

            builder.Property(x => x.Valor)
                   .HasPrecision(18, 2)
                   .IsRequired();

            builder.Property(x => x.DataOcorencia)
                   .IsRequired();

            builder.Property(x => x.FormaPagamento)
                   .IsRequired();

            builder.HasMany(x => x.Categorias)
                   .WithMany(c => c.Despesas)
                   .UsingEntity(e => e.ToTable("TBCategoria_TBDespesa"));
        }
    }
}
