using Domain;

namespace Business_Logic.Interfaces.Repositories
{
    public interface ITaskFileRepository
    {
        Task<TaskFile> GetByIdAsync(int id);
        Task<IEnumerable<TaskFile>> GetAllAsync();
        Task AddAsync(TaskFile taskFile);
        Task UpdateAsync(TaskFile taskFile);
        Task DeleteAsync(TaskFile taskFile);
        //Task<IEnumerable<TaskFile>> GetFilesByTaskIdAsync(TaskFile taskFile);
    }
}
