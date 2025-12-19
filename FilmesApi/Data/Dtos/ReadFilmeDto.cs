using FilmesApi.Models.Enums;
using System.ComponentModel.DataAnnotations;

namespace FilmesApi.Data.Dtos
{
    public class ReadFilmeDto
    {
        public string Titulo { get; set; }
        public string TituloOriginal { get; set; }
        public GeneroFilme Genero { get; set; }
        public string Diretor { get; set; }
        public string Duracao { get; set; }
        public DateTime HoraDaConsulta { get; set; } = DateTime.Now;
    }
}
