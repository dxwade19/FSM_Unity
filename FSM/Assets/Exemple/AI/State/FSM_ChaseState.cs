using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FSM_ChaseState : FSM_State
{
    public FSM_ChaseState(AI_Brain _brain) => brain = _brain;

    protected override void OnStateEnter()
    {
        
    }

    protected override void OnStateExit()
    {
        nextState = new FSM_PatrolState(brain);
        transition = new AI_PatrolToWaitTransition();
    }

    protected override IEnumerable OnStateUpdate()
    {
        while(brain.IsDetected)
        {
            brain.Mouvements.SetTarget(brain.DetectionSystem.LastTargetDetected.TargetPosition);
            brain.Mouvements.MoveTo();
            yield return null;
        }
        yield return null;
    }

}
