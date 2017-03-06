using System.Threading.Tasks;

namespace FunctionalCSharp.VladimirKhorikov
{
    public static class AsyncMaybeExtensions
    {
        public static async Task<Result<T>> ToResult<T>(this Task<Maybe<T>> maybeTask, string errorMessage)
            where T : class
        {
            var maybe = await maybeTask.ConfigureAwait(false);

            return maybe.ToResult(errorMessage);
        }
    }
}
