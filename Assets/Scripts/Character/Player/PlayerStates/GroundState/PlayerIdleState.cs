using UnityEngine;

public class PlayerIdleState : PlayerGroundState
{
    public PlayerIdleState(PlayerController player, StateMachine stateMachine, string stateBoolName) : base(player, stateMachine, stateBoolName)
    {
    }

    public override void Enter()
    {
        base.Enter();
    }

    public override void UpdateState()
    {
        base.UpdateState();
        player.MovimentCharacter(0f, rb.linearVelocityY);
    }

    public override void Exit()
    {
        base.Exit();
    }

    protected override void HandleTrasitionState()
    {
        base.HandleTrasitionState();
        if(getInputs.Direction.x != 0f)
        {
            stateMachine.ChangeCurrentState(player.WalkState);
        }
    }
}
