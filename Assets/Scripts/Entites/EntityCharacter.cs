using UnityEngine;
using System;

public abstract class EntityCharacter : MonoBehaviour
{

    //Componets
    public Rigidbody2D Rb { get; protected set; }
    public Animator Anim { get; protected set; }
    public StateMachine StateMachine { get; protected set; }


    //Attributes
    public float speedGround;
    public float forceJump;

    private int lookDirection = 1;


    public virtual void Awake()
    {
        Rb = GetComponent<Rigidbody2D>();
        Anim = GetComponentInChildren<Animator>();
        StateMachine = new StateMachine();
    }

    public virtual void Start()
    {
        
    }

    public virtual void Update()
    {
        HandleFlip();
    }

    public void MovimentCharacter(float directionX,float directionY)
    {
        Rb.linearVelocityX = directionX;
        Rb.linearVelocityY = directionY;
    }


    protected virtual void HandleFlip()
    {
        if (lookDirection != Math.Sign(Rb.linearVelocityX) && Math.Sign(Rb.linearVelocityX) != 0)
        {
            Flip();
        }
    }

    [ContextMenu("Flip")]
    private void Flip()
    {
       lookDirection *= -1;
       transform.Rotate(new Vector3(0f, 180f, 0));
    }

    

}
