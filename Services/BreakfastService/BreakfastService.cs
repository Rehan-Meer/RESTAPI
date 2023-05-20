using BasicAPI.InternalModels;
using ErrorOr;

namespace BasicAPI.Services.GetService
{
    public class BreakfastService : IBreakfastService
    {
        private static readonly Dictionary<int, BreakfastModel> _breakfasts = new();

        public ErrorOr<Created> CreateBreakfast(BreakfastModel _request)
        {
            _breakfasts.Add(_request.Id, _request);
            return Result.Created;
        }

        public ErrorOr<BreakfastModel> GetBreakfast(int _id)
        {

            if (_breakfasts.TryGetValue(_id, out BreakfastModel? response))
                return response;
            else
                return ServiceErrors.NotFound;

        }
        public ErrorOr<Updated> UpdateBreakfast(BreakfastModel request)
        {
            if (!_breakfasts.ContainsKey(request.Id))
                _breakfasts[request.Id] = request;

            return Result.Updated;
        }

        public ErrorOr<Deleted> DeleteBreakfast(int id)
        {
            if (_breakfasts.ContainsKey(id))
                _breakfasts.Remove(id);
            return Result.Deleted;
        }
    }
}
