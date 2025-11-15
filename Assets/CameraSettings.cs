using UnityEngine;

[CreateAssetMenu(fileName = "CameraSettings", menuName = "Scriptable Objects/CameraSettings")]
public class CameraSettings : ScriptableObject
{
    public Matrix4x4 matrix = Matrix4x4.identity;
}
