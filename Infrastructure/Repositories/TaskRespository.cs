using Servidor.Application.Interfaces;
using Servidor.Domain.Entities;
using Servidor.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Servidor.Infrastructure.Repositories
{
    public class TaskRepository : ITaskRepository
    {
        private readonly AppDbContext _context;

        public TaskRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<TaskItem>> GetAllAsync()
            => await _context.Tasks
                .Include(t => t.Status)
                .ToListAsync();

        public async Task<TaskItem?> GetByIdAsync(int id)
            => await _context.Tasks
                .Include(t => t.Status)
                .FirstOrDefaultAsync(t => t.Id == id);

        public async Task AddAsync(TaskItem task)
        {
            _context.Tasks.Add(task);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(TaskItem task)
        {
            _context.Tasks.Update(task);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(TaskItem task)
        {
            _context.Tasks.Remove(task);
            await _context.SaveChangesAsync();
        }
    }
}
