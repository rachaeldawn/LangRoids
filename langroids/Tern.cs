using System;

public static partial class LangRoids {
    public static T Choose<T>(Tern a, T ifTrue, T ifFalse, T ifOther) => Tern.Choose(a, ifTrue, ifFalse, ifOther);
}

public struct Tern {
    public uint literally {
        get; private set;
    }
    public bool True => literally == 0;
    public bool False => literally == 1;
    public bool Other => literally >= 2;
    public static implicit operator Tern(uint num) => new Tern { literally = num > 3 ? 3 : num };
    public static implicit operator Tern(bool val) => new Tern { literally = val ? (uint)1 : 0 };
    public static implicit operator Tern(bool? val) => val == null ? new Tern { literally = 2 } : (bool)val;
    public static implicit operator int(Tern a) => (int)a.literally;
    public static implicit operator bool?(Tern a) {
        if(a == 2) {
            return null;
        }
        return a == 1 ? true : false;
    } 
    public override string ToString() {
        if(True) {
            return nameof(True);
        }
        if(False) {
            return nameof(False);
        }
        return nameof(Other);
    }
    public static bool operator ==(Tern a, Tern b) => a.True == b.True && a.False == b.False && a.Other == b.Other;
    public static bool operator !=(Tern a, Tern b) => !(a == b);
    public static bool operator ==(Tern a, uint num) {
        Tern b = num;
        return a == b;
    }
    public static bool operator !=(Tern a, uint num) => !(a == num);
    public static bool operator ==(Tern a, bool b) {
        Tern other = b;
        return a == other;
    }
    public static bool operator !=(Tern a, bool b) => !(a == b);
    public static bool operator ==(Tern a, bool? b) {
        Tern other = b;
        return a == other;
    }
    public static bool operator !=(Tern a, bool? b) => !(a == b);
    public static T Choose<T>(Tern a, T ifTrue, T ifFalse, T ifOther) {
        bool? check = a;
        if(check == null) {
            return ifOther;
        }
        return (bool)check ? ifTrue : ifFalse;
    }

    public override bool Equals(object obj) {
        if (!(obj is Tern)) {
            return false;
        }

        var tern = (Tern)obj;
        return literally == tern.literally &&
               True == tern.True &&
               False == tern.False &&
               Other == tern.Other;
    }

    public override int GetHashCode() {
        var hashCode = 1704884989;
        hashCode = hashCode * -1521134295 + base.GetHashCode( );
        hashCode = hashCode * -1521134295 + literally.GetHashCode( );
        return hashCode;
    }
}
