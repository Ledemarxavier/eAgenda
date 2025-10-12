using eAgenda.Dominio.ModuloCategoria;
using eAgenda.Dominio.ModuloCompromisso;
using eAgenda.Dominio.ModuloContato;
using eAgenda.Dominio.ModuloDespesa;
using eAgenda.Dominio.ModuloTarefa;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace eAgenda.Infraestrutura.Arquivos.Compartilhado
{
    public class ContextoDados
    {
        public string pastaArmazenamento = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "e-Agenda");

        private string arquivoArmazenamento = "dados.json";

        public List<Tarefa> Tarefas { get; set; }
        public List<Categoria> Categorias { get; set; }
        public List<Despesa> Despesas { get; set; }
        public List<Contato> Contatos { get; set; }
        public List<Compromisso> Compromissos { get; set; }

        public ContextoDados()
        {
            Tarefas = new List<Tarefa>();
            Categorias = new List<Categoria>();
            Despesas = new List<Despesa>();
            Contatos = new List<Contato>();
            Compromissos = new List<Compromisso>();
        }

        public string ObterArquivoDados()
        {
            if (!Directory.Exists(pastaArmazenamento))
                Directory.CreateDirectory(pastaArmazenamento);
            return Path.Combine(pastaArmazenamento, arquivoArmazenamento);
        }

        public ContextoDados(bool carregarDados) : this()
        {
            if (carregarDados)
                Carregar();
        }

        public void Salvar()
        {
            string caminhoCompleto = Path.Combine(pastaArmazenamento, arquivoArmazenamento);

            JsonSerializerOptions jsonOptions= new JsonSerializerOptions();

            jsonOptions.WriteIndented = true;
            jsonOptions.ReferenceHandler = ReferenceHandler.Preserve;

            string json = JsonSerializer.Serialize(this, jsonOptions);

            if (!Directory.Exists(pastaArmazenamento))
                Directory.CreateDirectory(pastaArmazenamento);
            File.WriteAllText(caminhoCompleto, json);
        }

        public void Carregar()
        {
            string caminhoCompleto = Path.Combine(pastaArmazenamento, arquivoArmazenamento);
            if (File.Exists(caminhoCompleto) == false)
                return;
            string json = File.ReadAllText(caminhoCompleto);
            JsonSerializerOptions jsonOptions = new JsonSerializerOptions();
            jsonOptions.ReferenceHandler = ReferenceHandler.Preserve;
            ContextoDados? contextoDados = JsonSerializer.Deserialize<ContextoDados>(json, jsonOptions);
            if (contextoDados == null)
                return;
            Tarefas = contextoDados.Tarefas;
            Categorias = contextoDados.Categorias;
            Despesas = contextoDados.Despesas;
            Contatos = contextoDados.Contatos;
            Compromissos = contextoDados.Compromissos;
        }
    }
}
