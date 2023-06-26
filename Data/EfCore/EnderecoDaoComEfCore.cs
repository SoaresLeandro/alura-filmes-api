using AutoMapper;
using FilmesAPI.Data.Daos;
using FilmesAPI.Data.Dtos;
using FilmesAPI.Models;

namespace FilmesAPI.Data.EfCore
{
    public class EnderecoDaoComEfCore : IEnderecoDao
    {
        private FilmeContext _context;
        private IMapper _mapper;

        public EnderecoDaoComEfCore(FilmeContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public ReadEnderecoDto ObterEnderecoDtoPorId(int id) =>
            _mapper.Map<ReadEnderecoDto>(_context.Enderecos.FirstOrDefault(endereco => endereco.Id == id));

        public Endereco ObterEnderecoPorId(int id) =>
            _context.Enderecos.FirstOrDefault(endereco => endereco.Id == id);

        public IEnumerable<ReadEnderecoDto> ObterEnderecosDto(int skip = 0, int take = 0) =>
            _mapper.Map<IEnumerable<ReadEnderecoDto>>(_context.Enderecos.Skip(skip).Take(take).ToList());

        public IEnumerable<Endereco> ObterEnderecos() =>
            _context.Enderecos.ToList();

        public Endereco AdicionarEndereco(CreateEnderecoDto enderecoDto)
        {
            Endereco endereco = _mapper.Map<Endereco>(enderecoDto);

            _context.Enderecos.Add(endereco);
            _context.SaveChanges();

            return endereco;
        }

        public void AtualizarEndereco(UpdateEnderecoDto enderecoDto, Endereco endereco)
        {
            _mapper.Map(enderecoDto, endereco);

            _context.Enderecos.Update(endereco);
            _context.SaveChanges();
        }

        public void RemoverEndereco(Endereco endereco)
        {
            _context.Enderecos.Remove(endereco);
            _context.SaveChanges();
        }
    }
}
