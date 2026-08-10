using UnityEngine;

public class PlayerState : EntityState
{
    protected PlayerController player;
    public PlayerState(PlayerController player,StateMachine stateMachine, string stateBoolName) : base(stateMachine, stateBoolName)
    {
        this.player = player;
        rb = player.Rb;
        anim = player.Anim;

    }
}
