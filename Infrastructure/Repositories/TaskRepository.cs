using Business_Logic.Interfaces.Repositories;
using Domain;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories
{
    public class TaskRepository : ITaskRepository
    {
        private readonly ApllicationDbContext _context;
        public TaskRepository(ApllicationDbContext context)
        {
            _context = context;
        }
        public async Task<Domain.ToDoTask> GetByIdAsync(int id)
        {
            return await _context.Tasks
                .Where(t => t.Id == id)
                .FirstOrDefaultAsync();
        }
        public async Task<IEnumerable<Domain.ToDoTask>> GetAllAsync()
        {
            return await _context.Tasks
                .ToListAsync();
        }
        public async Task AddAsync(ToDoTask task)
        {
            await _context.Tasks.AddAsync(task);
            await _context.SaveChangesAsync();
        }
        public async Task UpdateAsync(Domain.ToDoTask task)
        {
            _context.Tasks.Update(task);
            await _context.SaveChangesAsync();
        }
        public async Task DeleteAsync(ToDoTask task)
        {
            _context.Tasks.Remove(task);
            await _context.SaveChangesAsync();
        }
    }
}
