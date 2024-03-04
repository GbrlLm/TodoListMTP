PARA COMEÇAR

Para executar o projeto back-end devemos primeiro atualizar o banco de dados. Para isso é necessário que tenha o banco de dados PostgreSQL instalado em sua máquina, a versão utilizada no projeto foi a 16.2.
Para começar devemos executar o comando de:

```console
dotnet ef database update
```

Caso não tenha instalado o Entity Framework em sua máquina, é necessário executar o comando

```console
dotnet tool install --global dotnet-ef
```
