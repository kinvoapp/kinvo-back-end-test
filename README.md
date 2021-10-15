# Projeto Produto Financeiro



Dado o contexto de uma aplicação financeira, a solução desenvolvida foi uma API Rest integrada a um banco de dados SQL Server, dessa forma facilitaria a manutenção e a integração com o código fonte principal.

Nesse projeto também foi desenvolvido uma aplicação web utilizando a estrutura MVC, como forma de melhorar a visualização da API numa possível aplicação real. 



**IMPORTANTE**: 

A projeto MVC (**ProjetoMVC** ) utiliza a configuração de **referência** as Models e o Context do projeto da API (**Aliquota.Domain**), ou seja não é um projeto independente e só funcionará se o seu diretório estiver no mesmo nível do diretório da API (dentro de uma mesma Solution).



**Funcionamento:**

- A Entidade Applications recebe os dados de uma aplicação financeira do usuário, contendo o valor, a data de aplicação e a data do resgate. 
- A Entidade Rescues exibe os resgates das aplicações realizados pelo usuário, contendo valor, datas de aplicação e resgate, valor líquido e valor bruto, lucro do período, porcentagem e valor calculado do Imposto de Renda sob o lucro.



**Sugestão para implementação no Front-End:**

- O método "Delete" na Entidade Applications  foi modificado na sua Controller para quando disparado, além de excluir os dados na sua Entidade, também enviá-los para Entidade Rescues. Então é necessário implementar: Uma personalização visual do botão que dispara o método Delete na ApplicationsController modificando de "Deletar" para "Resgatar aplicação" e criar uma rota que se comunique com o método GET na RescuesController.





