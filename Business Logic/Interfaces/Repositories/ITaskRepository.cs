using Domain;

namespace Business_Logic.Interfaces.Repositories
{
    public interface ITaskRepository
    {
        Task<ToDoTask>GetByIdAsync(int id);
        Task<IEnumerable<ToDoTask>> GetAllAsync();
        Task AddAsync(ToDoTask task);
        Task UpdateAsync(ToDoTask task);
        Task DeleteAsync(ToDoTask task);
    }
}
