using System;
using System.Collections.Generic;
using System.Text;

/// <summary>
/// A binary tree of logic
/// </summary>
public class LogicTree {
    public LogicNode Root {
        get; set;
    }
    public void Execute() {
        var next = Root.Next( );
        while (next != null) {
            next = next.Next( );
        }
    }
}