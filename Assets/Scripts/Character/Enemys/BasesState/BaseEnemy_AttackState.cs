using UnityEngine;

public class BaseEnemy_AttackState : EnemyState
{
    public BaseEnemy_AttackState(Enemy enemy, StateMachine stateMachine, string stateBoolName) : base(enemy, stateMachine, stateBoolName)
    {
    }

    public override void Enter()
    {
        base.Enter();
        enemy.SetVelocity(0,rb.linearVelocityY);
    }

    public override void UpdateState()
    {
        base.UpdateState();
        if (animationTrigger)
        {
            stateMachine.ChangeCurrentState(enemy.idleState);
        }
    }
}
