using FilmesApi.Models.Enums;
using System.ComponentModel.DataAnnotations;

namespace FilmesApi.Models;

public class Filme
{
    [Key]
    [Required]
    public int Id { get; set; }

    [Required(ErrorMessage = "O titulo é obrigatório")]
    [MaxLength(50, ErrorMessage = "O titulo nao deve exceder 50 caracteres")]
    public string Titulo { get; set; }

    [Required]
    [MaxLength(50, ErrorMessage = "O titulo nao deve exceder 50 caracteres")]
    public string TituloOriginal { get; set; }

    [Required(ErrorMessage = "O gênero é obrigatório")]
    public GeneroFilme Genero { get; set; }

    [Required(ErrorMessage = "O titulo é obrigatório")]
    [MaxLength(30, ErrorMessage = "O diretor nao deve exceder 30 caracteres")]
    public string Diretor { get; set; }

    [Required(ErrorMessage = "A duração é obrigatória")]
    [MaxLength(8, ErrorMessage = "A duração deve estar no formato hh:mm:ss")]
    public string Duracao { get; set; }
    
}
