using UnityEngine;

public class PlayerStateAttackBase : PlayerState
{
    private float timerAttackVelocity;

    private int attackIndex = 0;
    private int maxComboNumber = 2;
    private const int FirstComboIndex = 0;


    public PlayerStateAttackBase(PlayerController player, StateMachine stateMachine, string stateBoolName) : base(player, stateMachine, stateBoolName)
    {

    }

    public override void Enter()
    {
        base.Enter();


        


        timerAttackVelocity = player.timerAttackVelocity;
        player.SetVelocity(player.attackVelocity.x * player.lookDirection, rb.linearVelocityY);

        anim.SetInteger("AttackCombo", attackIndex);
        if (attackIndex >= maxComboNumber) attackIndex = FirstComboIndex;

        

        

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

    public override void Exit()
    {
        base.Exit();
        attackIndex++;
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
