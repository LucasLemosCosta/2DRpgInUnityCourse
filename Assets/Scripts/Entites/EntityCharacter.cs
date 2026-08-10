using UnityEngine;

public abstract class EntityCharacter : MonoBehaviour
{

    //Componets
    public Rigidbody2D Rb { get; protected set; }
    public Animator Anim { get; protected set; }


    private void Awake()
    {
        Rb = GetComponent<Rigidbody2D>();
        Anim = GetComponentInChildren<Animator>();
    }

}
