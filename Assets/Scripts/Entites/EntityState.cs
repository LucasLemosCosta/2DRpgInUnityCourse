using UnityEngine;

public abstract class EntityState
{
    protected StateMachine stateMachine;
    protected string animationBoolName;

    protected Animator anim;
    protected Rigidbody rb;

    public EntityState(StateMachine stateMachine,string stateBoolName)
    {
        this.stateMachine = stateMachine;
        this.animationBoolName = stateBoolName;
    }

    public virtual void Enter()
    {

    }

    public virtual void UpdateState()
    {

    }

    public virtual void Exit()
    {

    }
}
