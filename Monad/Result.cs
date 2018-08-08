using System;

namespace Monad
{
    public struct Result<T>
    {
        private readonly T _value;
        public readonly Exception Exception;

        public T Value
        {
            get
            {
                if (Exception != null)
                {
                    throw Exception;
                }
                return _value;
            }
        }

        public bool IsFailed { get; internal set; }

        public Result(T value)
        {
            _value = value;
            IsFailed = false;
            Exception = null;
        }

        public Result(string error)
        {
            if (error == null) throw new ArgumentNullException("e");
            Exception = new Exception(error);
            IsFailed = true;
            _value = default(T);
        }

        public Result<T> Succeded()
        {
            return this;
        }

        public Result<T> Failed(string error)
        {
            return new Result<T>(error);
        }

        public override string ToString()
        {
            return IsFailed
                ? Exception.ToString()
                : Value != null
                    ? Value.ToString()
                    : "[null]";
        }
    }
}