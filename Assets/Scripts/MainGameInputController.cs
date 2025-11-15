using UnityEngine;
using UnityEngine.InputSystem;

public class MainGameInputController : MonoBehaviour
{
    [SerializeField] Player player;
    void Update()
    {
        Vector2 move = Vector2.zero;
        if (Keyboard.current.wKey.isPressed || Keyboard.current.spaceKey.isPressed) player.Jump();
        if (Keyboard.current.sKey.isPressed) move += Vector2.down;
        if (Keyboard.current.aKey.isPressed) move += Vector2.left;
        if (Keyboard.current.dKey.isPressed) move += Vector2.right;

        if (move != Vector2.zero) player.Move(move);
        else player.StopMove();

        if (Keyboard.current.upArrowKey.wasPressedThisFrame) player.GravityMovement("Up");
        if (Keyboard.current.downArrowKey.wasPressedThisFrame) player.GravityMovement("Down");
        if (Keyboard.current.leftArrowKey.wasPressedThisFrame) player.GravityMovement("Left");
        if (Keyboard.current.rightArrowKey.wasPressedThisFrame) player.GravityMovement("Right");

        var gamepad = Gamepad.current;
        if (gamepad != null)
            {
                if (gamepad.dpad.up.wasPressedThisFrame) player.GravityMovement("Up");
                if (gamepad.dpad.down.wasPressedThisFrame) player.GravityMovement("Down");
                if (gamepad.dpad.left.wasPressedThisFrame) player.GravityMovement("Left");
                if (gamepad.dpad.right.wasPressedThisFrame) player.GravityMovement("Right");
                /*
                Gamepad.current.buttonSouth.wasPressedThisFrame;   // A button
                Gamepad.current.buttonEast.wasPressedThisFrame;    // B button
                Gamepad.current.buttonWest.wasPressedThisFrame;    // X button
                Gamepad.current.buttonNorth.wasPressedThisFrame;   // Y button
                */

            
            }

    }
}
