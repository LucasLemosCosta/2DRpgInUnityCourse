using UnityEngine;

public class PlayerStateAttackBase : PlayerState
{
    private float timerAttackVelocity;

    private int attackIndex = 0;
    private int maxComboNumber = 3;
    private float lastAttack;
    private const int FirstComboIndex = 0;


    public PlayerStateAttackBase(PlayerController player, StateMachine stateMachine, string stateBoolName) : base(player, stateMachine, stateBoolName)
    {

    }

    public override void Enter()
    {
        base.Enter();


        ResetComboIndexIfNeeded();
        ApplyAttackVelocity();
        
        anim.SetInteger("AttackCombo", attackIndex);




    }
    public override void UpdateState()
    {
        base.UpdateState();

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
        lastAttack = Time.time;

    }

    protected override void HandleTrasitionState()
    {
        base.HandleTrasitionState();
        if (animationTrigger)
        {
            stateMachine.ChangeCurrentState(player.IdleState);
        }
    }

    private void ResetComboIndexIfNeeded()
    {
        if (Time.time > lastAttack + player.timeToResetAttack) attackIndex = FirstComboIndex;
        if (attackIndex >= maxComboNumber) attackIndex = FirstComboIndex;
    }
    private void ApplyAttackVelocity()
    {
        timerAttackVelocity = player.timerAttackVelocity;
        player.SetVelocity(player.attackVelocity.x * player.lookDirection, rb.linearVelocityY);
    }


}
