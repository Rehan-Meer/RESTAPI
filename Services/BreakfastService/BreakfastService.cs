using ErrorOr;

namespace BasicAPI.Services.GetService
{
    public class BreakfastService : IBreakfastService
    {
        private static readonly Dictionary<int, Breakfast> _breakfasts = new();

        public ErrorOr<Created> CreateBreakfast(Breakfast request)
        {
            _breakfasts.Add(request.Id, request);
            return Result.Created;
        }
        public ErrorOr<Breakfast> GetBreakfast(int Id)
        {
            if (_breakfasts.TryGetValue(Id, out Breakfast? response))
                return response;
            else
                return Error.NotFound("Breakfast not found.");

        }
        public ErrorOr<Updated> UpdateBreakfast(Breakfast request)
        {
            if (!_breakfasts.ContainsKey(request.Id))
                _breakfasts[request.Id] = request;

            return Result.Updated;
        }
        public ErrorOr<Deleted> DeleteBreakfast(int Id)
        {
            if (_breakfasts.ContainsKey(Id))
                _breakfasts.Remove(Id);
            return Result.Deleted;
        }
    }
}
