using ErrorOr;

namespace BasicAPI.Services.GetService
{
    public interface IBreakfastService
    {
        ErrorOr<Created> CreateBreakfast(Breakfast request);

        ErrorOr<Breakfast> GetBreakfast(int Id);

        ErrorOr<Updated> UpdateBreakfast(Breakfast request);

        ErrorOr<Deleted> DeleteBreakfast(int Id);
    }
}
