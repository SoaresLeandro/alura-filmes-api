using FilmesAPI.Data.Dtos;
using FilmesAPI.Models;

namespace FilmesAPI.Data.Daos
{
    public interface ICinemaDao
    {
        ReadCinemaDto ObterCinemaDtoPorId(int id);

        Cinema ObterCinemaPorId(int id);

        IEnumerable<ReadCinemaDto> ObterCinemasDto(int skip = 0, int take = 0, int? enderecoId = 0);

        IEnumerable<Cinema> ObterCinemas();

        Cinema AdicionarCinema(CreateCinemaDto cinemaDto);

        void AtualizarCinema(UpdateCinemaDto cinemaDto, Cinema cinema);

        void RemoverCinema(Cinema cinema);
    }
}
