using BasicAPI.DBContext;
using ErrorOr;

namespace BasicAPI.Services.GetService
{
    public interface IUserService
    {
        ErrorOr<Created> CreateUser(User user, DBContext.ClientDBContext _dbContext);

        ErrorOr<User> GetUser(int Id, DBContext.ClientDBContext _dbContext);

        ErrorOr<List<User>> GetAllUsers(DBContext.ClientDBContext _dbContext);

        ErrorOr<Updated> UpdateUser(User user, DBContext.ClientDBContext _dbContext);

        ErrorOr<Deleted> DeleteUser(int Id, DBContext.ClientDBContext _dbContext);
    }
}
