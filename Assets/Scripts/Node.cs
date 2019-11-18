using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Node
{
    public virtual void Decide() { }
}

class BinaryNode : Node
{
    public Node yesNode;
    public Node noNode;
    public string Decision;
    bool t = true;
    public override void Decide()
    {
        if (t)
        {
            yesNode.Decide();
        }
        else
        {
            noNode.Decide();
        }
    }
}

class ActionNode : Node
{
    public Action actionMethod;
    public override void Decide()
    {
        actionMethod();
    }
}
