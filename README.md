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
# Como usar a Api
```
Depois de fazer o download dos arquivos que compõem a API, existem alguns pacotes que precisam ser instalados para sua utilização. Abaixo está o passo a passo:

## Pré-requisitos
- Ter instalado na máquina o **MySQL**.  
  Exemplo de configuração no `appsettings.json`:
  ```json
  "ConnectionStrings": {
    "FilmeConnection": "server=127.0.0.1;database=filme;user=seuUsuario;password=suaSenha"
    (Substitua seuUsuario e suaSenha pelas credenciais do seu banco local)
  }
- Ter o **Visual Studio** ou **Visual Studio Code** com suporte a .NET 6.0.
- Ter o **.NET 6 SDK** instalado.

## Pacotes NuGet necessários
- Automapper (versão 12.0.0)
- Automapper.Extensions.Microsoft.DependencyInjection (versão 12.0.0)
- Microsoft.AspNetCore.Mvc.NewtonsoftJson (versão 6.0.10)
- Microsoft.EntityFrameworkCore (versão 6.0.10)
- Microsoft.EntityFrameworkCore.Tools (versão 6.0.10)
- Pomelo.EntityFrameworkCore.MySql (versão 6.0.2)
- Swashbuckle.AspNetCore (versão 6.5.0)

## Configuração do Banco de Dados
No **Package Manager Console** do Visual Studio, execute os seguintes comandos:

1. Criar a migration inicial:
   ```powershell
   Add-Migration InitialCreate
2. Atualizar o banco de dados:
    Update-Database

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
1 - Ação | 2 - Aventura | 3 - Comédia | 4 - Documentário | 5 - Drama | 6 - Espionagem | 7 - Faroeste | 8 - Fantasia | 9 - Ficção Científica | 10 - Musical | 11 - Romance | 12 - Suspense | 13 - Terror | 14 - Animação | 15 - Crime
```
# Endpoints principais
```
Criar filme (POST)

POST /filme
{
  "titulo": "Interestelar",
  "tituloOriginal": "Interstellar",
  "genero": 9,
  "diretor": "Christopher Nolan",
  "duracao": "02:49:00",
  "fotoUrl": "https://a.ltrbxd.com/resized/film-poster/5/2/5/1/6/52516-django-unchained-0-1000-0-1500-crop.jpg?v=f02aed63a3"
}

Listar filmes com paginação (GET

GET /filme?skip=0&take=10
[
  {
    "titulo": "Django Livre",
    "tituloOriginal": "Django Unchained",
    "genero": 7,
    "diretor": "Quentin Tarantino",
    "duracao": "02:45:00",
    "fotoUrl": "https://link.com/django.jpg",
    "horaDaConsulta": "2025-12-21T13:42:00"
  }
]

Recuperar filme por ID (GET)

GET /filme/{id}
{
  "titulo": "O Senhor dos Anéis: A Sociedade do Anel",
  "tituloOriginal": "The Lord of the Rings: The Fellowship of the Ring",
  "genero": 8,
  "diretor": "Peter Jackson",
  "duracao": "02:58:00",
  "fotoUrl": "https://link.com/lotr.jpg",
  "horaDaConsulta": "2025-12-21T13:42:00"
}

 Atualizar filme (PUT)

PUT /filme/{id}
{
  "titulo": "Interestelar",
  "tituloOriginal": "Interstellar",
  "genero": 9,
  "diretor": "Christopher Nolan",
  "duracao": "02:49:00",
  "fotoUrl": "https://link.com/interstellar.jpg"
}

Atualização parcial (PATCH)

PATCH /filme/{id}
[
  { "op": "replace", "path": "/titulo", "value": "Novo Título" },
  { "op": "replace", "path": "/fotoUrl", "value": "https://link.com/novo.jpg" }
]

 Remover filme (DELETE)

DELETE /filme/{id}

