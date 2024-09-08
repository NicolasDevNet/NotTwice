using System.Collections.Generic;
using UnityEngine.Rendering;
using UnityEngine;

namespace NotTwice.Proxies.Runtime.Interfaces
{
    /// <summary>
	/// Interface contract outlining methods to be defined for path operations
	/// </summary>
    public interface INTQualitySettings
    {
        // Current pixel light count.
        int PixelLightCount { get; set; }

        // Shadow projection used.
        ShadowQuality Shadows { get; set; }

        // Shadow projection type.
        ShadowProjection ShadowProjection { get; set; }

        // Number of shadow cascades.
        int ShadowCascades { get; set; }

        // Maximum shadow rendering distance.
        float ShadowDistance { get; set; }

        // Default resolution of shadows.
        ShadowResolution ShadowResolution { get; set; }

        // Shadowmask mode.
        ShadowmaskMode ShadowmaskMode { get; set; }

        // Offset shadow near plane.
        float ShadowNearPlaneOffset { get; set; }

        // Split point for 2 cascade shadow.
        float ShadowCascade2Split { get; set; }

        // Split point for 4 cascade shadow.
        Vector3 ShadowCascade4Split { get; set; }

        // Desired LOD bias.
        float LodBias { get; set; }

        // Anisotropic filtering mode.
        AnisotropicFiltering AnisotropicFiltering { get; set; }

        // Master texture limit.
        int MasterTextureLimit { get; set; }

        // Maximum LOD level.
        int MaximumLODLevel { get; set; }

        // Particle raycast budget.
        int ParticleRaycastBudget { get; set; }

        // Use soft particles.
        bool SoftParticles { get; set; }

        // Use soft vegetation.
        bool SoftVegetation { get; set; }

        // VSync count.
        int VSyncCount { get; set; }

        // Anti-aliasing level.
        int AntiAliasing { get; set; }

        // Async upload time slice.
        int AsyncUploadTimeSlice { get; set; }

        // Async upload buffer size.
        int AsyncUploadBufferSize { get; set; }

        // Use persistent buffer for async upload.
        bool AsyncUploadPersistentBuffer { get; set; }

        // Use real-time reflection probes.
        bool RealtimeReflectionProbes { get; set; }

        // Billboards face camera position.
        bool BillboardsFaceCameraPosition { get; set; }

        // Resolution scaling fixed DPI factor.
        float ResolutionScalingFixedDPIFactor { get; set; }

        // Render pipeline asset.
        RenderPipelineAsset RenderPipeline { get; set; }

        // Skin weights.
        SkinWeights SkinWeights { get; set; }

        // Streaming mipmaps active.
        bool StreamingMipmapsActive { get; set; }

        // Streaming mipmaps memory budget.
        float StreamingMipmapsMemoryBudget { get; set; }

        // Streaming mipmaps renderers per frame.
        int StreamingMipmapsRenderersPerFrame { get; set; }

        // Maximum level reduction for streaming mipmaps.
        int StreamingMipmapsMaxLevelReduction { get; set; }

        // Add all cameras for streaming mipmaps.
        bool StreamingMipmapsAddAllCameras { get; set; }

        // Maximum file I/O requests for streaming mipmaps.
        int StreamingMipmapsMaxFileIORequests { get; set; }

        // Maximum queued frames.
        int MaxQueuedFrames { get; set; }

        // Quality level names.
        string[] Names { get; }

        // Desired color space.
        ColorSpace DesiredColorSpace { get; }

        // Active color space.
        ColorSpace ActiveColorSpace { get; }

        // Methods

        // Increase quality level.
        void IncreaseLevel(bool applyExpensiveChanges = false);

        // Decrease quality level.
        void DecreaseLevel(bool applyExpensiveChanges = false);

        // Set quality level.
        void SetQualityLevel(int index, bool applyExpensiveChanges = true);

        // Set LOD settings.
        void SetLODSettings(float lodBias, int maximumLODLevel, bool setDirty = true);

        // Get render pipeline asset at a specific quality level.
        RenderPipelineAsset GetRenderPipelineAssetAt(int index);

        // Get current quality level.
        int GetQualityLevel();

        // Get current quality settings object.
        Object GetQualitySettings();
    }
}
