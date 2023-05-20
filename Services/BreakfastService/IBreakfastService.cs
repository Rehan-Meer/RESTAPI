using BasicAPI.InternalModels;
using ErrorOr;

namespace BasicAPI.Services.GetService
{
    public interface IBreakfastService
    {
        ErrorOr<Created> CreateBreakfast(BreakfastModel Request);

        ErrorOr<BreakfastModel> GetBreakfast(int Id);

        ErrorOr<Updated> UpdateBreakfast(BreakfastModel Request);

        ErrorOr<Deleted> DeleteBreakfast(int Id);
    }
}
