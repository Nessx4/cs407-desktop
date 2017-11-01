﻿Shader "Hidden/PPGaussianBlur"
{
	Properties
	{
		_MainTex ("Base (RGB)", 2D) = "white" {}
		_BlendAmount ("% Sepia-tone", Range(0, 1)) = 0
	}
	SubShader
	{
		Pass
		{
			CGPROGRAM
			#pragma vertex vert_img
			#pragma fragment frag
			
			#include "UnityCG.cginc"
			
			uniform sampler2D _MainTex;
			uniform float _BlendAmount;

			fixed4 frag (v2f_img i) : SV_Target
			{
				fixed4 tex = tex2D(_MainTex, i.uv);

				// Yay magic numbers! These represent sepia tone somehow.
				half3x3 magic = half3x3
				(
					0.393, 0.349, 0.272,	// Red.
					0.769, 0.686, 0.534,	// Green.
					0.189, 0.168, 0.131		// Blue.
				);

				half3 intermediate = (_BlendAmount * mul(tex.rgb, magic)) + 
					((1 - _BlendAmount) * tex.rbg);

				return half4(intermediate, tex.a);
			}
			ENDCG
		}
	}
}