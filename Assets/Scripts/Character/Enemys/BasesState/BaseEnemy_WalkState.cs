using UnityEngine;

public class BaseEnemy_WalkState : EnemyState
{
    public BaseEnemy_WalkState(Enemy enemy, StateMachine stateMachine, string stateBoolName) : base(enemy, stateMachine, stateBoolName)
    {
    }

    override public void Enter()
    {
        base.Enter();
        enemy.SetVelocity(enemy.speedGround * enemy.lookDirection, rb.linearVelocityY);
        


    }

    public override void UpdateState()
    {
        base.UpdateState();
        if(!enemy.OnGround || enemy.OnWall)
        {
            stateMachine.ChangeCurrentState(enemy.idleState);
        }
    }

}
