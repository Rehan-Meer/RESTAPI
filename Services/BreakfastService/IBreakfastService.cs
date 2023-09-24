using BasicAPI.DBContext;
using ErrorOr;

namespace BasicAPI.Services.GetService
{
    public interface IBreakfastService
    {
        ErrorOr<Created> CreateBreakfast(Breakfast request, BreakfastContext _dbContext);

        ErrorOr<Breakfast> GetBreakfast(int Id, BreakfastContext _dbContext);

        ErrorOr<Updated> UpdateBreakfast(Breakfast request, BreakfastContext _dbContext);

        ErrorOr<Deleted> DeleteBreakfast(int Id, BreakfastContext _dbContext);
    }
}
