
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

using (IWebDriver driver = new ChromeDriver())
{
    // Navegue para a página do formulário
    driver.Navigate().GoToUrl("\\\\Mac\\Home\\FIAP\\curso_qualidade_software\\aula_1\\index.html");

    // Preencha o formulário com dados válidos
    IWebElement campoNome = driver.FindElement(By.Id("nome"));
    campoNome.SendKeys("João da Silva");

    IWebElement campoEmail = driver.FindElement(By.Id("email"));
    campoEmail.SendKeys("joao.silva@example.com");

    IWebElement campoMensagem = driver.FindElement(By.Id("mensagem"));
    campoMensagem.SendKeys("Esta é uma mensagem de teste.");

    // Enviar o formulário
    IWebElement botaoEnviar = driver.FindElement(By.CssSelector("input[type='submit']"));
    botaoEnviar.Click();
        

    Console.WriteLine("O formulário foi enviado com sucesso!");

    // Fechar o navegador após o teste
    driver.Quit();
}

Console.ReadLine();
