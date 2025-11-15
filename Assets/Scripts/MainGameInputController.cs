using UnityEngine;
using UnityEngine.InputSystem;

public class MainGameInputController : MonoBehaviour
{
    [SerializeField] Player player;
      void Update()
    {
        if (Keyboard.current.wKey.wasPressedThisFrame) player.Up();
        if (Keyboard.current.sKey.wasPressedThisFrame) player.Down();
        if (Keyboard.current.aKey.wasPressedThisFrame) player.Left();
        if (Keyboard.current.dKey.wasPressedThisFrame) player.Right();

        var gamepad = Gamepad.current;
        if (gamepad != null)
        {
            if (gamepad.dpad.up.wasPressedThisFrame) player.Up();
            if (gamepad.dpad.down.wasPressedThisFrame) player.Down();
            if (gamepad.dpad.left.wasPressedThisFrame) player.Left();
            if (gamepad.dpad.right.wasPressedThisFrame) player.Right();
            /*
            Gamepad.current.buttonSouth.wasPressedThisFrame;   // A button
            Gamepad.current.buttonEast.wasPressedThisFrame;    // B button
            Gamepad.current.buttonWest.wasPressedThisFrame;    // X button
            Gamepad.current.buttonNorth.wasPressedThisFrame;   // Y button
            */

        
        }

    }
}
