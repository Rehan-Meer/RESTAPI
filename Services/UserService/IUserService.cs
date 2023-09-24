using BasicAPI.DBContext;

namespace BasicAPI.Services.UserService
{
    public interface IUserService
    {
        public bool Register(User _user, BreakfastContext dBContext);
        public bool Authenticate(User _user, BreakfastContext dBContext);

    }
}