using UnityEngine;

public class RumbleController : MonoBehaviour
{
    public bool gameover = false;
    public void SetRumble(float lowFrequency, float highFrequency)
    {
        var gamepad = UnityEngine.InputSystem.Gamepad.current;
        if (gamepad != null)
        {
            if (gameover)
            {
                lowFrequency = 0;
                highFrequency = 0;
            }
            gamepad.SetMotorSpeeds(lowFrequency, highFrequency);
        }
    }
}
