# Filmes API

API desenvolvida em ASP.NET Core com operações RESTful para gerenciamento de filmes.
Permite cadastrar, visualizar, atualizar e excluir filmes com informações como título, gênero, diretor e duração.
A documentação e os testes podem ser feitos via Swagger ou Postman.


# Tecnologias utilizadas
```
- C#
- ASP.NET Core
- Entity Framework Core (ORM)
- MySQL (Pomelo)
- AutoMapper
- NewtonsoftJson (suporte a JSON Patch)
- Swagger / Swashbuckle (documentação)
- Postman (testes)
- Data Annotations (validação)

```
## Estrutura principal
```
FilmesApi/
  Controllers/
    FilmeController.cs
  Data/
    FilmeContext.cs
    Dtos/
      CreateFilmeDto.cs
      UpdateFilmeDto.cs
      ReadFilmeDto.cs
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
# Enumeradores de gênero
```
1 - Ação
2 - Aventura
3 - Comédia
4 - Documentário
5 - Drama
6 - Espionagem
7 - Faroeste
8 - Fantasia
9 - Ficção Científica
10 - Musical
11 - Romance
12 - Suspense
13 - Terror
14 - Animação
15 - Crime
```
# Endpoints principais
```
Criar filme

{
  "titulo": "Interestelar",
  "tituloOriginal": "Interstellar",
  "genero": 9,
  "diretor": "Christopher Nolan",
  "duracao": "02:49:00"
}

* Listar filmes (com paginação)
GET /filme?skip=0&take=10
Retorna uma lista paginada de filmes

* Recuperar filme por I
GET /filme/{id}
Retorna os dados de um filme específico

* Atualizar filme (PUT
PUT /filme/{id}
Atualiza todos os campos do filme.

* Atualização parcial (PATCH
PATCH /filme/{id}

[
  { "op": "replace", "path": "/titulo", "value": "Novo Título" }
]

* Remover filme
DELETE /filme/{id}
Remove um filme do banco de dados
