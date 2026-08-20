using UnityEngine;

public class PlayerFallState : PlayerAirState
{
    public PlayerFallState(PlayerController player, StateMachine stateMachine, string stateBoolName) : base(player, stateMachine, stateBoolName)
    {
    }

    public override void UpdateState()
    {
        base.UpdateState();
        player.MovimentCharacter(getInputs.Direction.x * player.speedAir, rb.linearVelocityY);
    }
}
