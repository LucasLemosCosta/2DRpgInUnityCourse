using UnityEngine;

public class BaseEnemy_IdleState : BaseEnemy_GroundState
{

    private float timeOfEnterState = 0f;

    public BaseEnemy_IdleState(Enemy enemy, StateMachine stateMachine, string stateBoolName) : base(enemy, stateMachine, stateBoolName)
    {
    }

    public override void Enter()
    {
        base.Enter();
        timeOfEnterState = Time.time;
        enemy.SetVelocity(0f, rb.linearVelocityY);
    }

    protected override void HandleTransitionState()
    {
        base.HandleTransitionState();
        float elapsedTime = Time.time - timeOfEnterState;
        if (elapsedTime > enemy.timeToQuitIdle)
        {
            stateMachine.ChangeCurrentState(enemy.walkState);
        }

    }
    public override void Exit()
    {
        base.Exit();
        if(!enemy.OnGround)
        {
            enemy.Flip();
        }
    }


}
