using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AI_PatrolToWaitTransition : ITransition
{
    public IEnumerable Enter()
    {
        yield return null;
    }

    public IEnumerable Exit()
    {
        yield return null;
    }
}
