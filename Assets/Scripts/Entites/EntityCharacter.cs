using UnityEngine;
using System;
using Unity.VisualScripting;

public abstract class EntityCharacter : MonoBehaviour
{

    public Rigidbody2D Rb { get; protected set; }
    public Animator Anim { get; protected set; }
    protected StateMachine StateMachine;


    [Header("Attributes")]
    public float speedGround;
    public float speedAir;
    public float forceJump;

    [Range(0, 1)] public float fallSpeedMultiplier;

    [Header("Check Ground")]

    [SerializeField] private LayerMask whatIsGround;
    [SerializeField] private float sizeRayGround;
    [SerializeField] private Transform targetGround;
    public bool OnGround { get; protected set; }


    [Header("Wall Check")]
    [SerializeField] private LayerMask whatIsWall;
    [SerializeField] private float sizeRayWall;
    public bool OnWall { get; protected set; }

    public int lookDirection { get; protected set; } = 1;  //The value must be 1 or -1

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
        HandleCollider();
        StateMachine.CurrentState?.UpdateState();
    }

    public virtual void OnDrawGizmos()
    {
        Vector3 groundPosition = targetGround == null ?
        transform.position : targetGround.position;

        Gizmos.color = Color.red;
        Gizmos.DrawLine(groundPosition, groundPosition + (Vector3.down * sizeRayGround));
        Gizmos.DrawLine(transform.position, transform.position + (Vector3.right * lookDirection * sizeRayWall));
    }

    public void CallStateAnimationTrigger()
    {
        StateMachine.CurrentState.CallAnimationTrigger();
    }

    public void SetVelocity(float directionX, float directionY)
    {
        Rb.linearVelocity = new Vector2(directionX, directionY);
        HandleFlip(directionX);
    }


    public virtual void HandleCollider()
    {
        OnGround = targetGround != null ?
         Physics2D.Raycast(targetGround.position, Vector2.down, sizeRayGround, whatIsGround) :
         Physics2D.Raycast(transform.position, Vector2.down, sizeRayGround, whatIsGround);


        OnWall = Physics2D.Raycast(transform.position, Vector2.right * lookDirection, sizeRayWall, whatIsWall);
    }

    protected virtual void HandleFlip(float directionX)
    {

        if (Math.Sign(directionX) != lookDirection && Math.Sign(directionX) != 0)
            Flip();
    }

    [ContextMenu("Flip")]
    public void Flip()
    {
        lookDirection *= -1; //mirror the direction value
        transform.Rotate(new Vector3(0f, 180f, 0));
    }




}
