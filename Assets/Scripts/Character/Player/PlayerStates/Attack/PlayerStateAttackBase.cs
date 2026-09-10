using UnityEngine;

public class PlayerStateAttackBase : PlayerState
{
    private float timerAttackVelocity;

    public PlayerStateAttackBase(PlayerController player, StateMachine stateMachine, string stateBoolName) : base(player, stateMachine, stateBoolName)
    {
    }

    public override void Enter()
    {
        base.Enter();
        timerAttackVelocity = player.timerAttackVelocity;
        player.SetVelocity(player.attackVelocity.x * player.lookDirection, rb.linearVelocityY);

    }
    public override void UpdateState()
    {
        base.UpdateState();
        Debug.Log(rb.linearVelocityX);
        Debug.Log(player.attackVelocity.x * player.lookDirection);
        timerAttackVelocity -= Time.deltaTime;
        if (timerAttackVelocity < 0)
        {
            player.SetVelocity(0, rb.linearVelocityX);
        }


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
