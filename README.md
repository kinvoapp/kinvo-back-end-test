# Aliquota

### Tecnologias Utilizadas:
- .NET 5(C#)
- ASP .NET Core
- Sql Server
- Docker
- Docker-Compose
- Entity Framework Core tools 


# Instruções
- Abra o CMD/Power Shell/Terminal com permissões de administrador no diretório raiz do projeto
- Com o CMD/Power Shell/Terminal e execute 'docker-compose up -d' para que seja criado um container com uma instância do SQL Server
- Crie um banco chamado 'aliquota'
- Entre em 'src/Aliquota.Domain/'
- Execute no CMD/Power Shell/Terminal 'dotnet ef database update -s ../Aliquota.WebApp/Aliquota.WebApp.csproj'
- Entre em 'src/Aliquota.WebApp/'
- Execute 'dotnet run'
- [Acesse a Aplicação em](http://localhost:5000/Painel)

