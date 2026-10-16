using UnityEngine;

public class BaseEnemy_WalkState : BaseEnemy_GroundState
{
    public BaseEnemy_WalkState(Enemy enemy, StateMachine stateMachine, string stateBoolName) : base(enemy, stateMachine, stateBoolName)
    {
    }

    override public void Enter()
    {
        base.Enter();
        enemy.SetVelocity(enemy.speed * enemy.lookDirection, rb.linearVelocityY);
        


    }

    public override void UpdateState()
    {
        base.UpdateState();
        if(!enemy.OnGround)
        {
            stateMachine.ChangeCurrentState(enemy.idleState);
        }
        if(enemy.OnWall)
        {
            enemy.Flip();
            stateMachine.ChangeCurrentState(enemy.idleState);
        }
    }

}
