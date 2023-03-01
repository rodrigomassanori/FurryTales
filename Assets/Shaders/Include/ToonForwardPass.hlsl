#ifndef ToonForwardPassIncluded
#define ToonForwardPassIncluded

struct Attributes
{
    float4 PositionOS : Position;

    float3 NormalOS : Normal;
    
    float4 TangentOS : Tangent;
    
    float2 Texcoord : TexCoord0;
    
    float2 LightmapUV : TexCoord1;
    
    UnityVertexInputInstanceIdD
};

struct Varyings
{
	float2 Uv : TexCoord0;

    DeclareLightmapOrSh(LightmapUV, VertexSH, 1);

    #if defined(RequiresWorldSpacePosInterpolator)
        float3 PositionWS : TexCoord2;
    #endif

    #if defined(NormalMap) || defined(HairSpecular)
        float4 NormalWS : TexCoord3;

        float4 TangentWS : TexCoord4;
        
        float4 BitangentWS : TexCoord5;
    
    #else
        float3 NormalWS : TexCoord3;
        
        float3 ViewDirWS : TexCoord4;
    #endif

    half4 FogFactorAndVertexLight : TexCoord6;

    #if defined(RequiresVertexShadowCoordInterpolator)
        float4 ShadowCoord : TexCoord7;
    #endif

    float4 PositionCS : SvPosition;

    UnityVertexInputInstanceIdD

    UnityVertexOutputStereo
};