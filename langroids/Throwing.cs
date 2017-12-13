using System;
using System.Collections.Generic;

public static partial class LangRoids {
    /// <summary>
    /// Do Action if it is not null, or throw the excepion e
    /// </summary>
    /// <param name="act">The action to perform</param>
    /// <param name="e">The exception to throw if act is null</param>
    public static void DoOrThrow<E>(Action act) where E : Exception, new() {
        if (act == null) {
            throw new E();
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
    public static void DoOrThrow<E>(bool test, Action act) where E : Exception, new() 
        => Perform(test, () => DoOrThrow<E>(act));

    /// <summary>
    /// Throw the exception if test is true
    /// </summary>
    /// <param name="test"></param>
    /// <param name="e"></param>
    public static void ThrowIf<E>(bool test) where E : Exception, new() 
        => Perform(test, () => throw new E());
    public static void ThrowIf<E>(Func<bool> test, Exception e) where E : Exception, new()
        => ThrowIf<E>(test( ));
}