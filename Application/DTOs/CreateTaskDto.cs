using System.ComponentModel.DataAnnotations;

namespace Servidor.Application.DTOs
{
    public class CreateTaskDto
    {
        [Required]
        [MaxLength(100)]
        public string Titulo { get; set; } = null!;
        public string? Descricao { get; set; }
        public int StatusId { get; set; }
        public DateTime? DataDeConclusao { get; set; }
    }
}
