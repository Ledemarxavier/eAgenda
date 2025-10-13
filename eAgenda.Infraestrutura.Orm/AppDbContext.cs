using eAgenda.Dominio.ModuloContato;
using eAgenda.Infraestrutura.Orm.ModuloContato;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace eAgenda.Infraestrutura.Orm
{
    public class AppDbContext(DbContextOptions options) : DbContext(options)
    {
        public DbSet<Contato> Contatos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new MapeadorContatoEmOrm());

            base.OnModelCreating(modelBuilder);
        }
    }


}
