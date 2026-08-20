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

    [Header("Check Ground")]
    
    [SerializeField] private LayerMask whatIsGround;
    [SerializeField] private float sizeRayGround;
    public bool OnGround { get; protected set; }

    //Controllers
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
        HandleCollider();
    }

    public virtual void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawLine(transform.position, transform.position + (Vector3.down * sizeRayGround));
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

    public virtual void HandleCollider()
    {
        OnGround = Physics2D.Raycast(transform.position, Vector2.down, sizeRayGround,whatIsGround);
        Debug.Log(OnGround);
    }


    [ContextMenu("Flip")]
    private void Flip()
    {
       lookDirection *= -1;
       transform.Rotate(new Vector3(0f, 180f, 0));
    }

    

}
