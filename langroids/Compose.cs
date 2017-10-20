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
    public static void Compose<T>(T arg, params Action<T>[] pipeline) => Repeat(pipeline.Length, i => pipeline[i](arg));

    /// <summary>
    /// Perform a set of operations if test is true on an object of T
    /// </summary>
    /// <typeparam name="T">The type to use</typeparam>
    /// <param name="test">Whether or not the pipeline should be executed</param>
    /// <param name="arg">The item to operate on</param>
    /// <param name="pipeline">The array of functions to iterate over</param>
    public static void Compose<T>(bool test, T arg, params Action<T>[] pipeline) => Perform(test, () => Compose(arg, pipeline));
}