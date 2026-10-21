using UnityEngine;

public class BaseEnemy_BattleState : EnemyState
{

    private Transform player;
    private float lastTimeEnterInBattleState;
    public BaseEnemy_BattleState(Enemy enemy, StateMachine stateMachine, string animBoolName) : base(enemy, stateMachine, animBoolName)
    {
    }

    override public void Enter()
    {
        base.Enter();
        lastTimeEnterInBattleState = Time.time;

        if (player == null) player = enemy.PlayerDetected().transform;



        
    }
    public override void UpdateState()
    {
        base.UpdateState();

        enemy.SetVelocity(DirectionPlayer() * enemy.battleSpeed, rb.linearVelocityY);

        anim.SetFloat("xVelocity", rb.linearVelocityX);
        anim.SetFloat("battleSpeedMultipliar", enemy.battleSpeed / enemy.speed);


    }
    protected override void HandleTransitionState()
    {
        base.HandleTransitionState();

        if (DistancePlayer() < enemy.attackDistance)
            stateMachine.ChangeCurrentState(enemy.attackState);
        if(BattleStateOver())
            stateMachine.ChangeCurrentState(enemy.idleState);
    }


    private float DistancePlayer()
    {
        float distance = player == null ?
        float.MaxValue : Mathf.Abs(player.position.x - enemy.transform.position.x);
        return distance;
    }
    private bool BattleStateOver()
    {
        bool isOver = false;
        float elapsedTime = Time.time - lastTimeEnterInBattleState;

        if (elapsedTime > enemy.battleDuration) isOver = true;
        return isOver;
    }
    private int DirectionPlayer()
    {
        int direction = 1;
        if (player != null)
            direction = player.position.x - enemy.transform.position.x > 0 ? 1 : -1;
        return direction;
    }




}
