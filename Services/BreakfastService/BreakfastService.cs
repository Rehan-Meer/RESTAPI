using BasicAPI.DBContext;
using ErrorOr;
using Microsoft.IdentityModel.Tokens;

namespace BasicAPI.Services.GetService
{
    public class BreakfastService : IBreakfastService
    {
        public ErrorOr<Created> CreateBreakfast(Breakfast request, DBContext.DBContext _dbContext)
        {
            _dbContext.Breakfast.Add(request);
            _dbContext.SaveChanges();
            return Result.Created;
        }
        public ErrorOr<Breakfast> GetBreakfast(int Id, DBContext.DBContext _dbContext)
        {
            return _dbContext.Breakfast.Find(Id) != null ? _dbContext.Breakfast.Find(Id) : Error.NotFound("Breakfast not found.");
        }
        public ErrorOr<Updated> UpdateBreakfast(Breakfast request, DBContext.DBContext _dbContext)
        {
            if (!_dbContext.Breakfast.IsNullOrEmpty())
            {
                var toBeUpdated = _dbContext.Breakfast.Find(request.Id);
                if (toBeUpdated != null)
                {
                    toBeUpdated.Update(request);
                    _dbContext.SaveChanges();
                    return Result.Updated;
                }
                else
                    return Error.NotFound("Breakfast not found.");
            }
            else
                return Error.NotFound("No Breakfast Found.");
        }
        public ErrorOr<Deleted> DeleteBreakfast(int Id, DBContext.DBContext _dbContext)
        {
            if (!_dbContext.Breakfast.IsNullOrEmpty())
            {
                var toBeDeleted = _dbContext.Breakfast.Find(Id);
                if (toBeDeleted != null)
                {
                    _dbContext.Breakfast.Remove(toBeDeleted);
                    _dbContext.SaveChanges();
                    return Result.Deleted;
                }
                else
                    return Error.NotFound("Breakfast not found.");
            }
            else
                return Error.NotFound("No Breakfast Found.");
        }
    }
}