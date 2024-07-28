using BasicAPI.DBContext;
using ErrorOr;

namespace BasicAPI.Services.GetService
{
    public interface ITaskService
    {
        ErrorOr<Created> CreateTask(Task task, ClientDBContext _dbContext);

        ErrorOr<Task> GetTask(int Id, ClientDBContext _dbContext);

        ErrorOr<Updated> UpdateTask(Task task, ClientDBContext _dbContext);

        ErrorOr<Deleted> DeleteTask(int Id, ClientDBContext _dbContext);
    }
}