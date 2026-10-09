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
        HandleTransitionState();
    }

    public virtual void Exit()
    {
        animationTrigger = false;
        anim.SetBool(animationBoolName, false);
    }


    protected virtual void HandleTransitionState()
    {
        //if and change state with StateMachine
    }

    public void CallAnimationTrigger() => animationTrigger = true;


}
