using NotTwice.Proxies.Runtime.Interfaces;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using Object = UnityEngine.Object;

namespace NotTwice.Proxies.Runtime
{
    /// <summary>
    /// Proxy acting as a flat pass for <see cref="QualitySettings"/> static methods.
    /// </summary>
    public class NTQualitySettingsProxy : INTQualitySettings
    {
        // Propriétés

        public int PixelLightCount
        {
            get
            {
                return QualitySettings.pixelLightCount;
            }
            set
            {
                QualitySettings.pixelLightCount = value;
            }
        }

        public ShadowQuality Shadows
        {
            get
            {
                return QualitySettings.shadows;
            }
            set
            {
                QualitySettings.shadows = value;
            }
        }

        public ShadowProjection ShadowProjection
        {
            get
            {
                return QualitySettings.shadowProjection;
            }
            set
            {
                QualitySettings.shadowProjection = value;
            }
        }

        public int ShadowCascades
        {
            get
            {
                return QualitySettings.shadowCascades;
            }
            set
            {
                QualitySettings.shadowCascades = value;
            }
        }

        public float ShadowDistance
        {
            get
            {
                return QualitySettings.shadowDistance;
            }
            set
            {
                QualitySettings.shadowDistance = value;
            }
        }

        public ShadowResolution ShadowResolution
        {
            get
            {
                return QualitySettings.shadowResolution;
            }
            set
            {
                QualitySettings.shadowResolution = value;
            }
        }

        public ShadowmaskMode ShadowmaskMode
        {
            get
            {
                return QualitySettings.shadowmaskMode;
            }
            set
            {
                QualitySettings.shadowmaskMode = value;
            }
        }

        public float ShadowNearPlaneOffset
        {
            get
            {
                return QualitySettings.shadowNearPlaneOffset;
            }
            set
            {
                QualitySettings.shadowNearPlaneOffset = value;
            }
        }

        public float ShadowCascade2Split
        {
            get
            {
                return QualitySettings.shadowCascade2Split;
            }
            set
            {
                QualitySettings.shadowCascade2Split = value;
            }
        }

        public Vector3 ShadowCascade4Split
        {
            get
            {
                return QualitySettings.shadowCascade4Split;
            }
            set
            {
                QualitySettings.shadowCascade4Split = value;
            }
        }

        public float LodBias
        {
            get
            {
                return QualitySettings.lodBias;
            }
            set
            {
                QualitySettings.lodBias = value;
            }
        }

        public AnisotropicFiltering AnisotropicFiltering
        {
            get
            {
                return QualitySettings.anisotropicFiltering;
            }
            set
            {
                QualitySettings.anisotropicFiltering = value;
            }
        }

        public int MasterTextureLimit
        {
            get
            {
                return QualitySettings.masterTextureLimit;
            }
            set
            {
                QualitySettings.masterTextureLimit = value;
            }
        }

        public int MaximumLODLevel
        {
            get
            {
                return QualitySettings.maximumLODLevel;
            }
            set
            {
                QualitySettings.maximumLODLevel = value;
            }
        }

        public int ParticleRaycastBudget
        {
            get
            {
                return QualitySettings.particleRaycastBudget;
            }
            set
            {
                QualitySettings.particleRaycastBudget = value;
            }
        }

        public bool SoftParticles
        {
            get
            {
                return QualitySettings.softParticles;
            }
            set
            {
                QualitySettings.softParticles = value;
            }
        }

        public bool SoftVegetation
        {
            get
            {
                return QualitySettings.softVegetation;
            }
            set
            {
                QualitySettings.softVegetation = value;
            }
        }

        public int VSyncCount
        {
            get
            {
                return QualitySettings.vSyncCount;
            }
            set
            {
                QualitySettings.vSyncCount = value;
            }
        }

        public int AntiAliasing
        {
            get
            {
                return QualitySettings.antiAliasing;
            }
            set
            {
                QualitySettings.antiAliasing = value;
            }
        }

        public int AsyncUploadTimeSlice
        {
            get
            {
                return QualitySettings.asyncUploadTimeSlice;
            }
            set
            {
                QualitySettings.asyncUploadTimeSlice = value;
            }
        }

        public int AsyncUploadBufferSize
        {
            get
            {
                return QualitySettings.asyncUploadBufferSize;
            }
            set
            {
                QualitySettings.asyncUploadBufferSize = value;
            }
        }

        public bool AsyncUploadPersistentBuffer
        {
            get
            {
                return QualitySettings.asyncUploadPersistentBuffer;
            }
            set
            {
                QualitySettings.asyncUploadPersistentBuffer = value;
            }
        }

        public bool RealtimeReflectionProbes
        {
            get
            {
                return QualitySettings.realtimeReflectionProbes;
            }
            set
            {
                QualitySettings.realtimeReflectionProbes = value;
            }
        }

        public bool BillboardsFaceCameraPosition
        {
            get
            {
                return QualitySettings.billboardsFaceCameraPosition;
            }
            set
            {
                QualitySettings.billboardsFaceCameraPosition = value;
            }
        }

        public float ResolutionScalingFixedDPIFactor
        {
            get
            {
                return QualitySettings.resolutionScalingFixedDPIFactor;
            }
            set
            {
                QualitySettings.resolutionScalingFixedDPIFactor = value;
            }
        }

        public RenderPipelineAsset RenderPipeline
        {
            get
            {
                return QualitySettings.renderPipeline;
            }
            set
            {
                QualitySettings.renderPipeline = value;
            }
        }

        public SkinWeights SkinWeights
        {
            get
            {
                return QualitySettings.skinWeights;
            }
            set
            {
                QualitySettings.skinWeights = value;
            }
        }

        public bool StreamingMipmapsActive
        {
            get
            {
                return QualitySettings.streamingMipmapsActive;
            }
            set
            {
                QualitySettings.streamingMipmapsActive = value;
            }
        }

        public float StreamingMipmapsMemoryBudget
        {
            get
            {
                return QualitySettings.streamingMipmapsMemoryBudget;
            }
            set
            {
                QualitySettings.streamingMipmapsMemoryBudget = value;
            }
        }

        public int StreamingMipmapsRenderersPerFrame
        {
            get
            {
                return QualitySettings.streamingMipmapsRenderersPerFrame;
            }
            set
            {
                QualitySettings.streamingMipmapsRenderersPerFrame = value;
            }
        }

        public int StreamingMipmapsMaxLevelReduction
        {
            get
            {
                return QualitySettings.streamingMipmapsMaxLevelReduction;
            }
            set
            {
                QualitySettings.streamingMipmapsMaxLevelReduction = value;
            }
        }

        public bool StreamingMipmapsAddAllCameras
        {
            get
            {
                return QualitySettings.streamingMipmapsAddAllCameras;
            }
            set
            {
                QualitySettings.streamingMipmapsAddAllCameras = value;
            }
        }

        public int StreamingMipmapsMaxFileIORequests
        {
            get
            {
                return QualitySettings.streamingMipmapsMaxFileIORequests;
            }
            set
            {
                QualitySettings.streamingMipmapsMaxFileIORequests = value;
            }
        }

        public int MaxQueuedFrames
        {
            get
            {
                return QualitySettings.maxQueuedFrames;
            }
            set
            {
                QualitySettings.maxQueuedFrames = value;
            }
        }

        public string[] Names
        {
            get
            {
                return QualitySettings.names;
            }
        }

        public ColorSpace DesiredColorSpace
        {
            get
            {
                return QualitySettings.desiredColorSpace;
            }
        }

        public ColorSpace ActiveColorSpace
        {
            get
            {
                return QualitySettings.activeColorSpace;
            }
        }

        // Méthodes

        public void IncreaseLevel(bool applyExpensiveChanges = false)
        {
            QualitySettings.IncreaseLevel(applyExpensiveChanges);
        }

        public void DecreaseLevel(bool applyExpensiveChanges = false)
        {
            QualitySettings.DecreaseLevel(applyExpensiveChanges);
        }

        public void SetQualityLevel(int index, bool applyExpensiveChanges = true)
        {
            QualitySettings.SetQualityLevel(index, applyExpensiveChanges);
        }

        public void SetLODSettings(float lodBias, int maximumLODLevel, bool setDirty = true)
        {
            QualitySettings.SetLODSettings(lodBias, maximumLODLevel, setDirty);
        }

        public RenderPipelineAsset GetRenderPipelineAssetAt(int index)
        {
            return QualitySettings.GetRenderPipelineAssetAt(index);
        }

        public int GetQualityLevel()
        {
            return QualitySettings.GetQualityLevel();
        }

        public Object GetQualitySettings()
        {
            return QualitySettings.GetQualitySettings();
        }
    }
}
