using System;
using System.Collections.Generic;
using System.Text;
public class LogicNode
{
    public Func<bool> Do {
        get;set;
    }
    public LogicNode True {
        get;set;
    }
    public LogicNode False {
        get;set;
    }
    public LogicNode Next() => Do( ) ? True : False;
}

