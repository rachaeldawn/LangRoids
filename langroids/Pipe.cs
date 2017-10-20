using System;
using System.Collections.Generic;
using System.Text;

public static partial class LangRoids {
    /// <summary>
    /// Perform a set of operations on an object of T, passing the result to the next function in the <paramref name="pipeline"/>.
    /// </summary>
    /// <typeparam name="T">The type to use</typeparam>
    /// <param name="arg">The item to operate on</param>
    /// <param name="pipeline">The array of functions to iterate over</param>
    /// <returns></returns>
    public static T Pipe<T>(T arg, params Func<T, T>[] pipeline) {
        Repeat(pipeline.Length, i => arg = pipeline[i](arg));
        return arg;
    }
}