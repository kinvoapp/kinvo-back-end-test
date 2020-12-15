> ![Logo Kinvo](https://github.com/kinvoapp/kinvo-mobile-test/blob/master/logo.svg)

# Teste para candidatos à vaga de Desenvolvedor C#  
Obrigado pela oportunidade de participar do teste, fiz o melhor que pude dentro do tempo que tive.

## Problema:

* Um determinado produto financeiro recolhe imposto de renda apenas quando o cliente faz o seu resgate. O cálculo do IR segue a seguinte lógica abaixo:
* Até 1 ano de aplicação: 22,5% sobre o lucro
* De 1 a 2 anos de aplicação: 18,5% sobre o lucro
* Acima de 2 anos de aplicação: 15% sobre o lucro
* A aplicação não pode ser igual ou menor que zero
* A data de resgate não pode ser menor que a data de aplicação

Após terminar seu teste submeta um pull request e aguarde seu feedback.

### Instruções:

1. Criar um projeto de classes chamado “Aliquota.Domain”;-ok
2. Criar um projeto de testes chamado “Aliquota.Domain.Test”-ok (porem não fiz a implementação dos testes)
3. Modelar a(s) entidade(s) que resolvem o problema abaixo; - ok (fiz uma modelagem de algumas entidates, mas no fim mudei para tornar mais prático e entregar no tempo requerido)
A única entidade válida para o desafio será a FinancialApplication, porém não apaguei as outras para evitar problemas de refatoração, já que estou entregando em cima do prazo.

4. Mapear as entidades no Entity Framework Core; - ok
5. Criar um projeto de frontend para permitir a persistência de dados (console, webapp, etc.); -ok (fiz a implementação do swagger para ser mais rápido e entregar o desafio, cheguei a criar um projeto de fronte, mas não tive tempo de implementar)
4. Testar a(s) entidade(s) de forma que garantam as regras de negócio; - testei manualmente com o swagger
5. Utilizar os conceitos de DDD, OO, POCO e SOLID que você julgar necessário; - utilizado
6. Use inglês ou português no seu código. Como achar melhor. Isso não será critério de avaliação. -ok


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
