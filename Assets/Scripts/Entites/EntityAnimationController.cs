
using UnityEngine;

public class EntityAnimationController : MonoBehaviour
{

    private EntityCharacter character;

    private void Awake()
    {
        character = GetComponentInParent<EntityCharacter>();

    }
    public void AnimationAttackEnd()
    {
        character.CallStateAnimationTrigger();

    }
}
