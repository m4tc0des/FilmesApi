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
  Migrations/
  Program.cs
  appsettings.json

```
# Endpoints principais
```
Criar filme
POST /filme
Envia um JSON com os dados do filme:
{
  "titulo": "Interestelar",
  "tituloOriginal": "Interstellar",
  "genero": 1,
  "diretor": "Christopher Nolan",
  "duracao": "02:49:00"
}

Listar filmes (com paginação)
GET /filme?skip=0&take=10
Retorna uma lista paginada de filmes

Buscar filme por ID
GET /filme/{id}
Retorna o filme correspondente ou 404 caso não exista

```
