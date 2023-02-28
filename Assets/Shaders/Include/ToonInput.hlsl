#ifndef ToonInputIncluded
#define ToonInputIncluded

#include "Packages/com.unity.render-pipelines.universal/ShaderLibrary/AmbientOcclusion.hlsl"
#include "Packages/com.unity.render-pipelines.core/ShaderLibrary/Packing.hlsl"
#include "Packages/com.unity.render-pipelines.core/ShaderLibrary/CommonMaterial.hlsl"
#include "Packages/com.unity.render-pipelines.universal/ShaderLibrary/Lighting.hlsl"

TEXTURE2D(BaseMap);            

SAMPLER(SamplerBaseMap);

TEXTURE2D(BumpMap);     

TEXTURE2D(EmissionMap);

CbufferStart(UnityPerMaterial)

float4 BaseMapST;

half4 BaseColor;

half3 Shadow1Color;

half Shadow1Step;

half Shadow1Feather;

half Shadow2Step;

half Shadow2Feather;

half3 Shadow2Color;

half DiffuseRampV;

half InShadowMapStrength;

half SSAOStrength;

half ReceiveHairShadowOffset;

half4 EmissionColor;

half OcclusionStrength;

half Cutoff;

half BumpScale;

half Smoothness;

half Metallic;

half4 SpecColor;

half SpecularStep;

half SpecularFeather;

half SpecularShift;

half SpecularShiftIntensity;

float4 SpecularShiftMapST;

half RimBlendShadow;

half RimBlendLdotV;

half3 RimColor;

half RimFlip;

half RimStep;

half RimFeather;

half OutlineWidth;

half4 OutlineColor;

half2 LdotFL;

float4 SDFShadowMapTexelSize;

half3 MatCapColor;

half MatCapUVScale;

CbufferEnd

TEXTURE2D(ClipMask);

TEXTURE2D(InShadowMap);

TEXTURE2D(OcclusionMap);   

TEXTURE2D(MetallicGlossMap);  

TEXTURE2D(SpecGlossMap); 

#ifdef SDFSHADOWMAP
    TEXTURE2D(SDFShadowMap);   
    
    SAMPLER(SamplerSDFShadowMap);
#endif

#ifdef HAIRSPECULAR
    TEXTURE2D(SpecularShiftMap);   
    
    SAMPLER(SamplerSpecularShiftMap);
#endif

#ifdef DIFFUSERAMPMAP
    TEXTURE2D(DiffuseRampMap);  
    
    SAMPLER(SamplerLinearClamp);
#endif

#if defined(ReceiveHairShadowMask) && defined(HairShadowMask)
    TEXTURE2D(HairShadowMask);   
    
    SAMPLER(SamplerHairShadowMask);
#endif

#ifdef SpecularSetup
#define SampleMetallicSpecular(uv) SampleTEXTURE2D(SpecGlossMap, SamplerBaseMap, uv)

#else
#define SampleMetallicSpecular(uv) SampleTEXTURE2D(MetallicGlossMap, SamplerBaseMap, uv)

#endif

#ifdef MATCAP
    TEXTURE2D(MatCapMap);   
    SAMPLER(SamplerMatCapMapLinearClamp);
#endif

struct SurfaceDataToon
{
    half3 albedo;

    half3 specular;
    
    half metallic;
    
    half smoothness;
    
    half3 normalTS;
    
    half3 emission;
    
    half  occlusion;
    
    half  alpha;
};

struct InputDataToon
{
    float3 positionWS;

    half3 normalWS;
    
    half3 viewDirectionWS;
    
    float4 shadowCoord;
    
    half fogCoord;
    
    half3 vertexLighting;
    
    half3 bakedGI;
    
    float2 normalizedScreenSpaceUV;
    
    half4 shadowMask;
    
    half3 tangentWS;
    
    half3 bitangentWS;
    
    float depth;
};

struct ToonData
{
    half specularShift;

#ifndef DIFFUSERAMPMAP
    half3 shadow1;

    half shadow1Step;
    
    half shadow1Feather;
    
    half3 shadow2;
    
    half shadow2Step;
    
    half shadow2Feather;
#endif

    half inShadow;

#ifdef _SDFSHADOWMAP
    half sdfShadowMask;

    half LdotF;
#endif

    half hairShadowMask;

    half ssao;
    
    half specularStep;
    
    half specularFeather;
    
    half3 rimColor;
    
    half rimFlip;
    
    half rimStep;
    
    half rimFeather;
    
    half rimBlendShadow;
    
    half rimBlendLdotV;
};

#ifdef MATCAP
    half3 SampleMatCap(half2 uv)
    {
        return SampleTEXTURE2D(MatCapMap, SamplerMatCapMapLinearClamp, (uv - MatCapUVScale) 
        / (1 - 2 * MatCapUVScale)).rgb * MatCapColor;
    }
#endif

half SampleAmbientOcclusionToon(float2 normalizedScreenSpaceUV, half occlusion)
{
    half ssao = 1.0;

    #if defined(ScreenSpaceOcclusion)
        ssao = SampleAmbientOcclusion(normalizedScreenSpaceUV);

        ssao = StepFeatherToon(ssao, Shadow1Step, Shadow1Feather);
    
        ssao = lerp(1, ssao, SSAOStrength);

    #endif
        ssao = min(ssao, occlusion);

        return ssao;
}

half SampleHairShadowMask(float2 normalizedScreenSpaceUV, float depth)
{
    #if defined(_RECEIVE_HAIRSHADOWMASK) && defined(_HAIRSHADOWMASK)
        half3 lightDirectionWS = GetMainLight().direction;
        
        half3 lightDirectionVS = TransformWorldToViewDir(lightDirectionWS,true);
        
        float2 samplerUV = normalizedScreenSpaceUV + lightDirectionVS.xy * min(depth, 0.01) * ReceiveHairShadowOffset;
        
        float hairDepth = SampleTEXTURE2D(HairShadowMask, SamplerHairShadowMask, SamplerUV);
        
        half hairMask = step(hairDepth, depth);
        
        return hairMask;

    #else
        return 1.0;
    #endif
}

half SampleSDFShadowMask(float2 uv)
{
    #ifdef SDFSHADOWMAP
        uv.x *= step(0, LdotFL.y) * 2 - 1;
        
        float mask = SampleTEXTURE2D(SDFShadowMap, SamplerSDFShadowMap, uv);
        
        return mask;
    
    #else
        return 1.0;
    #endif
}

#ifdef DIFFUSERAMPMAP
    half3 SampleRampMap(half H_Lambert)
    {
        return SampleTEXTURE2D(DiffuseRampMap, SamplerLinearClamp, half2(HLambert, DiffuseRampV)).xyz;
    }
#endif

half SampleClipMask(float2 uv)
{
    #ifdef AlphaTestOn
    #ifdef INVERSECLIPMASK
        return 1.0h - SampleTEXTURE2D(ClipMask, SamplerBaseMap, uv).r;
    
    #else
        return SampleTEXTURE2D(ClipMask, SamplerBaseMap, uv).r;
    #endif
    
    #else
        return 1.0;
    #endif
}

half Alpha(half albedoAlpha, half4 color, half cutoff)
{
    half alpha = color.a * albedoAlpha;
    
    #if defined(AlphaTestOn)
        clip(alpha - cutoff);
    #endif

    return alpha;
}

half4 SampleAlbedoAlpha(float2 uv, Texture2dParam(albedoAlphaMap, SamplerAlbedoAlphaMap))
{
    half4 color = SampleTEXTURE2D(albedoAlphaMap, SamplerAlbedoAlphaMap, uv);

    color.a *= SampleClipMask(uv);
    
    return color;
}

half3 SampleEmission(float2 uv, half3 emissionColor, TEXTURE2D_PARAM(emissionMap, sampler_BaseMap))
{
    #ifndef EMISSION
        return 0;
    
    #else
        return SAMPLE_TEXTURE2D(emissionMap, sampler_BaseMap, uv).rgb * emissionColor;
    #endif
}

half SampleInShadow(float2 uv)
{
    half inShadow = (1 - SAMPLE_TEXTURE2D(_InShadowMap,sampler_BaseMap,uv).r) * _InShadowMapStrength;
    return 1 - inShadow;
}

half SampleSpecularShift(float2 uv)
{
#ifdef _HAIRSPECULAR
    half specularShift = SAMPLE_TEXTURE2D(_SpecularShiftMap,sampler_SpecularShiftMap,uv*_SpecularShiftMap_ST.xy + _SpecularShiftMap_ST.zw).r*_SpecularShiftIntensity+_SpecularShift;
    return specularShift;
#else
    return 0.0;
#endif
}

half4 SampleMetallicSpecGloss(float2 uv, half smoothness)
{
    half4 specGloss = SAMPLE_METALLICSPECULAR(uv);
#if _SPECULAR_SETUP
    specGloss.rgb *= _SpecColor.rgb;
#else
    specGloss.rgb *= _Metallic.rrr;
#endif
    specGloss.a *= smoothness;
    return specGloss;
}

half SampleOcclusion(float2 uv)
{
#ifdef _OCCLUSIONMAP
// TODO: Controls things like these by exposing SHADER_QUALITY levels (low, medium, high)
#if defined(SHADER_API_GLES)
    return SAMPLE_TEXTURE2D(_OcclusionMap, sampler_BaseMap, uv).g;
#else
    half occ = SAMPLE_TEXTURE2D(_OcclusionMap, sampler_BaseMap, uv).g;
    return LerpWhiteTo(occ, _OcclusionStrength);
#endif
#else
    return 1.0;
#endif
}

inline void InitializeSurfaceDataToon(float2 uv,out SurfaceDataToon outSurfaceData)
{
    half4 albedoAlpha = SampleAlbedoAlpha(uv, TEXTURE2D_ARGS(_BaseMap, sampler_BaseMap));
    outSurfaceData.alpha = Alpha(albedoAlpha.a, _BaseColor, _Cutoff);
    half4 specGloss = SampleMetallicSpecGloss(uv, _Smoothness);
    outSurfaceData.albedo = albedoAlpha.rgb * _BaseColor.rgb;
#if _SPECULAR_SETUP
    outSurfaceData.metallic = 1.0h;
    outSurfaceData.specular = specGloss.rgb;
#else
    outSurfaceData.metallic = specGloss.r;
    outSurfaceData.specular = half3(0.0h, 0.0h, 0.0h);
#endif
    outSurfaceData.smoothness = specGloss.a;
    outSurfaceData.normalTS = SampleNormal(uv, TEXTURE2D_ARGS(_BumpMap, sampler_BaseMap), _BumpScale);
    outSurfaceData.occlusion = SampleOcclusion(uv);
    outSurfaceData.emission = SampleEmission(uv, _EmissionColor.rgb, TEXTURE2D_ARGS(_EmissionMap, sampler_BaseMap));
}

inline void InitializeToonData(float2 uv, float2 normalizedScreenSpaceUV,float3 albedo, half occlusion, float depth, out ToonData outToonData)
{
    outToonData.inShadow = SampleInShadow(uv);
#ifndef _DIFFUSERAMPMAP
    outToonData.shadow1 = albedo * _Shadow1Color;
    outToonData.shadow1Step = _Shadow1Step;
    outToonData.shadow1Feather = _Shadow1Feather;
    outToonData.shadow2 = albedo * _Shadow2Color;
    outToonData.shadow2Step = _Shadow2Step;
    outToonData.shadow2Feather = _Shadow2Feather;
#endif
    outToonData.ssao = SampleAmbientOcclusionToon(normalizedScreenSpaceUV, occlusion);
#ifdef _SDFSHADOWMAP
    outToonData.sdfShadowMask = SampleSDFShadowMask(uv);
    outToonData.LdotF = saturate(_LdotFL.x);
#endif
    outToonData.hairShadowMask = SampleHairShadowMask(normalizedScreenSpaceUV, depth);
    outToonData.specularStep = _SpecularStep;
    outToonData.specularFeather = _SpecularFeather;
    outToonData.specularShift = SampleSpecularShift(uv);
    
    outToonData.rimColor = _RimColor;
    outToonData.rimStep = _RimStep;
    outToonData.rimFeather = _RimFeather;
    outToonData.rimBlendShadow = _RimBlendShadow;
    outToonData.rimFlip = _RimFlip;
    outToonData.rimBlendLdotV = _RimBlendLdotV;
}

#endif