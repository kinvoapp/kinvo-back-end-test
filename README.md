> ![Logo Kinvo](https://github.com/kinvoapp/kinvo-mobile-test/blob/master/logo.svg)

# Teste para candidatos à vaga de Desenvolvedor C#  


## Problema:

* Um determinado produto financeiro recolhe imposto de renda apenas quando o cliente faz o seu resgate. O cálculo do IR segue a seguinte lógica abaixo:
* Até 1 ano de aplicação: 22,5% sobre o lucro
* De 1 a 2 anos de aplicação: 18,5% sobre o lucro
* Acima de 2 anos de aplicação: 15% sobre o lucro
* A aplicação não pode ser igual ou menor que zero
* A data de resgate não pode ser menor que a data de aplicação

Após terminar seu teste submeta um pull request e aguarde seu feedback.

### Instruções:

1. Criar um projeto de classes chamado “Aliquota.Domain”;
2. Criar um projeto de testes chamado “Aliquota.Domain.Test”
3. Modelar a(s) entidade(s) que resolvem o problema abaixo;
4. Mapear as entidades no Entity Framework Core;
5. Criar um projeto de frontend para permitir a persistência de dados (console, webapp, etc.);
4. Testar a(s) entidade(s) de forma que garantam as regras de negócio;
5. Utilizar os conceitos de DDD, OO, POCO e SOLID que você julgar necessário;
6. Use inglês ou português no seu código. Como achar melhor. Isso não será critério de avaliação.


### Pré-requisitos:

* Utilizar C# e framework .NET Core;
* Utilizar xUnit para os testes;
* O projeto deve compilar;
* Os testes devem rodar pelo Test Explorer do VS e via console (dotnet test);


* **Importante:** Usamos o mesmo teste para todos os níveis de desenvolvedor, **junior**, **pleno** ou **senior**, mas procuramos adequar nossa exigência na avaliação com cada um desses níveis sem, por exemplo, exigir excelência de quem está começando :-)

## Submissão

Para iniciar o teste, faça um fork deste repositório, crie uma branch com o seu nome e depois envie-nos o pull request.
Se você apenas clonar o repositório não vai conseguir fazer push e depois vai ser mais complicado fazer o pull request.

**Sucesso!**

## Minha Submissão

Eu usei o swagger para gerar uma página web expondo as chamadas da API.

### Instruções

1. Colocar o projeto Aliquota.API como startup project.
2. Executar a aplicação.
3. Executar chamada Post do Usuario gerar um usuario com qualquer nome.
4. Executar chamada Post de ProdutoFinanceiroes gerar um produto financeiro com uma descrição qualquer ("ex. Taxa de Rendimento 10%") e o valor da taxa de rendimento ("ex. 10").
5. Executar chamada Post de Aplicacaos gerar uma Aplicacao com o valor inicial da aplicacao (ex. 100) e os ids do Usuario e Produto Financeiro criado anteriormente, ambos são 1 no nosso passo a passo.
6. Executar chamada "Get /Api/Aplicacaos/", verificar a aplicacao acima preenchida exceto os campos dataResgate e valorResgate nulos.
7. Executar chamada "Put /api/Aplicacaos/RealizarResgate/{aplicacaoId}" com o Id da aplicação acima, seguinte o passo a passo o valor é 1.
8. Executar chamada  "Get /Api/Aplicacaos/" novamente, agora os campos nulos estão preenchidos.

Nos testes unitarios os mesmos metodos são utilizados para testar essas funcionalidades, porém o valor do DateTime.UTCNow é mockado para simular aplicações com longas durações.
