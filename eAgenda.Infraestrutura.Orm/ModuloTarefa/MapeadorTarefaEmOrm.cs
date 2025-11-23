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
    public class MapeadorTarefaEmOrm : IEntityTypeConfiguration<Tarefa>
    {
        public void Configure(EntityTypeBuilder<Tarefa> builder)
        {
            builder.ToTable("TBTarefa");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Titulo)
                   .HasMaxLength(100)
                   .IsRequired();

            builder.Property(x => x.Prioridade)
                   .IsRequired();

            builder.Property(x => x.DataCriacao)
                   .IsRequired();

            builder.Property(x => x.Concluida)
                   .IsRequired();

            builder.Property(x => x.DataConclusao)
                   .IsRequired(false);

            builder.HasMany(x => x.Itens)
                   .WithOne(i => i.Tarefa)
                   .OnDelete(DeleteBehavior.Cascade)
                   .IsRequired();
        }
    }
    
}
