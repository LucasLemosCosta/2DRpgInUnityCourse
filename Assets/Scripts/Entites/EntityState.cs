using UnityEngine;

public abstract class EntityState
{

    protected StateMachine stateMachine;
    protected string animationBoolName;

    protected Animator anim;
    protected Rigidbody2D rb;

    public EntityState(StateMachine stateMachine,string stateBoolName)
    {
        this.stateMachine = stateMachine;
        this.animationBoolName = stateBoolName;
    }

    public virtual void Enter()
    {
        anim.SetBool(animationBoolName, true);
    }

    public virtual void UpdateState()
    {
        CheckChangeState();
    }

    public virtual void Exit()
    {
        anim.SetBool(animationBoolName, false);
    }

    protected virtual void CheckChangeState()
    {

    }
}
