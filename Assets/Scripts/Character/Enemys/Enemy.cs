using Unity.VisualScripting;
using UnityEngine;

public class Enemy : EntityCharacter
{


    public BaseEnemy_IdleState idleState {get; protected set;}
    public BaseEnemy_WalkState walkState{get; protected set;}
    public BaseEnemy_BattleState battleState {get; protected set;}
    public BaseEnemy_AttackState attackState {get; protected set;}

    [Range(0,2)] public float walkSpeedAnimMultiplier;




    public float timeToQuitIdle = 3;





    public override void Start()
    {
        base.Start();
        StateMachine.InitStateMachine(idleState);
    }

}
