﻿using AutoMapper;
using FilmesAPI.Data.Dtos;
using FilmesAPI.Models;

namespace FilmesAPI.Data.Daos
{
    public class FilmeDao
    {
        private FilmeContext _context;
        private IMapper _mapper;

        public FilmeDao(FilmeContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public Filme ObterFilmePorId(int id) => 
            _context.Filmes.FirstOrDefault(filme => filme.Id == id);

        public ReadFilmeDto ObterFilmeDtoPorId(int id) =>
            _mapper.Map<ReadFilmeDto>(_context.Filmes.FirstOrDefault(f => f.Id == id));

        public IEnumerable<Filme> ListarFilmes() => _context.Filmes.ToList();

        public IEnumerable<ReadFilmeDto> ObterFilmesDto(int skip = 0, int take = 0, string? nomeDoCinema = null)
        {
            return nomeDoCinema is null ?
                _mapper.Map<List<ReadFilmeDto>>(_context.Filmes.Skip(skip).Take(take).ToList()) :
                _mapper.Map<List<ReadFilmeDto>>(_context.Filmes
                    .Skip(skip)
                    .Take(2)
                    .Where(filme => filme.Sessoes
                        .Any(sessao => sessao.Cinema.Nome == nomeDoCinema))
                    .ToList());
        }

        public Filme AdicionarFilme(CreateFilmeDto filmeDto)
        {
            Filme filme = _mapper.Map<Filme>(filmeDto);

            _context.Filmes.Add(filme);
            _context.SaveChanges();

            return filme;
        }

        public void AtualizarFilme(UpdateFilmeDto filmeDto, Filme filme)
        {
            _mapper.Map(filme, filmeDto);

            _context.Update(filme);
            _context.SaveChanges();
        }

        public void RemoverFilme(Filme filme)
        {
            _context.Remove(filme);
            _context.SaveChanges();
        }
    }
}
