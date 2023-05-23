using AutoMapper;
using FilmesAPI.Data.Dtos;
using FilmesAPI.Models;

namespace FilmesAPI.Profiles
{
    public class EnderecoProfile : Profile
    {
        public EnderecoProfile()
        {
            CreateMap<Endereco, CreateEnderecoDto>().ReverseMap();
            CreateMap<Endereco, UpdateEnderecoDto>().ReverseMap();
            CreateMap<Endereco, ReadEnderecoDto>().ReverseMap();
        }
    }
}
