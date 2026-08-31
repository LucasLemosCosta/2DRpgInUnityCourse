using UnityEngine;

public abstract class PlayerGroundState : PlayerState
{
    protected PlayerGroundState(PlayerController player, StateMachine stateMachine, string stateBoolName) : base(player, stateMachine, stateBoolName)
    {
    }
    protected override void HandleTrasitionState()
    {
        base.HandleTrasitionState();
        if(!player.OnGround && rb.linearVelocityY < 0f)
        {
            stateMachine.ChangeCurrentState(player.FallState);
        }
        if(player.OnGround && getInputs.OnJump && rb.linearVelocityY >= 0f)
        {
            stateMachine.ChangeCurrentState(player.JumpState);
        }
    }

}
