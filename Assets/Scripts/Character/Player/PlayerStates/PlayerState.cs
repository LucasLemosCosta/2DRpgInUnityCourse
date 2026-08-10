using UnityEngine;

public class PlayerState : EntityState
{
    protected PlayerController player;
    protected GetInputs getInputs;
    public PlayerState(PlayerController player,StateMachine stateMachine, string stateBoolName) : base(stateMachine, stateBoolName)
    {
        this.player = player;
        rb = player.Rb;
        anim = player.Anim;
        getInputs = player.GetInputs;

    }
}
