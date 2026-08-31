using UnityEngine;

public class PlayerFallState : PlayerAirState
{
    public PlayerFallState(PlayerController player, StateMachine stateMachine, string stateBoolName) : base(player, stateMachine, stateBoolName)
    {
    }

    public override void UpdateState()
    {
        base.UpdateState();
        if(getInputs.Direction.x == 0)
        {
            player.MovimentCharacter(rb.linearVelocityX, rb.linearVelocityY);

        }
        else
        {
            player.MovimentCharacter(getInputs.Direction.x * player.speedAir, rb.linearVelocityY);
        }

    }

    protected override void HandleTrasitionState()
    {
        base.HandleTrasitionState();
        if(player.OnWall)
        {
            stateMachine.ChangeCurrentState(player.WallState);
        }

    }
}
