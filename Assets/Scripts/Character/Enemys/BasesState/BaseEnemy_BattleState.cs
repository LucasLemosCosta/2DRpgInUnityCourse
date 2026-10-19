using UnityEngine;

public class BaseEnemy_BattleState : EnemyState
{

    private Transform player;
    public BaseEnemy_BattleState(Enemy enemy, StateMachine stateMachine, string animBoolName) : base(enemy, stateMachine, animBoolName)
    {
    }

    override public void Enter()
    {
        base.Enter();
        player = enemy.PlayerDetected().transform;
    }
    public override void UpdateState()
    {
        base.UpdateState();

        enemy.SetVelocity(DirectionPlayer() * enemy.battleSpeed, rb.linearVelocityY);
        if (DistancePlayer() < enemy.attackDistance)
            stateMachine.ChangeCurrentState(enemy.attackState);

        anim.SetFloat("xVelocity",rb.linearVelocityX);

    
    }

    private float DistancePlayer()
    {
        float distance = player == null ?
        float.MaxValue : Mathf.Abs(player.position.x - enemy.transform.position.x);
        return distance;
    }

    private int DirectionPlayer()
    {
        int direction = player.position.x - enemy.transform.position.x > 0 && player != null ? 1 : -1;
        return direction;
    }


}
