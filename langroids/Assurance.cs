using System;
using System.Collections.Generic;
using System.Text;


/// <summary>
/// A container and conversion for easier Assure calls.
/// </summary>
public class Assurance
{
    public bool Test {
        get; set;
    }
    public Action Fail {
        get; set;
    }
    public Exception Except {
        get; set;
    }
    public Assurance(bool test, Action fail, Exception except) {
        Test = test;
        Fail = fail;
        Except = except;
    }

    public static implicit operator Assurance((bool test, Action fail, Exception e) assumption) => new Assurance(assumption.test, assumption.fail, assumption.e);
    public static implicit operator Assurance((bool test, Action fail) assumption) => new Assurance(assumption.test, assumption.fail, null);
    public static implicit operator Assurance((bool test, Exception e) assumption) => new Assurance(assumption.test, null, assumption.e);
}