## COMO EXECUTAR A APLICAÇÃO

# suba o container do mysql
docker-compose up

# execute as migrações
dotnet ef database update --project Aliquota.Infrasctruture

# rode a aplicação console
dotnet run --project Aliquota.Api