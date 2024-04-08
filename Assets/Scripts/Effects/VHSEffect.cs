using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;

[SerializeField]
public class VHSEffect : VolumeComponent, IPostProcessComponent
{
    [SerializeField]
    MaterialPropertyBlock MPropertyBlock;

    public MaterialPropertyBlock MaterialPropertyBlock => MPropertyBlock;

    public ClampedFloatParameter intensity = new ClampedFloatParameter(value: 0, min: 0, max: 1, overrideState: true); 
    
    public NoInterpColorParameter noiseColor = new NoInterpColorParameter(Color.white); 
    
    public ClampedFloatParameter ScanlinesHeight = new ClampedFloatParameter(value: 0, min: 0, max: 3, overrideState: true);
    
    public bool IsActive() => intensity.value > 0;

    public bool IsTileCompatible() => true;
}