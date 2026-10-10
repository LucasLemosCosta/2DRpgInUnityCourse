using Unity.VisualScripting;
using UnityEngine;

public class Enemy : EntityCharacter
{


    public BaseEnemy_IdleState idleState {get; private set;}
    public BaseEnemy_WalkState walkState{get; private set;}




    public float timeToQuitIdle = 3;



    public override void Awake()
    {
        base.Awake();
        idleState = new BaseEnemy_IdleState(this,StateMachine,"Idle");
        walkState = new BaseEnemy_WalkState(this,StateMachine,"Walk");

    }

    public override void Start()
    {
        base.Start();
        StateMachine.InitStateMachine(idleState);
    }

}
