using System;
using static LangRoids;

/// <summary>
/// A collection of conditional functions that all are Perform'd on Invoke
/// </summary>
public class Reasoning {
    /// <summary>
    /// "Sequence of reasoning"
    /// </summary>
    /// <returns></returns>
    (Func<bool> Test, Action Do)[] Sequence {get;set;}

    public Reasoning(params (Func<bool>, Action)[] reasons) {
        Sequence = reasons;
    }

    public void Invoke() => ForEach(Sequence, reason => Perform(reason.Test, reason.Do));

    public static implicit operator Reasoning((Func<bool>, Action)[] perfs) => new Reasoning(perfs);
}