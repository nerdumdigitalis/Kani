using System;

namespace Kani.Core
{
    public class GenericArgs<T> : EventArgs
    {
        public T Value { get; set; }
    }

    public class GenericArgs<T1, T2> : EventArgs
    {
        public T1 Value1 { get; set; }
        public T2 Value2 { get; set; }
    }

}
