using System.ComponentModel.DataAnnotations;

namespace FilmesAPI.Models
{
    public class Filme
    {
        [Required(ErrorMessage = "O campo Título é obrigatório.")]
        public string Titulo { get; set; }
        [StringLength(30, ErrorMessage = "O Gênero deve conter no máximo 30 caracteres.")]
        public string Genero { get; set; }
        [Required(ErrorMessage = "O campo Diretor é obrigatório.")]
        public string Diretor { get; set; }
        [Range(1, 600, ErrorMessage = "A duração deve ter entre 1 e 600 minutos.")]
        public int Duracao { get; set; }
    }
}
