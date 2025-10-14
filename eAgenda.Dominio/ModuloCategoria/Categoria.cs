using eAgenda.Dominio.Compartilhado;
using eAgenda.Dominio.ModuloDespesa;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eAgenda.Dominio.ModuloCategoria;
public class Categoria : EntidadeBase<Categoria>
{
    public string Titulo { get; set; }
    public List<Despesa> Despesas { get; set; }

    public Categoria()
    {
        Despesas = new List<Despesa>();
    }

    public Categoria(string titulo) : this()
    {
        Id = Guid.NewGuid();
        Titulo = titulo;
    }

    public override void AtualizarRegistro(Categoria registroEditado)
    {
        Titulo = registroEditado.Titulo;
    }
}