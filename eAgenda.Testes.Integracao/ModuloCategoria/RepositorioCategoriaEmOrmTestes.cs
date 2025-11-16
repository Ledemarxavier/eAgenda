using eAgenda.Dominio.ModuloCategoria;
using eAgenda.Testes.Integracao.Compartilhado;

namespace eAgenda.Testes.Integracao.ModuloCategoria
{
    [TestClass]
    [TestCategory("Testes de Integração de Categoria")]
    public class RepositorioCategoriaEmOrmTestes : TestFixture
    {
        [TestMethod]
        public void Deve_CadastrarRegistro_ComSucesso()
        {

            Categoria categoria = new Categoria("Mercado");

            repositorioCategoria?.CadastrarRegistro(categoria);

            Categoria? categoriaSelecionada = repositorioCategoria?.SelecionarRegistroPorId(categoria.Id);

            Assert.AreEqual(categoria, categoriaSelecionada);
        }

        [TestMethod]
        public void Deve_RetornarNulo_Ao_SelecionarRegistroPorId_ComIdErrado()
        {

            Categoria categoria = new Categoria("Mercado");


            repositorioCategoria?.CadastrarRegistro(categoria);

            Categoria? categoriaSelecionada = repositorioCategoria?.SelecionarRegistroPorId(Guid.NewGuid());

            Assert.AreNotEqual(categoria, categoriaSelecionada);
        }

        [TestMethod]
        public void Deve_EditarRegistro_ComSucesso()
        {
            Categoria categoriaOriginal = new Categoria("Mercado");

            repositorioCategoria?.CadastrarRegistro(categoriaOriginal);

            Categoria categoriaEditada = new Categoria("Lazer");

            bool? registroEditado = repositorioCategoria?.EditarRegistro(categoriaOriginal.Id, categoriaEditada);

            Categoria? categoriaSelecionado = repositorioCategoria?.SelecionarRegistroPorId(categoriaOriginal.Id);

            Assert.IsTrue(registroEditado);
            Assert.AreEqual(categoriaOriginal, categoriaSelecionado);
        }

        [TestMethod]
        public void Deve_ExcluirRegistro_ComSucesso()
        {

            Categoria categoria = new Categoria("Mercado");

            repositorioCategoria?.CadastrarRegistro(categoria);

            bool? registroExcluido = repositorioCategoria?.ExcluirRegistro(categoria.Id);

            Categoria? categoriaSelecionada = repositorioCategoria?.SelecionarRegistroPorId(categoria.Id);

            Assert.IsTrue(registroExcluido);
            Assert.IsNull(categoriaSelecionada);
        }
    }
}
