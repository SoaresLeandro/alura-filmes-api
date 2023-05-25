using AutoMapper;
using FilmesAPI.Data;
using FilmesAPI.Data.Dtos;
using FilmesAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace FilmesAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CinemaController : ControllerBase
    {
        private FilmeContext _context;
        private IMapper _mapper;
        public CinemaController(FilmeContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpPost]
        public IActionResult AdicionaCinema([FromBody] CreateCinemaDto cinemaDto)
        {
            Cinema cinema = _mapper.Map<Cinema>(cinemaDto);
            _context.Cinemas.Add(cinema);
            _context.SaveChanges();

            return CreatedAtAction(nameof(RecuperarCinemaPorId), new { id = cinema.Id }, cinema);
        }

        [HttpGet]
        public IActionResult RecuperarFilmes([FromQuery] int skip = 0, [FromQuery] int take = 2)
        {
            return Ok(_mapper.Map<List<ReadCinemaDto>>(_context.Cinemas.ToList().Skip(skip).Take(take)));
        }

        [HttpGet("{id}")]
        public IActionResult RecuperarCinemaPorId(int id)
        {
            Cinema cinema = _context.Cinemas.FirstOrDefault(cinema => cinema.Id == id);

            ReadCinemaDto cinemaDto = _mapper.Map<ReadCinemaDto>(cinema);

            return cinema is null ? NotFound() : Ok(cinemaDto);
        }

        [HttpPut("{id}")]
        public IActionResult AtualizarCinema(int id, UpdateCinemaDto cinemaDto)
        {
            Cinema cinema = _context.Cinemas.FirstOrDefault(cinema => cinema.Id == id);

            if(cinema is null) return NotFound();

            _mapper.Map(cinemaDto, cinema);
            _context.SaveChanges();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult DeletarCinema(int id)
        {
            Cinema cinema = _context.Cinemas.FirstOrDefault(cinema => cinema.Id == id);

            if(cinema is null) return NotFound();

            _context.Cinemas.Remove(cinema);
            _context.SaveChanges();

            return NoContent();
        }
    }
}
