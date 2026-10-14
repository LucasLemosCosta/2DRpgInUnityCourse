using UnityEngine;

public class EnemySkeleton : Enemy
{

    public override void Awake()
    {
        base.Awake();
        idleState = new BaseEnemy_IdleState(this,StateMachine,"Idle");
        walkState = new BaseEnemy_WalkState(this,StateMachine,"Walk");
        attackState = new BaseEnemy_AttackState(this,StateMachine,"Attack");

    }


    [ContextMenu("Attack")]
    public void AttackTest()
    {
        StateMachine.ChangeCurrentState(attackState);
    }

}
