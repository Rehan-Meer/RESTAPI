using ErrorOr;
namespace BasicAPI.Services
{
    public static class ServiceErrors
    {

        public static Error NotFound => Error.NotFound(StringConstants.BreakfastNotFound);
    }
}
