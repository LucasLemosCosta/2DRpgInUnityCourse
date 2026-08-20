using UnityEngine;
using UnityEngine.InputSystem;

public class GetInputs : MonoBehaviour
{
    public Vector2 Direction { get; protected set; }
    public bool OnJump { get; private set; }

    public void GetDirection(InputAction.CallbackContext ctx)
    {
        Direction = ctx.ReadValue<Vector2>().normalized;

    }

    public void GetInputJump(InputAction.CallbackContext ctx) => OnJump = ctx.performed;
}
