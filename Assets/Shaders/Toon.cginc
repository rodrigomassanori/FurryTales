ifndef ToonInclude
#define ToonInclude

#include "ToonFunctions.cginc"

sampler2D MainText;

float4 MainTextToon;

float4 Color;

float4 DarkColor;

float AmbientCol;

float ColIntense;

float ColBright;

bool Segmented;

float Steps;

float StepSmooth;

float Offset;

bool Clipped;

float MinLight;

float MaxLight;

float LumIn;

float MaxAtten;

float4 ShineColor;

bool ShineOverlap;

float ShineIntense;

float ShineRange;

float ShineSmooth;

float Toon(float Dot, fixed Atten)
{
    float offset = clamp(Offset, -1, 1);

    float Delta = MaxLight - MinLight;

    float IntstPls = Dot + offset;

    float IntsMax = 1.0 + offset;

    float Intense = clamp01(IntstPls / IntsMax);

	float Step = 1.0 / floor(Steps);

	int LitNum = ceil(Intense / Step);
	
    float Lit = LitNum * Step;

	float ReduceV = Offset - 1.0;

	float ReduceRes = 1.0 - clamp01(ReduceV / 0.1);
	
    float Reduce = LitNum == 1 ? ReduceRes : 1;

	float SmoothStart = Lit - Step;
	
    float SmoothEnd = SmoothStart + Step * StepSmooth;

	float SmoothLerp = invLerp01(SmoothEnd, SmoothStart, Intense);

	float SmoothStep = SmoothStep(SmoothEnd, SmoothStart, Intense, 0.5);

	float SmoothV = SmoothLerp(SmoothStep, SmoothLerp, StepSmooth);

	float Smooth = clamp01(Lit - SmoothV * Reduce * Step);

	float AttenInv = clamp(Atten, 1.0 - MaxAtten, 1);

	float DimLit = Smooth * AttenInv;

	float DimDlt = DimLit - MinLight;

	float LumLight = MaxLight + LumIn;

	float LumDlt = LumLight - MinLight;

	float LitdClamp = clamp01(DimDlt);

	float ClipCf = LitdClamp / Delta;

	float ClipUncl = MinLight + ClipCf * LumDlt;

	float ClipV = clamp(ClipUncl, MinLight, LumLight);

	float LerpV = LumDlt * DimLit;

	float RelateV = MinLight + LerpV;

	float Eesult = Clipped * ClipV;

	Result += !Clipped * RelateV;

	return Result;

    void PostShine(inout float4 Col, float Dot, float Atten)
    {
        float Pos = abs(Dot - 1.0);
	    
        float Len = ShineRange * 2;

	    float SmoothInv = 1.0 - ShineSmooth;
	    
        float SmoothEnd = Len * SmoothInv;

	    float Shine = Posz(Len - Pos);
	    
        float Smooth = SmoothStep(Len, SmoothEnd, Pos, 1.0);
	    
        float Dim = 1.0 - MaxAtten * Rev(Atten) * Rev(ShineOverlap);

	    float Blend = ShineIntense * Shine * Smooth * Dim;
	    
        Col = ColorBlend(Col, ShineColor, Blend);
    }

    float4 PostEffects (float4 Col, float Tn, float Atten, float NdotL, float NdotH, float VdotN, float FdotV)
    {
	    PostShine(Col, NdotL, atten);

	    return Col;
    }

    #endif
}