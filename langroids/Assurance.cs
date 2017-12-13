using System;
using System.Collections.Generic;
using System.Text;

public class Assurance {
    public bool Test {
        get;set;
    }
    public Action Fail {
        get; set;
    }
    public Assurance(bool test, Action fail) {
        Test = test;
        Fail = fail;
    }
    public static implicit operator Assurance((bool test, Action fail) asr)
        => new Assurance(asr.test, asr.fail);
}