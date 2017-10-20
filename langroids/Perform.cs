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
    /// Call success if true, or call DoOrThrow if false using the tuple fail's values for the DoOrThrow
    /// </summary>
    /// <param name="test">Whether or not to perform success</param>
    /// <param name="fail">fail.fail is the action to call, if null, fail.e will be used in DoOrThrow</param>
    /// <param name="success">What to do if the test passes</param>
    public static void Perform(bool test, (Action fail, Exception e) fail, Action success) => Perform(test, () => DoOrThrow(fail.fail, fail.e), success);

    /// <summary>
    /// Call success if true, or call DoOrThrow if false using the tuple fail's values for the DoOrThrow
    /// </summary>
    /// <param name="test">Whether or not to perform success</param>
    /// <param name="fail">fail.fail is the action to call, if null, fail.e will be used in DoOrThrow</param>
    /// <param name="success">What to do if the test passes</param>
    /// <param name="success"></param>
    public static void Perform(Func<bool> test, (Action fail, Exception e) fail, Action success) => Perform(test( ), fail, success);

    /// <summary>
    /// Throw an exception if the test fails, otherwise perform success
    /// </summary>
    /// <param name="test"></param>
    /// <param name="fail"></param>
    /// <param name="success"></param>
    public static void Perform(bool test, Exception fail, Action success) => Perform(test, () => throw fail, success);

    /// <summary>
    /// Throw an exception if the test fails, otherwise perform success
    /// </summary>
    /// <param name="test"></param>
    /// <param name="fail"></param>
    /// <param name="success"></param>
    public static void Perform(Func<bool> test, Exception fail, Action success) => Perform(test( ), () => throw fail, success);
    /// <summary>
    /// Call success if performing test returns true, otherwise call fail
    /// </summary>
    /// <param name="test"></param>
    /// <param name="fail"></param>
    /// <param name="success"></param>
    public static void Perform(Func<bool> test, Action fail, Action success) => Perform(test( ), fail, success);
    /// <summary>
    /// Call success when the result of test is true, otherwise do nothing.
    /// </summary>
    /// <param name="test"></param>
    /// <param name="success"></param>
    public static void Perform(Func<bool> test, Action success) => Perform(test, () => { }, success);

    /// <summary>
    /// Call success if test is true
    /// </summary>
    /// <param name="test"></param>
    /// <param name="success"></param>
    public static void Perform(bool test, Action success) => Perform(test, () => { }, success);

    public static void Perform(Assurance[] assurances, Action success) => Perform(Assure(assurances), success);
    public static void Perform(Assurance assure, Action success) => Perform(assure.Test, (assure.Fail, assure.Except), success);
    public static void Perform(Assurance a1, Assurance a2, Action success) => Perform(Assure(new Assurance[] { a1, a2 }), success);
    public static void Perform(Assurance a1, Assurance a2, Assurance a3, Action success) => Perform(Assure(new Assurance[] { a1, a2, a3 }), success);
    public static void Perform(Assurance a1, Assurance a2, Assurance a3, Assurance a4, Action success) => Perform(Assure(new Assurance[] { a1, a2, a3, a4 }), success);
    public static void Perform(Assurance a1, Assurance a2, Assurance a3, Assurance a4, Assurance a5, Action success) => Perform(Assure(new Assurance[] { a1, a2, a3, a4, a5 }), success);
    public static void Perform(Assurance a1, Assurance a2, Assurance a3, Assurance a4, Assurance a5, Assurance a6, Action success) => Perform(Assure(new Assurance[] { a1, a2, a3, a4, a5, a6 }), success);
    public static void Perform(Assurance a1, Assurance a2, Assurance a3, Assurance a4, Assurance a5, Assurance a6, Assurance a7, Action success) => Perform(Assure(new Assurance[] { a1, a2, a3, a4, a5, a6, a7 }), success);
    public static void Perform(Assurance a1, Assurance a2, Assurance a3, Assurance a4, Assurance a5, Assurance a6, Assurance a7, Assurance a8, Action success) => Perform(Assure(new Assurance[] { a1, a2, a3, a4, a5, a6, a7, a8 }), success);
    public static void Perform(Assurance a1, Assurance a2, Assurance a3, Assurance a4, Assurance a5, Assurance a6, Assurance a7, Assurance a8, Assurance a9, Action success) => Perform(Assure(new Assurance[] { a1, a2, a3, a4, a5, a6, a7, a8, a9 }), success);
}
