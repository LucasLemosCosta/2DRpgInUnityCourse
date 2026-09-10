using UnityEngine;

public class PlayerWallJumpState : PlayerGroundState
{
    public PlayerWallJumpState(PlayerController player, StateMachine stateMachine, string stateBoolName) : base(player, stateMachine, stateBoolName)
    {
    }


    public override void Enter()
    {
        base.Enter();
        player.SetVelocity(0f, player.wallJump.y);
    }

    public override void UpdateState()
    {
        base.UpdateState();
        player.SetVelocity(player.wallJump.x * player.lookDirection,rb.linearVelocityY );

    }

    public override void Exit()
    {
        base.Exit();
    }
}
