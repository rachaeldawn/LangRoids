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
    /// Set an reference to any variable to its default value.
    /// </summary>
    /// <param name="arg">The reference to nullify</param>
    public static void Nullify<T>(ref T arg) => arg = default;

    /// <summary>
    /// Set an object to null
    /// </summary>
    /// <param name="arg">The object to set to null</param>
    public static void Nullify(object arg) => arg = null;


    /// <summary>
    /// Return the default value for type T
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <returns></returns>
    public static T Nothing<T>() => default;
}