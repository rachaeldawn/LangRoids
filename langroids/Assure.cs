using System;
using System.Collections.Generic;
using System.Text;

public static partial class LangRoids {
    public static bool Assure(bool test, Action fail, Exception e) {
        if (!test) {
            DoOrThrow(fail, e);
            return false;
        }
        return true;
    }
    public static bool Assure(params (bool test, Action success, Exception e)[] assurances) {
        foreach ((bool test, Action success, Exception e) in assurances) {
            if (!Assure(test, success, e)) {
                return false;
            }
        }
        return true;
    }
    public static bool Assure(Assurance asn) => Assure(asn.Test, asn.Fail, asn.Except);
    public static bool Assure(Assurance[] assurances) {
        foreach (Assurance a in assurances) {
            if (!Assure(a)) {
                return false;
            }
        }
        return true;
    }
}