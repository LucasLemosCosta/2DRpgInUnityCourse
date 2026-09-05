using UnityEngine;

public class PlayerStateAttackBase : PlayerState
{
    public PlayerStateAttackBase(PlayerController player, StateMachine stateMachine, string stateBoolName) : base(player, stateMachine, stateBoolName)
    {
    }

    protected override void HandleTrasitionState()
    {
        base.HandleTrasitionState();
        if (animationTrigger)
        {
            stateMachine.ChangeCurrentState(player.IdleState);
        }
    }
}
