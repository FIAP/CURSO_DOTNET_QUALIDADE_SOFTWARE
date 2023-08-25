Funcionalidade: Criação de Usuário

Cenário: Cadastro de um novo usuário
Dado que estou na página de registro
Quando preencher o formulário de registro com as seguintes informações:

#Nome: "João da Silva"
#Email: "joao@example.com"
#Senha: "senha123"
E clicar no botão "Registrar"
Então devo ser redirecionado para a página de login
E devo receber uma mensagem de confirmação de registro


Cenário: Cadastro de usuário com informações inválidas
Dado que estou na página de registro
Quando preencher o formulário de registro com informações inválidas:

#Nome: ""
#Email: "joao@example.com"
#Senha: "senha123"
E clicar no botão "Registrar"
Então devo ver uma mensagem de erro indicando que o nome é obrigatório