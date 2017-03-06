using System;

namespace FunctionalCSharp.VladimirKhorikov
{
    public static class MaybeExtensions
    {
        public static Result<T> ToResult<T>(this Maybe<T> maybe, string errorMessage)
            where T : class
        {
            if (maybe.HasNoValue)
                return Result.Fail<T>(errorMessage);

            return Result.Ok(maybe.Value);
        }

        public static T Unwrap<T>(this Maybe<T> maybe, T defaultValue = null)
            where T : class
        {
            return maybe.Unwrap(x => x, defaultValue);
        }

        public static TK Unwrap<T, TK>(this Maybe<T> maybe, Func<T, TK> selector, TK defaultValue = default(TK))
            where T : class
        {
            return maybe.HasValue ? selector(maybe.Value) : defaultValue;
        }

        public static Maybe<T> Where<T>(this Maybe<T> maybe, Func<T, bool> predicate)
            where T : class
        {
            if (maybe.HasNoValue)
                return null;

            return predicate(maybe.Value) ? maybe : null;
        }

        public static Maybe<TK> Select<T, TK>(this Maybe<T> maybe, Func<T, TK> selector)
            where T : class
            where TK : class
        {
            return maybe.HasNoValue ? null : selector(maybe.Value);
        }

        public static Maybe<TK> Select<T, TK>(this Maybe<T> maybe, Func<T, Maybe<TK>> selector)
            where T : class
            where TK : class
        {
            return maybe.HasNoValue ? null : selector(maybe.Value);
        }

        public static void Execute<T>(this Maybe<T> maybe, Action<T> action)
            where T : class
        {
            if (maybe.HasNoValue)
                return;

            action(maybe.Value);
        }
    }
}
