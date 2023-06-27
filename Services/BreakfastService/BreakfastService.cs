using Azure.Core;
using BasicAPI.DBContext;
using ErrorOr;
using Microsoft.IdentityModel.Tokens;

namespace BasicAPI.Services.GetService
{
    public class BreakfastService : IBreakfastService
    {
        public ErrorOr<Created> CreateBreakfast(Breakfast request, BreakfastContext breakfastContext)
        {
            breakfastContext.Breakfast.Add(request);
            breakfastContext.SaveChanges();
            return Result.Created;
        }
        public ErrorOr<Breakfast> GetBreakfast(int Id, BreakfastContext breakfastContext)
        {
            return breakfastContext.Breakfast.Find(Id) != null ? breakfastContext.Breakfast.Find(Id) : Error.NotFound("Breakfast not found.");
        }

        public ErrorOr<Updated> UpdateBreakfast(Breakfast request, BreakfastContext breakfastContext)
        {

            return Result.Updated;
        }
        public ErrorOr<Deleted> DeleteBreakfast(int Id, BreakfastContext breakfastContext)
        {
            if (!breakfastContext.Breakfast.IsNullOrEmpty())
            {
                var toBeDeleted = breakfastContext.Breakfast.Find(Id);
                if (toBeDeleted != null)
                {
                    breakfastContext.Breakfast.Remove(toBeDeleted);
                    breakfastContext.SaveChanges();
                    return Result.Deleted;
                }
                else
                    return Error.NotFound("Breakfast not found.");
            }
            else
                return Error.NotFound("Breakfast not found.");
        }
    }
}
