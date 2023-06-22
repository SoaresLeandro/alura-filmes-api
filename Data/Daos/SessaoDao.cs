﻿using AutoMapper;
using FilmesAPI.Data.Dtos;
using FilmesAPI.Models;

namespace FilmesAPI.Data.Daos
{
    public class SessaoDao
    {
        private FilmeContext _context;
        private IMapper _mapper;

        public SessaoDao(FilmeContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public Sessao AdicionarSessao(CreateSessaoDto sessaoDto)
        {
            Sessao sessao = _mapper.Map<Sessao>(sessaoDto);

            _context.Sessoes.Add(sessao);
            _context.SaveChanges();

            return sessao;
        }

        public IEnumerable<ReadSessaoDto> ObterSessoesDto() =>
            _mapper.Map<List<ReadSessaoDto>>(_context.Sessoes.ToList());

        public ReadSessaoDto RecuperarSessao(int cinemaId, int filmeId) =>
            _mapper.Map<ReadSessaoDto>(_context.Sessoes
                .FirstOrDefault(sessao => sessao.CinemaId == cinemaId && sessao.FilmeId == filmeId));
    }
}
