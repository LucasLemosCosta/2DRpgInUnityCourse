using UnityEngine;

public class BaseEnemy_AttackState : EnemyState
{
    private float impactAttackTime;
    public BaseEnemy_AttackState(Enemy enemy, StateMachine stateMachine, string stateBoolName) : base(enemy, stateMachine, stateBoolName)
    {
    }

    public override void Enter()
    {
        base.Enter();
        ApplyAttack();
    }

    public override void UpdateState()
    {
        base.UpdateState();
        impactAttackTime -= Time.deltaTime;
        if (impactAttackTime <= 0) enemy.SetVelocity(0, rb.linearVelocityY);

        if (animationTrigger)
        {
            stateMachine.ChangeCurrentState(enemy.battleState);
        }
    }

    private void ApplyAttack()
    {
        impactAttackTime = enemy.impactDuration;
        enemy.SetVelocity(enemy.impactAttack.x * enemy.lookDirection, enemy.impactAttack.y);
    }
}
