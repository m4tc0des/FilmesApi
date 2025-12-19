using AutoMapper;
using FilmesApi.Data;
using FilmesApi.Data.Dtos;
using FilmesApi.Models;
using Microsoft.AspNetCore.Mvc;
using FilmesApi.Data.Dtos;
using Microsoft.AspNetCore.JsonPatch;

namespace FilmesApi.Controllers;

[ApiController]
[Route("[controller]")]
public class FilmeController : ControllerBase
{

    private FilmeContext _context;
    private IMapper _mapper;

    public FilmeController(FilmeContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }
    /// <summary>
    /// Adiciona um novo filme ao banco de dados.
    /// </summary>
    /// <param name="filmeDto">Objeto com os dados do filme a ser criado. Campo <c>Genero</c> deve ser um valor válido do enum.</param>
    /// <returns>
    /// Status codes:
    /// - 201 Created: inserção realizada com sucesso, retorna localização do recurso.
    /// - 400 Bad Request: payload inválido ou ausente.
    /// - 422 Unprocessable Entity: validação falhou.
    /// </returns>
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    public IActionResult AdicionarFilme([FromBody] CreateFilmeDto filmeDto)
    {
        Filme filme = _mapper.Map<Filme>(filmeDto);
        _context.Filmes.Add(filme);
        _context.SaveChanges();
        return CreatedAtAction(nameof(RecuperarFilmePorId), new { id = filme.Id }, filme);
    }
    /// <summary>
    /// Lista os filmes cadastrados com suporte à paginação.
    /// </summary>
    /// <param name="skip">Quantidade de registros a pular.</param>
    /// <param name="take">Quantidade de registros a retornar.</param>
    /// <returns>
    /// Status codes:
    /// - 200 OK: lista retornada com sucesso (inclui campo <c>Genero</c>).
    /// - 400 Bad Request: parâmetros de paginação inválidos.
    /// </returns>
    [HttpGet]
    public IEnumerable<ReadFilmeDto> VisualizarFilme([FromQuery] int skip = 0, int take = 10)
    {
        return _mapper.Map<List<ReadFilmeDto>>(_context.Filmes.Skip(skip).Take(take));
    }
    /// <summary>
    /// Recupera os dados de um filme específico pelo ID.
    /// </summary>
    /// <param name="id">ID do filme a ser consultado.</param>
    /// <returns>
    /// Status codes:
    /// - 200 OK: filme encontrado (inclui campo <c>Genero</c>).
    /// - 404 Not Found: nenhum filme com o ID informado.
    /// </returns>
    [HttpGet("{id}")]
    public IActionResult RecuperarFilmePorId(int id)
    {
        var filme = _context.Filmes.FirstOrDefault(x => x.Id == id);
        if (filme == null)
        {
            return NotFound();
        }
        var filmeDto = _mapper.Map<ReadFilmeDto>(filme); 
            return Ok(filmeDto);
    }
    /// <summary>
    /// Atualiza completamente os dados de um filme existente.
    /// </summary>
    /// <param name="id">ID do filme a ser atualizado.</param>
    /// <param name="filmeDto">Objeto com os novos dados do filme. Campo <c>Genero</c> deve ser válido.</param>
    /// <returns>
    /// Status codes:
    /// - 204 No Content: atualização realizada com sucesso.
    /// - 404 Not Found: filme não encontrado.
    /// - 400 Bad Request: payload inválido.
    /// - 422 Unprocessable Entity: validação falhou.
    /// </returns>
    [HttpPut("{id}")]
    public IActionResult AtualizaFilme(int id, [FromBody] UpdateFilmeDto filmeDto)
    {
        var filme = _context.Filmes.FirstOrDefault(x => x.Id == id);
        if (filme == null) 
            return NotFound();
        _mapper.Map(filmeDto, filme);
        _context.SaveChanges();
        return NoContent();
    }
    /// <summary>
    /// Atualiza parcialmente os dados de um filme usando JSON Patch.
    /// </summary>
    /// <param name="id">ID do filme a ser atualizado.</param>
    /// <param name="patch">Documento JSON Patch com as alterações. Campo <c>Genero</c>, se presente, deve ser válido.</param>
    /// <returns>
    /// Status codes:
    /// - 204 No Content: atualização parcial realizada com sucesso.
    /// - 404 Not Found: filme não encontrado.
    /// - 400 Bad Request: documento de patch inválido.
    /// - 422 Unprocessable Entity: validação falhou após aplicação do patch.
    /// </returns>
    [HttpPatch("{id}")]
    public IActionResult AtualizaFilmeParcial(int id, JsonPatchDocument<UpdateFilmeDto> patch)
    {
        var filme = _context.Filmes.FirstOrDefault(x => x.Id == id);
        if (filme == null)
            return NotFound();
        var filmeParaAtualizar = _mapper.Map<UpdateFilmeDto>(filme);
        
        patch.ApplyTo(filmeParaAtualizar, ModelState);

        if (!TryValidateModel(filmeParaAtualizar))
        {
            return ValidationProblem(ModelState);
        }
        _mapper.Map(filmeParaAtualizar, filme);
        _context.SaveChanges();
        return NoContent();
    }
    /// <summary>
    /// Remove um filme do banco de dados.
    /// </summary>
    /// <param name="id">ID do filme a ser removido.</param>
    /// <returns>
    /// Status codes:
    /// - 204 No Content: remoção realizada com sucesso.
    /// - 404 Not Found: filme não encontrado.
    /// </returns>
    [HttpDelete("{id}")]
    public IActionResult DeletaFilme(int id)
    {
        var filme = _context.Filmes.FirstOrDefault(x => x.Id == id);
        if (filme == null) return NotFound();
        _context.Remove(filme);
        _context.SaveChanges();
        return NoContent();
    }
}
