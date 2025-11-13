using eAgenda.Dominio.ModuloContato;
using eAgenda.Infraestrutura.Orm;
using eAgenda.Infraestrutura.Orm.ModuloContato;
using eAgenda.Testes.Integracao.Compartilhado;

namespace eAgenda.Testes.Integracao
{
    [TestClass]
    [TestCategory("Testes de Integração de Contato")]
    public sealed class RepositorioContatoEmOrmTestes : TestFixture
    {
       

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

            repositorioContato?.CadastrarRegistro(contato);

            Contato? contatoSelecionado = repositorioContato?.SelecionarRegistroPorId(contato.Id);

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

            Contato? contatoSelecionado = repositorioContato?.SelecionarRegistroPorId(Guid.NewGuid());

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

            repositorioContato?.CadastrarRegistro(contatoOriginal);

            Contato contatoEditado = new Contato(
                "Julio Teste-edit",
                "(49) 98533-3334",
                "julio@email.com",
                "Academia do Programador",
                "Testador"
            );


            bool? registroEditado = repositorioContato?.EditarRegistro(contatoOriginal.Id, contatoEditado);


            Contato? contatoSelecionado = repositorioContato?.SelecionarRegistroPorId(contatoOriginal.Id);

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

            repositorioContato?.CadastrarRegistro(contatoOriginal);

            // Ação
            bool? registroExcluido = repositorioContato?.ExcluirRegistro(contatoOriginal.Id);

            // Asserção
            Contato? contatoSelecionado = repositorioContato?.SelecionarRegistroPorId(contatoOriginal.Id);

            Assert.IsTrue(registroExcluido);
            Assert.IsNull(contatoSelecionado);
        }
    }
}
