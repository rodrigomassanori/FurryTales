#ifndef ToonOutlinePassIncluded
#define ToonOutlinePassIncluded

struct Attributes
{
    float4 PositionOS : Position;
    
    float3 NormalOS : Normal;
    
    #ifdef UseSmoothNormal
        float4 TangentOS : Tangent;
        
        float2 Texcoord7 : TexCoordD7;
    #endif
    
    UnityVertexInputInstanceId
};

struct Varyings
{
    float4 PositionCS : SvPosition;

    UnityVertexInputInstanceId
    
    UnityVertexOutputStereo
};

float4 TransformOutlineToHClipScreenSpace(float4 Position, float3 Normal, float OutlineWidth)
{
    float4 PositionCS = TransformObjectToHClip(Position.xyz);

    #ifdef UseSmoothNormal
        float3 ClipNormal = TransformWorldToHClipDir(Normal);

    #else
        float3 NormalWS = TransformObjectToWorldNormal(Normal);

        float3 ClipNormal = TransformWorldToHClipDir(NormalWS);

    #endif

    float2 ProjectedNormal = normalize(ClipNormal.xy);

    float4 NearUpperRight = mul(UnityCameraInvProjection, float4(1, 1, UnityNearClipValue, ProjectionParams.y));
    
    float Aspect = abs(NearUpperRight.y / NearUpperRight.x);
    
    ProjectedNormal.x *= Aspect;
    
    ProjectedNormal *= min(PositionCS.w, 3);
    
    PositionCS.xy += 0.01 * OutlineWidth * ProjectedNormal.xy;
    
    return PositionCS;
}

Varyings Vertex(Attributes Input)
{
    Varyings Output = (Varyings) 0;

    UnitySetupInstanceId(Input);

    UnityTransferInstanceId(Input, Output);
    
    UnityInitializeVertexOutputStereo(Output);

#ifdef UseSmoothNormal
    float3 NormalDir = TransformObjectToWorldNormal(Input.NormalOS);
    
    float3 TangentDir = TransformObjectToWorldNormal(Input.TangentOS.xyz);
    
    float3 BitangentDir = normalize(cross(NormalDir, TangentDir) * Input.TangentOS.w);
    
    float3x3 Ttbn = float3x3(TangentDir, BitangentDir, NormalDir);
    
    float3 BakeNormal = GetSmoothedWorldNormal(Input.TexCoord7, Ttbn);
    
    Output.PositionCS = TransformOutlineToHClipScreenSpace(Input.PositionOS, BakeNormal, OutlineWidth);

#else
    Output.PositionCS = TransformOutlineToHClipScreenSpace(Input.PositionOS, Input.NormalOS, OutlineWidth);

#endif
    return Output;
}

half4 Fragment(Varyings Input) : SvTarget
{
    UnitySetupInstanceId(Input);

    UnitySetupStereoEyeIndexPostVertex(Input);
    
    return OutlineColor;
}

#endif