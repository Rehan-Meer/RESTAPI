using BasicAPI.DBContext;
using ErrorOr;

namespace BasicAPI.Services.GetService
{
    public interface IBreakfastService
    {
        ErrorOr<Created> CreateBreakfast(Breakfast request, BreakfastContext breakfastContext);

        ErrorOr<Breakfast> GetBreakfast(int Id, BreakfastContext breakfastContext);

        ErrorOr<Updated> UpdateBreakfast(Breakfast request, BreakfastContext breakfastContext);

        ErrorOr<Deleted> DeleteBreakfast(int Id, BreakfastContext breakfastContext);
    }
}
