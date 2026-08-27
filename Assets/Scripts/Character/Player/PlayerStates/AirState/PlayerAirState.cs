using UnityEngine;

public abstract class PlayerAirState : PlayerState
{
    public PlayerAirState(PlayerController player, StateMachine stateMachine, string stateBoolName) : base(player, stateMachine, stateBoolName)
    {
    }

    protected override void HandleTrasitionState()
    {
        base.HandleTrasitionState();
        if(player.OnGround)
        {
            stateMachine.ChangeCurrentState(player.IdleState);
        }
    }
}
