#ifndef ToonFaceHairMaskPassIncluded
#define ToonFaceHairMaskPassIncluded

struct Attributes
{
    float4 PositionOS : Position;

    UnityVertexInputInstanceId
};

struct Varyings
{
    float4 PositionCS : SvPosition;

    UnityVertexInputInstanceId

    UnityVertexOutputStereo
};

Varyings Vertex(Attributes Input)
{
    Varyings Output = (Varyings) 0;

    UnitySetupInstanceId(Input);

    UnityTransferInstanceId(Input, Output);

    UnityInitializeVertexOutputStereo(Output);

    Output.PositionCS = TransformObjectToHClip(Input.PositionOS.xyz);

    return Output;
}

half4 Fragment(Varyings Input) : SvTarget
{
    UnitySetupInstanceId(Input);

    UnitySetupStereoEyeIndexPostVertex(Input);

    half Depth = Input.PositionCS.z / Input.PositionCS.w;

    return half4(Depth, 0, 0, 0);
}

#endif