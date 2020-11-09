
<img src="https://github.com/kinvoapp/kinvo-mobile-test/blob/master/logo.svg" > 

# Teste para candidatos à vaga de Desenvolvedor C#  

## Solução:

### Tecnologia:

* [.Net Core](https://docs.microsoft.com/en-us/aspnet/core/introduction-to-aspnet-core?view=aspnetcore-3.1#recommended-learning-path)
* [SQL Server (Docker)](https://hub.docker.com/_/microsoft-mssql-server)
* [XUnit](https://xunit.net/)

### Historias de Usuário:

* Eu, como investidor, quero me cadastrar na plataforma para gerenciar meu patrimônio.
* Eu, como investidor, preciso inserir os meus produtos financeiros para calcular impostos.
* Eu, como investidor, preciso visualizar a lista dos meus produtos para simples conferência.

### Domínio

O domínio da solução consiste em duas classes base: **Cliente** e **ProdutoFinanceiro**.  

<img src="https://github.com/tarcisiobruni/kinvo-back-end-test/blob/tarcisiobruni/images/kinvo-solucao.png" width="40%" > 

### Arquitetura

Em alinhamento com as especificações do desafio, optou-se por utilizar uma arquitetura *Clean Architecture*. O intuito é quebrar a aplicacao de acordo com suas responsabilidades e papeis (bem semelhante a uma arquitetura em camadas). Um dos principais beneficios desta abordagem está na melhor manutenabilidade do código, ainda  que novas funcionalidades sejam requeridas e o repositório cresça.

De acordo com [Microsoft](https://docs.microsoft.com/en-us/dotnet/architecture/modern-web-apps-azure/common-web-application-architectures):

> Clean architecture puts the business logic and application 						model at the center of the application. Instead of having business logic depend on data access or other infrastructure concerns, this dependency is inverted: infrastructure and implementation details depend on the Application Core.

Segue abaixo diagrama da arquitetura:

<img src="https://github.com/tarcisiobruni/kinvo-back-end-test/blob/tarcisiobruni/images/clean-architecture.png" width="40%">

Na implementação da solução, o mapeamento pôde ser feito da seguinte forma:
- ApplicationCore -> Domain (Aliquota.Domain)
- Infrastructure -> Infrastructure (Aliquota.Infrastructure)
- UserInterface (linha de comando) -> Application (Aliquota.Application)
- 
<img src="https://github.com/tarcisiobruni/kinvo-back-end-test/blob/tarcisiobruni/images/solution-explorer.png" width="50%">

#### **Aliquota.Domain**

Projeto de classes com as entidades de domínio. Também contém projeto para execução de testes de unidade.

#### **Aliquota.Infrastructure**

Projeto utilizando como ORM o [EFCore](https://docs.microsoft.com/en-us/ef/core/).      

>Entity Framework (EF) Core is a lightweight, extensible, open source and cross-platform version of the popular Entity Framework data access technology.

#### **Aliquota.Application**

Aplicação console para interação com o usuário.

## Referencias:

* https://docs.microsoft.com/en-us/dotnet/architecture/modern-web-apps-azure/common-web-application-architectures#clean-architecture 
* https://docs.microsoft.com/en-us/ef/core/
