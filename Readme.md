<h1 align="center">
📄<br>API de Clientes - T2M
</h1>

## 📚 Sobre o projeto

> Esse repositório contém uma API efetuando um CRUD para o registro de Clientes. API foi criada em .netCore 6, com Entity Framework 6.0.22 e utilizando NUnit para execução dos testes unitários
---


## 💻 Requerimentos

Para a API funcionar, é necessário possuir uma versão do SQL Server, para registro dos dados.


## 🚀 Iniciando o projeto

Para que o projeto funcione, é necessário executar o Migrations no Visual Studio, para que o banco seja criado.

Com o botão direito no projeto Clientes.API, vá em "Abrir no Terminal" e digite o comando abaixo:

```
dotnet ef database update
```

Feito isso, o banco estará criado e o projeto poderá ser executado

## ☕ Executando o projeto

O projeto irá disponibilizar cinco endpoints:

* Post: Incluindo dados de cliente na base de dados;
* Get: Primeiro Get retornará todos os registros da tabela;
* Put: Alteração dos dados do cliente na base de dados;
* Get: Segundo Get, passando o Id, retorna os dados de um cliente;
* Delete: Exclui um registro do banco de dados.


*Alex Damião </br>
Analista de Sistemas Sênior*