Shader "Custom/ColorBlindness"
{
    Properties
    {
        _MainTex ("Texture", 2D) = "white" {}
    }

    SubShader
    {
        Tags { "RenderType"="Opaque" }
        Pass
        {
            ZTest Always Cull Off ZWrite Off
            Fog { Mode Off }

            CGPROGRAM
            #pragma vertex vert_img
            #pragma fragment frag
            #include "UnityCG.cginc"

            sampler2D _MainTex;
            float4x4 _ColorBlindMatrix; // Declared here instead of Properties

            fixed4 frag(v2f_img i) : SV_Target
            {
                fixed4 col = tex2D(_MainTex, i.uv);
                fixed3 rgb = mul(_ColorBlindMatrix, float4(col.rgb, 1)).rgb;
                return fixed4(rgb, col.a); // Preserve original alpha
            }

            ENDCG
        }
    }
}
