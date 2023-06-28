using FilmesAPI.Data.Daos;
using FilmesAPI.Data.Dtos;
using FilmesAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace FilmesAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CinemaController : ControllerBase
    {
        private ICinemaDao _cinemaDao;
        public CinemaController(ICinemaDao cinemaDao)
        {
            _cinemaDao = _cinemaDao;
        }

        [HttpPost]
        public IActionResult AdicionaCinema([FromBody] CreateCinemaDto cinemaDto)
        {
            Cinema cinema = _cinemaDao.IncluirCinemaDto(cinemaDto);

            return CreatedAtAction(nameof(RecuperarCinemaPorId), new { id = cinema.Id }, cinema);
        }

        [HttpGet]
        public IActionResult RecuperarCinemas([FromQuery] int skip = 0, [FromQuery] int take = 2, [FromQuery] int? enderecoId = null)
        {
            return Ok(_cinemaDao.ObterCinemasDto(skip, take, enderecoId));
        }

        [HttpGet("{id}")]
        public IActionResult RecuperarCinemaPorId(int id)
        {
            ReadCinemaDto cinemaDto = _cinemaDao.ObterCinemaDtoPorId(id);

            return cinemaDto is null ? NotFound() : Ok(cinemaDto);
        }

        [HttpPut("{id}")]
        public IActionResult AtualizarCinema(int id, UpdateCinemaDto cinemaDto)
        {
            Cinema cinema = _cinemaDao.ObterPorId(id);

            if(cinema is null) return NotFound();

            _cinemaDao.AlterarCinemaDto(cinemaDto, cinema);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult DeletarCinema(int id)
        {
            Cinema cinema = _cinemaDao.ObterPorId(id);

            if(cinema is null) return NotFound();

            _cinemaDao.Excluir(cinema);

            return NoContent();
        }
    }
}
