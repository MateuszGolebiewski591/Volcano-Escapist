using UnityEngine;
using UnityEngine.InputSystem;

public class ColorBlindnessFilter : MonoBehaviour
{
    public Material material;
    private Matrix4x4 currentMatrix = Matrix4x4.identity;
    public CameraSettings settings;

    void Start()
    {
        currentMatrix = settings.matrix;
    }

    private static readonly Matrix4x4 Protanopia = new Matrix4x4(
        new Vector4(0.567f, 0.433f, 0.0f, 0.0f),
        new Vector4(0.558f, 0.442f, 0.0f, 0.0f),
        new Vector4(0.0f, 0.242f, 0.758f, 0.0f),
        new Vector4(0, 0, 0, 1)
    );
    private static readonly Matrix4x4 Deuteranopia = new Matrix4x4(
        new Vector4(0.625f, 0.375f, 0.0f, 0.0f),
        new Vector4(0.7f, 0.3f, 0.0f, 0.0f),
        new Vector4(0.0f, 0.3f, 0.7f, 0.0f),
        new Vector4(0, 0, 0, 1)
    );
    private static readonly Matrix4x4 Tritanopia = new Matrix4x4(
        new Vector4(0.95f, 0.05f, 0.0f, 0.0f),
        new Vector4(0.0f, 0.433f, 0.567f, 0.0f),
        new Vector4(0.0f, 0.475f, 0.525f, 0.0f),
        new Vector4(0, 0, 0, 1)
    );

    void OnRenderImage(RenderTexture src, RenderTexture dest)
    {
        if (material != null)
            Graphics.Blit(src, dest, material);
        else
            Graphics.Blit(src, dest);
    }

    public void FilterProtanopia()
    {
        material.SetMatrix("_ColorBlindMatrix", Protanopia);
        settings.matrix = Protanopia;
    }

    public void FilterTritanopia()
    {
        material.SetMatrix("_ColorBlindMatrix", Tritanopia);
        settings.matrix = Tritanopia;
    }

    public void FilterDeuteranopia()
    {
        material.SetMatrix("_ColorBlindMatrix", Deuteranopia);
        settings.matrix = Deuteranopia;
    }
    public void FilterNormal()
    {
        material.SetMatrix("_ColorBlindMatrix", Matrix4x4.identity);
        settings.matrix = Matrix4x4.identity;
    }
}
