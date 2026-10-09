using UnityEngine;

public class EnemyState : EntityState
{

    protected Enemy enemy;


    public EnemyState(Enemy enemy, StateMachine stateMachine, string stateBoolName) : base(stateMachine, stateBoolName)
    {

        this.enemy = enemy;
        rb = enemy.Rb;
        anim = enemy.Anim;

    }
}
