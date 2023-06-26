using FilmesAPI.Data.Daos;
using FilmesAPI.Data.Dtos;
using FilmesAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace FilmesAPI.Controllers
{
    [ApiController, Route("{Controller}")]
    public class SessaoController : ControllerBase
    {
        private ISessaoDao _sessaoDao;

        public SessaoController(ISessaoDao sessaoDao)
        {
            _sessaoDao = sessaoDao;
        }

        [HttpPost]
        public IActionResult CadastrarSessao([FromBody] CreateSessaoDto sessaoDto)
        {
            Sessao sessao = _sessaoDao.AdicionarSessao(sessaoDto);

            return CreatedAtAction(nameof(RecuperarSessao), new { CinemaId = sessao.CinemaId, FilmeId = sessao.FilmeId }, sessao);
        }

        [HttpGet]
        public IActionResult RecuperarSessoes()
        {
            return Ok(_sessaoDao.ObterSessoesDto());
        }

        [HttpGet("{cinemaId}/{filmeId}")]
        public IActionResult RecuperarSessao(int cinemaId, int filmeId) 
        {
            ReadSessaoDto sessao = _sessaoDao.RecuperarSessao(cinemaId, filmeId);

            return sessao is null ? NotFound() : Ok(sessao);
        }
    }
}
