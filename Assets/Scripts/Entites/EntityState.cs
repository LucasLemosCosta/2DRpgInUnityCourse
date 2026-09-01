using UnityEngine;

public abstract class EntityState
{


    protected Animator anim;
    protected Rigidbody2D rb;
    protected StateMachine stateMachine;

    protected string animationBoolName;
    protected bool animationTrigger;

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
        HandleTrasitionState();
    }

    public virtual void Exit()
    {
        anim.SetBool(animationBoolName, false);
        animationTrigger = false;
    }


    protected virtual void HandleTrasitionState()
    {
        //if and change state with StateMachine
    }

    public void CallAnimationTrigger() => animationTrigger = true;


}
