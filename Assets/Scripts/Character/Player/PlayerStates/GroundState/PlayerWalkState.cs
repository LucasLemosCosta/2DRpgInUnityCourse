using Unity.Multiplayer.PlayMode;
using UnityEngine;

public class PlayerWalkState : PlayerState
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
        player.MovimentCharacter(getInputs.DirectionX.x * player.speedGround, rb.linearVelocityY);
    }

    public override void Exit()
    {
        base.Exit();
    }

    protected override void CheckChangeState()
    {
        base.CheckChangeState();
        if(getInputs.DirectionX.x == 0f)
        {
            stateMachine.ChangeCurrentState(player.IdleState);
        }
    }
}

