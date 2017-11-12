using System;
using System.Collections.Generic;
using System.Text;

public static partial class LangRoids {
    /// <summary>
    /// Call each function in order. 
    /// </summary>
    /// <param name="funcs"></param>
    public static void Compose(params Action[] funcs) {
        for (int i = 0 ; i < funcs.Length ; i++) {
            funcs[i].Invoke( );
        }
    }

    /// <summary>
    /// Conditional run of compose. If test is true, run compose.
    /// </summary>
    /// <param name="test"></param>
    /// <param name="funcs"></param>
    public static void Compose(bool test, params Action[] funcs) => Perform(test, () => {
        for (int i = 0 ; i < funcs.Length ; i++) {
            funcs[i].Invoke( );
        }
    });

    /// <summary>
    /// Perform a set of operations on an object of T
    /// </summary>
    /// <typeparam name="T">The type to use</typeparam>
    /// <param name="arg">The item to operate on</param>
    /// <param name="pipeline">The array of functions to iterate over</param>
    public static void Compose<T>(T arg, params Action<T>[] pipeline) 
        => Repeat(pipeline.Length, i => pipeline[i](arg));
	public static void Compose<T1, T2>(T1 arg1, T2 arg2, params Action<T1, T2>[] pipeline) 
        => Repeat(pipeline.Length, i => pipeline[i](arg1, arg2));
	public static void Compose<T1, T2, T3>(T1 arg1, T2 arg2, T3 arg3, params Action<T1, T2, T3>[] pipeline) 
        => Repeat(pipeline.Length, i => pipeline[i](arg1, arg2, arg3));
	public static void Compose<T1, T2, T3, T4>(T1 arg1, T2 arg2, T3 arg3, T4 arg4, params Action<T1, T2, T3, T4>[] pipeline) 
        => Repeat(pipeline.Length, i => pipeline[i](arg1, arg2, arg3, arg4));
	public static void Compose<T1, T2, T3, T4, T5>(T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, params Action<T1, T2, T3, T4, T5>[] pipeline) 
        => Repeat(pipeline.Length, i => pipeline[i](arg1, arg2, arg3, arg4, arg5));
	public static void Compose<T1, T2, T3, T4, T5, T6>(T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, params Action<T1, T2, T3, T4, T5, T6>[] pipeline) 
        => Repeat(pipeline.Length, i => pipeline[i](arg1, arg2, arg3, arg4, arg5, arg6));
	public static void Compose<T1, T2, T3, T4, T5, T6, T7>(T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, params Action<T1, T2, T3, T4, T5, T6, T7>[] pipeline) 
        => Repeat(pipeline.Length, i => pipeline[i](arg1, arg2, arg3, arg4, arg5, arg6, arg7));
	public static void Compose<T1, T2, T3, T4, T5, T6, T7, T8>(T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, params Action<T1, T2, T3, T4, T5, T6, T7, T8>[] pipeline) 
        => Repeat(pipeline.Length, i => pipeline[i](arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8));
	public static void Compose<T1, T2, T3, T4, T5, T6, T7, T8, T9>(T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9, params Action<T1, T2, T3, T4, T5, T6, T7, T8, T9>[] pipeline) 
        => Repeat(pipeline.Length, i => pipeline[i](arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9));
    /// <summary>
    /// Perform a set of operations if test is true on an object of T
    /// </summary>
    /// <typeparam name="T">The type to use</typeparam>
    /// <param name="test">Whether or not the pipeline should be executed</param>
    /// <param name="arg">The item to operate on</param>
    /// <param name="pipeline">The array of functions to iterate over</param>
    public static void Compose<T>(bool test, T arg, params Action<T>[] pipeline) => 
    	Perform(test, () => Compose(arg, pipeline));
    public static void Compose<T1, T2>(bool test, T1 arg1, T2 arg2, params Action<T1, T2>[] pipeline) => 
    	Perform(test, () => Compose(arg1, arg2, pipeline));
    public static void Compose<T1, T2, T3>(bool test, T1 arg1, T2 arg2, T3 arg3, params Action<T1, T2, T3>[] pipeline) => 
    	Perform(test, () => Compose(arg1, arg2, arg3, pipeline));
    public static void Compose<T1, T2, T3, T4>(bool test, T1 arg1, T2 arg2, T3 arg3, T4 arg4, params Action<T1, T2, T3, T4>[] pipeline) => 
    	Perform(test, () => Compose(arg1, arg2, arg3, arg4, pipeline));
    public static void Compose<T1, T2, T3, T4, T5>(bool test, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, params Action<T1, T2, T3, T4, T5>[] pipeline) => 
    	Perform(test, () => Compose(arg1, arg2, arg3, arg4, arg5, pipeline));
    public static void Compose<T1, T2, T3, T4, T5, T6>(bool test, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6,  params Action<T1, T2, T3, T4, T5, T6>[] pipeline) => 
    	Perform(test, () => Compose(arg1, arg2, arg3, arg4, arg5, arg6, pipeline));
    public static void Compose<T1, T2, T3, T4, T5, T6, T7>(bool test, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, params Action<T1, T2, T3, T4, T5, T6, T7>[] pipeline) => 
    	Perform(test, () => Compose(arg1, arg2, arg3, arg4, arg5, arg6, arg7, pipeline));
    public static void Compose<T1, T2, T3, T4, T5, T6, T7, T8>(bool test, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, params Action<T1, T2, T3, T4, T5, T6, T7, T8>[] pipeline) => 
    	Perform(test, () => Compose(arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, pipeline));
    public static void Compose<T1, T2, T3, T4, T5, T6, T7, T8, T9>(bool test, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9, params Action<T1, T2, T3, T4, T5, T6, T7, T8, T9>[] pipeline) => 
    	Perform(test, () => Compose(arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, pipeline));
}