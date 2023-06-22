using FilmesAPI.Data.Daos;
using FilmesAPI.Data.Dtos;
using FilmesAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace FilmesAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class FilmeController : ControllerBase
    {
        private FilmeDao _filmeDao;

        public FilmeController(FilmeDao filmeDao)
        {
            _filmeDao = filmeDao;
        }

        ///<summary>
        ///    Adiciona um filme ao banco de dados
        ///</summary>
        ///<param name="filmeDto">Objeto com os campos necessários para a criação de um filme </param>
        ///<returns>IActionResult</returns>
        ///<response code="201">Caso a inserção seja feita com sucesso</response>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public IActionResult AdicionaFilme([FromBody] CreateFilmeDto filmeDto)
        {
            Filme filme = _filmeDao.AdicionarFilme(filmeDto);

            return CreatedAtAction(nameof(RecuperarFilmePorId), new { Id = filme.Id }, filme);
        }

        [HttpGet]
        public IActionResult RecuperarFilmes([FromQuery] int skip = 0, [FromQuery] int take = 2, [FromQuery] string? nomeDoCinema = null)
        {
            IEnumerable<ReadFilmeDto> filmes = _filmeDao.ObterFilmesDto(skip, take, nomeDoCinema);

            return Ok(filmes);
        }

        [HttpGet("{id}")]
        public IActionResult RecuperarFilmePorId(int id)
        {
            ReadFilmeDto filme = _filmeDao.ObterFilmeDtoPorId(id);

            return filme is not null ? Ok(filme) : NotFound();
        }

        [HttpPut("{id}")]
        public IActionResult AtualizaFilme([FromBody] UpdateFilmeDto filmeDto, int id)
        {
            Filme filme = _filmeDao.ObterFilmePorId(id);

            if(filme is null) return NotFound();

            _filmeDao.AtualizarFilme(filmeDto, filme);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult DeletaFilme(int id)
        {
            Filme filme = _filmeDao.ObterFilmePorId(id);

            if(filme is null) return NotFound();

            _filmeDao.RemoverFilme(filme);

            return NoContent();
        }
    }
}
