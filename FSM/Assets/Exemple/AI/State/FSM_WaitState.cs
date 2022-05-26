using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FSM_WaitState : FSM_State
{
    float _waitTime = 0;

    public FSM_WaitState(AI_Brain _brain) => brain = _brain;

    protected override void OnStateEnter()
    {
        Debug.Log("enter wait State");
        _waitTime = Random.Range(0, 5);
        brain.Animation.SetWalksAnimation(false);
    }

    protected override void OnStateExit()
    {
        nextState = new FSM_PatrolState(brain);
        transition = new AI_PatrolToChaseTransition();
        brain.IsPattern = true;
    }

    protected override IEnumerable OnStateUpdate()
    {
        if (brain.IsDetected) yield break;
        yield return new WaitForSeconds(_waitTime);
    }
}
