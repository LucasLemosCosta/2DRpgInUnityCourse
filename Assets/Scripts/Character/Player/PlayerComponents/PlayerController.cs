using UnityEngine;

public class PlayerController : EntityCharacter
{
    //States
    public PlayerIdleState IdleState { get; protected set; }
    public PlayerWalkState WalkState { get; protected set; }
    public PlayerFallState FallState { get; protected set; }
    public PlayerJumpState JumpState { get; protected set; }

    public GetInputs GetInputs { get; private set; }


    public override void Awake()
    {
        base.Awake();
        //Set
        GetInputs = GetComponentInChildren<GetInputs>();
        IdleState = new PlayerIdleState(this, StateMachine, "Idle");
        WalkState = new PlayerWalkState(this, StateMachine, "Walk");
        FallState = new PlayerFallState(this, StateMachine, "Fall");
        JumpState = new PlayerJumpState(this, StateMachine, "Jump");

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
}
