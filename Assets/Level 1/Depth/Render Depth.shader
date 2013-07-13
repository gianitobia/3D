Shader "Render Depth" {
	SubShader {
	    Tags { "RenderType"="Opaque" }
	    Pass {
	        Fog { Mode Off }
			CGPROGRAM
			// Upgrade NOTE: excluded shader from OpenGL ES 2.0 because it does not contain a surface program or both vertex and fragment programs.
			//#pragma exclude_renderers gles
			//#pragma only_renderers opengl
			#pragma vertex vert
			#pragma fragment frag
			#include "UnityCG.cginc"
	
			struct v2f {
			    float4 pos : SV_POSITION;
			    float2 depth : TEXCOORD0;
			};
			
			v2f vert (appdata_base v) {
			    v2f o;
			    o.pos = mul (UNITY_MATRIX_MVP, v.vertex);
			    UNITY_TRANSFER_DEPTH(o.depth);
			  
			    return o;
			}
			
			half4 frag(v2f i) : COLOR {
			    UNITY_OUTPUT_DEPTH(i.depth);
			}
		ENDCG
		}
	}
}
