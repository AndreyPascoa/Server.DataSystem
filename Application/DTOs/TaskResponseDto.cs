namespace Servidor.Application.DTOs
{
    public class TaskResponseDto
    {
        public int Id { get; set; }
        public string Titulo { get; set; } = null!;
        public string? Descricao { get; set; }
        public string Status { get; set; } = null!;
        public DateTime DataDeCriacao { get; set; }
        public DateTime? DataDeConclusao { get; set; }
    }
}
