using UnityEngine;

public class PlayerController : EntityCharacter
{
    //States
    public PlayerIdleState IdleState { get; private set; }
    public PlayerWalkState WalkState { get; private set; }
    public PlayerFallState FallState { get; private set; }
    public PlayerJumpState JumpState { get; private set; }
    public PlayerWallState WallState { get; private set; }
    public PlayerWallJumpState WallJumpState { get; private set; }
    public PlayerStateAttackBase AttackBase { get; private set; }
    public GetInputs GetInputs { get; private set; }


    public Vector2 wallJump;

    [Header("Attack detils")]
    [SerializeField] private Vector2 attackImpulse;
    private int comboAttack = 0;


   


    public override void Awake()
    {
        base.Awake();
        //Set
        GetInputs = GetComponentInChildren<GetInputs>();
        IdleState = new PlayerIdleState(this, StateMachine, "Idle");
        WalkState = new PlayerWalkState(this, StateMachine, "Walk");
        FallState = new PlayerFallState(this, StateMachine, "Fall");
        JumpState = new PlayerJumpState(this, StateMachine, "Jump");
        WallState = new PlayerWallState(this, StateMachine, "Wall");
        WallJumpState = new PlayerWallJumpState(this, StateMachine, "Jump");
        AttackBase = new PlayerStateAttackBase(this, StateMachine, "Attack");

    }

    public override void Start()
    {
        base.Start();
        StateMachine?.InitStateMachine(IdleState);
        
    }
    public override void Update()
    {
        base.Update();
        StateMachine.CurrentState?.UpdateState();
    }

    protected override void HandleFlip()
    {
        if(canFlip)
        {
            if(GetInputs.Direction.x != lookDirection && GetInputs.Direction.x != 0 && Rb.linearVelocityX != lookDirection)
            {
                Flip();
            }
        }
    }
}
