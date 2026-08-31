using UnityEngine;

public class PlayerJumpState : PlayerGroundState
{
    public PlayerJumpState(PlayerController player, StateMachine stateMachine, string stateBoolName) : base(player, stateMachine, stateBoolName)
    {
    }

    public override void Enter()
    {
        base.Enter();
        player.MovimentCharacter(0f, player.forceJump);
    }

    public override void UpdateState()
    {
        base.UpdateState();
        player.MovimentCharacter(getInputs.Direction.x * player.speedAir, rb.linearVelocityY);

    }

}
