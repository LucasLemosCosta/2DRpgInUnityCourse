using UnityEngine;

public abstract class EntityCharacter : MonoBehaviour
{

    //Componets
    public Rigidbody2D Rb { get; protected set; }
    public Animator Anim { get; protected set; }
    public StateMachine StateMachine { get; protected set; }


    //Attributes
    public float speedGround;
    public float forceJump;


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
        
    }

    public void MovimentCharacter(float directionX,float directionY)
    {
        Rb.linearVelocityX = directionX;
        Rb.linearVelocityY = directionY;
    }

    

}
