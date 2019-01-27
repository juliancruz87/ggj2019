Shader "Unlit/simpleWave2"
{
	Properties
	{
		_MainTex ("Texture", 2D) = "white" {}
		_waveLength("waveLength", Range(0.01,2)) = 0.71
		_waveHeight("waveHeight", Range(0.01,2)) = 0.48
		_waveFrequency("waveFrequency", Range(0.01,2)) = 0.53
		_vertOffset("vertOffset", Range(0.01,2)) = 1
	}

	SubShader
	{
		Tags { "RenderType"="Opaque" }
		LOD 100
		Pass
		{
			Tags {"LightMode"="ForwardBase"}

			CGPROGRAM			
			#pragma vertex vert
			#pragma fragment frag
			//#pragma surface surf Lambert
			// make fog work
			#pragma multi_compile_fog			
			#include "UnityCG.cginc"
			#include "UnityLightingCommon.cginc"

			
			struct appdata
			{
				float4 vertex : POSITION;
				float2 uv : TEXCOORD0;
				float3 normal : NORMAL;
				float4 tangent : TANGENT;

			};

			struct v2f
			{
				float2 uv : TEXCOORD0;
				UNITY_FOG_COORDS(1)
				float4 vertex : SV_POSITION;
				float4 color : COLOR;

			};

			sampler2D _MainTex;
			float4 _MainTex_ST;
			
			float _waveLength = 0.71f;
			float _waveHeight = 0.48f;
			float _waveFrequency = 0.53f;
			float _vertOffset = 1;

			float3 getNewVertPosition( float3 v2 )
			{	
				v2.y = 0;
 				float3 waveSource1 = float3(2, 0, 2);
 				float dist = distance(v2, waveSource1);                       
		        dist = (dist % _waveLength) / _waveLength;					
				float _pi = 3.14f;
		        float  offset = (_pi * 2 * dist); 		        
                v2.y = _waveHeight * sin(_Time.y *  _pi *  2 * _waveFrequency + offset);
                return v2;

			}

			v2f vert (appdata v)
			{
				v2f o;											
				float3 vertPosition = getNewVertPosition(v.vertex); 				

				// calculate the bitangent (sometimes called binormal) from the cross product of the normal and the tangent
				float4 bitangent = float4( cross( v.normal, v.tangent ), 0 );
				// how far we want to offset our vert position to calculate the new normal				

				float3 v1 = getNewVertPosition( v.vertex + v.tangent  * _vertOffset );
				float3 v2 = getNewVertPosition( v.vertex + bitangent  * _vertOffset );
				// now we can create new tangents and bitangents based on the deformed positions
				float3 newTangent =   v1 - vertPosition;
				float3 newBitangent = v2 - vertPosition;

				// recalculate the normal based on the new tangent & bitangent				
				v.normal = cross( newTangent, newBitangent );				
				v.normal = normalize(v.normal);
				
				v.vertex = float4( vertPosition , 0)  ;
				o.vertex = UnityObjectToClipPos( v.vertex );         
				o.uv = TRANSFORM_TEX(v.uv, _MainTex);		
				

				// light 
				half3 worldNormal = UnityObjectToWorldNormal(v.normal);				
				// projection of the light into the surface
				// it is the amount of light projected.
				half projectionAngle = max( 0, dot (worldNormal , _WorldSpaceLightPos0.xyz) );
				// plus the color of the light
				o.color = projectionAngle * _LightColor0;

				// Show normal
				//o.color = float4 ( v.normal , 0 );				
				return o;
			}			

			
			fixed4 frag (v2f i) : SV_Target
			{
				fixed4 col = tex2D(_MainTex, i.uv);				
				col = col * i.color;
				return col;
			}
			
			ENDCG
		}
	}
}
