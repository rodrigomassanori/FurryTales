using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;

[System.Serializable]
public class VHSEffectPostProcessPass : ScriptableRenderPass
{
    RenderTargetIdentifier source;

    RenderTargetIdentifier destinationA;
    
	RenderTargetIdentifier destinationB;
    
	RenderTargetIdentifier latestDest;

    readonly int temporaryRTIdA = Shader.PropertyToID("_TempRT");
    
	readonly int temporaryRTIdB = Shader.PropertyToID("_TempRTB");

    public VHSEffectPostProcessPass()
    {
        renderPassEvent = RenderPassEvent.BeforeRenderingPostProcessing;
    }

    [System.Obsolete]
#pragma warning disable CS0809
    public override void OnCameraSetup(CommandBuffer cmd, ref RenderingData renderingData)
#pragma warning restore CS0809
    {
        RenderTextureDescriptor descriptor = renderingData.cameraData.cameraTargetDescriptor;

        descriptor.depthBufferBits = 0;

        var renderer = renderingData.cameraData.renderer;
        
		source = renderer.cameraColorTarget;

        cmd.GetTemporaryRT(temporaryRTIdA, descriptor, FilterMode.Bilinear);
        
		destinationA = new RenderTargetIdentifier(temporaryRTIdA);
        
		cmd.GetTemporaryRT(temporaryRTIdB, descriptor, FilterMode.Bilinear);
        
		destinationB = new RenderTargetIdentifier(temporaryRTIdB);
    }

    [System.Obsolete]
#pragma warning disable CS0809
    public override void Execute(ScriptableRenderContext context, ref RenderingData renderingData)
#pragma warning restore CS0809
    {
        var materials = VHSEffectMaterialPointer.instance;

        if (materials == null)
        {
            Debug.LogError("Custom Post Processing Materials instance is null");

            return;
        }

        CommandBuffer cmd = CommandBufferPool.Get("VHS Effect Post Processing");

        cmd.Clear();

        var stack = VolumeManager.instance.stack;

        void BlitTo(Material mat, int pass = 0)
        {
            var first = latestDest;

            var last = first == destinationA ? destinationB : destinationA;
            
			Blit(cmd, first, last, mat, pass);

            latestDest = last;
        }

        latestDest = source;

        var customEffect = stack.GetComponent<VHSEffect>();

        if (customEffect.IsActive())
        {
            var material = materials.VHSEffectMaterial;

            material.SetFloat(Shader.PropertyToID("_Intensity"), customEffect.intensity.value);

            material.SetColor(Shader.PropertyToID("StaticColor"), customEffect.noiseColor.value);
            
			material.SetFloat(Shader.PropertyToID("ScanLinesHeight"), customEffect.ScanlinesHeight.value);

            BlitTo(material);
        }

        Blit(cmd, latestDest, source);

        context.ExecuteCommandBuffer(cmd);

        CommandBufferPool.Release(cmd);
    }

    public override void OnCameraCleanup(CommandBuffer cmd)
    {
        cmd.ReleaseTemporaryRT(temporaryRTIdA);

        cmd.ReleaseTemporaryRT(temporaryRTIdB);
    }
}