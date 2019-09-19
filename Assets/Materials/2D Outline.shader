Shader "Custom/2D Outline"
{
    Properties
    {
        _MainTex ("Texture", 2D) = "white" {}
		_Color("Color", Color) = (1,1,1,1)
		_Width("OutlineWidth", Range(0, 100) ) = 1
	}
		SubShader
		{

			Cull Off
			Blend One OneMinusSrcAlpha

			Pass {

			CGPROGRAM

			#pragma vertex vertexFunc
			#pragma fragment fragmentFunc

			#include "UnityCG.cginc"
			sampler2D _MainTex;
			float _Width;
			struct v2f {
				float4 pos : SV_POSITION;
				half2 uv : TEXCOORD0;
			};
			v2f vertexFunc(appdata_base v) {
				v2f o;
				o.pos = UnityObjectToClipPos(v.vertex);
				o.uv = v.texcoord;

				return o;
			}

			fixed4 _Color;
			float4 _MainTex_TexelSize;
			fixed4 fragmentFunc(v2f i) : COLOR{
				half4 c = tex2D(_MainTex, i.uv);
				c.rgb *= c.a;

				//outline defnition
				half4 outlineC = _Color;
				outlineC.a *= ceil(c.a);
				float width = _Width;
				//check alpha of the four pixels next to it
					fixed upAlpha = tex2D(_MainTex, i.uv + fixed2(0, _MainTex_TexelSize.y * width )).a;

					for (int x = 0; x < width; x += 1)
					{
						//if (tex2D(_MainTex, i.uv + fixed2(0, _MainTex_TexelSize.y * i)).a 
					}

					fixed downAlpha = tex2D(_MainTex, i.uv - fixed2(0, _MainTex_TexelSize.y * width)).a;
					fixed leftAlpha = tex2D(_MainTex, i.uv + fixed2(_MainTex_TexelSize.x * width, 0)).a;
					fixed rightAlpha = tex2D(_MainTex, i.uv - fixed2(_MainTex_TexelSize.x * width, 0)).a;
					
					//lerp (result color, normal color(can be alpha 0 ofcorse, 0 to 1 which is defined in the four vars above multiplied above)
					return lerp( outlineC, c, (upAlpha * downAlpha *rightAlpha * leftAlpha));
			} 

			ENDCG
		}
    }
    FallBack "Diffuse"
}
