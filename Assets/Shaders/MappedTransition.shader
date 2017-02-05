Shader "Unlit/MappedTransition"
{
	Properties
	{
		_MainTex ("Texture", 2D) = "white" {}
		cutoff("Cutoff", Range(0,1)) = 0
		color1("Color 1", Color) = (1,1,1,1)
		color2("Color 2", Color) = (1,1,1,1)
		transitionGradient("Texture", 2D) = "white" {}
	}
	SubShader
	{
		Tags { "Queue"="Transparent" "RenderType"="Transparent" }
		LOD 100
		Blend SrcAlpha OneMinusSrcAlpha

		Pass
		{
			CGPROGRAM
			#pragma vertex vert
			#pragma fragment frag
			
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
			};

			sampler2D _MainTex;
			float4 _MainTex_ST;

			float cutoff;
			float4 color1;
			float4 color2;
			sampler2D transitionGradient;

			v2f vert (appdata v)
			{
				v2f o;
				o.vertex = UnityObjectToClipPos(v.vertex);
				o.uv = TRANSFORM_TEX(v.uv, _MainTex);
				UNITY_TRANSFER_FOG(o,o.vertex);
				return o;
			}
			
			fixed4 frag(v2f i) : SV_Target
			{
				float transitonValue = tex2D(transitionGradient, i.uv).x;

				fixed4 col = tex2D(_MainTex, i.uv);
				
				if (transitonValue < cutoff)
					col *= color2;
				else
					col *= color1;
				
				return col;
			}
			ENDCG
		}
	}
}
