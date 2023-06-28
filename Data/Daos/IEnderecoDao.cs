using FilmesAPI.Data.Dtos;
using FilmesAPI.Models;

namespace FilmesAPI.Data.Daos
{
    public interface IEnderecoDao : ICommand<Endereco>, IQuery<Endereco>
    {
        ReadEnderecoDto ObterEnderecoDtoPorId(int id);

        //Endereco ObterEnderecoPorId(int id);

        IEnumerable<ReadEnderecoDto> ObterEnderecosDto(int skip = 0, int take = 0);

        //IEnumerable<Endereco> ObterEnderecos();

        Endereco AdicionarEndereco(CreateEnderecoDto enderecoDto);

        void AtualizarEndereco(UpdateEnderecoDto enderecoDto, Endereco endereco);

        //void RemoverEndereco(Endereco endereco);
    }
}
