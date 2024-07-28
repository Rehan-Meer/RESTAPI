using ErrorOr;

namespace BasicAPI.Services.GetService
{
    public class TaskService : ITaskService
    {
        public ErrorOr<Created> CreateTask(Task task, DBContext.ClientDBContext _dbContext)
        {
            _dbContext.Task.Add(task);
            _dbContext.SaveChanges();
            return Result.Created;
        }
        public ErrorOr<Task> GetTask(int Id, DBContext.ClientDBContext _dbContext) =>
            _dbContext.Task.Find(Id) is Task task ? task : Error.NotFound("Task not found.");

        public ErrorOr<List<Task>> GetAllTasks(DBContext.ClientDBContext _dbContext) =>
            _dbContext.Task.Count() > 0 ? _dbContext.Task.ToList() : Error.NotFound("Task not found.");

        public ErrorOr<Updated> UpdateTask(Task task, DBContext.ClientDBContext _dbContext)
        {
            var toBeUpdated = _dbContext.Task.First(u => u.Id == task.Id);
            if (toBeUpdated == null)
                return Error.NotFound("Task not found.");

            toBeUpdated.Update(task);
            _dbContext.SaveChanges();
            return Result.Updated;
        }
        public ErrorOr<Deleted> DeleteTask(int Id, DBContext.ClientDBContext _dbContext)
        {
            var toBeDeleted = _dbContext.Task.First(u => u.Id == Id);

            if (toBeDeleted == null)
                return Error.NotFound("Task not found.");

            _dbContext.Task.Remove(toBeDeleted);
            _dbContext.SaveChanges();
            return Result.Deleted;
        }
    }
}