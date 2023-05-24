namespace FilmesAPI.Data.Dtos
{
    public class ReadSessaoDto
    {
        public int FilmeId { get; set; }
        public int CinemaId { get; set; }
        public DateTime DataDaConsulta { get => DateTime.Now; }
    }
}
