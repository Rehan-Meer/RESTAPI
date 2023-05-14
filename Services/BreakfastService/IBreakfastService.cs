using BasicAPI.DTOs;
using BasicAPI.InternalModels;

namespace BasicAPI.Services.GetService
{
    public interface IBreakfastService
    {
        void CreateBreakfast(BreakfastModel _request);

        BreakfastModel GetBreakfast(int _id);

        void UpdateBreakfast(BreakfastModel id);

        void DeleteBreakfast(int id);
    }
}
