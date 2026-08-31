using UnityEngine;


public class PlayerWallState : PlayerAirState
{
    public PlayerWallState(PlayerController player, StateMachine stateMachine, string stateBoolName) : base(player, stateMachine, stateBoolName)
    {
    }
    public override void Enter()
    {
        base.Enter();
        player.CanFlip(false);
    }
    public override void UpdateState()
    {
        base.UpdateState();
        player.MovimentCharacter(0, rb.linearVelocityY * player.fallSpeedMultiplier);
    }

    protected override void HandleTrasitionState()
    {
        base.HandleTrasitionState();
        if(getInputs.Direction.x != 0 && getInputs.Direction.x != player.lookDirection)
        {
            stateMachine.ChangeCurrentState(player.IdleState);
        }

        if(getInputs.OnJump && player.OnWall)
        {
            stateMachine.ChangeCurrentState(player.WallJumpState);
        }

        
    }

    public override void Exit()
    {
        base.Exit();
        player.CanFlip(true);
        player.Flip();

    }
}
