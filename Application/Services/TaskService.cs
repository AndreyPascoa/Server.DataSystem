using Servidor.Application.DTOs;
using Servidor.Application.Interfaces;
using Servidor.Domain.Entities;

namespace Servidor.Application.Services
{
    public class TaskService : ITaskService
    {
        private readonly ITaskRepository _repository;

        public TaskService(ITaskRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<TaskResponseDto>> GetAllAsync()
        {
            var tasks = await _repository.GetAllAsync();

            return tasks.Select(t => new TaskResponseDto
            {
                Id = t.Id,
                Titulo = t.Titulo,
                Descricao = t.Descricao,
                Status = t.Status.Descricao,
                DataDeCriacao = t.DataDeCriacao,
                DataDeConclusao = t.DataDeConclusao
            }).ToList();
        }

        public async Task<TaskResponseDto?> GetByIdAsync(int id)
        {
            var task = await _repository.GetByIdAsync(id);

            if (task is null)
                return null;

            return new TaskResponseDto
            {
                Id = task.Id,
                Titulo = task.Titulo,
                Descricao = task.Descricao,
                Status = task.Status.Descricao,
                DataDeCriacao = task.DataDeCriacao,
                DataDeConclusao = task.DataDeConclusao
            };
        }

        public async Task CreateAsync(CreateTaskDto dto)
        {
            if (dto.Titulo.Length > 100)
                throw new ArgumentException("O título não pode ter mais de 100 caracteres.");


            if (string.IsNullOrWhiteSpace(dto.Titulo))
                throw new ArgumentException("O título é obrigatório.");

            if (dto.DataDeConclusao.HasValue &&
                dto.DataDeConclusao < DateTime.Now)
                throw new ArgumentException("Data de conclusão inválida.");

            var task = new TaskItem
            {
                Titulo = dto.Titulo,
                Descricao = dto.Descricao,
                StatusId = dto.StatusId,
                DataDeConclusao = dto.DataDeConclusao
            };

            await _repository.AddAsync(task);
        }

        public async Task<bool> UpdateAsync(int id, UpdateTaskDto dto)
        {
            if (dto.Titulo.Length > 100)
                throw new ArgumentException("O título não pode ter mais de 100 caracteres.");

            var task = await _repository.GetByIdAsync(id);
            if (task == null)
                return false;

            if (dto.DataDeConclusao.HasValue && dto.DataDeConclusao.Value < task.DataDeCriacao)
                throw new ArgumentException("A data de conclusão não pode ser anterior à data de criação.");

            task.Titulo = dto.Titulo;
            task.Descricao = dto.Descricao;
            task.StatusId = dto.StatusId;

            if (dto.StatusId == 3 && !dto.DataDeConclusao.HasValue)
            {
                task.DataDeConclusao = DateTime.Now;
            }
            else
            {
                task.DataDeConclusao = dto.DataDeConclusao;
            }

            await _repository.UpdateAsync(task);
            return true;
        }


        public async Task<bool> DeleteAsync(int id)
        {
            var task = await _repository.GetByIdAsync(id);
            if (task == null)
                return false;

            await _repository.DeleteAsync(task);
            return true;
        }
    }
}
