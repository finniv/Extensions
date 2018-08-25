using System;
using Monad;

namespace ResultExtension
{

    public static class ResultExtensions
    {

        public static Result<T> When<T>(this Result<T> self, bool condition, string error = "")
        {
            if (condition)
            {
                return self;
            }
            return new Result<T>("error");
        }
        public static Result<T> Do<T>(this Result<T> self, Func<T, T> func)
        {
            try
            {
                return new Result<T>(func(self.Value));
            }
            catch (System.Exception ex)
            {
                Console.WriteLine(ex);
                return self;
            }
        }

        public static Result<T> OnSucces<T>(this Result<T> self, Action action)
        {
            if (!self.IsFailed)
            {
                action();
            }
            return self;
        }
        public static T GetValueOrDefault<T>(this Result<T> self)
        {
            if (self.IsFailed)
            {
                return default(T);
            }
            return self.Value;
        }

        public static Result<TOut> Map<TIn, TOut>(this Result<TIn> self, Func<TIn,TOut> func)
        {
            var mapped = func(self.Value);
            return new Result<TOut>(mapped);
        }
    }
}