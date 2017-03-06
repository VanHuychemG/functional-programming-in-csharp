using System;
using System.Threading.Tasks;

namespace FunctionalCSharp.VladimirKhorikov
{
    /// <summary>
    /// Extensions for async operations where the task appears in the left operand only
    /// </summary>
    public static class AsyncResultExtensionsLeftOperand
    {
        public static async Task<Result<TK>> OnSuccess<T, TK>(this Task<Result<T>> resultTask, Func<T, TK> func)
        {
            var result = await resultTask.ConfigureAwait(false);

            return result.OnSuccess(func);
        }

        public static async Task<Result<T>> OnSuccess<T>(this Task<Result> resultTask, Func<T> func)
        {
            var result = await resultTask.ConfigureAwait(false);

            return result.OnSuccess(func);
        }

        public static async Task<Result<TK>> OnSuccess<T, TK>(this Task<Result<T>> resultTask, Func<T, Result<TK>> func)
        {
            var result = await resultTask.ConfigureAwait(false);

            return result.OnSuccess(func);
        }

        public static async Task<Result<T>> OnSuccess<T>(this Task<Result> resultTask, Func<Result<T>> func)
        {
            var result = await resultTask.ConfigureAwait(false);

            return result.OnSuccess(func);
        }

        public static async Task<Result<TK>> OnSuccess<T, TK>(this Task<Result<T>> resultTask, Func<Result<TK>> func)
        {
            var result = await resultTask.ConfigureAwait(false);

            return result.OnSuccess(func);
        }

        public static async Task<Result> OnSuccess<T>(this Task<Result<T>> resultTask, Func<T, Result> func)
        {
            var result = await resultTask.ConfigureAwait(false);

            return result.OnSuccess(func);
        }

        public static async Task<Result> OnSuccess(this Task<Result> resultTask, Func<Result> func)
        {
            var result = await resultTask.ConfigureAwait(false);

            return result.OnSuccess(func);
        }

        public static async Task<Result<T>> Ensure<T>(this Task<Result<T>> resultTask, Func<T, bool> predicate, string errorMessage)
        {
            var result = await resultTask.ConfigureAwait(false);

            return result.Ensure(predicate, errorMessage);
        }

        public static async Task<Result> Ensure(this Task<Result> resultTask, Func<bool> predicate, string errorMessage)
        {
            var result = await resultTask.ConfigureAwait(false);

            return result.Ensure(predicate, errorMessage);
        }

        public static async Task<Result<TK>> Map<T, TK>(this Task<Result<T>> resultTask, Func<T, TK> func)
        {
            var result = await resultTask.ConfigureAwait(false);

            return result.Map(func);
        }

        public static async Task<Result<T>> Map<T>(this Task<Result> resultTask, Func<T> func)
        {
            var result = await resultTask.ConfigureAwait(false);

            return result.Map(func);
        }

        public static async Task<Result<T>> OnSuccess<T>(this Task<Result<T>> resultTask, Action<T> action)
        {
            var result = await resultTask.ConfigureAwait(false);

            return result.OnSuccess(action);
        }

        public static async Task<Result> OnSuccess(this Task<Result> resultTask, Action action)
        {
            var result = await resultTask.ConfigureAwait(false);

            return result.OnSuccess(action);
        }

        public static async Task<T> OnBoth<T>(this Task<Result> resultTask, Func<Result, T> func)
        {
            var result = await resultTask.ConfigureAwait(false);

            return result.OnBoth(func);
        }

        public static async Task<TK> OnBoth<T, TK>(this Task<Result<T>> resultTask, Func<Result<T>, TK> func)
        {
            var result = await resultTask.ConfigureAwait(false);

            return result.OnBoth(func);
        }

        public static async Task<Result<T>> OnFailure<T>(this Task<Result<T>> resultTask, Action action)
        {
            var result = await resultTask.ConfigureAwait(false);

            return result.OnFailure(action);
        }

        public static async Task<Result> OnFailure(this Task<Result> resultTask, Action action)
        {
            var result = await resultTask.ConfigureAwait(false);

            return result.OnFailure(action);
        }

        public static async Task<Result<T>> OnFailure<T>(this Task<Result<T>> resultTask, Action<string> action)
        {
            var result = await resultTask.ConfigureAwait(false);

            return result.OnFailure(action);
        }
    }
}
