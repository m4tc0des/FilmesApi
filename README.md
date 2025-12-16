# Filmes API

API desenvolvida em ASP.NET Core com operações RESTful para gerenciamento de filmes. Permite cadastrar e visualizar filmes com informações como título, gênero, diretor e duração. Documentação e testes podem ser feitos via Swagger ou Postman.

Este projeto ainda está em desenvolvimento e novas funcionalidades serão implementadas em breve, como atualização e exclusão de registros, além de melhorias na documentação.

# Tecnologias utilizadas
```
- C#
- ASP.NET Core
- Entity Framework Core (ORM)
- MySQL
- AutoMapper
- NewtonsoftJson (suporte a JSON Patch)
- Swagger / Swashbuckle
- Postman
- Data Annotations (validação)

```
## Estrutura principal
```
FilmesApi/
  Controllers/
    FilmeController.cs
  Data/
    FilmeContext.cs
  Data/Dtos/
    CreateFilmeDto.cs
    UpdateFilmeDto.cs
  Models/
    Filme.cs
    Enums/
      GeneroFilme.cs
  Profiles/
    FilmeProfile.cs
  Migrations/
  Program.cs
  appsettings.json

```
# Endpoints principais
```
Criar filme

POST /filme
Exemplo de JSON:
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

Atualizar Filme (PUT)

PUT /filme/{id}
Atualiza todos os campos do filme

Atualização parcial (PATCH)
PATCH /filme/{id}
Exemplo:
[
  { "op": "replace", "path": "/titulo", "value": "Novo Título" }
]
