using FilmesAPI.Data.Dtos;
using FilmesAPI.Models;

namespace FilmesAPI.Data.Daos
{
    public interface ISessaoDao
    {
        Sessao AdicionarSessao(CreateSessaoDto sessaoDto);

        IEnumerable<ReadSessaoDto> ObterSessoesDto();

        ReadSessaoDto RecuperarSessao(int cinemaId, int filmeId);
    }
}
