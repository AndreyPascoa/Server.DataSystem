using System.ComponentModel.DataAnnotations.Schema;

namespace Servidor.Domain.Entities
{
    public class TaskItem
    {
        public int Id { get; set; }
        public string Titulo { get; set; }
        public string? Descricao { get; set; }
        public DateTime DataDeCriacao { get; set; }
        public DateTime? DataDeConclusao { get; set; }

        public int StatusId { get; set; }

        public Status Status { get; set; }
    }
}
