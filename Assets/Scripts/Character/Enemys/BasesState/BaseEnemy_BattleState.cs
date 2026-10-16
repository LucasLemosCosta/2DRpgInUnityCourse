using UnityEngine;

public class BaseEnemy_BattleState : EnemyState
{
    public BaseEnemy_BattleState(Enemy enemy, StateMachine stateMachine, string animBoolName) : base(enemy, stateMachine, animBoolName)
    {
    }

    override public void Enter()
    {
        base.Enter();
        enemy.SetVelocity(0, rb.linearVelocityY);
        Debug.Log("Battle State");
    }

    
}
