Shader "Bytesized/Toon"
{
	Properties
	{
		_Color("Color", Color) = (1, 1, 1, 1)

		_MainTex("Main Texture", 2D) = "white" {}

		[HDR] _AmbientColor("Ambient Color", Color) = (0.4, 0.4, 0.4, 100)

		[HDR] _SpecularColor("Specular Color", Color) = (0.9, 0.9, 0.9, 100)

		_Glossiness("Glossiness", Float) = 200

		[HDR] _RimColor("Rim Color", Color) = (1, 1, 1, 1)

		_RimBlend("Rim Blend", Range(0, 100)) = 50

		_RimThreshold("Rim Threshold", Range(0, 100)) = 20

		_Smoothness("Smoothness", Range(0, 50)) = 25
	}
	
	SubShader
	{
		Pass
		{
			Tags
			{
				"LightMode" = "ForwardBase"
			}

			CGPROGRAM
			
			#pragma vertex vert
			
			#pragma fragment frag
			
			#pragma multi_compile_fwdbase
			
			#include "ToonPass.cginc"
			
			ENDCG
		}
		
		Pass 
		{
			Tags
			{
				"LightMode" = "ForwardAdd"
			}

            Blend One One
            ZWrite Off

			CGPROGRAM

			#pragma vertex vert
			
			#pragma fragment frag

			#pragma multi_compile_fwdadd_fullshadows

			#include "ToonPass.cginc"

			ENDCG
		}

        UsePass "Legacy Shaders/VertexLit/SHADOWCASTER"
	}
}