using System;
using TechTalk.SpecFlow;

namespace API.Tests
{
    [Binding]
    public class CriacaoDeUsuarioStepDefinitions
    {
        [Given(@"que estou na página de registro")]
        public void GivenQueEstouNaPaginaDeRegistro()
        {
            throw new PendingStepException();
        }

        [When(@"preencher o formulário de registro com as seguintes informações:")]
        public void WhenPreencherOFormularioDeRegistroComAsSeguintesInformacoes()
        {
            throw new PendingStepException();
        }

        [When(@"clicar no botão ""([^""]*)""")]
        public void WhenClicarNoBotao(string registrar)
        {
            throw new PendingStepException();
        }

        [Then(@"devo ser redirecionado para a página de login")]
        public void ThenDevoSerRedirecionadoParaAPaginaDeLogin()
        {
            throw new PendingStepException();
        }

        [Then(@"devo receber uma mensagem de confirmação de registro")]
        public void ThenDevoReceberUmaMensagemDeConfirmacaoDeRegistro()
        {
            throw new PendingStepException();
        }

        [When(@"preencher o formulário de registro com informações inválidas:")]
        public void WhenPreencherOFormularioDeRegistroComInformacoesInvalidas()
        {
            throw new PendingStepException();
        }

        [Then(@"devo ver uma mensagem de erro indicando que o nome é obrigatório")]
        public void ThenDevoVerUmaMensagemDeErroIndicandoQueONomeEObrigatorio()
        {
            throw new PendingStepException();
        }
    }
}
