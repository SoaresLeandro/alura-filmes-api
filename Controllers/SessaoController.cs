using AutoMapper;
using FilmesAPI.Data;
using FilmesAPI.Data.Dtos;
using FilmesAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace FilmesAPI.Controllers
{
    [ApiController, Route("{Controller}")]
    public class SessaoController : ControllerBase
    {
        private FilmeContext _context;
        private IMapper _mapper;

        public SessaoController(FilmeContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpPost]
        public IActionResult CadastrarSessao([FromBody] CreateSessaoDto sessaoDto)
        {
            Sessao sessao = _mapper.Map<Sessao>(sessaoDto);
            _context.Sessoes.Add(sessao);
            _context.SaveChanges();

            return CreatedAtAction(nameof(RecuperarSessaoPorId), new { id = sessao.Id }, sessao);
        }

        [HttpGet]
        public IActionResult RecuperarSessoes()
        {
            return Ok(_mapper.Map<List<ReadSessaoDto>>(_context.Sessoes.ToList()));
        }

        [HttpGet("{id}")]
        public IActionResult RecuperarSessaoPorId(int id) 
        {
            Sessao sessao = _context.Sessoes.FirstOrDefault(sessao => sessao.Id == id);

            return sessao is null ? NotFound() : Ok(_mapper.Map<ReadSessaoDto>(sessao));
        }
    }
}
