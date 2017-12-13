using System;
using System.Collections.Generic;
using System.Text;

public static partial class LangRoids {
    public static bool Assure<E>(bool test)
        where E: Exception, new() {
        if (!test) {
            throw new E( );
        }
        return true;
    }
    public static bool Assure<E>(bool test, Action fail)
        where E : Exception, new(){
        if (!test) {
            DoOrThrow<E>(fail);
            return false;
        }
        return true;
    }

    public static bool Assure<E>(Assurance<E> asn) 
        where E : Exception, new()
        => Assure<E>(asn.Test, asn.Fail);
}