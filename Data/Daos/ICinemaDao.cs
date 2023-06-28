using FilmesAPI.Data.Dtos;
using FilmesAPI.Models;

namespace FilmesAPI.Data.Daos
{
    public interface ICinemaDao : ICommand<Cinema>, IQuery<Cinema>
    {
        ReadCinemaDto ObterCinemaDtoPorId(int id);

        IEnumerable<ReadCinemaDto> ObterCinemasDto(int skip = 0, int take = 0, int? enderecoId = 0);

        Cinema IncluirCinemaDto(CreateCinemaDto cinemaDto);

        void AlterarCinemaDto(UpdateCinemaDto cinemaDto, Cinema cinema);
    }
}
