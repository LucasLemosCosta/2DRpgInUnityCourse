using UnityEngine;

public sealed class StateMachine
{
    public EntityState CurrentState { get; private set; }
    private bool canChangeState = true;

    public void InitStateMachine(EntityState newState)
    {
        CurrentState = newState;
        CurrentState.Enter();
    }

    public void ChangeCurrentState(EntityState newState)
    {
        CurrentState.Exit();
        CurrentState = newState;
        CurrentState.Enter();
    }

    public void AnableCanChangeState(bool anable) => canChangeState = anable;

}
