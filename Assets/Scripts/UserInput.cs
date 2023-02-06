using UnityEngine;
using UnityEngine.InputSystem;

public class UserInput : MonoBehaviour
{

    public static bool click;

    public void OnFire(InputAction.CallbackContext ctx)
    {
        click = ctx.canceled ? false : true;
    }
}
