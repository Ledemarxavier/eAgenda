using eAgenda.Dominio.ModuloDespesa;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eAgenda.Infraestrutura.Orm.ModuloDespesa
{
    public class RepositorioDespesaEmOrm : IRepositorioDespesa
    {
        private readonly AppDbContext context;
        private readonly DbSet<Despesa> registros;

        public RepositorioDespesaEmOrm(AppDbContext context)
        {
            this.context = context;
            registros = context.Despesas;
        }

        public void CadastrarRegistro(Despesa novoRegistro)
        {
            registros.Add(novoRegistro);

            context.SaveChanges();
        }

        public bool EditarRegistro(Guid idRegistro, Despesa registroEditado)
        {
            var registroSelecionado = SelecionarRegistroPorId(idRegistro);

            if (registroSelecionado is null)
                return false;

            registroSelecionado.AtualizarRegistro(registroEditado);

            context.SaveChanges();

            return true;
        }

        public bool ExcluirRegistro(Guid idRegistro)
        {
            var registroSelecionado = SelecionarRegistroPorId(idRegistro);

            if (registroSelecionado is null)
                return false;

            registros.Remove(registroSelecionado);

            context.SaveChanges();

            return true;
        }

        public Despesa? SelecionarRegistroPorId(Guid idRegistro)
        {
            return registros.Include(c => c.Categorias).FirstOrDefault(x => x.Id == idRegistro);
        }

        public List<Despesa> SelecionarRegistros()
        {
            return registros.Include(c => c.Categorias).ToList();
        }
    }
}
