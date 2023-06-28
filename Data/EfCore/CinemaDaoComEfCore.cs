using AutoMapper;
using FilmesAPI.Data.Daos;
using FilmesAPI.Data.Dtos;
using FilmesAPI.Models;

namespace FilmesAPI.Data.EfCore
{
    public class CinemaDaoComEfCore : ICinemaDao
    {
        private FilmeContext _context;
        private IMapper _mapper;

        public CinemaDaoComEfCore(FilmeContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public ReadCinemaDto ObterCinemaDtoPorId(int id) =>
            _mapper.Map<ReadCinemaDto>(_context.Cinemas.FirstOrDefault(cinema => cinema.Id == id));

        public Cinema ObterPorId(int id) =>
            _context.Cinemas.FirstOrDefault(cinema => cinema.Id == id);

        public IEnumerable<ReadCinemaDto> ObterCinemasDto(int skip = 0, int take = 0, int? enderecoId = 0)
        {
            return enderecoId > 0 ?
                _mapper.Map<IEnumerable<ReadCinemaDto>>(_context.Cinemas.Where(cinema => cinema.EnderecoId == enderecoId)
                    .ToList()) :
                _mapper.Map<IEnumerable<ReadCinemaDto>>(_context.Cinemas.Skip(skip).Take(take).ToList());
        }

        public IEnumerable<Cinema> Listar() =>
            _context.Cinemas.ToList();

        public Cinema IncluirCinemaDto(CreateCinemaDto cinemaDto)
        {
            Cinema cinema = _mapper.Map<Cinema>(cinemaDto);

            _context.Cinemas.Add(cinema);
            _context.SaveChanges();

            return cinema;
        }

        public void AlterarCinemaDto(UpdateCinemaDto cinemaDto, Cinema cinema)
        {
            _mapper.Map(cinemaDto, cinema);

            _context.Cinemas.Update(cinema);
            _context.SaveChanges();
        }

        public void Excluir(Cinema cinema)
        {
            _context.Cinemas.Remove(cinema);
            _context.SaveChanges();
        }
    }
}
