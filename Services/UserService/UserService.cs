using ErrorOr;

namespace BasicAPI.Services.GetService
{
    public class UserService : IUserService
    {
        public ErrorOr<Created> CreateUser(User user, DBContext.ClientDBContext _dbContext)
        {
            _dbContext.User.Add(user);
            _dbContext.SaveChanges();
            return Result.Created;
        }
        public ErrorOr<User> GetUser(int Id, DBContext.ClientDBContext _dbContext) =>
            _dbContext.User.Find(Id) is User user ? user : Error.NotFound("User not found.");
        public ErrorOr<List<User>> GetAllUsers(DBContext.ClientDBContext _dbContext) =>
            _dbContext.User.Count() > 0 ? _dbContext.User.ToList() : Error.NotFound("User not found.");
        public ErrorOr<Updated> UpdateUser(User user, DBContext.ClientDBContext _dbContext)
        {
            var toBeUpdated = _dbContext.User.First(u => u.Id == user.Id);
            if (toBeUpdated == null)
                return Error.NotFound("User not found.");

            toBeUpdated.Update(user);
            _dbContext.SaveChanges();
            return Result.Updated;
        }
        public ErrorOr<Deleted> DeleteUser(int Id, DBContext.ClientDBContext _dbContext)
        {
            var toBeDeleted = _dbContext.User.First(u => u.Id == Id);

            if (toBeDeleted == null)
                return Error.NotFound("User not found.");

            _dbContext.User.Remove(toBeDeleted);
            _dbContext.SaveChanges();
            return Result.Deleted;
        }
    }
}