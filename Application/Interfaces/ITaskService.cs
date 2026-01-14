using Servidor.Application.DTOs;

namespace Servidor.Application.Interfaces
{
    public interface ITaskService
    {
        Task<List<TaskResponseDto>> GetAllAsync();
        Task<TaskResponseDto?> GetByIdAsync(int id);
        Task CreateAsync(CreateTaskDto taskDto);
        Task<bool> UpdateAsync(int id, UpdateTaskDto taskDto);
        Task<bool> DeleteAsync(int id);
    }
}
