#ifndef ToonLightningIncluded
#define ToonLightningIncluded

#include "Packages/com.unity.render-pipelines.core/ShaderLibrary/Color.hlsl"
#include "Packages/com.unity.render-pipelines.universal/ShaderLibrary/Lighting.hlsl"

struct BrdfDataToon
{
    half3 Diffuse;

    half3 Specular;
    
    half PerceptualRoughness;
    
    half Roughness;
    
    half Roughness2;
    
    half GrazingTerm;
    
    half NormalizationTerm;
    
    half Roughness2MinusOne;

    #if defined HairSpecular || defined HairSpecularViewNormal
        half SpecularExponent;
    #endif
};

inline void InitializeBrdfDataToon(SurfaceDataToon SurfaceData, out BrdfDataToon OutBrdfData)
{
    #ifdef SpecularSetup
        half Reflectivity = ReflectivitySpecular(SurfaceData.Specular);
        
        half OneMinusReflectivity = 1.0h - Reflectivity;

        OutBrdfData.Diffuse = SurfaceData.albedo;

        OutBrdfData.Specular = SurfaceData.Specular;

    #else
        half OneMinusReflectivity = OneMinusReflectivityMetallic(SurfaceData.metallic);
        
        half Reflectivity = 1.0 - OneMinusReflectivity;

        OutBrdfData.Diffuse = SurfaceData.albedo;
        
        OutBrdfData.Specular = lerp(kDieletricSpec.rgb, SurfaceData.albedo, SurfaceData.metallic);
    #endif
    
    OutBrdfData.GrazingTerm = saturate(surfaceData.smoothness + reflectivity);
    
    OutBrdfData.PerceptualRoughness = PerceptualSmoothnessToPerceptualRoughness(SurfaceData.smoothness);
    
    OutBrdfData.Roughness = max(PerceptualRoughnessToRoughness(OutBrdfData.PerceptualRoughness), HalfMinSqrt);
    
    OutBrdfData.Roughness2 = max(OutBrdfData.Roughness * OutBrdfData.Roughness, HalfMin);

    #if defined HairSpecular || defined HairSpecularViewNormal
        OutBrdfData.SpecularExponent = RoughnessToBlinnPhongSpecularExponent(OutBrdfData.Roughness);
    #endif

    OutBrdfData.NormalizationTerm = OutBrdfData.Roughness * 4.0h + 2.0h;
        
    OutBrdfData.Roughness2MinusOne = OutBrdfData.Roughness2 - 1.0h;
}

#ifdef HairSpecular
    half DirectSpecularHairToon(half sSpecularExponent, half SpecularShift, half3 NormalWS, 
    half3 LightDirectionWS, half3 ViewDirectionWS, half3 BitangentWS,half SpecularStep, half SpecularFeather)
    {
        half3 T = ShiftTangent(BitangentWS, NormalWS, SpecularShift);

        half LdotV = dot(LightDirectionWS, ViewDirectionWS);
        
        float InvLenLV = rsqrt(max(2.0 * LdotV + 2.0, FltEps));
        
        half3 H = (LightDirectionWS+viewDirectionWS) * InvLenLV;
        
        half Spec = DKajiyaKay(T, H, SpecularExponent);

        half NormalizeSpec = Spec * rcp(SpecularExponent + 2) * 2 * PI;
        
        Spec *= StepFeatherToon(NormalizeSpec, SpecularStep, SpecularFeather);

        return Spec;
    }

#elif defined HairSpecularViewNormal
    half DirectSpecularHairViewNormalToon(half SpecularExponent, half3 NormalWS, 
    half3 ViewDirectionWS, half SpecularStep, half SpecularFeather)
    {
        half NdotV = saturate(dot(normalize(NormalWS.xz), normalize(ViewDirectionWS.xz)));

        half Spec = pow(NdotV, SpecularExponent);

        return StepFeatherToon(Spec, SpecularStep, SpecularFeather);
    }

#else
    half DirectSpecularToon(BrdfDataToon BrdfData, half3 NormalWS, 
    half3 LightDirectionWS, half3 ViewDirectionWS, half Step, half Feather)
    {
        float3 HalfDir = SafeNormalize(float3(LightDirectionWS) + float3(ViewDirectionWS));

        float NoH = saturate(dot(NormalWS, HalfDir));
        
        half LoH = saturate(dot(LightDirectionWS, HalfDir));
        
        half LoH2 = LoH * LoH;
        
        float D = NoH * NoH * BrdfData.Roughness2MinusOne + 1.00001f;
        
        half D2 = half(D * D);
    
        half SpecularTerm = BrdfData.Roughness2 / (D2 * max(0.1h, LoH2) * brdfData.normalizationTerm);
        
        half normalizeSpec = BrdfData.Roughness2 * BrdfData.Roughness2 * rcp(D2);
    
        SpecularTerm *= StepFeatherToon(NormalizeSpec, Step, Feather);
        
        return SpecularTerm;
    }
#endif  

half3 SpecularBrdfToon(BrdfDataToon BrdfData, half3 NormalWS, half3 LightDirectionWS, half3 ViewDirectionWS, 
half3 BitangentWS, half SpecularShift, half SpecularStep, half SpecularFeather)
{
    #ifndef SpecularHighlightsOff
        #ifdef HairSpecular
            half SpecularTerm = DirectSpecularHairToon(BrdfData.SpecularExponent, SpecularShift, NormalWS, 
            LightDirectionWS, ViewDirectionWS, BitangentWS, SpecularStep, SpecularFeather);
    
        #elif defined HairSpecularViewNormal
            half SpecularTerm = DirectSpecularHairViewNormalToon(BrdfData.SpecularExponent, 
            NormalWS, ViewDirectionWS, SpecularStep, SpecularFeather);
    
        #else
            half SpecularTerm = DirectSpecularToon(BrdfData, NormalWS, 
            LightDirectionWS, ViewDirectionWS, SpecularStep, SpecularFeather);
        #endif

        SpecularTerm = SpecularTerm - HALF_MIN;

        SpecularTerm = clamp(SpecularTerm, 0.0, 100.0);
    
        half3 SpecularColor = SpecularTerm * BrdfData.Specular;
    
        return SpecularColor;
    
        #else
            return 0;
    #endif
}

half3 GlossyEnvironmentToon(half3 ReflectVector, half PerceptualRoughness, half Occlusion)
{
    #if !defined(EnvironmentReflectionsOff)
        half Mip = PerceptualRoughnessToMipmapLevel(PerceptualRoughness);
        
        half4 EncodedIrradiance = SAMPLE_TEXTURECUBE_LOD(UnitySpecCube0, SamplerUnitySpecCube0, ReflectVector, Mip);
    
    #if !defined(UnityUseNativeHdr)
        half3 Irradiance = DecodeHDREnvironment(EncodedIrradiance, UnitySpecCube0Hdr);
    
    #else
        half3 Irradiance = EncodedIrradiance.rbg;
    #endif

    return Irradiance * Occlusion;
    
    #else
        return 0;
    #endif
}

half3 GlobalIlluminationToon(BrdfDataToon BrdfData, half3 BakedGi, 
half Occlusion, half3 NormalWS, half3 ViewDirectionWS)
{
    half3 ReflectVector = reflect(-ViewDirectionWS, NormalWS);

    half FresnelTerm = Pow4(1.0 - saturate(dot(NormalWS, ViewDirectionWS)));
    
    half3 IndirectDiffuse = BakedGi * Occlusion * BrdfData.Diffuse;
    
    half3 Reflection = GlossyEnvironmentToon(ReflectVector, BrdfData.PerceptualRoughness, Occlusion);
    
    float SurfaceReduction = 1.0 / (BrdfData.Roughness2 + 1.0);
    
    half3 IndirectSpecular = SurfaceReduction * Reflection * lerp(BrdfData.Specular, BrdfData.GrazingTerm, FresnelTerm);
    
    return IndirectDiffuse + IndirectSpecular;
}

half HairShadowMaskAtten(half HairShadowMask, half HLambert)
{
    half HairAtten = lerp(1, HairShadowMask, HLambert);

    return HairAtten;
}

#ifdef SdfShadowMap
    half SdfShadowRadiance(half SdfShadowMask, half2 LdotF, half3 LightDirectionWS, 
    half LightAttenuation, half InShadow, half HairShadowMask, half ShadowStep, half ShadowFeather)
    {    
        half Radiance = 1 - saturate( (1 - SdfShadowMask - LdotF - (ShadowStep * 2 - 1)) / ShadowFeather + 1);

        LightAttenuation = lerp(StepAntiAliasing(LightAttenuation, 0.5), LightAttenuation, ShadowFeather);
    
        LightAttenuation = saturate(LightAttenuation * InShadow);
    
        Radiance *= LightAttenuation * HairShadowMaskAtten(HairShadowMask, Radiance);
    
        return Radiance;
    }

#else
    half3 DoubleShadowToon(half3 Shadow1, half3 Shadow2, half3 BaseColor, half2 Radiance)
    {
        half3 FinalColor = lerp(lerp(Shadow2, Shadow1, Radiance.y), BaseColor, Radiance.x);
        
        return FinalColor;
    }

#ifndef DiffuseRampMap
    half2 RadianceToon(half3 NormalWS, half3 LightDirectionWS, half LightAttenuation, 
    half InShadow, half hHairShadowMask, half Shadow1Step, half Shadow1Feather, half Shadow2Step, half Shadow2Feather)
    {
        half2 Radiance;
        LightAttenuation = lerp(StepAntiAliasing(LightAttenuation, 0.5), LightAttenuation, Shadow1Feather);

        LightAttenuation = saturate(LightAttenuation * InShadow);
        
        half HLambert = 0.5 * dot(NormalWS, LightDirectionWS) + 0.5;

        Radiance.x = StepFeatherToon(HLambert, Shadow1Step, Shadow1Feather) 
        * LightAttenuation * HairShadowMaskAtten(HairShadowMask, HLambert);
        
        Radiance.y = StepFeatherToon(HLambert, Shadow2Step, Shadow2Feather);
        
        return Radiance;
    }

#else
    half3 RampRadianceToon(half3 NormalWS, half3 LightDirectionWS, 
    half LightAttenuation, half InShadow, half HairShadowMask)
    {
        half3 Radiance;
        
        LightAttenuation = StepAntiAliasing(LightAttenuation,0.5);
        
        LightAttenuation = saturate(LightAttenuation * InShadow);
        
        half HLambert = 0.5 * dot(NormalWS, LightDirectionWS) + 0.5;
        
        Radiance.xyz =  SampleRampMap(HLambert) * LightAttenuation * HairShadowMaskAtten(HairShadowMask, HLambert);
        
        return Radiance;
    }
#endif

#endif

float3 RimLight(half3 RimColor, half3 NormalWS, half3 ViewDirectionWS, 
half3 LightDirectionWS, half RimStep, half RimFeather, half RimBlendShadow, 
half RimBlendLdotV, half RimFlip, half Radiance)
{
    half LdotV = dot(-LightDirectionWS, ViewDirectionWS) * 0.5 + 0.5;

    half Fresnel = (1.0 - saturate(dot(NormalWS, ViewDirectionWS)));
    
    Fresnel = StepFeatherToon(Fresnel, RimStep, RimFeather);
    
    Fresnel = lerp(Fresnel, Fresnel * LdotV, RimBlendLdotV);
    
    half3 Color = RimColor * Fresnel;
    
    Radiance = lerp(Radiance, 1 - Radiance, RimFlip);
    
    Color = lerp(Color, Color * Radiance, RimBlendShadow);

    return Color;
}

half3 MatCapLight(half3 NormalWS, half3 ViewDirection, half Radiance)
{
    #ifdef MatCap
        half3 ViewNormal = TransformWorldToViewDir(NormalWS);

        half2 ViewNormalAsMatCapUV = ViewNormal * 0.5 + 0.5;
        
        half3 Color = SampleMatCap(ViewNormalAsMatCapUV);
    
        return Color * Radiance;

    #else
        return 0;
    #endif
}

half3 LightingToon(BrdfDataToon BrdfData, SurfaceDataToon SurfaceData, InputDataToon InputData, 
ToonData ToonDt, Light L, half IsMainLight)
{
    half LightAttenuation = L.DistanceAttenuation * L.ShadowAttenuation;

    half3 Color = half3(0.0h, 0.0h, 0.0h);

    #ifdef SdfShadowMap
        half Radiance = SDFShadowRadiance(ToonDt.SdfShadowMask, 
        ToonDt.LdotF, L.Direction, LightAttenuation, ToonDt.InShadow, ToonDt.HairShadowMask, 
        ToonDt.Shadow1Step, ToonDt.Shadow1Feather);
        
        half3 SpecularColor = SpecularBDRFToon(BrdfData, InputData.NormalWS, L.Direction, 
        InputData.ViewDirectionWS, InputData.BitangentWS, ToonDt.SpecularShift, 
        ToonDt.SpecularStep, ToonDt.SpecularFeather) * Radiance;
        
        half3 DiffuseColor = lerp(ToonDt.Shadow1, BrdfData.Diffuse, Radiance);
        
        Color = DiffuseColor + SpecularColor;

    #else
        #ifdef DiffuseRampMap
            half3 Radiance = RampRadianceToon(InputData.NormalWS, L.Direction, 
            LightAttenuation, ToonDt.InShadow, ToonDt.HairShadowMask);
        
            half3 SpecularColor = SpecularBDRFToon(BrdfData, InputData.NormalWS, L.Direction, 
            InputData.ViewDirectionWS, InputData.BitangentWS, ToonDt.SpecularShift, 
            ToonDt.SpecularStep, ToonDt.SpecularFeather) * Radiance;
        
            half3 DiffuseColor = Radiance.xyz * BrdfData.Diffuse;
        
            Color = SpecularColor + DiffuseColor;

    #else
        half2 Radiance = RadianceToon(InputData.NormalWS, L.Direction, 
        LightAttenuation, ToonDt.InShadow, ToonDt.HairShadowMask, ToonDt.Shadow1Step, ToonDt.Shadow1Feather, 
        ToonDt.Shadow2Step, ToonDt.Shadow2Feather);
    
        half3 SpecularColor = SpecularBDRFToon(BrdfData, InputData.NormalWS, L.Direction, InputData.ViewDirectionWS, 
        InputData.BitangentWS, ToonDt.SpecularShift, ToonDt.SpecularStep, ToonDt.SpecularFeather) * Radiance.x;
    
        half3 DiffuseColor = DoubleShadowToon(ToonDt.Shadow1, ToonDt.Shadow2, BrdfData.Diffuse, Radiance);
    
        Color +=  specularColor + diffuseColor;
    #endif

    #endif
        Color += IsMainLight * RimLight(ToonDt.RimColor, InputData.NormalWS, InputData.ViewDirectionWS, 
        L.direction, ToonDt.RimStep, ToonDt.RimFeather, ToonDt.RimBlendShadow, ToonDt.RimBlendLdotV, 
        ToonDt.RimFlip, Radiance.x);
        
        Color += IsMainLight * MatCapLight(InputData.NormalWS, InputData.ViewDirectionWS, Radiance.x);
        
        return Color * L.Color;
}

half4 FragmentLitToon(InputDataToon InputData, SurfaceDataToon SurfaceData, ToonData ToonDt)
{
    BrdfDataToon BrdfData;
    
    InitializeBRDFDataToon(SurfaceData, BrdfData);

    #if defined(ShadowsShadowMask) && defined(LightMapOn)
        half4 ShadowMask = InputData.ShadowMask;
    
    #elif !defined (LightMapOn)
        half4 ShadowMask = UnityProbesOcclusion;
    
    #else
        half4 ShadowMask = half4(1, 1, 1, 1);
    #endif

    uint MeshRenderingLayers = GetMeshRenderingLightLayer();
    
    Light MainLight = GetMainLight(InputData.ShadowCoord, InputData.PositionWS, ShadowMask);
    
    MixRealtimeAndBakedGI(MainLight, InputData.NormalWS, InputData.BakedGi);
    
    half3 Color = GlobalIlluminationToon(BrdfData, InputData.BakedGi, ToonDt.Ssao, 
    InputData.NormalWS, InputData.ViewDirectionWS);
    
    if (IsMatchingLightLayer(MainLight.LayerMask, MeshRenderingLayers))
    {
        Color += LightingToon(BrdfData, SurfaceData, InputData, ToonDt, MainLight, 1);
    }

    #ifdef AdditionalLights
        uint PixelLightCount = GetAdditionalLightsCount();

        for (uint LightIndex = 0u; LightIndex < PixelLightCount; ++LightIndex)
        {
            Light L = GetAdditionalLight(LightIndex, InputData.PositionWS, ShadowMask);

            if(IsMatchingLightLayer(L.LayerMask, MeshRenderingLayers))
            {
                Color += LightingToon(BrdfData, SurfaceData, InputData, ToonDt, L, 0);
            }
        }
    #endif

    #ifdef AdditionalLightsVertex
        Color += InputData.VertexLighting * BrdfData.Diffuse;
    #endif

    Color += SurfaceData.Emission;

    return half4(Color, SurfaceData.Alpha);
}

#endif