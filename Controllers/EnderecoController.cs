using FilmesAPI.Data.Daos;
using FilmesAPI.Data.Dtos;
using FilmesAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace FilmesAPI.Controllers
{
    [ApiController]
    [Route("[Controller]")]
    public class EnderecoController : ControllerBase
    {
        private IEnderecoDao _enderecoDao;

        public EnderecoController(IEnderecoDao enderecoDao)
        {
            _enderecoDao = enderecoDao;
        }

        [HttpPost]
        public IActionResult AdiconarEndereco([FromBody] CreateEnderecoDto enderecoDto)
        {
            Endereco endereco =  _enderecoDao.AdicionarEndereco(enderecoDto);

            return CreatedAtAction(nameof(RecuperarEnderecoPorId), new { Id = endereco.Id }, endereco);
        }

        [HttpGet("{id}")]
        public IActionResult RecuperarEnderecoPorId(int id)
        {
            ReadEnderecoDto endereco = _enderecoDao.ObterEnderecoDtoPorId(id);

            return endereco is null ? NotFound() : Ok(endereco);
        }

        [HttpGet]
        public IActionResult RecuperarEnderecos()
        {
            return Ok(_enderecoDao.ObterEnderecosDto());
        }

        [HttpPut("{id}")]
        public IActionResult AtualizarEndereco([FromBody] UpdateEnderecoDto enderecoDto, int id)
        {
            Endereco endereco = _enderecoDao.ObterEnderecoPorId(id);

            if(endereco is null) return NotFound();

            _enderecoDao.AtualizarEndereco(enderecoDto, endereco);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult ExcluirEndereco(int id)
        {
            Endereco endereco = _enderecoDao.ObterEnderecoPorId(id);

            if(endereco is null) return NotFound();

            _enderecoDao.RemoverEndereco(endereco);

            return NoContent();
        }
    }
}
