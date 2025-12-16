using FilmesApi.Models.Enums;
using System.ComponentModel.DataAnnotations;

namespace FilmesApi.Data.Dtos;

public class UpdateFilmeDto
{

    [Required(ErrorMessage = "O titulo é obrigatório")]
    [StringLength(50, ErrorMessage = "O titulo nao deve exceder 50 caracteres")]
    public string Titulo { get; set; }

    [Required]
    [StringLength(50, ErrorMessage = "O titulo nao deve exceder 50 caracteres")]
    public string TituloOriginal { get; set; }

    [Required(ErrorMessage = "O gênero é obrigatório")]
    public GeneroFilme Genero { get; set; }

    [Required(ErrorMessage = "O titulo é obrigatório")]
    [StringLength(30, ErrorMessage = "O diretor nao deve exceder 30 caracteres")]
    public string Diretor { get; set; }

    [Required(ErrorMessage = "A duração é obrigatória")]
    [StringLength(8, ErrorMessage = "A duração deve estar no formato hh:mm:ss")]
    public string Duracao { get; set; }
}
