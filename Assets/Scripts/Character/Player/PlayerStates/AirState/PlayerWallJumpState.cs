using UnityEngine;

public class PlayerWallJumpState : PlayerGroundState
{
    public PlayerWallJumpState(PlayerController player, StateMachine stateMachine, string stateBoolName) : base(player, stateMachine, stateBoolName)
    {
    }


    public override void Enter()
    {
        base.Enter();
        player.CanFlip(false);
        player.MovimentCharacter(0f, player.wallJump.y);
    }

    public override void UpdateState()
    {
        base.UpdateState();
        player.MovimentCharacter(player.wallJump.x * player.lookDirection,rb.linearVelocityY );

    }

    protected override void HandleTrasitionState()
    {
        base.HandleTrasitionState();

 
    }

    public override void Exit()
    {
        base.Exit();
        player.CanFlip(true);
    }
}
