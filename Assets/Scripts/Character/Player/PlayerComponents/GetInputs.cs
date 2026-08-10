using UnityEngine;
using UnityEngine.InputSystem;

public class GetInputs : MonoBehaviour
{
    public Vector2 DirectionX { get; protected set; }

    public void GetDirection(InputAction.CallbackContext ctx)
    {
        DirectionX = ctx.ReadValue<Vector2>();
    }
}
