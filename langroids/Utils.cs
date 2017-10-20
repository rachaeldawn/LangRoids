using System;
using System.Collections.Generic;
using System.Text;

public static partial class LangRoids {
    public static void DoNothing() {
    }
    public static bool ContainsAll<T>(this List<T> obj, List<T> all) {
        foreach (var val in all) {
            if (!obj.Contains(val)) {
                return false;
            }
        }
        return true;
    }


    /// <summary>
    /// Set an object to its default value.
    /// </summary>
    /// <param name="arg">The object to nullify</param>
    public static void Nullify<T>(ref T arg) => arg = default;


    /// <summary>
    /// Return the default value for type T
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <returns></returns>
    public static T Nothing<T>() => default;
}