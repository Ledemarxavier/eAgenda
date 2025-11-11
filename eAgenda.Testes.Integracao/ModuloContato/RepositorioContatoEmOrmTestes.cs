using eAgenda.Dominio.ModuloContato;
using eAgenda.Infraestrutura.Orm;
using eAgenda.Infraestrutura.Orm.ModuloContato;

namespace eAgenda.Testes.Integracao
{
    [TestClass]
    public sealed class RepositorioContatoEmOrmTestes
    {
        private static readonly AppDbContext dbContext = AppDbContextFactory.CriarDbContext("Data Source=(LocalDB)\\MSSQLLocalDB;Initial Catalog=eAgendaTestDb;Integrated Security=True");
        private static readonly RepositorioContatoEmOrm repositorioContato = new RepositorioContatoEmOrm(dbContext);

        [TestInitialize]
        public void ConfigurarTestes()
        {
            dbContext.Database.EnsureCreated();

            dbContext.Tarefas.RemoveRange(dbContext.Tarefas);
            dbContext.Despesas.RemoveRange(dbContext.Despesas);
            dbContext.Categorias.RemoveRange(dbContext.Categorias);
            dbContext.Compromissos.RemoveRange(dbContext.Compromissos);
            dbContext.Contatos.RemoveRange(dbContext.Contatos);

            dbContext.SaveChanges();
        }

        [TestMethod]
        public void Deve_CadastrarRegistro_ComSucesso()
        {
            Contato contato = new Contato(
                "Julio Teste",
                "(49) 98533-3334",
                "julio@email.com",
                "Academia do Programador",
                "Testador"
            );

            repositorioContato.CadastrarRegistro(contato);

            Contato? contatoSelecionado = repositorioContato.SelecionarRegistroPorId(contato.Id);

            // Asserção
            Assert.AreEqual(contato, contatoSelecionado);
        }

        [TestMethod]
        public void Deve_RetornarNulo_Ao_SelecionarRegistroPoId_ComIdErrado()
        {
            Contato contato = new Contato(
               "Julio Teste",
                "(49) 98533-3334",
                "julio@email.com",
                "Academia do Programador",
                "Testador"
            );

            repositorioContato.CadastrarRegistro(contato);

            Contato? contatoSelecionado = repositorioContato.SelecionarRegistroPorId(Guid.NewGuid());

            // Asserção
            Assert.AreNotEqual(contato, contatoSelecionado);
        }

        [TestMethod]
        public void Deve_EditarRegistro_ComSucesso()
        {
            // Padrão AAA
            // Arranjo
            Contato contatoOriginal = new Contato(
               "Julio Teste",
                "(49) 98533-3334",
                "julio@email.com",
                "Academia do Programador",
                "Testador"
            );

            repositorioContato.CadastrarRegistro(contatoOriginal);

            Contato contatoEditado = new Contato(
                "Julio Teste-edit",
                "(49) 98533-3334",
                "julio@email.com",
                "Academia do Programador",
                "Testador"
            );


            bool registroEditado = repositorioContato.EditarRegistro(contatoOriginal.Id, contatoEditado);


            Contato? contatoSelecionado = repositorioContato.SelecionarRegistroPorId(contatoOriginal.Id);

            Assert.IsTrue(registroEditado);
            Assert.AreEqual(contatoOriginal, contatoSelecionado);
        }

        [TestMethod]
        public void Deve_ExcluirRegistro_ComSucesso()
        {
            // Arranjo
            Contato contatoOriginal = new Contato(
                "Julio Teste",
                "(49) 98533-3334",
                "julio@email.com",
                "Academia do Programador",
                "Testador"
            );

            bool registroExcluido = repositorioContato.ExcluirRegistro(contatoOriginal.Id);

            // Ação
            repositorioContato.ExcluirRegistro(contatoOriginal.Id);

            // Asserção
            Contato? contatoSelecionado = repositorioContato.SelecionarRegistroPorId(contatoOriginal.Id);

            Assert.IsTrue(registroExcluido);
            Assert.IsNull(contatoSelecionado);
        }
    }
}
