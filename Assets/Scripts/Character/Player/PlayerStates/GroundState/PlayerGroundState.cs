using UnityEngine;

public abstract class PlayerGroundState : PlayerState
{
    protected PlayerGroundState(PlayerController player, StateMachine stateMachine, string stateBoolName) : base(player, stateMachine, stateBoolName)
    {
    }
    protected override void CheckChangeState()
    {
        base.CheckChangeState();
        if(!player.OnGround && rb.linearVelocityY < 0f)
        {
            stateMachine.ChangeCurrentState(player.FallState);
        }
        if(player.OnGround && getInputs.OnJump)
        {
            stateMachine.ChangeCurrentState(player.JumpState);
        }
    }

}
