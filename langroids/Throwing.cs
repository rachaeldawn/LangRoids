using System;
using System.Collections.Generic;

public static partial class LangRoids {
    /// <summary>
    /// Do Action if it is not null, or throw the excepion e
    /// </summary>
    /// <param name="act">The action to perform</param>
    /// <param name="e">The exception to throw if act is null</param>
    public static void DoOrThrow(Action act, Exception e) {
        if (act == null) {
            throw e;
        } else {
            act.Invoke( );
        }
    }
    /// <summary>
    /// Conditional DoOrThrow. If test is true, run DoOrThrow.
    /// </summary>
    /// <param name="test"></param>
    /// <param name="act"></param>
    /// <param name="e"></param>
    public static void DoOrThrow(bool test, Action act, Exception e) => Perform(test, () => DoOrThrow(act, e));

    
    

    


    /// <summary>
    /// Throw the exception if test is true
    /// </summary>
    /// <param name="test"></param>
    /// <param name="e"></param>
    public static void ThrowIf(bool test, Exception e) => Perform(test, () => throw e);
    public static void ThrowIf(Func<bool> test, Exception e) => ThrowIf(test( ), e);   
}