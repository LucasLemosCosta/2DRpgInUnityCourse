using UnityEngine;

public class PlayerIdleState : PlayerGroundState
{
    public PlayerIdleState(PlayerController player, StateMachine stateMachine, string stateBoolName) : base(player, stateMachine, stateBoolName)
    {
    }

    public override void Enter()
    {
        base.Enter();
        player.SetVelocity(0f, rb.linearVelocityY);
    }

    protected override void HandleTransitionState()
    {
        base.HandleTransitionState();
        
        bool lockChangeToWalk = player.lookDirection == getInputs.Direction.x && player.OnWall;
        if(getInputs.Direction.x != 0f && !lockChangeToWalk)
        {
            stateMachine.ChangeCurrentState(player.WalkState);
        }
     
    }
}
