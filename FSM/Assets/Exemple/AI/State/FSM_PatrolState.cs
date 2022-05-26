using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FSM_PatrolState : FSM_State
{
    public FSM_PatrolState(AI_Brain _brain) => brain = _brain;

    protected override void OnStateEnter()
    {
        Debug.Log("enter patrol State");
        brain.Mouvements.SetTarget(brain.Pattern.PickPoint());
        brain.Animation.SetWalksAnimation(true);
        brain.IsPattern = true;
    }

    protected override void OnStateExit()
    {
        if(brain.IsDetected)
        {
            nextState = new FSM_ChaseState(brain);
            transition = new AI_PatrolToWaitTransition();
            return;
        }

        nextState = new FSM_WaitState(brain);
        transition = new AI_PatrolToWaitTransition();
    }

    protected override IEnumerable OnStateUpdate()
    {
        while (brain.IsPattern)
        {
            brain.Mouvements.MoveTo();
            yield return null;
        }

        yield return null;
    }

}
