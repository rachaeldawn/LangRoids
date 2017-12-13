using System;
using System.Collections.Generic;
using System.Text;

public class Assurance<E> 
    where E : Exception, new()
{
    public Action Fail {
        get;set;
    }
    public bool Test {
        get; set;
    }

    public void Except() 
        => throw new E( );

    public Assurance(bool test) 
        => Test = test;

    public Assurance(bool test, Action fail)
        : this(test)
        => Fail = fail;

    public static implicit operator Assurance<E>((bool test, Action fail, Type e) asr) 
        => asr.e == typeof(E) ? new Assurance<E>(asr.test, asr.fail) : null;
}