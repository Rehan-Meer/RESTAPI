using BasicAPI.InternalModels;
using System.Diagnostics.CodeAnalysis;

namespace BasicAPI.Services.GetService
{
    public class BreakfastService : IBreakfastService
    {
        private static readonly Dictionary<int, BreakfastModel> _result = new();


        public void CreateBreakfast(BreakfastModel _request) => _result.Add(_request.Id, _request);

        public BreakfastModel GetBreakfast(int _id) => _result[_id];

        public void UpdateBreakfast(BreakfastModel request) => _result[request.Id] = request;

        public void DeleteBreakfast(int id) => _result.Remove(id);
    }
}
