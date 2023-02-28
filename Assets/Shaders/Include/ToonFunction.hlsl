#ifndef ToonFunctionIncluded
#define ToonFunctionIncluded

#include "Packages/com.unity.render-pipelines.universal/ShaderLibrary/Core.hlsl"

float3 GetSmoothedWorldNormal(float2 uv7, float3x3 Ttbn)
{
    float3 normal = float3(uv7, 0);

    normal.z = sqrt(1.0 - saturate(dot(normal.xy, normal.xy)));
    
    return mul(normal, Ttbn);
}

float RoughnessToBlinnPhongSpecularExponent(float roughness)
{
    return clamp(2 * rcp(roughness * roughness) - 2, FltEps, rcp(FltEps));
}

half StepAntiAliasing(half x, half y)
{
    half v = x - y;

    return saturate(v / (fwidth(v) + HalfMin));
}

inline half StepFeatherToon(half value, half step, half feather)
{
    return saturate((value - step+feather) / feather);
}

#endif