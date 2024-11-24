// Made with Amplify Shader Editor v1.9.3.2
// Available at the Unity Asset Store - http://u3d.as/y3X 
Shader "ConvolutionFilter"
{
	Properties
	{
		
	}

	SubShader
	{
		LOD 0

		Cull Off
		ZWrite Off
		ZTest Always
		
		Pass
		{
			CGPROGRAM

			

			#pragma vertex Vert
			#pragma fragment Frag
			#pragma target 3.0

			#include "UnityCG.cginc"
			#include "UnityShaderVariables.cginc"
			#define ASE_NEEDS_FRAG_SCREEN_POSITION_NORMALIZED

		
			struct ASEAttributesDefault
			{
				float3 vertex : POSITION;
				float2 texcoord : TEXCOORD0;
				
			};

			struct ASEVaryingsDefault
			{
				float4 vertex : SV_POSITION;
				float2 texcoord : TEXCOORD0;
				float2 texcoordStereo : TEXCOORD1;
			#if STEREO_INSTANCING_ENABLED
				uint stereoTargetEyeIndex : SV_RenderTargetArrayIndex;
			#endif
				
			};

			uniform sampler2D _MainTex;
			uniform half4 _MainTex_TexelSize;
			uniform half4 _MainTex_ST;
			
			UNITY_DECLARE_DEPTH_TEXTURE( _CameraDepthTexture );
			uniform float4 _CameraDepthTexture_TexelSize;


			
			float2 TransformTriangleVertexToUV (float2 vertex)
			{
				float2 uv = (vertex + 1.0) * 0.5;
				return uv;
			}

			ASEVaryingsDefault Vert( ASEAttributesDefault v  )
			{
				ASEVaryingsDefault o;
				o.vertex = float4(v.vertex.xy, 0.0, 1.0);
				o.texcoord = TransformTriangleVertexToUV (v.vertex.xy);
#if UNITY_UV_STARTS_AT_TOP
				o.texcoord = o.texcoord * float2(1.0, -1.0) + float2(0.0, 1.0);
#endif
				o.texcoordStereo = TransformStereoScreenSpaceTex (o.texcoord, 1.0);

				v.texcoord = o.texcoordStereo;
				float4 ase_ppsScreenPosVertexNorm = float4(o.texcoordStereo,0,1);

				

				return o;
			}

			float4 Frag (ASEVaryingsDefault i  ) : SV_Target
			{
				float4 ase_ppsScreenPosFragNorm = float4(i.texcoordStereo,0,1);

				float4 break31 = ase_ppsScreenPosFragNorm;
				float temp_output_79_0 = ( 2.0 / _ScreenParams.x );
				float temp_output_33_0 = ( break31.x - temp_output_79_0 );
				float temp_output_81_0 = ( 2.0 / _ScreenParams.y );
				float temp_output_34_0 = ( break31.y + temp_output_81_0 );
				float4 appendResult41 = (float4(temp_output_33_0 , temp_output_34_0 , ase_ppsScreenPosFragNorm.z , ase_ppsScreenPosFragNorm.w));
				float clampDepth57 = Linear01Depth(SAMPLE_DEPTH_TEXTURE( _CameraDepthTexture, appendResult41.xy ));
				float3x3 break100 = float3x3(-1,-1,-1,-1,8,-1,-1,-1,-1);
				float4 appendResult39 = (float4(ase_ppsScreenPosFragNorm.x , temp_output_34_0 , ase_ppsScreenPosFragNorm.z , ase_ppsScreenPosFragNorm.w));
				float clampDepth62 = Linear01Depth(SAMPLE_DEPTH_TEXTURE( _CameraDepthTexture, appendResult39.xy ));
				float temp_output_32_0 = ( break31.x + temp_output_79_0 );
				float4 appendResult42 = (float4(temp_output_32_0 , temp_output_34_0 , ase_ppsScreenPosFragNorm.z , ase_ppsScreenPosFragNorm.w));
				float clampDepth63 = Linear01Depth(SAMPLE_DEPTH_TEXTURE( _CameraDepthTexture, appendResult42.xy ));
				float4 appendResult38 = (float4(temp_output_33_0 , ase_ppsScreenPosFragNorm.y , ase_ppsScreenPosFragNorm.z , ase_ppsScreenPosFragNorm.w));
				float clampDepth58 = Linear01Depth(SAMPLE_DEPTH_TEXTURE( _CameraDepthTexture, appendResult38.xy ));
				float4 appendResult37 = (float4(ase_ppsScreenPosFragNorm.x , ase_ppsScreenPosFragNorm.y , ase_ppsScreenPosFragNorm.z , ase_ppsScreenPosFragNorm.w));
				float clampDepth61 = Linear01Depth(SAMPLE_DEPTH_TEXTURE( _CameraDepthTexture, appendResult37.xy ));
				float4 appendResult36 = (float4(temp_output_32_0 , ase_ppsScreenPosFragNorm.y , ase_ppsScreenPosFragNorm.z , ase_ppsScreenPosFragNorm.w));
				float clampDepth64 = Linear01Depth(SAMPLE_DEPTH_TEXTURE( _CameraDepthTexture, appendResult36.xy ));
				float temp_output_35_0 = ( break31.y - temp_output_81_0 );
				float4 appendResult44 = (float4(temp_output_33_0 , temp_output_35_0 , ase_ppsScreenPosFragNorm.z , ase_ppsScreenPosFragNorm.w));
				float clampDepth59 = Linear01Depth(SAMPLE_DEPTH_TEXTURE( _CameraDepthTexture, appendResult44.xy ));
				float4 appendResult40 = (float4(temp_output_32_0 , temp_output_35_0 , ase_ppsScreenPosFragNorm.z , ase_ppsScreenPosFragNorm.w));
				float clampDepth60 = Linear01Depth(SAMPLE_DEPTH_TEXTURE( _CameraDepthTexture, appendResult40.xy ));
				float4 appendResult43 = (float4(temp_output_32_0 , temp_output_35_0 , ase_ppsScreenPosFragNorm.z , ase_ppsScreenPosFragNorm.w));
				float clampDepth65 = Linear01Depth(SAMPLE_DEPTH_TEXTURE( _CameraDepthTexture, appendResult43.xy ));
				

				float4 color = ( tex2D( _MainTex, ase_ppsScreenPosFragNorm.xy ) * (0.5 + (abs( ( saturate( ( ( clampDepth57 * break100[ 0 ][ 0 ] ) + ( clampDepth62 * break100[ 0 ][ 1 ] ) + ( clampDepth63 * break100[ 0 ][ 2 ] ) + ( clampDepth58 * break100[ 1 ][ 0 ] ) + ( clampDepth61 * break100[ 1 ][ 1 ] ) + ( clampDepth64 * break100[ 1 ][ 2 ] ) + ( clampDepth59 * break100[ 2 ][ 0 ] ) + ( clampDepth60 * break100[ 2 ][ 1 ] ) + ( clampDepth65 * break100[ 2 ][ 2 ] ) ) ) - 1.0 ) ) - 0.0) * (1.0 - 0.5) / (1.0 - 0.0)) );
				
				return color;
			}
			ENDCG
		}
	}
	CustomEditor "ASEMaterialInspector"
	
	Fallback Off
}
/*ASEBEGIN
Version=19302
Node;AmplifyShaderEditor.ScreenPosInputsNode;25;-823.7578,-139.0696;Float;False;0;False;0;5;FLOAT4;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.ScreenParams;26;-817.8159,91.88477;Inherit;False;0;5;FLOAT4;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.RangedFloatNode;96;-1196.052,358.4648;Inherit;False;Constant;_Float3;Float 3;0;0;Create;True;0;0;0;False;0;False;2;0;0;0;0;1;FLOAT;0
Node;AmplifyShaderEditor.BreakToComponentsNode;31;-479.4577,-123.2697;Inherit;False;FLOAT4;1;0;FLOAT4;0,0,0,0;False;16;FLOAT;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4;FLOAT;5;FLOAT;6;FLOAT;7;FLOAT;8;FLOAT;9;FLOAT;10;FLOAT;11;FLOAT;12;FLOAT;13;FLOAT;14;FLOAT;15
Node;AmplifyShaderEditor.SimpleDivideOpNode;79;-483.0897,165.7461;Inherit;False;2;0;FLOAT;0;False;1;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.SimpleDivideOpNode;81;-484.9898,267.3465;Inherit;False;2;0;FLOAT;0;False;1;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.SimpleAddOpNode;32;-154.4578,-125.2697;Inherit;False;2;2;0;FLOAT;0;False;1;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.SimpleSubtractOpNode;33;-168.4578,-24.26965;Inherit;False;2;0;FLOAT;0;False;1;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.SimpleAddOpNode;34;-150.4578,86.23046;Inherit;False;2;2;0;FLOAT;0;False;1;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.SimpleSubtractOpNode;35;-164.4578,187.2304;Inherit;False;2;0;FLOAT;0;False;1;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.DynamicAppendNode;41;171.5304,-294.5515;Inherit;False;FLOAT4;4;0;FLOAT;0;False;1;FLOAT;0;False;2;FLOAT;0;False;3;FLOAT;0;False;1;FLOAT4;0
Node;AmplifyShaderEditor.DynamicAppendNode;39;598.8879,-282.9337;Inherit;False;FLOAT4;4;0;FLOAT;0;False;1;FLOAT;0;False;2;FLOAT;0;False;3;FLOAT;0;False;1;FLOAT4;0
Node;AmplifyShaderEditor.DynamicAppendNode;38;166.8489,-11.19327;Inherit;False;FLOAT4;4;0;FLOAT;0;False;1;FLOAT;0;False;2;FLOAT;0;False;3;FLOAT;0;False;1;FLOAT4;0
Node;AmplifyShaderEditor.DynamicAppendNode;37;597.2808,-4.817881;Inherit;False;FLOAT4;4;0;FLOAT;0;False;1;FLOAT;0;False;2;FLOAT;0;False;3;FLOAT;0;False;1;FLOAT4;0
Node;AmplifyShaderEditor.DynamicAppendNode;44;166.8475,284.3075;Inherit;False;FLOAT4;4;0;FLOAT;0;False;1;FLOAT;0;False;2;FLOAT;0;False;3;FLOAT;0;False;1;FLOAT4;0
Node;AmplifyShaderEditor.DynamicAppendNode;40;609.6048,285.025;Inherit;False;FLOAT4;4;0;FLOAT;0;False;1;FLOAT;0;False;2;FLOAT;0;False;3;FLOAT;0;False;1;FLOAT4;0
Node;AmplifyShaderEditor.DynamicAppendNode;42;1009.082,-295.9341;Inherit;False;FLOAT4;4;0;FLOAT;0;False;1;FLOAT;0;False;2;FLOAT;0;False;3;FLOAT;0;False;1;FLOAT4;0
Node;AmplifyShaderEditor.DynamicAppendNode;36;999.7217,-19.26858;Inherit;False;FLOAT4;4;0;FLOAT;0;False;1;FLOAT;0;False;2;FLOAT;0;False;3;FLOAT;0;False;1;FLOAT4;0
Node;AmplifyShaderEditor.DynamicAppendNode;43;1016.1,273.825;Inherit;False;FLOAT4;4;0;FLOAT;0;False;1;FLOAT;0;False;2;FLOAT;0;False;3;FLOAT;0;False;1;FLOAT4;0
Node;AmplifyShaderEditor.Matrix3X3Node;99;-1191.836,568.0912;Inherit;False;Constant;_Matrix0;Matrix 0;0;0;Create;True;0;0;0;False;0;False;-1,-1,-1,-1,8,-1,-1,-1,-1;0;1;FLOAT3x3;0
Node;AmplifyShaderEditor.ScreenDepthNode;57;310.4178,-295.7998;Inherit;False;1;True;1;0;FLOAT4;0,0,0,0;False;1;FLOAT;0
Node;AmplifyShaderEditor.ScreenDepthNode;58;302.1883,-5.793849;Inherit;False;1;True;1;0;FLOAT4;0,0,0,0;False;1;FLOAT;0
Node;AmplifyShaderEditor.ScreenDepthNode;59;305.4603,279.4732;Inherit;False;1;True;1;0;FLOAT4;0,0,0,0;False;1;FLOAT;0
Node;AmplifyShaderEditor.ScreenDepthNode;60;753.7003,292.5606;Inherit;False;1;True;1;0;FLOAT4;0,0,0,0;False;1;FLOAT;0
Node;AmplifyShaderEditor.ScreenDepthNode;61;737.3408,-1.431392;Inherit;False;1;True;1;0;FLOAT4;0,0,0,0;False;1;FLOAT;0
Node;AmplifyShaderEditor.ScreenDepthNode;62;729.2106,-279.4405;Inherit;False;1;True;1;0;FLOAT4;0,0,0,0;False;1;FLOAT;0
Node;AmplifyShaderEditor.ScreenDepthNode;63;1144.838,-289.9703;Inherit;False;1;True;1;0;FLOAT4;0,0,0,0;False;1;FLOAT;0
Node;AmplifyShaderEditor.ScreenDepthNode;64;1140.971,-11.96124;Inherit;False;1;True;1;0;FLOAT4;0,0,0,0;False;1;FLOAT;0
Node;AmplifyShaderEditor.ScreenDepthNode;65;1161.693,282.0308;Inherit;False;1;True;1;0;FLOAT4;0,0,0,0;False;1;FLOAT;0
Node;AmplifyShaderEditor.BreakToComponentsNode;100;392.5037,595.159;Inherit;False;FLOAT3x3;1;0;FLOAT3x3;0,0,0,1,0,0,1,0,1;False;16;FLOAT;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4;FLOAT;5;FLOAT;6;FLOAT;7;FLOAT;8;FLOAT;9;FLOAT;10;FLOAT;11;FLOAT;12;FLOAT;13;FLOAT;14;FLOAT;15
Node;AmplifyShaderEditor.SimpleMultiplyOpNode;66;324.5958,-212.9134;Inherit;False;2;2;0;FLOAT;0;False;1;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.SimpleMultiplyOpNode;71;751.0238,-207.4603;Inherit;False;2;2;0;FLOAT;0;False;1;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.SimpleMultiplyOpNode;67;320.7286,74.91116;Inherit;False;2;2;0;FLOAT;0;False;1;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.SimpleMultiplyOpNode;70;744.975,80.3643;Inherit;False;2;2;0;FLOAT;0;False;1;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.SimpleMultiplyOpNode;68;318.5477,364.5408;Inherit;False;2;2;0;FLOAT;0;False;1;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.SimpleMultiplyOpNode;69;749.3379,373.2659;Inherit;False;2;2;0;FLOAT;0;False;1;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.SimpleMultiplyOpNode;72;1157.924,-204.9028;Inherit;False;2;2;0;FLOAT;0;False;1;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.SimpleMultiplyOpNode;73;1162.782,80.74057;Inherit;False;2;2;0;FLOAT;0;False;1;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.SimpleMultiplyOpNode;74;1173.155,378.0045;Inherit;False;2;2;0;FLOAT;0;False;1;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.SimpleAddOpNode;76;1506.523,-59.37023;Inherit;False;9;9;0;FLOAT;0;False;1;FLOAT;0;False;2;FLOAT;0;False;3;FLOAT;0;False;4;FLOAT;0;False;5;FLOAT;0;False;6;FLOAT;0;False;7;FLOAT;0;False;8;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.SaturateNode;91;1634.175,-59.4765;Inherit;False;1;0;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.RangedFloatNode;93;1674.175,31.5235;Inherit;False;Constant;_Float2;Float 2;0;0;Create;True;0;0;0;False;0;False;1;0;0;0;0;1;FLOAT;0
Node;AmplifyShaderEditor.SimpleSubtractOpNode;92;1842.175,-61.4765;Inherit;False;2;0;FLOAT;0;False;1;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.TemplateShaderPropertyNode;88;1179.074,-714.7876;Inherit;True;0;0;_MainTex;Shader;False;0;5;SAMPLER2D;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.AbsOpNode;94;2011.175,-62.4765;Inherit;False;1;0;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.RangedFloatNode;102;1999.026,29.21733;Inherit;False;Constant;_Float0;Float 0;0;0;Create;True;0;0;0;False;0;False;0;0;0;0;0;1;FLOAT;0
Node;AmplifyShaderEditor.RangedFloatNode;104;1982.633,177.9216;Inherit;False;Constant;_Float4;Float 4;0;0;Create;True;0;0;0;False;0;False;0.5;0;0;0;0;1;FLOAT;0
Node;AmplifyShaderEditor.RangedFloatNode;103;1989.658,102.9841;Inherit;False;Constant;_Float1;Float 0;0;0;Create;True;0;0;0;False;0;False;1;0;0;0;0;1;FLOAT;0
Node;AmplifyShaderEditor.RangedFloatNode;105;1983.804,272.7645;Inherit;False;Constant;_Float5;Float 0;0;0;Create;True;0;0;0;False;0;False;1;0;0;0;0;1;FLOAT;0
Node;AmplifyShaderEditor.SamplerNode;89;1513.959,-574.2742;Inherit;True;Property;_TextureSample0;Texture Sample 0;0;0;Create;True;0;0;0;False;0;False;-1;None;None;True;0;False;white;Auto;False;Object;-1;Auto;Texture2D;8;0;SAMPLER2D;;False;1;FLOAT2;0,0;False;2;FLOAT;0;False;3;FLOAT2;0,0;False;4;FLOAT2;0,0;False;5;FLOAT;1;False;6;FLOAT;0;False;7;SAMPLERSTATE;;False;5;COLOR;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.TFHCRemapNode;101;2172.319,17.50827;Inherit;False;5;0;FLOAT;0;False;1;FLOAT;0;False;2;FLOAT;1;False;3;FLOAT;0;False;4;FLOAT;1;False;1;FLOAT;0
Node;AmplifyShaderEditor.SimpleMultiplyOpNode;90;2349.221,-104.5204;Inherit;False;2;2;0;COLOR;0,0,0,0;False;1;FLOAT;0;False;1;COLOR;0
Node;AmplifyShaderEditor.TemplateMultiPassMasterNode;0;2514.957,-94.06885;Float;False;True;-1;2;ASEMaterialInspector;0;8;ConvolutionFilter;32139be9c1eb75640a847f011acf3bcf;True;SubShader 0 Pass 0;0;0;SubShader 0 Pass 0;1;False;False;False;False;False;False;False;False;False;False;False;False;False;False;True;2;False;;False;False;False;False;False;False;False;False;False;False;False;True;2;False;;True;7;False;;False;False;False;False;0;False;False;False;False;False;False;False;False;False;False;False;False;False;False;False;False;False;False;False;False;False;False;False;False;False;False;False;False;False;False;True;2;False;0;;0;0;Standard;0;0;1;True;False;;False;0
WireConnection;31;0;25;0
WireConnection;79;0;96;0
WireConnection;79;1;26;1
WireConnection;81;0;96;0
WireConnection;81;1;26;2
WireConnection;32;0;31;0
WireConnection;32;1;79;0
WireConnection;33;0;31;0
WireConnection;33;1;79;0
WireConnection;34;0;31;1
WireConnection;34;1;81;0
WireConnection;35;0;31;1
WireConnection;35;1;81;0
WireConnection;41;0;33;0
WireConnection;41;1;34;0
WireConnection;41;2;25;3
WireConnection;41;3;25;4
WireConnection;39;0;25;1
WireConnection;39;1;34;0
WireConnection;39;2;25;3
WireConnection;39;3;25;4
WireConnection;38;0;33;0
WireConnection;38;1;25;2
WireConnection;38;2;25;3
WireConnection;38;3;25;4
WireConnection;37;0;25;1
WireConnection;37;1;25;2
WireConnection;37;2;25;3
WireConnection;37;3;25;4
WireConnection;44;0;33;0
WireConnection;44;1;35;0
WireConnection;44;2;25;3
WireConnection;44;3;25;4
WireConnection;40;0;32;0
WireConnection;40;1;35;0
WireConnection;40;2;25;3
WireConnection;40;3;25;4
WireConnection;42;0;32;0
WireConnection;42;1;34;0
WireConnection;42;2;25;3
WireConnection;42;3;25;4
WireConnection;36;0;32;0
WireConnection;36;1;25;2
WireConnection;36;2;25;3
WireConnection;36;3;25;4
WireConnection;43;0;32;0
WireConnection;43;1;35;0
WireConnection;43;2;25;3
WireConnection;43;3;25;4
WireConnection;57;0;41;0
WireConnection;58;0;38;0
WireConnection;59;0;44;0
WireConnection;60;0;40;0
WireConnection;61;0;37;0
WireConnection;62;0;39;0
WireConnection;63;0;42;0
WireConnection;64;0;36;0
WireConnection;65;0;43;0
WireConnection;100;0;99;0
WireConnection;66;0;57;0
WireConnection;66;1;100;0
WireConnection;71;0;62;0
WireConnection;71;1;100;1
WireConnection;67;0;58;0
WireConnection;67;1;100;3
WireConnection;70;0;61;0
WireConnection;70;1;100;4
WireConnection;68;0;59;0
WireConnection;68;1;100;6
WireConnection;69;0;60;0
WireConnection;69;1;100;7
WireConnection;72;0;63;0
WireConnection;72;1;100;2
WireConnection;73;0;64;0
WireConnection;73;1;100;5
WireConnection;74;0;65;0
WireConnection;74;1;100;8
WireConnection;76;0;66;0
WireConnection;76;1;71;0
WireConnection;76;2;72;0
WireConnection;76;3;67;0
WireConnection;76;4;70;0
WireConnection;76;5;73;0
WireConnection;76;6;68;0
WireConnection;76;7;69;0
WireConnection;76;8;74;0
WireConnection;91;0;76;0
WireConnection;92;0;91;0
WireConnection;92;1;93;0
WireConnection;94;0;92;0
WireConnection;89;0;88;0
WireConnection;89;1;25;0
WireConnection;101;0;94;0
WireConnection;101;1;102;0
WireConnection;101;2;103;0
WireConnection;101;3;104;0
WireConnection;101;4;105;0
WireConnection;90;0;89;0
WireConnection;90;1;101;0
WireConnection;0;0;90;0
ASEEND*/
//CHKSM=C5C6470F23E197A6591686D68837E10B481350C5