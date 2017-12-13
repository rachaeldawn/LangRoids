using System;
using System.Collections.Generic;
using System.Text;


public static partial class LangRoids {
    /// <summary>
    /// Call success if test is true, otherwise call fail
    /// </summary>
    /// <param name="test"></param>
    /// <param name="fail"></param>
    /// <param name="success"></param>
    public static void Perform(bool test, Action fail, Action success) {
        if (test) {
            success( );
            return;
        }
        fail( );
    }

    /// <summary>
    /// Call success if test is true
    /// </summary>
    /// <param name="test"></param>
    /// <param name="success"></param>
    public static void Perform(bool test, Action success)
        => Perform(test, DoNothing, success);

    public static void Perform<E>(bool test, Action success)
        where  E : Exception, new()
        => Perform(test, () => throw new E( ), success);
    /// <summary>
    /// Throw an exception if the test fails, otherwise perform success
    /// </summary>
    /// <param name="test"></param>
    /// <param name="fail"></param>
    /// <param name="success"></param>
    public static void Perform<E>(Func<bool> test, Action success)
        where E : Exception, new()
        => Perform(test( ), () => throw new E( ), success);

    public static void Perform<E>(bool test, Action fail, Action success)
        where E : Exception, new()
        => Perform(test, (fail ?? (() => throw new E( ))), success);
    /// <summary>
    /// Call success if performing test returns true, otherwise call fail
    /// </summary>
    /// <param name="test"></param>
    /// <param name="fail"></param>
    /// <param name="success"></param>
    public static void Perform(Func<bool> test, Action fail, Action success)
        => Perform(test( ), fail, success);


    public static void Perform<E>(Func<bool> test, Action fail, Action success)
        where E : Exception, new()
        => Perform(test( ), (fail ?? (() => throw new E( ))), success);
    /// <summary>
    /// Call success when the result of test is true, otherwise do nothing.
    /// </summary>
    /// <param name="test"></param>
    /// <param name="success"></param>
    public static void Perform(Func<bool> test, Action success)
        => Perform(test, DoNothing, success);

    public static void Perform(Assurance asr, Action success)
        => Perform(asr.Test, asr.Fail, success);

    public static void Perform(Assurance[] asrs, Action success) {
        foreach (var asr in asrs) {
            if (!asr.Test) {
                asr.Fail( );
                return;
            }
        }
        success( );
    }
    public static void Perform(Assurance a1, Assurance a2, Action success)
        => Perform(new Assurance[] { a1, a2 }, success);
    public static void Perform(Assurance a1, Assurance a2, Assurance a3, Action success)
        => Perform(new Assurance[] { a1, a2, a3 }, success);
    public static void Perform(Assurance a1, Assurance a2, Assurance a3, Assurance a4, Action success)
        => Perform(new Assurance[] { a1, a2, a3, a4 }, success);
    public static void Perform(Assurance a1, Assurance a2, Assurance a3, Assurance a4, Assurance a5, Action success)
        => Perform(new Assurance[] { a1, a2, a3, a4, a5 }, success);
    public static void Perform(Assurance a1, Assurance a2, Assurance a3, Assurance a4, Assurance a5, Assurance a6, Action success)
        => Perform(new Assurance[] { a1, a2, a3, a4, a5, a6 }, success);
    public static void Perform(Assurance a1, Assurance a2, Assurance a3, Assurance a4, Assurance a5, Assurance a6, Assurance a7, Action success)
        => Perform(new Assurance[] { a1, a2, a3, a4, a5, a6, a7 }, success);
    public static void Perform(Assurance a1, Assurance a2, Assurance a3, Assurance a4, Assurance a5, Assurance a6, Assurance a7, Assurance a8, Action success)
        => Perform(new Assurance[] { a1, a2, a3, a4, a5, a6, a7, a8 }, success);
    public static void Perform(Assurance a1, Assurance a2, Assurance a3, Assurance a4, Assurance a5, Assurance a6, Assurance a7, Assurance a8, Assurance a9, Action success)
        => Perform(new Assurance[] { a1, a2, a3, a4, a5, a6, a7, a8, a9 }, success);

    public static void Perform<E>(Assurance<E> asr, Action success)
        where E : Exception, new()
        => Perform<E>(asr.Test, asr.Fail, success);

    public static void Perform<E1, E2>(Assurance<E1> a1, Assurance<E2> a2, Action success)
        where E1 : Exception, new()
        where E2 : Exception, new()
        => Perform(Assure(a1) && Assure(a2), success);

    public static void Perform<E1, E2, E3>(Assurance<E1> a1, Assurance<E2> a2, Assurance<E3> a3, Action success)
        where E1 : Exception, new()
        where E2 : Exception, new()
        where E3 : Exception, new()
        => Perform(Assure(a1) && Assure(a2) && Assure(a3), success);

    public static void Perform<E1, E2, E3, E4, E5, E6>(Assurance<E1> a1, Assurance<E2> a2, Assurance<E3> a3, Assurance<E4> a4, Action success)
        where E1 : Exception, new()
        where E2 : Exception, new()
        where E3 : Exception, new()
        where E4 : Exception, new()
        => Perform(Assure(a1) && Assure(a2) && Assure(a3) && Assure(a4), success);

    public static void Perform<E1, E2, E3, E4, E5>(Assurance<E1> a1, Assurance<E2> a2, Assurance<E3> a3, Assurance<E4> a4, Assurance<E5> a5, Action success)
        where E1 : Exception, new()
        where E2 : Exception, new()
        where E3 : Exception, new()
        where E4 : Exception, new()
        where E5 : Exception, new()
        => Perform(Assure(a1) && Assure(a2) && Assure(a3) && Assure(a4) && Assure(a5), success);
        
    public static void Perform<E1, E2, E3, E4, E5, E6>(Assurance<E1> a1, Assurance<E2> a2, Assurance<E3> a3, Assurance<E4> a4, Assurance<E5> a5, Assurance<E6> a6, Action success)
        where E1 : Exception, new()
        where E2 : Exception, new()
        where E3 : Exception, new()
        where E4 : Exception, new()
        where E5 : Exception, new()
        where E6 : Exception, new()
        => Perform(Assure(a1) && Assure(a2) && Assure(a3) && Assure(a4) && Assure(a5) && Assure(a6), success);
        
    public static void Perform<E1, E2, E3, E4, E5, E6, E7>(Assurance<E1> a1, Assurance<E2> a2, Assurance<E3> a3, Assurance<E4> a4, Assurance<E5> a5, Assurance<E6> a6, Assurance<E7> a7, Action success)
        where E1 : Exception, new()
        where E2 : Exception, new()
        where E3 : Exception, new()
        where E4 : Exception, new()
        where E5 : Exception, new()
        where E6 : Exception, new()
        where E7 : Exception, new()
        => Perform(Assure(a1) && Assure(a2) && Assure(a3) && Assure(a4) && Assure(a5) && Assure(a6) && Assure(a7), success);
        
    public static void Perform<E1, E2, E3, E4, E5, E6, E7, E8>(Assurance<E1> a1, Assurance<E2> a2, Assurance<E3> a3, Assurance<E4> a4, Assurance<E5> a5, Assurance<E6> a6, Assurance<E7> a7, Assurance<E8> a8, Action success)
        where E1 : Exception, new()
        where E2 : Exception, new()
        where E3 : Exception, new()
        where E4 : Exception, new()
        where E5 : Exception, new()
        where E6 : Exception, new()
        where E7 : Exception, new()
        where E8 : Exception, new()
        => Perform(Assure(a1) && Assure(a2) && Assure(a3) && Assure(a4) && Assure(a5) && Assure(a6) && Assure(a7) && Assure(a8), success);
        
    public static void Perform<E1, E2, E3, E4, E5, E6, E7, E8, E9>(Assurance<E1> a1, Assurance<E2> a2, Assurance<E3> a3, Assurance<E4> a4, Assurance<E5> a5, Assurance<E6> a6, Assurance<E7> a7, Assurance<E8> a8, Assurance<E9> a9, Action success)
        where E1 : Exception, new()
        where E2 : Exception, new()
        where E3 : Exception, new()
        where E4 : Exception, new()
        where E5 : Exception, new()
        where E6 : Exception, new()
        where E7 : Exception, new()
        where E8 : Exception, new()
        where E9 : Exception, new()
        => Perform(Assure(a1) && Assure(a2) && Assure(a3) && Assure(a4) && Assure(a5) && Assure(a6) && Assure(a7) && Assure(a8) && Assure(a9), success);

}
