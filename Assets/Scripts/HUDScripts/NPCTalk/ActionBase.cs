using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ActionBase
{
    protected readonly BettingScript _bettingUnit;
    protected ActionBase(BettingScript bettingUnit)
    {
        _bettingUnit = bettingUnit;
    }
    public abstract void Execute();
    public abstract void Undo();
}
