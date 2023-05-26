namespace FilmesAPI.Data.Dtos
{
    public class ReadFilmeDto
    {        
        public string Titulo { get; set; }
        
        public string Genero { get; set; }
        
        public string Diretor { get; set; }
        public int Duracao { get; set; }
        public DateTime DataDaConsulta { get => DateTime.Now;  }
        public ICollection<ReadSessaoDto> Sessoes { get; set; }
    }
}
