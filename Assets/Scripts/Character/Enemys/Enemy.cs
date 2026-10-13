using Unity.VisualScripting;
using UnityEngine;

public class Enemy : EntityCharacter
{


    public BaseEnemy_IdleState idleState {get; protected set;}
    public BaseEnemy_WalkState walkState{get; protected set;}




    public float timeToQuitIdle = 3;





    public override void Start()
    {
        base.Start();
        StateMachine.InitStateMachine(idleState);
    }

}
