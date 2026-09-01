using UnityEngine;

public class EntityAnimationController : MonoBehaviour
{

    private EntityCharacter character;

    private void Awake()
    {
        character = GetComponent<EntityCharacter>();
    }
    public void AnimationAttackEnd()
    {
        character.CallStateAnimationTrigger();
    }
}
