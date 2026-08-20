using UnityEngine;

public abstract class PlayerGroundState : PlayerState
{
    protected PlayerGroundState(PlayerController player, StateMachine stateMachine, string stateBoolName) : base(player, stateMachine, stateBoolName)
    {
    }


}
