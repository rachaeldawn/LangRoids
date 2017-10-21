using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public static partial class LangRoids {
    /// <summary>
    /// Filter everything failing the predicate, and return it as a new IEnumerable<typeparamref name="T"/>
    /// </summary>
    /// <typeparam name="T">The type to use</typeparam>
    /// <param name="col">The collection to filter</param>
    /// <param name="pred">The predicate to use in the filter process</param>
    /// <returns></returns>
    public static IEnumerable<T> Filter<T>(this IEnumerable<T> col, Predicate<T> pred) {
        foreach (var obj in col) {
            if (pred(obj)) {
                yield return obj;
            }
        }
    }
}
