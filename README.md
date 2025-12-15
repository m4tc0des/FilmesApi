# 🎬 Filmes API

API desenvolvida em **ASP.NET Core** com operações **RESTful** para gerenciamento de filmes.  
Permite cadastrar e visualizar filmes com informações como título, gênero, diretor e duração.  
Documentação e testes podem ser feitos via **Swagger** ou **Postman**.  

⚠️ Este projeto ainda está em desenvolvimento e novas funcionalidades serão implementadas em breve, como integração com banco de dados, atualização e exclusão de registros, além de melhorias na documentação.


---

## 🚀 Tecnologias utilizadas
- C#
- ASP.NET Core
- Swagger (documentação)
- Postman (testes)
- Data Annotations para validação

---

## 📌 Estrutura principal

### Controller
```csharp
using FilmesApi.Models;
using Microsoft.AspNetCore.Mvc;

namespace FilmesApi.Controllers;

[ApiController]
[Route("[controller]")]
public class FilmeController : ControllerBase
{
    private static List<Filme> filmes = new List<Filme>();
    
    [HttpPost]
    public void AdicionarFilme([FromBody]Filme filme) 
    {
        filmes.Add(filme);
        Console.WriteLine(filme.Titulo);
        Console.WriteLine(filme.Genero);
        Console.WriteLine(filme.Diretor);
        Console.WriteLine(filme.Duracao);
    }

    [HttpGet]
    public IEnumerable<Filme> VisualizarFilme()
    {
        return filmes;
    }
}
```
### Model
```csharp
public class Filme
{
    [Required(ErrorMessage = "O titulo é obrigatório")]
    [MaxLength(50, ErrorMessage = "O titulo nao deve exceder 50 caracteres")]
    public string Titulo { get; set; }

    [Required(ErrorMessage = "O gênero é obrigatório")]
    [MaxLength(30, ErrorMessage = "O gênero nao deve exceder 30 caracteres")]
    public string Genero { get; set; }

    [Required(ErrorMessage = "O diretor é obrigatório")]
    [MaxLength(30, ErrorMessage = "O diretor nao deve exceder 30 caracteres")]
    public string Diretor { get; set; }

    [Required(ErrorMessage = "A duração é obrigatória")]
    [MaxLength(8, ErrorMessage = "A duração deve estar no formato hh:mm:ss")]
    public string Duracao { get; set; }
}


