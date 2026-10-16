using UnityEngine;
using System;
using Unity.VisualScripting;

public abstract class EntityCharacter : MonoBehaviour
{

    public Rigidbody2D Rb { get; protected set; }
    public Animator Anim { get; protected set; }
    protected StateMachine StateMachine;


    [Header("Attributes")]
    public float speed;
    public float forceJump;

    [Header("Check Ground")]

    [SerializeField] private LayerMask whatIsGround;
    [SerializeField] private float sizeRayGround;
    [SerializeField] private Transform targetGround;
    public bool OnGround { get; protected set; }


    [Header("Wall Check")]
    [SerializeField] private Transform primaryTargetWall;
    [SerializeField] private Transform secondTargetWall;
    [SerializeField] protected LayerMask whatIsWall;
    [SerializeField] private float sizeRayWall;

    private Vector3 groundPosition;
    private Vector3 primaryWallPosition;
    private Vector3 secondWallPosition;

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
        GetCollidersPosition();
        Gizmos.color = Color.red;
        Gizmos.DrawLine(groundPosition, groundPosition + (Vector3.down * sizeRayGround));
        Gizmos.DrawLine(primaryWallPosition, primaryWallPosition + (Vector3.right * lookDirection * sizeRayWall));
        Gizmos.DrawLine(secondWallPosition, secondWallPosition + (Vector3.right * lookDirection * sizeRayWall));
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
        GetCollidersPosition();

        OnGround = Physics2D.Raycast(groundPosition , Vector2.down, sizeRayGround, whatIsGround);
        OnWall =  Physics2D.Raycast(primaryWallPosition, Vector2.right * lookDirection, sizeRayWall, whatIsWall) &&
        Physics2D.Raycast(secondWallPosition, Vector2.right * lookDirection, sizeRayWall, whatIsWall);
    }

    public virtual void GetCollidersPosition()
    {
        groundPosition = targetGround == null ?
        transform.position : targetGround.position;

        primaryWallPosition = primaryTargetWall == null ?
        transform.position : primaryTargetWall.position;

        secondWallPosition = secondTargetWall == null ?
        transform.position : secondTargetWall.position;
    }

    protected virtual void HandleFlip(float directionX)
    {
        if (Math.Sign(directionX) != lookDirection && Math.Sign(directionX) != 0)
        {
            Flip();
        }
    }

    [ContextMenu("Flip")]
    public void Flip()
    {
        lookDirection *= -1; //mirror the direction value
        transform.Rotate(new Vector3(0f, 180f, 0));
    }




}
