using System;
using System.Collections.Generic;
using System.Text;

public static partial class LangRoids {
    /// <summary>
    /// Repeat something amt times.
    /// </summary>
    /// <param name="amt"></param>
    /// <param name="act"></param>
    public static void Repeat(int amt, Action act) => Perform(amt != 0, () => {
        for (int i = 0 ; i < amt ; i++) {
            act.Invoke( );
        }
    });

    /// <summary>
    /// Repeat something amt times, passing in the iteration's index.
    /// </summary>
    /// <param name="amt"></param>
    /// <param name="act"></param>
    public static void Repeat(int amt, Action<int> act) => Perform(amt != 0, () => Repeat(amt, 0, act));
    /// <summary>
    /// Repeat something amt times, starting at index startIndex, passing in the iterations index.
    /// </summary>
    /// <param name="amt"></param>
    /// <param name="startIndex"></param>
    /// <param name="act"></param>
    public static void Repeat(int amt, int startIndex, Action<int> act) {
        for (int i = 0 ; i < amt ; i++) {
            act.Invoke(startIndex + i);
        }
    }
    public static void ForEach<T>(IEnumerable<T> col, Action<T> func) {
        foreach (T obj in col) {
            func(obj);
        }
    }
}