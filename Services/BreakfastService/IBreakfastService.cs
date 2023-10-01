using BasicAPI.DBContext;
using ErrorOr;

namespace BasicAPI.Services.GetService
{
    public interface IBreakfastService
    {
        ErrorOr<Created> CreateBreakfast(Breakfast request, DBContext.DBContext _dbContext);

        ErrorOr<Breakfast> GetBreakfast(int Id, DBContext.DBContext _dbContext);

        ErrorOr<Updated> UpdateBreakfast(Breakfast request, DBContext.DBContext _dbContext);

        ErrorOr<Deleted> DeleteBreakfast(int Id, DBContext.DBContext _dbContext);
    }
}
