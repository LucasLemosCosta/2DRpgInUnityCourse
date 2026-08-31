using UnityEngine;
using System;
using Unity.VisualScripting;

public abstract class EntityCharacter : MonoBehaviour
{

    //Componets
    public Rigidbody2D Rb { get; protected set; }
    public Animator Anim { get; protected set; }
    public StateMachine StateMachine { get; protected set; }




    [Header("Attributes")]
    public float speedGround;
    public float speedAir;
    public float forceJump;

    [Range(0, 1)] public float fallSpeedMultiplier;

    [Header("Check Ground")]
    
    [SerializeField] private LayerMask whatIsGround;
    [SerializeField] private float sizeRayGround;
    public bool OnGround { get; protected set; }


    [Header("Wall Check")]
    [SerializeField] private LayerMask whatIsWall;
    [SerializeField] private float sizeRayWall;
    public bool OnWall { get; protected set; }

    //Controllers
    public int lookDirection { get; protected set; } = 1;  //The value must be 1 or -1
    protected bool canFlip = true;


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
        HandleCollider();
    }

    public virtual void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawLine(transform.position, transform.position + (Vector3.down * sizeRayGround));
        Gizmos.DrawLine(transform.position, transform.position + (Vector3.right * lookDirection * sizeRayWall));
    }

    public void MovimentCharacter(float directionX,float directionY)
    {
        Rb.linearVelocityX = directionX;
        Rb.linearVelocityY = directionY;
    }

    



    public virtual void HandleCollider()
    {
        OnGround = Physics2D.Raycast(transform.position, Vector2.down, sizeRayGround,whatIsGround);
        OnWall = Physics2D.Raycast(transform.position, Vector2.right * lookDirection,sizeRayWall, whatIsWall);
    }

    protected virtual void HandleFlip()
    {
        if (canFlip)
        {
            if (lookDirection != Math.Sign(Rb.linearVelocityX) && Rb.linearVelocityX != 0)
            {
                Flip();
            }
        }
    }

    [ContextMenu("Flip")]
    public void Flip()
    {
        lookDirection *= -1; //mirror the direction value
        transform.Rotate(new Vector3(0f, 180f, 0));

    }

    public void CanFlip(bool able) => canFlip = able;

    

}
