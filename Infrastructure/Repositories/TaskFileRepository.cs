using Business_Logic.Interfaces.Repositories;
using Domain;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories
{
    public class TaskFileRepository : ITaskFileRepository
    {
        private readonly ApllicationDbContext _context;
        public TaskFileRepository(ApllicationDbContext context)
        {
            _context = context;
        }
        public async Task<TaskFile> GetByIdAsync(int id)
        {
            return await _context.TaskFiles
                .Where(tf => tf.Id == id)
                .FirstOrDefaultAsync();
        }
        public async Task<IEnumerable<TaskFile>> GetAllAsync()
        {
            return await _context.TaskFiles
                .ToListAsync();
        }
        public async Task AddAsync(TaskFile taskFile)
        {
            await _context.TaskFiles.AddAsync(taskFile);
            await _context.SaveChangesAsync();
        }
        public async Task UpdateAsync(TaskFile taskFile)
        {
            _context.TaskFiles.Update(taskFile);
            await _context.SaveChangesAsync();
        }
        public async Task DeleteAsync(TaskFile taskFile)
        {
            _context.TaskFiles.Remove(taskFile);
            await _context.SaveChangesAsync();
        }
    }
}
