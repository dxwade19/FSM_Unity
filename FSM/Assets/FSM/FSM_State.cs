using System.Collections;
using System;


public abstract class FSM_State
{
    public event Action<FSM_State, ITransition> OnEndState = null;
    protected FSM_State nextState = null;
    protected ITransition transition = null;
    protected AI_Brain brain = null;

    protected abstract void OnStateEnter();
    protected abstract IEnumerable OnStateUpdate();
    protected abstract void OnStateExit();

    

    public IEnumerable State()
    {
        OnStateEnter();
        yield return OnStateUpdate().GetEnumerator();
        OnStateExit();
        OnEndState?.Invoke(nextState, transition);
        yield break;
    }

}
