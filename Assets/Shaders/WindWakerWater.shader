﻿Shader "4GamPat/Water/WindWakerWater"
{
	Properties
	{
		_Tint("Tint", Color) = (1, 1, 1, 0.5)
		_MainTex ("Texture", 2D) = "white" {}
		_NoiseTex("Extra Wave Noise", 2D) = "white" {}
		_Speed("Wave Speed", Range(0, 1)) = 0.5
		_Frequency("Wave Frequency", Range(0, 1)) = 0.5
		_Height("Wave Height", Range(0, 1)) = 0.5
		_Foam("Foam Line Thickness", Range(0, 3)) = 0.5
	}

	SubShader
	{
		Tags { "RenderType" = "Opaque" "Queue" = "Transparent" }
		LOD 100
		Blend SrcAlpha OneMinusSrcAlpha

		Pass
		{
			CGPROGRAM
			#pragma vertex vert
			#pragma fragment frag
			// make fog work
			#pragma multi_compile_fog
			
			#include "UnityCG.cginc"

			struct appdata
			{
				float4 vertex : POSITION;
				float2 uv : TEXCOORD0;
			};

			struct v2f
			{
				float2 uv : TEXCOORD0;
				UNITY_FOG_COORDS(1)
				float4 vertex : SV_POSITION;
				float4 screenPos : TEXCOORD1;
			};

			float4 _Tint;
			uniform sampler2D _CameraDepthTexture;
			sampler2D _MainTex, _NoiseTex;
			float4 _MainTex_ST;
			float _Speed, _Frequency, _Height, _Foam;
			
			v2f vert (appdata v)
			{
				v2f o;
				
				float4 tex = tex2Dlod(_NoiseTex, float4(v.uv, 0, 0));
				v.vertex.y += sin(_Time.z * _Speed + (v.vertex.x * v.vertex.z * _Frequency * tex)) * _Height;
				o.vertex = UnityObjectToClipPos(v.vertex);
				o.uv = TRANSFORM_TEX(v.uv, _MainTex);
				o.screenPos = ComputeScreenPos(o.vertex);

				UNITY_TRANSFER_FOG(o,o.vertex);
				return o;
			}
			
			fixed4 frag (v2f i) : SV_Target
			{
				fixed4 col = tex2D(_MainTex, i.uv) * _Tint;
				half depth = LinearEyeDepth(SAMPLE_DEPTH_TEXTURE_PROJ(_CameraDepthTexture, UNITY_PROJ_COORD(i.screenPos)));
				half4 foamLine = 1 - saturate(_Foam * (depth - i.screenPos.w));
				col += foamLine * _Tint;
				return col;
			}
			ENDCG
		}
	}
}
