# Filmes API

API desenvolvida em ASP.NET Core com operações RESTful para gerenciamento de filmes. Permite cadastrar e visualizar filmes com informações como título, gênero, diretor e duração. Documentação e testes podem ser feitos via Swagger ou Postman.

Este projeto ainda está em desenvolvimento e novas funcionalidades serão implementadas em breve, como atualização e exclusão de registros, além de melhorias na documentação.

# Tecnologias utilizadas
```
- C#
- ASP.NET Core
- Swagger (documentação)
- Postman (testes)
- Data Annotations para validação
- Entity Framework Core (ORM)
- MySQL (banco de dados relacional)
```
## Estrutura principal
```
FilmesApi/
  Controllers/
    FilmeController.cs
  Data/
    FilmeContext.cs
  Models/
    Filme.cs
    Enums/
      GeneroFilme.cs
  Program.cs
  appsettings.json

```
# Endpoints principais
```
POST /filme -> adiciona um novo filme

GET /filme -> lista filmes com paginação (skip, take)

GET /filme/{id} -> busca filme por Id
```
