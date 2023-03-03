#ifndef UniversalToonMetaPassIncluded
#define UniversalToonMetaPassIncluded

#include "Packages/com.unity.render-pipelines.universal/ShaderLibrary/MetaInput.hlsl"

struct Attributes
{
    float4 PositionOS : Position;

    float3 NormalOS : Normal;
    
    float2 Uv0 : TexCoord0;
    
    float2 Uv1 : TexCoord1;
    
    float2 Uv2 : TexCoord2;
    
    UnityVertexInputInstanceId
};

struct Varyings
{
    float4 PositionCS : SvPosition;

    float2 Uv : TexCoord0;
};

Varyings ToonVertexMeta(Attributes Input)
{
    Varyings Output = (Varyings) 0;

    Output.positionCS = UnityMetaVertexPosition(Input.PositionOS.xyz, Input.Uv1, Input.Uv2);
    
    Output.Uv = TransformTex(Input.uv0, BaseMap);
    
    return Output;
}

half4 ToonFragmentMeta(Varyings Input) : SV_Target
{
    SurfaceDataToon SurfaceData;

    InitializeSurfaceDataToon(Input.uv, SurfaceData);

    BrdfDataToon BrdfData;

    InitializeBRDFDataToon(SurfaceData, BrdfData);

    MetaInput MetaIpt;

    MetaIpt.Albedo = BrdfData.Diffuse + BrdfData.Specular * BrdfData.Roughness * 0.5;
    
    MetaIpt.Emission = SurfaceData.Emission;
    
    return UnityMetaFragment(metaInput);
}

#endif