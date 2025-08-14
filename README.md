Desafio Técnico: API de Cadastro de Produtos
Este repositório contém a solução para o desafio técnico de desenvolvimento de uma API REST para cadastro de produtos, consumida por um frontend em React.

O projeto foi desenvolvido com foco em boas práticas de engenharia de software, arquitetura limpa e um ecossistema de desenvolvimento moderno.

Tecnologias Utilizadas
Backend
.NET 6: Plataforma de desenvolvimento.
ASP.NET Core: Para construção da API REST (usando Minimal APIs).
Entity Framework Core (In-Memory): Para acesso a dados.
xUnit & Moq: Para testes unitários.
Swagger/OpenAPI: Para documentação da API.

Frontend
React: Biblioteca para construção da interface.

DevOps
Jenkins: Automação de CI/CD (build, teste e publish) através de um Jenkinsfile.

Arquitetura e Decisões de Design
A API foi estruturada seguindo princípios de Arquitetura Limpa e SOLID:

Single Responsibility Principle (SRP): As responsabilidades são bem definidas:

Controllers: Exposição dos endpoints HTTP.

Services: Orquestração da lógica de negócio.

Repositories: Acesso e manipulação dos dados.

Dependency Inversion Principle (DIP): Utiliza a injeção de dependência nativa do .NET. Camadas superiores (Services) dependem de abstrações (Interfaces) das camadas inferiores (Repositories), promovendo baixo acoplamento e alta testabilidade.

DTOs (Data Transfer Objects): Para desacoplar o contrato da API das entidades de domínio, evitando expor detalhes internos e facilitando a validação.

Como Executar o Projeto
Pré-requisitos
.NET SDK 6.0 ou superior.

Node.js e npm (para o frontend).


1. Executando a API .NET
# Navegue até a pasta da API
cd ProductApi

# Restaure as dependências
dotnet restore

# Execute a aplicação
dotnet run

A API estará disponível em https://localhost:7123 (verifique a porta no seu launchSettings.json).
A documentação do Swagger pode ser acessada em https://localhost:7123/swagger.

2. Executando o Frontend React
# Em outro terminal, navegue até a pasta do frontend
cd product-ui # ou o nome que você deu

# Instale as dependências
npm install

# Inicie o servidor de desenvolvimento
npm start

