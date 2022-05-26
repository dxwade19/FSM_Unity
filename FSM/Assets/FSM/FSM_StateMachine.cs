using System.Collections;
using System;
using UnityEngine;

public class FSM_StateMachine
{
    public event Action OnFSMStateEnter = null;
    public event Action OnFSMStateUpdate = null;
    public event Action OnFSMStateExit = null;
    public event Action OnFSMStateTransition = null;
    public event Action<string> OnFSMStateChange = null;
    public event Action OnFSMStop = null;

    public AI_Brain Brain { get; set; } = null;
    FSM_State currentState = null, nextState = null;
    bool enabled = true;
    ITransition nextTransition = null;

    public FSM_State CurrentState
    {
        get => currentState;
        set
        {
            currentState = value;
            //
            OnFSMStateChange?.Invoke(currentState.GetType().ToString());
            currentState.OnEndState += SetNextState;
            OnFSMStateEnter?.Invoke();  //Soit on appele onsateEnter du state soit la machine y va toutes seul
        }
    }

    void SetNextState(FSM_State _next, ITransition _transition)
    {
        nextState = _next;
        nextTransition = _transition;
    }


    public IEnumerable StartFSm(FSM_State _firstState)
    {
        CurrentState = _firstState;
        while(enabled)
        {
            yield return currentState.State().GetEnumerator();
            OnFSMStateExit?.Invoke();
            if (nextTransition == null)
            {
                OnFSMStop?.Invoke();
                yield break;
            }
            currentState.OnEndState -= SetNextState;
            if(nextState == null)
            {
                OnFSMStop?.Invoke();
                yield break;
            }
            OnFSMStateTransition?.Invoke();
            yield return nextTransition.Enter().GetEnumerator();
            yield return nextTransition.Exit().GetEnumerator();
            CurrentState = nextState;
            nextState = null;
            nextTransition = null;
        }
    }

}

//Utiliser grand State
//Dans State Rensgner les transitions
//Make Patrol, Make ConeSight and Chase
