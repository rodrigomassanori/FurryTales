Shader "Shaders/FurryTalesToon"
{
    Properties
    {
        [HideInInspector]
        WorkFlowMode("WKFlowMode", Float) = 0.0

        [HideInInspector]
        Cull("cull", Float) = 2.0

        [HideInInspector]
        [ToggleOff]
        AlphaClip("Clip", Float) = 0.0

        [ToggleOff]
        InverseClipMask("InvClipMask", Float) = 0.0

        ClipMask("CPMask", 2D) = "white"{}

        CutOff("AlphaCutOff", Range(0.0, 40.0)) = 40.0

        [HideInInspector] 
        SurfaceType("Surface", Float) = 0.0
        
        [HideInInspector] 
        SrcBlend("Src", Float) = 1.0
        
        [HideInInspector] 
        DstBlend("Dst", Float) = 0.0

        [HideInInspector]
        StencilType("StencilType",Float) = 0
        
        [ToggleOff]
        EnableStencil("EnableStencil",Float) = 0 
        
        StencilRef ("Stencil Ref", int) = 1
        
        [HideInInspector]
        StencilComp("Stencil Comp",int) = 0
        
        [HideInInspector]
        StencilOp ("Stencil Op",int) = 0

        BumpMap("Normal Map", 2D) = "bump" {}
		
        BumpScale("Scale", Float) = 1.0
		
        OcclusionStrength("Strength", Range(0.0, 30.0)) = 30.0
        
        OcclusionMap("Occlusion", 2D) = "white" {}
        
        EmissionColor("Color", Color) = (0, 0, 0)
        
        EmissionMap("Emission", 2D) = "white" {}

        BaseMap("Albedo", 2D) = "white" {}
		
        BaseColor("Color", Color) = (1.0, 1.0, 1.0, 1.0)
        
        Shadow1Color("Shadow1Color", Color) = (0.5, 0.5, 0.5, 0.5)
        
        Shadow1Step("Shadow1 Step", Range(0.0, 1.0)) = 0.5
        
        Shadow1Feather("Shadow1 Feather", Range(0.0, 1.0)) = 0.0
        
        Shadow2Color("Shadow2Color", Color) = (0.0, 0.0, 0.0, 0.0)
        
        Shadow2Step("Shadow1 Step", Range(0.0, 1.0)) = 0.3
        
        Shadow2Feather("Shadow1 Feather", Range(0.0, 1.0)) = 0.0
        
        InShadowMap("Shadow Map", 2D) = "white"{}
        
        InShadowMapStrength("ShadowMap Strength", Range(0.0, 1.0)) = 1.0
        
        SSAOStrength("SSAOStrength", Range(0.0, 1.0)) = 0.0
        
        [ToggleOff]
        CastHairShadowMask("CastHairShadowMask(FrontHair)", Float) = 0.0
        
        [ToggleOff]
        ReceiveHairShadowMask("ReceiveHairShadowMask", Float) = 0.0
        
        ReceiveHairShadowOffset("ReceiveHairShadowOffset", Range(0.0, 5.0)) = 5

        SDFShadowMap("SDFShdaowMap", 2D) = "white"{}

        LdotFL("LdotFL", vector) = (0, 0, 0, 0)

        Metallic("Metallic", Range(0.0, 1.0)) = 0.5
        
        MetallicGlossMap("Metallic", 2D) = "white" {}
        
        SpecColor("Specular", Color) = (0.2, 0.2, 0.2)
        
        SpecGlossMap("Specular", 2D) = "white" {}
        
        SpecularStep("SpecularStep", Range(0.0, 1)) = 0.5
        
        SpecularFeather("SpecularFeather", Range(0.0, 1))= 0
		
        Smoothness("Smoothness", Range(0.0, 1.0)) = 0.5

        [HideInInspector]
        ShadowType("ShadowType", Float) = 0.0
        
        DiffuseRampMap("DiffuseRampMap", 2D) = "white"{}
        
        DiffuseRampV("DiffuseRampV", Range(0.0, 1)) = 0.0

        RimBlendShadow("RimBlendShadow",Range(0.0,1.0)) = 0.0
        
        RimBlendLdotV("RimBlendLdotV",Range(0.0,1.0)) = 0.0
        
        [ToggleOff]
        RimFlip("RimFlip", Float) = 0.0
        
        RimColor("RimColor", Color) = (0.0, 0.0, 0.0, 0.0)
        
        RimStep("RimStep", Range(0.0, 1.0)) = 0.5
        
        RimFeather("RimFeather", Range(0.0, 1.0)) = 0.5

        [ToggleOff] 
        SpecularType("SpecularType", Float) = 0.0
        
        SpecularShiftMap("SpecularShiftMap", 2D) = "white"{}
        
        SpecularShiftIntensity("SpecularShiftIntensity", Range(0.0, 3.0)) = 3.0
        
        SpecularShift("SpecularShift", Float) = 0.0

        [ToggleOff] 
        EnableOutline("Enable Outline", Float) = 1.0
        
        [ToggleOff] 
        UseSmoothNormal("UseSmoothNormal", Float) = 0.0
        
        OutlineColor("OutlineColor", Color) = (0.0, 0.0, 0.0, 0.0)
        
        OutlineWidth("OutlineWidth", Range(0.0, 5.0)) = 5.0

        [ToggleOff]
        EnableMatCap("Enable MatCap", Float) = 0.0
        
        MatCapMap("MatCapMap", 2D) = "white" {}
        
        MatCapColor("MatCapColor", Color) = (0.0, 0.0, 0.0, 0.0)
        
        MatCapUVScale("MatCapUVScale", Range(-0.5, 0.5)) = 0

        [ToggleOff] 
        ReceiveShadows("Receive Shadows", Float) = 1.0
		
        [ToggleOff] 
        SpecularHighlights("Specular Highlights", Float) = 1.0
        
        [ToggleOff] 
        EnvironmentReflections("Environment Reflections", Float) = 0.0
        
        RenderQueue("Render Queue", Float) = 2000
        
        [HideInInspector]
        [NoScaleOffset]
        unity_Lightmaps("unity_Lightmaps", 2DArray) = "" {}
        
        [HideInInspector]
        [NoScaleOffset]
        unity_LightmapsInd("unity_LightmapsInd", 2DArray) = "" {}
        
        [HideInInspector]
        [NoScaleOffset]
        unity_ShadowMasks("unity_ShadowMasks", 2DArray) = "" {}
    }

    SubShader
    {
        Tags
        {
            "RenderType" = "Opaque"

            "RenderPipeline" = "UniversalPipeline" 
            
            "IgnoreProjector" = "True" 
            
            "ShaderModel" = "4.5"
        }

        LOD 300

        Pass
        {
            Name "HairShadowMask"

            ZTest Less
            
            Tags
            {
                "LightMode"="HairShadowMask"
            }

            ZWrite Off

            Cull Back
 
            HLSLPROGRAM

            #pragma exclude_renderers gles gles3 glcore
            
            #pragma target 4.5

            #pragma multi_compile_instancing
            
            #pragma multi_compile_fog

            #pragma vertex Vertex
            
            #pragma fragment Fragment
            
            #include "../Include/ToonInput.hlsl"
            
            #include "../Include/ToonHairShadowMaskPass.hlsl"
            
            ENDHLSL
        }

        Pass
        {
            Name "Outline"

            ZTest Less

            Tags
            {
                "LightMode" = "Outline"
            }

            ZWrite On

            Cull Front
            
            Stencil
            {
                Ref [StencilRef]
                
                Comp [StencilComp]
                
                Pass [StencilOp]
                
                Fail [StencilOp]
            }

            HLSLPROGRAM
            
            #pragma exclude_renderers gles gles3 glcore
            
            #pragma target 4.5

            #pragma shader_feature_local_vertex _USESMOOTHNORMAL
            
            #pragma multi_compile_instancing
            
            #pragma multi_compile_fog

            #pragma vertex Vertex
            
            #pragma fragment Fragment

            #include "../Include/ToonFunction.hlsl"    
            
            #include "../Include/ToonInput.hlsl"
            
            #include "../Include/ToonOutlinePass.hlsl"            
            
            ENDHLSL
        }

        Pass
        {
            Name "ForwardLit"
            
            Tags 
            {
                "LightMode" = "UniversalForward"
            }
            
            Blend[SrcBlend][DstBlend]
            
            ZWrite On
            
            Cull[Cull]
            
            Stencil
            {
                Ref[StencilRef]

                Comp[StencilComp]
                
                Pass [StencilOp]
                
                Fail [StencilOp]    
            }

            HLSLPROGRAM
            
            #pragma exclude_renderers gles gles3 glcore
            
            #pragma target 4.5

            #pragma shader_feature_local _SDFSHADOWMAP
            
            #pragma shader_feature_local_fragment _INVERSECLIPMASK
            
            #pragma shader_feature_local_fragment _DIFFUSERAMPMAP
            
            #pragma shader_feature_local _NORMALMAP
            
            #pragma shader_feature_local_fragment _ALPHATEST_ON
            
            #pragma shader_feature_local_fragment _EMISSION
            
            #pragma shader_feature_local_fragment _OCCLUSIONMAP
            
            #pragma shader_feature_local_fragment _SPECULARHIGHLIGHTS_OFF
            
            #pragma shader_feature_local_fragment _ENVIRONMENTREFLECTIONS_OFF
            
            #pragma shader_feature_local _RECEIVE_SHADOWS_OFF
            
            #pragma shader_feature_local_fragment _RECEIVE_HAIRSHADOWMASK
            
            #pragma shader_feature_local_fragment _SPECULAR_SETUP
            
            #pragma shader_feature_local_fragment _MATCAP
            
            #pragma multi_compile _ _HAIRSPECULAR _HAIRSPECULARVIEWNORMAL
            
            #pragma multi_compile _ _MAIN_LIGHT_SHADOWS
            
            #pragma multi_compile _ _MAIN_LIGHT_SHADOWS_CASCADE
            
            #pragma multi_compile _ _ADDITIONAL_LIGHTS_VERTEX _ADDITIONAL_LIGHTS
            
            #pragma multi_compile _ _ADDITIONAL_LIGHT_SHADOWS
            
            #pragma multi_compile_fragment _ _SHADOWS_SOFT
            
            #pragma multi_compile_fragment _ _SCREEN_SPACE_OCCLUSION
            
            #pragma multi_compile _ LIGHTMAP_SHADOW_MIXING
            
            #pragma multi_compile _ SHADOWS_SHADOWMASK
            
            #pragma multi_compile_fragment _ _LIGHT_LAYERS
            
            #pragma multi_compile_fragment _ _LIGHT_COOKIES

            #pragma multi_compile_fragment _ _HAIRSHADOWMASK

            #pragma multi_compile _ DIRLIGHTMAP_COMBINED
            
            #pragma multi_compile _ LIGHTMAP_ON
            
            #pragma multi_compile_fog

            #pragma multi_compile_instancing

            #pragma vertex ToonForwardPassVertex

            #pragma fragment ToonForwardPassFragment

            #include "../Include/ToonFunction.hlsl"
            
            #include "../Include/ToonInput.hlsl"
            
            #include "../Include/ToonLighting.hlsl"
            
            #include "../Include/ToonForwardPass.hlsl"
            
            ENDHLSL
        }

        Pass
        {
            Name "ShadowCaster"

            Tags
            {
                "LightMode" = "ShadowCaster"
            }

            ZWrite On
            
            ZTest LEqual
            
            ColorMask 0
            
            Cull[Cull]

            HLSLPROGRAM

            #pragma exclude_renderers gles gles3 glcore
            
            #pragma target 4.5
            
            #pragma shader_feature_local_fragment _INVERSECLIPMASK
            
            #pragma shader_feature_local_fragment _ALPHATEST_ON

            #pragma multi_compile_instancing
            
            #pragma multi_compile _ DOTS_INSTANCING_ON

            #pragma vertex ShadowPassVertex
            
            #pragma fragment ShadowPassFragment

            #include "../Include/ToonInput.hlsl"
            
            #include "Packages/com.unity.render-pipelines.universal/Shaders/ShadowCasterPass.hlsl"
            
            ENDHLSL
        }

        Pass
        {
            Name "DepthOnly"
            
            Tags
            {
                "LightMode" = "DepthOnly"
            }

            ZWrite On
            
            ColorMask 0
            
            Cull[Cull]

            HLSLPROGRAM

            #pragma exclude_renderers gles gles3 glcore
            
            #pragma target 4.5

            #pragma shader_feature_local_fragment _INVERSECLIPMASK
            
            #pragma shader_feature_local_fragment _ALPHATEST_ON

            #pragma multi_compile_instancing
            
            #pragma multi_compile _ DOTS_INSTANCING_ON

            #pragma vertex DepthOnlyVertex
            
            #pragma fragment DepthOnlyFragment

            #include "../Include/ToonInput.hlsl"
            
            #include "Packages/com.unity.render-pipelines.universal/Shaders/DepthOnlyPass.hlsl"   
            
            ENDHLSL
        }

        Pass
        {
            Name "DepthNormals"

            Tags
            {
                "LightMode" = "DepthNormals"
            }

            ZWrite On
            
            Cull[Cull]

            HLSLPROGRAM

            #pragma exclude_renderers gles gles3 glcore
            
            #pragma target 4.5

            #pragma vertex DepthNormalsVertex
            
            #pragma fragment DepthNormalsFragment

            #pragma shader_feature_local _NORMALMAP
            
            #pragma shader_feature_local_fragment _ALPHATEST_ON
            
            #pragma shader_feature_local_fragment _INVERSECLIPMASK

            #pragma multi_compile_instancing
            
            #pragma multi_compile _ DOTS_INSTANCING_ON

            #include "../Include/ToonInput.hlsl"
            
            #include "Packages/com.unity.render-pipelines.universal/Shaders/DepthNormalsPass.hlsl"
            
            ENDHLSL
        }

        Pass
        {
            Name "Meta"

            Tags
            {
                "LightMode" = "Meta"
            }

            Cull Off

            HLSLPROGRAM

            #pragma exclude_renderers gles gles3 glcore
            
            #pragma target 4.5

            #pragma vertex ToonVertexMeta
            
            #pragma fragment ToonFragmentMeta

            #pragma shader_feature_local_fragment _EMISSION
            
            #pragma shader_feature_local_fragment _ALPHATEST_ON
            
            #pragma shader_feature_local_fragment _INVERSECLIPMASK
            
            #pragma shader_feature_local_fragment _SPECGLOSSMAP
            
            #pragma shader_feature_local_fragment _SPECULAR_SETUP

            #include "../Include/ToonFunction.hlsl"
            
            #include "../Include/ToonInput.hlsl"
            
            #include "../Include/ToonLighting.hlsl"
            
            #include "../Include/ToonMetaPass.hlsl"
            
            ENDHLSL
        }
    }

    SubShader
    {
        Tags
        {
            "RenderType" = "Opaque" 

            "RenderPipeline" = "UniversalPipeline" 
            
            "IgnoreProjector" = "True" 
            
            "ShaderModel" = "2.0"
        }
        
        LOD 300

        Pass
        {
            Name "HairShadowMask"

            ZTest Less
            
            Tags
            {
                "LightMode" = "HairShadowMask"
            }
            
            ZWrite Off
            
            Cull[Cull]
 
            HLSLPROGRAM
            
            #pragma only_renderers gles gles3 glcore
            
            #pragma target 2.0

            #pragma multi_compile_instancing
            
            #pragma multi_compile_fog

            #pragma vertex Vertex
            
            #pragma fragment Fragment
            
            #include "../Include/ToonInput.hlsl"
            
            #include "../Include/ToonHairShadowMaskPass.hlsl"
            
            ENDHLSL
        }

        Pass 
        {
            Name "Outline"

            ZTest Less
            
            Tags 
            {
                "LightMode" = "Outline"
            }

            ZWrite On

            Cull Front
            
            Stencil
            {
                Ref [StencilRef]
                
                Comp [StencilComp]
                
                Pass [StencilOp]
                
                Fail [StencilOp]
            }

            HLSLPROGRAM
            
            #pragma only_renderers gles gles3 glcore
            
            #pragma target 2.0

            #pragma shader_feature_local_vertex _USESMOOTHNORMAL
            
            #pragma multi_compile_instancing
            
            #pragma multi_compile_fog

            #pragma vertex Vertex
            
            #pragma fragment Fragment
            
            #include "../Include/ToonFunction.hlsl"
            
            #include "../Include/ToonInput.hlsl"
            
            #include "../Include/ToonOutlinePass.hlsl"            
            
            ENDHLSL
        }

        Pass
        {
            Name "ForwardLit"

            Tags
            {
                "LightMode" = "UniversalForward"
            }

            Blend[SrcBlend][DstBlend]
            
            ZWrite On
            
            Cull[Cull]
            
            Stencil
            {
                Ref[StencilRef]
                
                Comp[StencilComp]
                
                Pass [StencilOp]
                
                Fail [StencilOp]    
            }

            HLSLPROGRAM
            
            #pragma only_renderers gles gles3 glcore
            
            #pragma target 2.0

            #pragma shader_feature_local _SDFSHADOWMAP
            
            #pragma shader_feature_local_fragment _INVERSECLIPMASK
            
            #pragma shader_feature_local_fragment _DIFFUSERAMPMAP
            
            #pragma shader_feature_local _NORMALMAP
            
            #pragma shader_feature_local_fragment _ALPHATEST_ON
            
            #pragma shader_feature_local_fragment _EMISSION
            
            #pragma shader_feature_local_fragment _OCCLUSIONMAP
            
            #pragma shader_feature_local_fragment _SPECULARHIGHLIGHTS_OFF
            
            #pragma shader_feature_local_fragment _ENVIRONMENTREFLECTIONS_OFF
            
            #pragma shader_feature_local _RECEIVE_SHADOWS_OFF
            
            #pragma shader_feature_local_fragment _RECEIVE_HAIRSHADOWMASK
            
            #pragma shader_feature_local_fragment _SPECULAR_SETUP
            
            #pragma shader_feature_local_fragment _MATCAP
            
            #pragma multi_compile _ _HAIRSPECULAR _HAIRSPECULARVIEWNORMAL

            #pragma multi_compile _ _MAIN_LIGHT_SHADOWS
            
            #pragma multi_compile _ _MAIN_LIGHT_SHADOWS_CASCADE
            
            #pragma multi_compile _ _ADDITIONAL_LIGHTS_VERTEX _ADDITIONAL_LIGHTS
            
            #pragma multi_compile _ _ADDITIONAL_LIGHT_SHADOWS
            
            #pragma multi_compile_fragment _ _SHADOWS_SOFT
            
            #pragma multi_compile_fragment _ _SCREEN_SPACE_OCCLUSION
            
            #pragma multi_compile _ LIGHTMAP_SHADOW_MIXING
            
            #pragma multi_compile _ SHADOWS_SHADOWMASK
            
            #pragma multi_compile_fragment _ _LIGHT_LAYERS
            
            #pragma multi_compile_fragment _ _LIGHT_COOKIES

            #pragma multi_compile_fragment _ _HAIRSHADOWMASK

            #pragma multi_compile _ DIRLIGHTMAP_COMBINED
            
            #pragma multi_compile _ LIGHTMAP_ON
            
            #pragma multi_compile_fog

            #pragma multi_compile_instancing

            #pragma vertex ToonForwardPassVertex
            
            #pragma fragment ToonForwardPassFragment

            #include "../Include/ToonFunction.hlsl"
            
            #include "../Include/ToonInput.hlsl"
            
            #include "../Include/ToonLighting.hlsl"
            
            #include "../Include/ToonForwardPass.hlsl"
            
            ENDHLSL
        }

        Pass
        {
            Name "ShadowCaster"
            
            Tags
            {
                "LightMode" = "ShadowCaster"
            }

            ZWrite On
            
            ZTest LEqual
            
            ColorMask 0
            
            Cull[Cull]

            HLSLPROGRAM

            #pragma only_renderers gles gles3 glcore
            
            #pragma target 2.0

            #pragma shader_feature_local_fragment _ALPHATEST_ON
            
            #pragma shader_feature_local_fragment _INVERSECLIPMASK

            #pragma multi_compile_instancing
            
            #pragma multi_compile _ DOTS_INSTANCING_ON

            #pragma vertex ShadowPassVertex
            
            #pragma fragment ShadowPassFragment

            #include "../Include/ToonInput.hlsl"
            
            #include "Packages/com.unity.render-pipelines.universal/Shaders/ShadowCasterPass.hlsl"
            
            ENDHLSL
        }

        Pass
        {
            Name "DepthOnly"

            Tags
            {
                "LightMode" = "DepthOnly"
            }

            ZWrite On
            
            ColorMask 0
            
            Cull[Cull]

            HLSLPROGRAM

            #pragma only_renderers gles gles3 glcore
            
            #pragma target 2.0

            #pragma shader_feature_local_fragment _ALPHATEST_ON
            
            #pragma shader_feature_local_fragment _INVERSECLIPMASK

            #pragma multi_compile_instancing
            
            #pragma multi_compile _ DOTS_INSTANCING_ON

            #pragma vertex DepthOnlyVertex
            
            #pragma fragment DepthOnlyFragment

            #include "../Include/ToonInput.hlsl"
            
            #include "Packages/com.unity.render-pipelines.universal/Shaders/DepthOnlyPass.hlsl"   
            
            ENDHLSL
        }

        Pass
        {
            Name "DepthNormals"

            Tags
            {
                "LightMode" = "DepthNormals"
            }

            ZWrite On
            
            Cull[Cull]

            HLSLPROGRAM
            
            #pragma only_renderers gles gles3 glcore
            #pragma target 2.0

            #pragma vertex DepthNormalsVertex
            
            #pragma fragment DepthNormalsFragment

            #pragma shader_feature_local _NORMALMAP
            
            #pragma shader_feature_local_fragment _ALPHATEST_ON
            
            #pragma shader_feature_local_fragment _INVERSECLIPMASK

            #pragma multi_compile_instancing
            
            #pragma multi_compile _ DOTS_INSTANCING_ON

            #include "../Include/ToonInput.hlsl"
            
            #include "Packages/com.unity.render-pipelines.universal/Shaders/DepthNormalsPass.hlsl"
            
            ENDHLSL
        }

        Pass
        {
            Name "Meta"

            Tags
            {
                "LightMode" = "Meta"
            }

            Cull Off

            HLSLPROGRAM

            #pragma only_renderers gles gles3 glcore

            #pragma target 2.0

            #pragma vertex ToonVertexMeta
            
            #pragma fragment ToonFragmentMeta

            #pragma shader_feature_local_fragment _EMISSION
            
            #pragma shader_feature_local_fragment _ALPHATEST_ON
            
            #pragma shader_feature_local_fragment _INVERSECLIPMASK
            
            #pragma shader_feature_local_fragment _SPECGLOSSMAP
            
            #pragma shader_feature_local_fragment _SPECULAR_SETUP

            #include "../Include/ToonFunction.hlsl"
            
            #include "../Include/ToonInput.hlsl"
            
            #include "../Include/ToonLighting.hlsl"
            
            #include "../Include/ToonMetaPass.hlsl"            
            
            ENDHLSL
        }
    }

    CustomEditor "FurryTales.Toon.Editor.ToonShaderGUI"
    
    FallBack "Hidden/Universal Render Pipeline/FallbackError"
}