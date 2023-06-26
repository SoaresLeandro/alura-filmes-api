using FilmesAPI.Data.Dtos;
using FilmesAPI.Models;

namespace FilmesAPI.Data.Daos
{
    public interface IFilmeDao
    {
        Filme ObterFilmePorId(int id);

        ReadFilmeDto ObterFilmeDtoPorId(int id);

        IEnumerable<Filme> ListarFilmes();

        IEnumerable<ReadFilmeDto> ObterFilmesDto(int skip = 0, int take = 0, string? nomeDoCinema = null);

        Filme AdicionarFilme(CreateFilmeDto filmeDto);

        void AtualizarFilme(UpdateFilmeDto filmeDto, Filme filme);

        void RemoverFilme(Filme filme);
    }
}
