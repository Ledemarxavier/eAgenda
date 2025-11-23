using eAgenda.Dominio.ModuloTarefa;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eAgenda.Infraestrutura.Orm.ModuloTarefa
{
    public class MapeadorItemTarefaEmOrm : IEntityTypeConfiguration<ItemTarefa>
    {
        public void Configure(EntityTypeBuilder<ItemTarefa> builder)
        {
            builder.ToTable("TBItemTarefa");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Titulo)
                   .HasMaxLength(100)
                   .IsRequired();

            builder.Property(x => x.Concluido)
                   .IsRequired();

            builder.HasOne(x => x.Tarefa)
                   .WithMany(i => i.Itens)
                   .OnDelete(DeleteBehavior.Cascade)
                   .IsRequired();
        }
    }
}
