# Teste Pratico

<h4 text-align="center"> 
	🚧 Teste Pratico- Sistema de Vagas  🚧
</h4>

<p text-align="center">
 <a href="#-sobre-o-projeto">Sobre</a> •
 <a href="#-funcionalidades">Funcionalidades</a> •
 <a href="#-como-executar-o-projeto">Como executar</a> • 
</p>


## 💻 Sobre o projeto

 Esse Teste Pratico, busca demonstrar uma API que simula o Sistema de vagas da Ploomes, mas que também pode ser utilizado para várias empresas. 

## 💻 Funcionalidades
 Nesse projeto, usuários administradores podem:
 - Inserir, Editar, Buscar e Deletar Vagas
 - Obter Candidatos de uma vaga
 - Obter Vagas de uma Empresa
 - Obter vagas por Empresa
 - Inserir, Editar, Buscar e Deletar Empresas
 - Inserir, Editar, Buscar e Deletar usuários
 - Inserir, Editar, Buscar e Deletar candidaturas
 Usuários externos, podem: 
 - Visualizar Vagas
 - Se Candidatar e retirar a candidatura
 - Visualizar vagas a qual se candidatou

## 🎲 Como Executar O Projeto

```bash
# Clone este repositório
$ git clone [linkGIT]
```
Verifique se há instalado na sua máquina o .NET SDK versão 5.0. Se não houver <a href="https://dotnet.microsoft.com/en-us/download/dotnet/5.0">Clique aqui</a>
```bash
$ dotnet restore
```
Crie o banco "Ploomes" no Microsoft SQL Server Management

Ao abrir a solução, no projeto "TestePratico.Application", clique no botão direito, clique em "Gerenciar segredos do usuário" e insira os dados do seu banco como nos exemplos abaixo
```bash
{
  "ConnectionStrings": { "DefaultConnection": "Server=[Nome_Do_Servidor];Database=Ploomes;Trusted_Connection=true;MultipleActiveResultSets=true;Persist Security Info=True;User ID=[user]; Password=[senha]" }
}
```

Repita o processo no projeto "TestePratico.Infra.Data"

No gerenciador de pacotes, selecione o TestePratico.Infra.Data e rode
```bash
add-migration "MigracaoInicial"
update-database -verbose
```
Se as alterações não ocorrerem no banco, delete os arquivos dentro na pasta migration, da camada TestePratico.Infra.Data e repita o processo.

Ao rodar o sistema, e acessar no localHost, insira na URL: " /swagger/index.html ", para acessar o Swagger.
Após criar o usuário, ao realizar o Login a API retornará um token que deve ser adicionado junto a palavra "Bearer" no campo que aparecerá, ao clicar em um dos símbolos de cadeados.

Qualquer dúvide entre em contato com o owner.

## Estrutura do código

A aplicação utiliza .NET Core, com arquitetura em camadas com DDD ou seja: uma modelagem de software cujo objetivo é facilitar a implementação de regras e processos complexos, onde visa a divisão de responsabilidades por camadas e é independente da tecnologia utilizada
<a href="https://alexalvess.medium.com/criando-uma-api-em-net-core-baseado-na-arquitetura-ddd-2c6a409c686">
  Arquitetura utilizada de exemplo
</a>
  <img alt="Estrutura" src="https://miro.medium.com/max/1282/1*qpHCIA7RDfW89KtSUXGJog.png">


### TestePratico.Application

Essa camada possui: 
##### Controllers

A controller são os serviços, todas herdam a classe Api Controller Base, recebendo assim as seguintes funçoes:
 * Execute, para a execução e tratamente de todas as controllers
 * Bad Request, para envio de erros

##### DTOS - Data Transfer Objects

Os DTOS são os objetos recebidos pelas controllers como parámetros ou respostas, organizados de maneira correta e buscando retornar/receber somente as informações necessárias.

##### Mapping

Os mappings transformam os DTO's em entidades.

##### Startup


##### Program.cs

Essa função cria o costrutor do local web, e as configurações da aplicação.

### TestePratico.Domain

Na domain pode-se encontrar:

##### Const

As constantes de notificações de erros e os enums que são utilizados no sistema.

##### Entities

As entidades representam a estutura do banco.

##### Interfaces

Interfaces dos repositórios e serviços, que serão chamadas em outras camadas.

##### Models

Aqui há models com estrutura de dados que possam ser necessárias no sistema.
Na pasta m3AutomateJson se encontra as modais com a estrutura do JsonConfig do gerador de código.

### TestePratico.Infra.CrossCutting
Nessa camada é encontrado códigos que serão utilizados em diversas camadas.
Exemplo:
O AssemblyUteis busca quais os arquivos precisam de injetar dependência entre as camadas, e o Resolvedor de Dependências, é chamado no Startup.cs para que as dependências sejam realizadas corretamente.
Criptografia que é utilizada no processo de autenticação e de criação de usuário.
### TestePratico.Infra.Data
Essa estrutura acessa o banco de dados, e faz sua gestão através do entity framework.
Nessa estrutura ficam as Migrations, Mappings e Repositórios no banco.
As alterações da estrutura do banco de dados devem ser realizads aqui.

### TestePratico.Service
Nessa camada se localizam as regras de negócios, validações antes dos dados serem enviados ao banco.
