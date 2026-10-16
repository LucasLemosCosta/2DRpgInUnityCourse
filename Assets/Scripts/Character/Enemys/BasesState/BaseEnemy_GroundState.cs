using UnityEngine;

public class BaseEnemy_GroundState : EnemyState
{
    public BaseEnemy_GroundState(Enemy enemy, StateMachine stateMachine, string animBoolName) : base(enemy, stateMachine, animBoolName)
    {
    }

    public override void UpdateState()
    {
        base.UpdateState();
        if(enemy.CheckPlayerDetected() == true)
        {
            stateMachine.ChangeCurrentState(enemy.battleState);
        }
    }
}
