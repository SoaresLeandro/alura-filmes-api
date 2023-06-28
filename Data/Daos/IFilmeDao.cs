using FilmesAPI.Data.Dtos;
using FilmesAPI.Models;

namespace FilmesAPI.Data.Daos
{
    public interface IFilmeDao : ICommand<Filme>, IQuery<Filme>
    {
        ReadFilmeDto ObterFilmeDtoPorId(int id);

        IEnumerable<ReadFilmeDto> ObterFilmesDto(int skip = 0, int take = 0, string? nomeDoCinema = null);

        Filme AdicionarFilme(CreateFilmeDto filmeDto);

        void AtualizarFilme(UpdateFilmeDto filmeDto, Filme filme);
    }
}
