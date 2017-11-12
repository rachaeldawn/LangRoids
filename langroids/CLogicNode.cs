using System;
using System.Collections.Generic;
using System.Text;
using static LangRoids;

/// <summary>
/// A node in a cancellable logic tree
/// </summary>
public class CLogicNode {
    public Func<Tern> Do {
        get; set;
    }
    public CLogicNode True {
        get; set;
    }
    public CLogicNode False {
        get; set;
    }
    public CLogicNode Next() => Tern.Choose(Do( ), True, False, null);
    public CLogicNode() => DoNothing( );
    public CLogicNode(CLogicNode True) => this.True = True;
    public CLogicNode(CLogicNode True, CLogicNode False) : this(True) => this.False = False;
}