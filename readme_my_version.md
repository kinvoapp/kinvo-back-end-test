# Oi! 🧙

Então, fazer esse projeto foi uma atividade bem legal, tive algumas dificuldades (principalmente no começo, pra esquentar a mente 🤓), mas após fazer algumas partes do projeto, o fluxo foi seguindo!

Gostaria de deixar algumas observações a respeito da minha versão do projeto:

* Eu optei por deixar o código completamente em inglês

* Talvez eu não tenha entendido bem, mas o projeto informa que o usuário ao remover seu investimento, ele teria uma taxa sobre o seu lucro com base no tempo que aquele investimento teve, mas não informa necessariamente quanto de lucro o usuário tem pelo tempo do investimento, então tomei a liberdade de fazer com a seguinte metodologia:

  1. O aumento do lucro/profit seria a cada mês passado
  2. A taxa seria de 5% ao mês
  3. A forma de juros adotada foi **Juros Composto**
  4. Sim, meu banco quebraria em menos de 6 meses com essa metodologia 💯

* O projeto informa para criar um frontend com persistência de dados, para manter a persistência, eu optei por usar um servidor MySQL pela facilidade (para isso, instalei o pacote "Pomelo.EntityFrameworkCore.MySQL" na versão 2.1.1).

* A connection string do DB ocorre em "appsettings.json", com a seguinte string:

  "AliquotaDomainContext": "server=localhost;userid=developer;password=1234567;database=aliquotadomain"

* Então qualquer modificação para se conectar em um DB do MySQL de teste, basta modificar essa string. Talvez também seja necessário os comandos via console no Visual Studio:

  1. "Add-Migration NomeDaMigration" e então "Update-Database"

     ou talvez somente

  2. "Update-Database"

### Todo o decorrer do projeto está salvo nos commits do github, podendo ser acompanhado como foi cada passo a passo e o que foi feito a cada passo

Obrigado! 🥳 
