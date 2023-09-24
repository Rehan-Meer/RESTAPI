using BasicAPI.DBContext;

namespace BasicAPI.Services.UserService
{
    public class UserService : IUserService
    {
        public bool Register(User _user, BreakfastContext dBContext)
        {
            dBContext.User.Add(_user);
            dBContext.SaveChanges();
            return true;
        }

        public bool Authenticate(User _user, BreakfastContext dBContext) => dBContext.User.Any(user => user.Equals(_user));
    }
}
