using Unity.VisualScripting;
using UnityEngine;

public class Enemy : EntityCharacter
{


    public BaseEnemy_IdleState idleState { get; protected set; }
    public BaseEnemy_WalkState walkState { get; protected set; }
    public BaseEnemy_BattleState battleState { get; protected set; }
    public BaseEnemy_AttackState attackState { get; protected set; }

    [Range(0, 2)] public float walkSpeedAnimMultiplier;
    public float timeToQuitIdle = 3;

    [Header("DetectedPlayer")]
    [SerializeField] private LayerMask whatIsPlayer;
    [SerializeField] private Transform targetPlayerCheck;
    public float detectionDistance = 5f;
    private Vector3 detectionPosition;

    [Header("Battle details")]
    public float attackDistance;
    public float battleSpeed;







    public override void Start()
    {
        base.Start();
        StateMachine.InitStateMachine(idleState);
    }

    public RaycastHit2D PlayerDetected()
    {
        RaycastHit2D hit = Physics2D.Raycast(detectionPosition, Vector2.right * lookDirection, detectionDistance, whatIsPlayer | whatIsWall);
        if (hit.collider == null || hit.collider.gameObject.layer != LayerMask.NameToLayer("Player"))
        {
            hit = default;
        }
        return hit;
    }

    public override void OnDrawGizmos()
    {
        base.OnDrawGizmos();
        Gizmos.color = Color.blue;
        Gizmos.DrawLine(detectionPosition, detectionPosition + Vector3.right * lookDirection * detectionDistance);
    }
    public override void GetCollidersPosition()
    {
        base.GetCollidersPosition();
        detectionPosition = targetPlayerCheck == null ?
        transform.position : targetPlayerCheck.position;
    }



}
