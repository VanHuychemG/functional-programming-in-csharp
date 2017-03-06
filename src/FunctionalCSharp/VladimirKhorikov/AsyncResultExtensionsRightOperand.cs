using System;
using System.Threading.Tasks;

namespace FunctionalCSharp.VladimirKhorikov
{
    /// <summary>
    ///     Extensions for async operations where the task appears in the right operand only
    /// </summary>
    public static class AsyncResultExtensionsRightOperand
    {
        public static async Task<Result<TK>> OnSuccess<T, TK>(this Result<T> result, Func<T, Task<TK>> func)
        {
            if (result.IsFailure)
                return Result.Fail<TK>(result.Error);

            var value = await func(result.Value).ConfigureAwait(false);

            return Result.Ok(value);
        }

        public static async Task<Result<T>> OnSuccess<T>(this Result result, Func<Task<T>> func)
        {
            if (result.IsFailure)
                return Result.Fail<T>(result.Error);

            var value = await func().ConfigureAwait(false);

            return Result.Ok(value);
        }

        public static async Task<Result<TK>> OnSuccess<T, TK>(this Result<T> result, Func<T, Task<Result<TK>>> func)
        {
            if (result.IsFailure)
                return Result.Fail<TK>(result.Error);

            return await func(result.Value).ConfigureAwait(false);
        }

        public static async Task<Result<T>> OnSuccess<T>(this Result result, Func<Task<Result<T>>> func)
        {
            if (result.IsFailure)
                return Result.Fail<T>(result.Error);

            return await func().ConfigureAwait(false);
        }

        public static async Task<Result<TK>> OnSuccess<T, TK>(this Result<T> result, Func<Task<Result<TK>>> func)
        {
            if (result.IsFailure)
                return Result.Fail<TK>(result.Error);

            return await func().ConfigureAwait(false);
        }

        public static async Task<Result> OnSuccess<T>(this Result<T> result, Func<T, Task<Result>> func)
        {
            if (result.IsFailure)
                return Result.Fail(result.Error);

            return await func(result.Value).ConfigureAwait(false);
        }

        public static async Task<Result> OnSuccess(this Result result, Func<Task<Result>> func)
        {
            if (result.IsFailure)
                return result;

            return await func().ConfigureAwait(false);
        }

        public static async Task<Result<T>> Ensure<T>(this Result<T> result, Func<T, Task<bool>> predicate, string errorMessage)
        {
            if (result.IsFailure)
                return Result.Fail<T>(result.Error);

            if (!await predicate(result.Value).ConfigureAwait(false))
                return Result.Fail<T>(errorMessage);

            return Result.Ok(result.Value);
        }

        public static async Task<Result> Ensure(this Result result, Func<Task<bool>> predicate, string errorMessage)
        {
            if (result.IsFailure)
                return Result.Fail(result.Error);

            if (!await predicate().ConfigureAwait(false))
                return Result.Fail(errorMessage);

            return Result.Ok();
        }

        public static async Task<Result<TK>> Map<T, TK>(this Result<T> result, Func<T, Task<TK>> func)
        {
            if (result.IsFailure)
                return Result.Fail<TK>(result.Error);

            var value = await func(result.Value).ConfigureAwait(false);

            return Result.Ok(value);
        }

        public static async Task<Result<T>> Map<T>(this Result result, Func<Task<T>> func)
        {
            if (result.IsFailure)
                return Result.Fail<T>(result.Error);

            var value = await func().ConfigureAwait(false);

            return Result.Ok(value);
        }

        public static async Task<Result<T>> OnSuccess<T>(this Result<T> result, Func<T, Task> action)
        {
            if (result.IsSuccess)
                await action(result.Value).ConfigureAwait(false);

            return result;
        }

        public static async Task<Result> OnSuccess(this Result result, Func<Task> action)
        {
            if (result.IsSuccess)
                await action().ConfigureAwait(false);

            return result;
        }

        public static async Task<T> OnBoth<T>(this Result result, Func<Result, Task<T>> func)
        {
            return await func(result).ConfigureAwait(false);
        }

        public static async Task<TK> OnBoth<T, TK>(this Result<T> result, Func<Result<T>, Task<TK>> func)
        {
            return await func(result).ConfigureAwait(false);
        }

        public static async Task<Result<T>> OnFailure<T>(this Result<T> result, Func<Task> func)
        {
            if (result.IsFailure)
                await func().ConfigureAwait(false);

            return result;
        }

        public static async Task<Result> OnFailure(this Result result, Func<Task> func)
        {
            if (result.IsFailure)
                await func().ConfigureAwait(false);

            return result;
        }

        public static async Task<Result<T>> OnFailure<T>(this Result<T> result, Func<string, Task> func)
        {
            if (result.IsFailure)
                await func(result.Error).ConfigureAwait(false);

            return result;
        }
    }
}
