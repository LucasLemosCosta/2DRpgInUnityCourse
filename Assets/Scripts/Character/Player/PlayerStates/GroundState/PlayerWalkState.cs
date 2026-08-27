using Unity.Multiplayer.PlayMode;
using UnityEngine;

public class PlayerWalkState : PlayerGroundState
{
    public PlayerWalkState(PlayerController player, StateMachine stateMachine, string stateBoolName) : base(player, stateMachine, stateBoolName)
    {
    }

    public override void Enter()
    {
        base.Enter();
    }

    public override void UpdateState()
    {
        base.UpdateState();
        player.MovimentCharacter(getInputs.Direction.x * player.speedGround, rb.linearVelocityY);
    }

    public override void Exit()
    {
        base.Exit();
    }

    protected override void HandleTrasitionState()
    {
        base.HandleTrasitionState();
        if(getInputs.Direction.x == 0f)
        {
            stateMachine.ChangeCurrentState(player.IdleState);
        }
    }
}

