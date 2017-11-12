using System;
using static LangRoids;

/// <summary>
/// A cancellable logic tree. Return a Tern.Other to halt further processing (Other = 2)
/// </summary>
public class CLogicTree {
    public CLogicNode Root {
        get; set;
    }
    public void Crawl() {
        var node = Root.Next();
        while(node != null) {
            node = Root.Next();
        }
    } 
}