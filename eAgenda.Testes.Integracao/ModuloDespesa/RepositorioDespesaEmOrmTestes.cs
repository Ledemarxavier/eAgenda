using eAgenda.Dominio.ModuloCategoria;
using eAgenda.Dominio.ModuloDespesa;
using eAgenda.Testes.Integracao.Compartilhado;
using FizzWare.NBuilder;

[TestClass]
[TestCategory("Testes de Integração de Despesa")]
public class RepositorioDespesaEmOrmTestes : TestFixture
{
    [TestMethod]
    public void Deve_CadastrarRegistro_ComSucesso()
    {
        //Arranjo
        Despesa despesa = new Despesa(
            "Compras",
            190.33m,
            DateTime.Now,
            FormaPagamento.Credito
        );

        //Ação
        repositorioDespesa?.CadastrarRegistro(despesa);

        //Asserção
        Despesa? despesaSelecionada = repositorioDespesa?.SelecionarRegistroPorId(despesa.Id);

        Assert.AreEqual(despesa, despesaSelecionada);
    }

    [TestMethod]
    public void Deve_CadastrarRegistro_ComCategoria_ComSucesso()
    {
        //Arranjo
        Categoria categoria = Builder<Categoria>
            .CreateNew()
            .Build();

        Despesa despesa = new Despesa(
            "Compras",
            190.33m,
            DateTime.Now,
            FormaPagamento.Credito
        );

        despesa.RegistrarCategoria(categoria);

        //Ação
        repositorioDespesa?.CadastrarRegistro(despesa);

        //Asserção
        Despesa? despesaSelecionado = repositorioDespesa?.SelecionarRegistroPorId(despesa.Id);

        Assert.AreEqual(despesa, despesaSelecionado);
    }

    [TestMethod]
    public void Deve_EditarRegistro_ComSucesso()
    {
        //Arranjo
        Categoria categoria = Builder<Categoria>
            .CreateNew()
            .Build();

        Despesa despesa = new Despesa(
            "Compras",
            190.33m,
            DateTime.Now,
            FormaPagamento.Credito
        );

        repositorioDespesa?.CadastrarRegistro(despesa);

        Despesa despesaEditada = new Despesa(
            "Steam",
            40.30m,
            DateTime.Now,
            FormaPagamento.Pix
        );

        //Ação
        bool? registroEditado = repositorioDespesa?.EditarRegistro(despesa.Id, despesaEditada);

        //Asserção
        Despesa? despesaSelecionado = repositorioDespesa?.SelecionarRegistroPorId(despesa.Id);

        Assert.IsTrue(registroEditado);
        Assert.AreEqual(despesa, despesaSelecionado);
    }

    [TestMethod]
    public void Deve_ExcluirRegistro_ComSucesso()
    {
        //Arranjo
        Categoria categoria = Builder<Categoria>
            .CreateNew()
            .Build();

        Despesa despesa = new Despesa(
            "Compras",
            190.33m,
            DateTime.Now,
            FormaPagamento.Credito
        );

        repositorioDespesa?.CadastrarRegistro(despesa);

        //Ação
        bool? registroExcluido = repositorioDespesa?.ExcluirRegistro(despesa.Id);

        //Asserção
        Despesa? despesaSelecionado = repositorioDespesa?.SelecionarRegistroPorId(despesa.Id);

        Assert.IsTrue(registroExcluido);
        Assert.IsNull(despesaSelecionado);
    }
}
