# Projeto Produto Financeiro



Dado o contexto de uma aplicação financeira, a solução desenvolvida foi uma API Rest integrada a um banco de dados SQL Server. Dessa forma, facilitaria a manutenção e a integração com o código fonte principal. Para fazer a simulação do recolhimento do Imposto de Renda, foi simulado um produto financeiro que rende 10% ao ano.

Nesse projeto também foi desenvolvido uma aplicação web utilizando a arquitetura MVC, como forma de melhorar a visualização da API numa possível aplicação real. 



**IMPORTANTE**: 

- O projeto MVC (**ProjetoMVC**) utiliza a configuração de **referência** para as Models e o Context do projeto da API (**Aliquota.Domain**), ou seja, não é um projeto independente e só funcionará se o seu diretório estiver no mesmo nível do diretório da API (dentro de uma mesma Solution).
- Ao iniciar o projeto é necessario subir o banco de dados. No console do seu gerenciador Nuget digite o comando `Update-Database` se estiver usando o Visual Studio ou o comando `dotnet ef database update` caso esteja no VS Code.
- Para rodar os testes são necessárias **duas** modificações temporarias no projeto: **1ª** na Model Context da API Aliquota.Domain alterar a entidade Applications **de**: `public DbSet<Application> Applications { get; set; }` **para**: `public virtual DbSet<Application> Applications { get; set; }`. **2ª** na ApplicationsController  da API, no método PutApplication, **substituir** `_context.Entry(application).State = EntityState.Modified;` **por** `_context.SetModified(application);`




**Funcionamento:**

- A Entidade Applications recebe os dados de uma aplicação financeira do usuário contendo o valor, a data de aplicação e a data do resgate. 
- A Entidade Rescues exibe os resgates das aplicações realizados pelo usuário contendo valor, datas de aplicação e resgate, valor líquido e valor bruto, lucro do período, porcentagem e valor calculado do Imposto de Renda sob o lucro.



**Sugestão para implementação no Front-End:**

- O método "Delete" na Entidade Applications foi modificado na sua Controller para quando disparado, além de excluir os dados na sua Entidade, também enviá-los para Entidade Rescues. Então é necessário implementar: Uma personalização visual do botão que dispara o método Delete na ApplicationsController, modificando de "Deletar" para "Resgatar aplicação" e criar uma rota que comunique com o método GET na RescuesController. (o ProjetoMVC já está implementado com essa funcionalidade e pode servir como modelo) 





