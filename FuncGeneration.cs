using System;

namespace Joe.Caching
{
    public partial class Cache
    {

		public void Add<TResult>(String key, TimeSpan duration, Func<TResult> handle)
        {
            this.Add(key, duration, (Delegate)handle);
        }
		public TResult GetOrAdd<TResult>(String key, TimeSpan duration, Func<TResult> handle)
        {
            return (TResult)this.GetOrAdd(key, duration, (Delegate)handle);
        }
		public void Add<T1, TResult>(String key, TimeSpan duration, Func<T1, TResult> handle)
        {
            this.Add(key, duration, (Delegate)handle);
        }
		public TResult GetOrAdd<T1, TResult>(String key, TimeSpan duration, Func<T1, TResult> handle, T1 arg1)
        {
            return (TResult)this.GetOrAdd(key, duration, (Delegate)handle, arg1);
        }
		public void Add<T1, T2, TResult>(String key, TimeSpan duration, Func<T1, T2, TResult> handle)
        {
            this.Add(key, duration, (Delegate)handle);
        }
		public TResult GetOrAdd<T1, T2, TResult>(String key, TimeSpan duration, Func<T1, T2, TResult> handle, T1 arg1, T2 arg2)
        {
            return (TResult)this.GetOrAdd(key, duration, (Delegate)handle, arg1, arg2);
        }
		public void Add<T1, T2, T3, TResult>(String key, TimeSpan duration, Func<T1, T2, T3, TResult> handle)
        {
            this.Add(key, duration, (Delegate)handle);
        }
		public TResult GetOrAdd<T1, T2, T3, TResult>(String key, TimeSpan duration, Func<T1, T2, T3, TResult> handle, T1 arg1, T2 arg2, T3 arg3)
        {
            return (TResult)this.GetOrAdd(key, duration, (Delegate)handle, arg1, arg2, arg3);
        }
		public void Add<T1, T2, T3, T4, TResult>(String key, TimeSpan duration, Func<T1, T2, T3, T4, TResult> handle)
        {
            this.Add(key, duration, (Delegate)handle);
        }
		public TResult GetOrAdd<T1, T2, T3, T4, TResult>(String key, TimeSpan duration, Func<T1, T2, T3, T4, TResult> handle, T1 arg1, T2 arg2, T3 arg3, T4 arg4)
        {
            return (TResult)this.GetOrAdd(key, duration, (Delegate)handle, arg1, arg2, arg3, arg4);
        }
		public void Add<T1, T2, T3, T4, T5, TResult>(String key, TimeSpan duration, Func<T1, T2, T3, T4, T5, TResult> handle)
        {
            this.Add(key, duration, (Delegate)handle);
        }
		public TResult GetOrAdd<T1, T2, T3, T4, T5, TResult>(String key, TimeSpan duration, Func<T1, T2, T3, T4, T5, TResult> handle, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5)
        {
            return (TResult)this.GetOrAdd(key, duration, (Delegate)handle, arg1, arg2, arg3, arg4, arg5);
        }
		public void Add<T1, T2, T3, T4, T5, T6, TResult>(String key, TimeSpan duration, Func<T1, T2, T3, T4, T5, T6, TResult> handle)
        {
            this.Add(key, duration, (Delegate)handle);
        }
		public TResult GetOrAdd<T1, T2, T3, T4, T5, T6, TResult>(String key, TimeSpan duration, Func<T1, T2, T3, T4, T5, T6, TResult> handle, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6)
        {
            return (TResult)this.GetOrAdd(key, duration, (Delegate)handle, arg1, arg2, arg3, arg4, arg5, arg6);
        }
		public void Add<T1, T2, T3, T4, T5, T6, T7, TResult>(String key, TimeSpan duration, Func<T1, T2, T3, T4, T5, T6, T7, TResult> handle)
        {
            this.Add(key, duration, (Delegate)handle);
        }
		public TResult GetOrAdd<T1, T2, T3, T4, T5, T6, T7, TResult>(String key, TimeSpan duration, Func<T1, T2, T3, T4, T5, T6, T7, TResult> handle, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7)
        {
            return (TResult)this.GetOrAdd(key, duration, (Delegate)handle, arg1, arg2, arg3, arg4, arg5, arg6, arg7);
        }
		public void Add<T1, T2, T3, T4, T5, T6, T7, T8, TResult>(String key, TimeSpan duration, Func<T1, T2, T3, T4, T5, T6, T7, T8, TResult> handle)
        {
            this.Add(key, duration, (Delegate)handle);
        }
		public TResult GetOrAdd<T1, T2, T3, T4, T5, T6, T7, T8, TResult>(String key, TimeSpan duration, Func<T1, T2, T3, T4, T5, T6, T7, T8, TResult> handle, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8)
        {
            return (TResult)this.GetOrAdd(key, duration, (Delegate)handle, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8);
        }
		public void Add<T1, T2, T3, T4, T5, T6, T7, T8, T9, TResult>(String key, TimeSpan duration, Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, TResult> handle)
        {
            this.Add(key, duration, (Delegate)handle);
        }
		public TResult GetOrAdd<T1, T2, T3, T4, T5, T6, T7, T8, T9, TResult>(String key, TimeSpan duration, Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, TResult> handle, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9)
        {
            return (TResult)this.GetOrAdd(key, duration, (Delegate)handle, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9);
        }
		public void Add<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, TResult>(String key, TimeSpan duration, Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, TResult> handle)
        {
            this.Add(key, duration, (Delegate)handle);
        }
		public TResult GetOrAdd<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, TResult>(String key, TimeSpan duration, Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, TResult> handle, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9, T10 arg10)
        {
            return (TResult)this.GetOrAdd(key, duration, (Delegate)handle, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10);
        }
		public void Add<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, TResult>(String key, TimeSpan duration, Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, TResult> handle)
        {
            this.Add(key, duration, (Delegate)handle);
        }
		public TResult GetOrAdd<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, TResult>(String key, TimeSpan duration, Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, TResult> handle, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9, T10 arg10, T11 arg11)
        {
            return (TResult)this.GetOrAdd(key, duration, (Delegate)handle, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11);
        }
		public void Add<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, TResult>(String key, TimeSpan duration, Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, TResult> handle)
        {
            this.Add(key, duration, (Delegate)handle);
        }
		public TResult GetOrAdd<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, TResult>(String key, TimeSpan duration, Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, TResult> handle, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9, T10 arg10, T11 arg11, T12 arg12)
        {
            return (TResult)this.GetOrAdd(key, duration, (Delegate)handle, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11, arg12);
        }
		public void Add<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, TResult>(String key, TimeSpan duration, Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, TResult> handle)
        {
            this.Add(key, duration, (Delegate)handle);
        }
		public TResult GetOrAdd<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, TResult>(String key, TimeSpan duration, Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, TResult> handle, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9, T10 arg10, T11 arg11, T12 arg12, T13 arg13)
        {
            return (TResult)this.GetOrAdd(key, duration, (Delegate)handle, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11, arg12, arg13);
        }
		public void Add<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, TResult>(String key, TimeSpan duration, Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, TResult> handle)
        {
            this.Add(key, duration, (Delegate)handle);
        }
		public TResult GetOrAdd<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, TResult>(String key, TimeSpan duration, Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, TResult> handle, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9, T10 arg10, T11 arg11, T12 arg12, T13 arg13, T14 arg14)
        {
            return (TResult)this.GetOrAdd(key, duration, (Delegate)handle, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11, arg12, arg13, arg14);
        }
		public void Add<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, TResult>(String key, TimeSpan duration, Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, TResult> handle)
        {
            this.Add(key, duration, (Delegate)handle);
        }
		public TResult GetOrAdd<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, TResult>(String key, TimeSpan duration, Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, TResult> handle, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9, T10 arg10, T11 arg11, T12 arg12, T13 arg13, T14 arg14, T15 arg15)
        {
            return (TResult)this.GetOrAdd(key, duration, (Delegate)handle, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11, arg12, arg13, arg14, arg15);
        }
		public void Add<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, TResult>(String key, TimeSpan duration, Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, TResult> handle)
        {
            this.Add(key, duration, (Delegate)handle);
        }
		public TResult GetOrAdd<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, TResult>(String key, TimeSpan duration, Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, TResult> handle, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9, T10 arg10, T11 arg11, T12 arg12, T13 arg13, T14 arg14, T15 arg15, T16 arg16)
        {
            return (TResult)this.GetOrAdd(key, duration, (Delegate)handle, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11, arg12, arg13, arg14, arg15, arg16);
        }
	}
}

