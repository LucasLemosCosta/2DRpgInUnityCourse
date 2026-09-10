using UnityEngine;


public class PlayerWallState : PlayerAirState
{
    public PlayerWallState(PlayerController player, StateMachine stateMachine, string stateBoolName) : base(player, stateMachine, stateBoolName)
    {
    }
    public override void Enter()
    {
        base.Enter();
        player.SetVelocity(0, 0);

    }
    public override void UpdateState()
    {
        base.UpdateState();

        player.SetVelocity(0, rb.linearVelocityY * player.fallSpeedMultiplier);
    }

    protected override void HandleTrasitionState()
    {
        base.HandleTrasitionState();
        if(getInputs.OnJump && player.OnWall)
        {
            stateMachine.ChangeCurrentState(player.WallJumpState);
        }  
    }

    public override void Exit()
    {
        base.Exit();
        player.Flip();
    }
}
