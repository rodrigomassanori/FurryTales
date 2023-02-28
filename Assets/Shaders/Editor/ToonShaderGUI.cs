using System;
using UnityEngine;
using UnityEditor;

namespace FurryTales.Toon.Editor
{
    public class ToonShaderGUI : ShaderGUI
    {
        #region Structs

        struct Styles
        {
            public static readonly GUIContent WorkflowMode = new GUIContent("Workflow Mode");
            
            public static readonly GUIContent SurfaceOptionsFold = new GUIContent("Surface Options");
            
            public static readonly GUIContent OutlineFold = new GUIContent("Outline");
            
            public static readonly GUIContent AdvancedOptionsFold = new GUIContent("Advanced Options");
            
            public static readonly GUIContent BaseFold = new GUIContent("Base");
            
            public static readonly GUIContent ShadowFold = new GUIContent("Shadow");
            
            public static readonly GUIContent SpecularFold = new GUIContent("Specular");
            
            public static readonly GUIContent RimFold = new GUIContent("Rim");
            
            public static readonly GUIContent SurfaceType = new GUIContent("SurfaceType");
            
            public static readonly GUIContent RenderFace = new GUIContent("Render Face");
            
            public static readonly GUIContent AlphaClipping = new GUIContent("Alpha Clipping");
            
            public static readonly GUIContent InverseClipMask = new GUIContent("Inverse ClipMask");
            
            public static readonly GUIContent AlphaClippingMask = new GUIContent("ClipMask Threshold");
            
            public static readonly GUIContent EnvironmentReflections = new GUIContent("Environment Reflections");
            
            public static readonly GUIContent RenderQueue = new GUIContent("RenderQueue");
            
            public static readonly GUIContent EnableStencil = new GUIContent("Stencil");
            
            public static readonly GUIContent StencilType = new GUIContent("Stencil Type");
            
            public static readonly GUIContent StencilRef = new GUIContent("Stencil Ref");
            
            public static readonly GUIContent Color = new GUIContent("Color");
            
            public static readonly GUIContent Normal = new GUIContent("Normal");
            
            public static readonly GUIContent Occlusion = new GUIContent("Occlusion");
            
            public static readonly GUIContent Emission = new GUIContent("Emission");
            
            public static readonly GUIContent ShadowType = new GUIContent("ShadowType");
            
            public static readonly GUIContent DiffuseRampMap = new GUIContent("DiffuseRampMap VOffset");
            
            public static readonly GUIContent Shadow1Step = new GUIContent("Shadow1Step");
            
            public static readonly GUIContent Shadow1Feather = new GUIContent("Shadow1Feather");
            
            public static readonly GUIContent Shadow2Step = new GUIContent("Shadow2Step");
            
            public static readonly GUIContent Shadow2Feather = new GUIContent("Shadow2Feather");
            
            public static readonly GUIContent InShadowMap = new GUIContent("InShadowMap");
            
            public static readonly GUIContent ReceiveShadows = new GUIContent("Receive Shadows");
            
            public static readonly GUIContent CastHairShadowMask = new GUIContent("CastHairShadowMask(Front Hair ShadowMask)");
            
            public static readonly GUIContent ReceiveHairShadowMask = new GUIContent("ReceiveHairShadowMask(Front Hair ShadowMask)");
            
            public static readonly GUIContent ReceiveHairShadowOffset = new GUIContent("ReceiveHairShadowOffset(Screen Space UV Offset)");
            
            public static readonly GUIContent SSAOStrength = new GUIContent("SSAO");
            
            public static readonly GUIContent SDFShadowMap = new GUIContent("SDFShadowMap(Face)");
            
            public static readonly GUIContent SpecularStep = new GUIContent("SpecularStep");
            
            public static readonly GUIContent SpecularFeather = new GUIContent("SpecularFeather");
            
            public static readonly GUIContent Specular = new GUIContent("Specular");
            
            public static readonly GUIContent Metallic = new GUIContent("Metallic");

            public static readonly GUIContent Smoothness = new GUIContent("Smoothness");
            
            public static readonly GUIContent SpecularType = new GUIContent("SpecularType");
            
            public static readonly GUIContent SpecularShiftMap = new GUIContent("HairShiftMap");
            
            public static readonly GUIContent SpecularShift = new GUIContent("SpecularShift");
            
            public static readonly GUIContent SpecularHighlights = new GUIContent("Enable Specular Highlights");

            public static readonly GUIContent EnableOutline = new GUIContent("EnableOutline");
            
            public static readonly GUIContent UseSmoothNormal = new GUIContent("UseSmoothNormal");
            
            public static readonly GUIContent OutlineWidth = new GUIContent("OutlineWidth");

            public static readonly GUIContent RimFlip = new GUIContent("RimFlip");

            public static readonly GUIContent RimBlendShadow = new GUIContent("RimBlendShadow");
            
            public static readonly GUIContent RimBlendLdotV = new GUIContent("RimBlendLdotV(BackLight)");
            
            public static readonly GUIContent RimColor = new GUIContent("RimColor");
            
            public static readonly GUIContent RimPow = new GUIContent("RimPow");
            
            public static readonly GUIContent RimStep = new GUIContent("RimStep");

            public static readonly GUIContent RimFeather = new GUIContent("RimFeather");
            
            public static readonly GUIContent EnableMatCap = new GUIContent("EnableMatCap");
            
            public static readonly GUIContent MatCap = new GUIContent("MatCap");
            
            public static readonly GUIContent MatCapUVScale = new GUIContent("MatCapUVScale");
        }

        struct MPropertyNames
        {
            public static readonly string WorkflowMode = "WorkflowMode";

            public static readonly string SurfaceType = "SurfaceType";
            
            public static readonly string Cull = "Cull";
            
            public static readonly string AlphaClip = "AlphaClip";
            
            public static readonly string InverseClipMask = "InverseClipMask";
            
            public static readonly string ClipMask = "ClipMask";
            
            public static readonly string Cutoff = "Cutoff";
            
            public static readonly string EnableStencil = "EnableStencil";
            
            public static readonly string StencilType = "StencilType";
            
            public static readonly string StencilRef = "StencilRef";
            
            public static readonly string EnvironmentReflections = "EnvironmentReflections";
            
            public static readonly string RenderQueue = "RenderQueue";

            public static readonly string BaseMap = "BaseMap";

            public static readonly string BaseColor = "BaseColor";

            public static readonly string Shadow1Color = "Shadow1Color";
            
            public static readonly string Shadow1Step = "Shadow1Step";
            
            public static readonly string Shadow1Feather = "Shadow1Feather";
            
            public static readonly string Shadow2Color = "Shadow2Color";
            
            public static readonly string Shadow2Step = "Shadow2Step";
            
            public static readonly string Shadow2Feather = "Shadow2Feather";
            
            public static readonly string InShadowMap = "InShadowMap";
            
            public static readonly string InShadowMapStrength = "InShadowMapStrength";
            
            public static readonly string ShadowType = "ShadowType";
            
            public static readonly string DiffuseRampMap = "DiffuseRampMap";
            
            public static readonly string DiffuseRampV = "DiffuseRampV";
            
            public static readonly string ReceiveShadows = "ReceiveShadows";
            
            public static readonly string CastHairShadowMask = "CastHairShadowMask";
            
            public static readonly string ReceiveHairShadowMask = "ReceiveHairShadowMask";
            
            public static readonly string ReceiveHairShadowOffset = "ReceiveHairShadowOffset";
            
            public static readonly string SSAOStrength = "SSAOStrength";
            
            public static readonly string SDFShadowMap = "SDFShadowMap";

            public static readonly string SpecularHighlights = "SpecularHighlights";

            public static readonly string Metallic = "Metallic";
            
            public static readonly string SpecColor = "SpecColor";
            
            public static readonly string MetallicGlossMap = "MetallicGlossMap";
            
            public static readonly string SpecGlossMap = "SpecGlossMap";
            
            public static readonly string SpecStep = "SpecularStep";
            
            public static readonly string SpecFeather = "SpecularFeather";
            
            public static readonly string Smoothness = "Smoothness";
            
            public static readonly string SpecularType = "SpecularType";
            
            public static readonly string SpecularShiftMap = "SpecularShiftMap";

            public static readonly string SpecularShiftIntensity = "SpecularShiftIntensity";
            
            public static readonly string SpecularShift = "SpecularShift";

            public static readonly string BumpMap = "BumpMap";

            public static readonly string BumpScale = "BumpScale";
            
            public static readonly string OcclusionMap = "OcclusionMap";
            
            public static readonly string OcclusionStrength = "OcclusionStrength";
            
            public static readonly string EmissionMap = "EmissionMap";
            
            public static readonly string EmissionColor = "EmissionColor";

            public static readonly string EnableOutline = "EnableOutline";
            
            public static readonly string UseSmoothNormal = "UseSmoothNormal";
            
            public static readonly string OutlineColor = "OutlineColor";
            
            public static readonly string OutlineWidth = "OutlineWidth";

            public static readonly string RimFlip = "RimFlip";
            
            public static readonly string RimBlendShadow = "RimBlendShadow";
            
            public static readonly string RimBlendLdotV = "RimBlendLdotV";
            
            public static readonly string RimColor = "RimColor";
            
            public static readonly string RimStep = "RimStep";
            
            public static readonly string RimFeather = "RimFeather";

            public static readonly string EnableMatCap = "EnableMatCap";
            
            public static readonly string MatCapMap = "MatCapMap";
            
            public static readonly string MatCapColor = "MatCapColor";
            
            public static readonly string MatCapUVScale = "MatCapUVScale";
        }

        #endregion

        #region Enum

        public enum WorkflowMode
        {
            Specular,

            Metallic,
        }

        public enum SurfaceType
        {
            Opaque,

            Transparent
        }

        public enum RenderFace
        {
            Front = 2,

            Back = 1,
            
            Both = 0
        }

        public enum StencilType
        {
            Mask = 0,

            Out = 1
        }

        public enum ShadowType
        {
            DoubleShade = 0,

            Ramp = 1,
            
            FaceSDFShadow = 2
        }

        public enum SpecularType
        {
            Default = 0,

            HairSpecularViewNormal,
            
            HairSpecularTangent
        }

        #endregion

        #region Fields

        const string EditorPrefKey = "FurryTales:ToonShaderGUI:";

        bool mSurfaceOptionsFoldout;
        
        bool mAdvancedOptionsFoldout;
        
        bool mBaseFoldout;
        
        bool mShadowFoldout;
        
        bool mSpecularFoldout;

        bool mRimFoldout;

        bool mOutlineFoldout;
        
        bool mMatCapFoldout;

        MaterialProperty mWorkflowModeProp;

        MaterialProperty mSurfaceTypeProp;

        MaterialProperty mCullProp;

        MaterialProperty mAlphaClipProp;

        MaterialProperty mInverseClipMaskProp;
        
        MaterialProperty mClipMaskProp;
        
        MaterialProperty mCutoffProp;
        
        MaterialProperty mEnvironmentReflectionsProp;
        
        MaterialProperty mRenderQueueProp;
        
        MaterialProperty mEnableStencilProp;
        
        MaterialProperty mStencilTypeProp;
        
        MaterialProperty mStencilRefProp;

        MaterialProperty mBaseMapProp;
        
        MaterialProperty mBaseColorProp;
        
        MaterialProperty mShadow1ColorProp;
        
        MaterialProperty mShadow1StepProp;
        
        MaterialProperty mShadow1FeatherProp;
        
        MaterialProperty mShadow2ColorProp;
        
        MaterialProperty mShadow2StepProp;
        
        MaterialProperty mShadow2FeatherProp;
        
        MaterialProperty mShadowTypeProp;
        
        MaterialProperty mDiffuseRampMapProp;
        
        MaterialProperty mDiffuseRampVProp;
        
        MaterialProperty mInShadowMapProp;
        
        MaterialProperty mInShadowMapStrengthProp;
        
        MaterialProperty mReceiveShadowsProp;
        
        MaterialProperty mCastHairShadowMaskProp;
        
        MaterialProperty mReceiveHairShadowMaskProp;
        
        MaterialProperty mReceiveHairShadowOffsetProp;
        
        MaterialProperty mSSAOStrengthProp;
        
        MaterialProperty mSDFShadowMapProp;

        MaterialProperty mBumpMapProp;
        
        MaterialProperty mBumpScaleProp;
        
        MaterialProperty mOcclusionMapProp;
        
        MaterialProperty mOcclusionStrengthProp;
        
        MaterialProperty mEmissionMapProp;
        
        MaterialProperty mEmissionColorProp;

        MaterialProperty mMetallicProp;
        
        MaterialProperty mSpecColorProp;
        
        MaterialProperty mMetallicGlossMapProp;
        
        MaterialProperty mSpecGlossMapProp;
        
        MaterialProperty mSpecStepProp;
        
        MaterialProperty mSpecFeatherProp;
        
        MaterialProperty mSmoothnessProp;
        
        MaterialProperty mSpecularHighlightsProp;
        
        MaterialProperty mSpecularTypeProp;
        
        MaterialProperty mSpeculatShiftMapProp;
        
        MaterialProperty mSpecularShiftIntensityProp;
        
        MaterialProperty mSpecularShiftProp;

        MaterialProperty mEnableOutlineProp;
        
        MaterialProperty mUseSmoothNormalProp;
        
        MaterialProperty mOutlineColorProp;
        
        MaterialProperty mOutlineWidthProp;

        MaterialProperty mRimFlipProp;
        
        MaterialProperty mRimBlendShadowProp;
        
        MaterialProperty mRimBlendLdotVProp;
        
        MaterialProperty mRimColorProp;
        
        MaterialProperty mRimStepProp;
        
        MaterialProperty mRimFeatherProp;

        MaterialProperty mEnableMatCapProp;
        
        MaterialProperty mMatCapMapProp;
        
        MaterialProperty mMatCapColorProp;
        
        MaterialProperty mMatCapUVScaleProp;

        #endregion

        #region GUI

        public override void OnGUI(MaterialEditor materialEditor, MaterialProperty[] properties)
        {
            mSurfaceOptionsFoldout = GetFoldoutState("SurfaceOptions");
            
            mAdvancedOptionsFoldout = GetFoldoutState("AdvancedOptions");
            
            mBaseFoldout = GetFoldoutState("Base");
            
            mShadowFoldout = GetFoldoutState("Shadow");
            
            mSpecularFoldout = GetFoldoutState("Specular");
            
            mRimFoldout = GetFoldoutState("Rim");
            
            mOutlineFoldout = GetFoldoutState("Outline");
            
            mMatCapFoldout = GetFoldoutState("MatCap");

            mWorkflowModeProp = FindProperty(MPropertyNames.WorkflowMode, properties, false);
            
            mSurfaceTypeProp = FindProperty(MPropertyNames.SurfaceType, properties, false);
            
            mCullProp = FindProperty(MPropertyNames.Cull, properties, false);
            
            mAlphaClipProp = FindProperty(MPropertyNames.AlphaClip, properties, false);
            
            mInverseClipMaskProp = FindProperty(MPropertyNames.InverseClipMask, properties, false);
            
            mClipMaskProp = FindProperty(MPropertyNames.ClipMask,properties,false);
            
            mCutoffProp = FindProperty(MPropertyNames.Cutoff, properties, false);
            
            mEnvironmentReflectionsProp = FindProperty(MPropertyNames.EnvironmentReflections, properties, false);
            
            mRenderQueueProp = FindProperty(MPropertyNames.RenderQueue, properties, false);
            
            mEnableStencilProp = FindProperty(MPropertyNames.EnableStencil, properties, false);
            
            mStencilTypeProp = FindProperty(MPropertyNames.StencilType, properties, false);
            
            mStencilRefProp = FindProperty(MPropertyNames.StencilRef, properties, false);

            mBaseMapProp = FindProperty(MPropertyNames.BaseMap, properties, false);
            
            mBaseColorProp = FindProperty(MPropertyNames.BaseColor, properties, false);
            
            mShadow1ColorProp = FindProperty(MPropertyNames.Shadow1Color, properties, false);
            
            mShadow1StepProp = FindProperty(MPropertyNames.Shadow1Step, properties, false);
            
            mShadow1FeatherProp = FindProperty(MPropertyNames.Shadow1Feather, properties, false);
            
            mShadow2ColorProp = FindProperty(MPropertyNames.Shadow2Color, properties, false);
            
            mShadow2StepProp = FindProperty(MPropertyNames.Shadow2Step, properties, false);
            
            mShadow2FeatherProp = FindProperty(MPropertyNames.Shadow2Feather, properties, false);
            
            mShadowTypeProp = FindProperty(MPropertyNames.ShadowType, properties, false);
            
            mDiffuseRampMapProp = FindProperty(MPropertyNames.DiffuseRampMap, properties, false);
            
            mDiffuseRampVProp = FindProperty(MPropertyNames.DiffuseRampV, properties, false);
            
            mInShadowMapProp = FindProperty(MPropertyNames.InShadowMap, properties, false);
            
            mInShadowMapStrengthProp = FindProperty(MPropertyNames.InShadowMapStrength, properties, false);
            
            mReceiveShadowsProp = FindProperty(MPropertyNames.ReceiveShadows, properties, false);
            
            mCastHairShadowMaskProp = FindProperty(MPropertyNames.CastHairShadowMask, properties, false);
            
            mReceiveHairShadowMaskProp = FindProperty(MPropertyNames.ReceiveHairShadowMask, properties, false);
            
            mReceiveHairShadowOffsetProp = FindProperty(MPropertyNames.ReceiveHairShadowOffset, properties, false);
            
            mSSAOStrengthProp = FindProperty(MPropertyNames.SSAOStrength, properties, false);
            
            mSDFShadowMapProp = FindProperty(MPropertyNames.SDFShadowMap, properties, false);

            mMetallicProp = FindProperty(MPropertyNames.Metallic, properties);
            
            mSpecColorProp = FindProperty(MPropertyNames.SpecColor, properties, false);
            
            mMetallicGlossMapProp = FindProperty(MPropertyNames.MetallicGlossMap, properties);
            
            mSpecGlossMapProp = FindProperty(MPropertyNames.SpecGlossMap, properties, false);
            
            mSpecStepProp = FindProperty(MPropertyNames.SpecStep, properties, false);
            
            mSpecFeatherProp = FindProperty(MPropertyNames.SpecFeather, properties, false);
            
            mSmoothnessProp = FindProperty(MPropertyNames.Smoothness, properties, false);
            
            mSpeculatShiftMapProp = FindProperty(MPropertyNames.SpecularShiftMap, properties, false);
            
            mSpecularShiftIntensityProp = FindProperty(MPropertyNames.SpecularShiftIntensity, properties, false);
            
            mSpecularShiftProp = FindProperty(MPropertyNames.SpecularShift, properties, false);
            
            mSpecularHighlightsProp = FindProperty(MPropertyNames.SpecularHighlights, properties, false);
            
            mBumpMapProp = FindProperty(MPropertyNames.BumpMap, properties, false);
            
            mBumpScaleProp = FindProperty(MPropertyNames.BumpScale, properties, false);
            
            mOcclusionMapProp = FindProperty(MPropertyNames.OcclusionMap, properties, false);
            
            mOcclusionStrengthProp = FindProperty(MPropertyNames.OcclusionStrength, properties, false);
            
            mEmissionMapProp = FindProperty(MPropertyNames.EmissionMap, properties, false);
            
            mEmissionColorProp = FindProperty(MPropertyNames.EmissionColor, properties, false);
            
            mSpecularTypeProp = FindProperty(MPropertyNames.SpecularType, properties, false);

            mEnableOutlineProp = FindProperty(MPropertyNames.EnableOutline, properties, false);
            
            mUseSmoothNormalProp = FindProperty(MPropertyNames.UseSmoothNormal, properties, false);
            
            mOutlineColorProp = FindProperty(MPropertyNames.OutlineColor, properties, false);
            
            mOutlineWidthProp = FindProperty(MPropertyNames.OutlineWidth, properties, false);

            mRimFlipProp = FindProperty(MPropertyNames.RimFlip, properties, false);
            
            mRimBlendShadowProp = FindProperty(MPropertyNames.RimBlendShadow, properties, false);
            
            mRimBlendLdotVProp = FindProperty(MPropertyNames.RimBlendLdotV, properties, false);
            
            mRimColorProp = FindProperty(MPropertyNames.RimColor, properties, false);
            
            mRimStepProp = FindProperty(MPropertyNames.RimStep, properties, false);
            
            mRimFeatherProp = FindProperty(MPropertyNames.RimFeather, properties, false);
            
            mEnableMatCapProp = FindProperty(MPropertyNames.EnableMatCap, properties, false);
            
            mMatCapMapProp = FindProperty(MPropertyNames.MatCapMap, properties, false);
            
            mMatCapColorProp = FindProperty(MPropertyNames.MatCapColor, properties, false);
            
            mMatCapUVScaleProp = FindProperty(MPropertyNames.MatCapUVScale, properties, false);

            EditorGUI.BeginChangeCheck();
            
            DrawProperties(materialEditor);

            if (EditorGUI.EndChangeCheck())
            {
                SetMaterialKeywords(materialEditor.target as Material);
            }
        }

        #endregion

        #region Keywords
        
        void SetKeyword(Material material, string keyword, bool value)
        {
            if (value)
            {
                material.EnableKeyword(keyword);
            }

            else
            {
                material.DisableKeyword(keyword);
            }
        }

        void SetMaterialKeywords(Material material)
        {
            material.shaderKeywords = null;

            SetKeyword(material, "SPECULAR_SETUP", material.GetFloat(MPropertyNames.WorkflowMode) == 0);

            bool alphaClip = material.GetFloat(MPropertyNames.AlphaClip) == 1;

            if (alphaClip)
            {
                SetKeyword(material,"INVERSECLIPMASK",material.GetFloat(MPropertyNames.InverseClipMask) == 1);

                material.EnableKeyword("ALPHATEST_ON");
            }

            else
            {
                material.DisableKeyword("ALPHATEST_ON");
            }

            SurfaceType surfaceType = (SurfaceType)material.GetFloat(MPropertyNames.SurfaceType);

            if (surfaceType == SurfaceType.Opaque)
            {
                if (alphaClip)
                {
                    material.SetOverrideTag("RenderType", "TransparentCutout");
                }

                else
                {
                    material.SetOverrideTag("RenderType", "Opaque");
                }

                material.SetInt("SrcBlend", (int)UnityEngine.Rendering.BlendMode.One);

                material.SetInt("DstBlend", (int)UnityEngine.Rendering.BlendMode.Zero);
                
                material.SetShaderPassEnabled("ShadowCaster", true);
            }

            else
            {
                material.SetInt("SrcBlend", (int)UnityEngine.Rendering.BlendMode.SrcAlpha);
                
                material.SetInt("DstBlend", (int)UnityEngine.Rendering.BlendMode.OneMinusSrcAlpha);

                material.SetOverrideTag("RenderType", "Transparent");

                material.SetShaderPassEnabled("ShadowCaster", false);
            }

            SetKeyword(material, "RECEIVE_SHADOWS_OFF", material.GetFloat(MPropertyNames.ReceiveShadows) == 0.0f);

            SetKeyword(material, "RECEIVE_HAIRSHADOWMASK", material.GetFloat(MPropertyNames.ReceiveHairShadowMask) == 1.0f);

            SetKeyword(material, "SPECULARHIGHLIGHTS_OFF", material.GetFloat(mSpecularHighlightsProp.name) == 0.0f);

            SetKeyword(material, "ENVIRONMENTREFLECTIONS_OFF", material.GetFloat(mEnvironmentReflectionsProp.name) == 0.0f);

            SetKeyword(material,"NORMALMAP", material.GetTexture(MPropertyNames.BumpMap) != null);

            SetKeyword(material,"OCCLUSIONMAP", material.GetTexture(MPropertyNames.OcclusionMap) != null);

            bool hasEmissionMap = material.GetTexture(MPropertyNames.EmissionMap) != null;

            Color emissionColor = material.GetColor(MPropertyNames.EmissionColor);
            
            SetKeyword(material,"EMISSION", hasEmissionMap || emissionColor != Color.black);

            SetKeyword(material, "HAIRSPECULAR", material.HasProperty(MPropertyNames.SpecularType) 
            && material.GetFloat(MPropertyNames.SpecularType) == 2.0f);
            
            SetKeyword(material, "HAIRSPECULARVIEWNORMAL", material.HasProperty(MPropertyNames.SpecularType) 
            && material.GetFloat(MPropertyNames.SpecularType) == 1.0f);

            SetKeyword(material,"USESMOOTHNORMAL", material.GetFloat(MPropertyNames.UseSmoothNormal) == 1.0);

            SetKeyword(material,"DIFFUSERAMPMAP", material.HasProperty(MPropertyNames.ShadowType) 
            && material.GetFloat(MPropertyNames.ShadowType) == 1.0f);
            
            SetKeyword(material, "SDFSHADOWMAP", material.HasProperty(MPropertyNames.ShadowType) 
            && material.GetFloat(MPropertyNames.ShadowType) == 2.0f);

            material.SetShaderPassEnabled("Outline", material.GetFloat(MPropertyNames.EnableOutline) == 1.0f);

            if (material.HasProperty(MPropertyNames.CastHairShadowMask))
            {
                material.SetShaderPassEnabled("HairShadowMask", 
                material.GetFloat(MPropertyNames.CastHairShadowMask) == 1.0f);
            }

            SetKeyword(material, "MATCAP", material.GetFloat(MPropertyNames.EnableMatCap) == 1.0);
        }

        #endregion

        #region Properties

        void DrawProperties(MaterialEditor materialEditor)
        {
            var surfaceOptionsFold = EditorGUILayout.BeginFoldoutHeaderGroup(mSurfaceOptionsFoldout, 
            Styles.SurfaceOptionsFold);
            
            if (surfaceOptionsFold)
            {
                EditorGUILayout.Space();

                DrawSurfaceOptions(materialEditor);
                
                EditorGUILayout.Space();
            }

            SetFoldoutState("SurfaceOptions", mSurfaceOptionsFoldout, surfaceOptionsFold);

            EditorGUILayout.EndFoldoutHeaderGroup();

            var baseFold = EditorGUILayout.BeginFoldoutHeaderGroup(mBaseFoldout, Styles.BaseFold);

            if (baseFold)
            {
                EditorGUILayout.Space();

                DrawBaseProperties(materialEditor);
                
                EditorGUILayout.Space();
            }

            SetFoldoutState("Base", mBaseFoldout, baseFold);
            
            EditorGUILayout.EndFoldoutHeaderGroup();

            var shadowFold = EditorGUILayout.BeginFoldoutHeaderGroup(mShadowFoldout, Styles.ShadowFold);

            if (shadowFold)
            {
                EditorGUILayout.Space();

                DrawShadowProperties(materialEditor);
                
                EditorGUILayout.Space();
            }

            SetFoldoutState("Shadow", mShadowFoldout, shadowFold);

            EditorGUILayout.EndFoldoutHeaderGroup();

            var specularFold = EditorGUILayout.BeginFoldoutHeaderGroup(mSpecularFoldout, Styles.SpecularFold);

            if (specularFold)
            {
                EditorGUILayout.Space();

                DrawSpecularProperties(materialEditor);
                
                EditorGUILayout.Space();
            }

            SetFoldoutState("Specular", mSpecularFoldout, specularFold);

            EditorGUILayout.EndFoldoutHeaderGroup();

            var rimFold = EditorGUILayout.BeginFoldoutHeaderGroup(mRimFoldout, Styles.RimFold);

            if (rimFold)
            {
                EditorGUILayout.Space();

                DrawRimProperties(materialEditor);
                
                EditorGUILayout.Space();
            }

            SetFoldoutState("Rim", mRimFoldout, rimFold);
            
            EditorGUILayout.EndFoldoutHeaderGroup();

            var OutlineFold = EditorGUILayout.BeginFoldoutHeaderGroup(mOutlineFoldout, Styles.OutlineFold);

            if (OutlineFold)
            {
                EditorGUILayout.Space();

                DrawOutlineProperties(materialEditor);
                
                EditorGUILayout.Space();
            }

            SetFoldoutState("Outline", mOutlineFoldout, OutlineFold);
            
            EditorGUILayout.EndFoldoutHeaderGroup();

            var matCapFold = EditorGUILayout.BeginFoldoutHeaderGroup(mMatCapFoldout, Styles.MatCap);

            if (matCapFold)
            {
                EditorGUILayout.Space();

                DrawMatCapProperties(materialEditor);
                
                EditorGUILayout.Space();
            }

            SetFoldoutState("MatCap", mMatCapFoldout, matCapFold);
            
            EditorGUILayout.EndFoldoutHeaderGroup();

            var advancedOptionsFold = EditorGUILayout.BeginFoldoutHeaderGroup(mAdvancedOptionsFoldout, 
            Styles.AdvancedOptionsFold);

            if (advancedOptionsFold)
            {
                EditorGUILayout.Space();

                DrawAdvancedOptions(materialEditor);
                
                EditorGUILayout.Space();
            }

            SetFoldoutState("AdvancedOptions", mAdvancedOptionsFoldout, advancedOptionsFold);
            
            EditorGUILayout.EndFoldoutHeaderGroup();
        }

        void DrawSurfaceOptions(MaterialEditor materialEditor)
        {
            var material = materialEditor.target as Material;

            if (material.HasProperty(MPropertyNames.WorkflowMode))
            {
                EditorGUI.showMixedValue = mSurfaceTypeProp.hasMixedValue;

                EditorGUI.BeginChangeCheck();
                
                var workflow = EditorGUILayout.Popup(Styles.WorkflowMode, 
                (int)mWorkflowModeProp.floatValue, Enum.GetNames(typeof(WorkflowMode)));
                
                if (EditorGUI.EndChangeCheck())
                {
                    materialEditor.RegisterPropertyChangeUndo(Styles.WorkflowMode.text);

                    mWorkflowModeProp.floatValue = workflow;
                }

                EditorGUI.showMixedValue = false;
            }

            if (material.HasProperty(MPropertyNames.SurfaceType))
            {
                EditorGUI.showMixedValue = mSurfaceTypeProp.hasMixedValue;

                EditorGUI.BeginChangeCheck();
                
                var surface = EditorGUILayout.Popup(Styles.SurfaceType, 
                (int)mSurfaceTypeProp.floatValue, Enum.GetNames(typeof(SurfaceType)));
                
                if (EditorGUI.EndChangeCheck())
                {
                    materialEditor.RegisterPropertyChangeUndo(Styles.SurfaceType.text);

                    if ((SurfaceType)surface == SurfaceType.Opaque)
                    {
                        material.renderQueue = (int)UnityEngine.Rendering.RenderQueue.Geometry;
                    }

                    else
                    {
                        material.renderQueue = (int)UnityEngine.Rendering.RenderQueue.Transparent;
                    }

                    mRenderQueueProp.floatValue = material.renderQueue;
                    
                    mSurfaceTypeProp.floatValue = surface;
                }

                EditorGUI.showMixedValue = false;
            }

            if (material.HasProperty(MPropertyNames.Cull))
            {
                if ((SurfaceType)material.GetFloat(MPropertyNames.SurfaceType) == SurfaceType.Opaque)
                {
                    EditorGUI.showMixedValue = mCullProp.hasMixedValue;

                    EditorGUI.BeginChangeCheck();

                    int renderFace = EditorGUILayout.Popup(Styles.RenderFace, 
                    (int)mCullProp.floatValue, Enum.GetNames(typeof(RenderFace)));
                    
                    if (EditorGUI.EndChangeCheck())
                    {
                        materialEditor.RegisterPropertyChangeUndo(Styles.RenderFace.text);

                        mCullProp.floatValue = renderFace;
                        
                        material.doubleSidedGI = (RenderFace)mCullProp.floatValue != RenderFace.Front;
                    }

                    EditorGUI.showMixedValue = false;
                }

                else
                {
                    mCullProp.floatValue = (float)RenderFace.Front;
                    
                    material.doubleSidedGI = false;
                }
            }

            if (material.HasProperty(MPropertyNames.AlphaClip) && material.HasProperty(MPropertyNames.Cutoff))
            {
                EditorGUI.BeginChangeCheck();

                var enableAlphaClip = EditorGUILayout.Toggle(Styles.AlphaClipping, mAlphaClipProp.floatValue == 1);
                
                if (EditorGUI.EndChangeCheck())
                {
                    mAlphaClipProp.floatValue = enableAlphaClip ? 1 : 0;
                    
                    mRenderQueueProp.floatValue = enableAlphaClip ? 
                    (int)UnityEngine.Rendering.RenderQueue.AlphaTest : (int)UnityEngine.Rendering.RenderQueue.Geometry;
                }

                if (mAlphaClipProp.floatValue == 1)
                {
                    materialEditor.ShaderProperty(mInverseClipMaskProp, Styles.InverseClipMask);
                    
                    materialEditor.TexturePropertySingleLine(Styles.AlphaClippingMask, mClipMaskProp, mCutoffProp);
                }
            }

            if (material.HasProperty(MPropertyNames.EnableStencil) && material.HasProperty(MPropertyNames.StencilRef))
            {
                EditorGUI.BeginChangeCheck();

                var enableStencil = EditorGUILayout.Toggle(Styles.EnableStencil, mEnableStencilProp.floatValue == 1);
                
                if (EditorGUI.EndChangeCheck())
                {
                    mEnableStencilProp.floatValue = enableStencil ? 1 : 0;
                }

                if (mEnableStencilProp.floatValue == 1)
                {
                    EditorGUI.showMixedValue = mStencilTypeProp.hasMixedValue;

                    EditorGUI.BeginChangeCheck();
                    
                    var stencilType = EditorGUILayout.Popup(Styles.StencilType, 
                    (int)mStencilTypeProp.floatValue, Enum.GetNames(typeof(StencilType)));
                    
                    if (EditorGUI.EndChangeCheck())
                    {
                        materialEditor.RegisterPropertyChangeUndo(Styles.StencilType.text);

                        mStencilTypeProp.floatValue = stencilType;
                        
                        if (mStencilTypeProp.floatValue == 0)
                        {
                            material.SetInt("StencilComp", (int)UnityEngine.Rendering.CompareFunction.Always);

                            material.SetInt("StencilOp", (int)UnityEngine.Rendering.StencilOp.Replace);
                        }

                        else if (mStencilTypeProp.floatValue == 1)
                        {
                            material.SetInt("StencilComp", (int)UnityEngine.Rendering.CompareFunction.NotEqual);

                            material.SetInt("StencilOp", (int)UnityEngine.Rendering.StencilOp.Keep);
                        }
                    }

                    materialEditor.ShaderProperty(mStencilRefProp, Styles.StencilRef);
                    
                    EditorGUI.showMixedValue = false;
                }

                else
                {
                    material.SetInt("StencilComp", (int)UnityEngine.Rendering.CompareFunction.Disabled);

                    material.SetInt("StencilOp", (int)UnityEngine.Rendering.StencilOp.Keep);
                }
            }
        }

        void DrawBaseProperties(MaterialEditor materialEditor)
        {
            materialEditor.TexturePropertySingleLine(Styles.Color, mBaseMapProp, mBaseColorProp);

            materialEditor.TexturePropertySingleLine(Styles.Normal, mBumpMapProp, mBumpScaleProp);

            materialEditor.TexturePropertySingleLine(Styles.Occlusion, mOcclusionMapProp,
            mOcclusionMapProp.textureValue != null ? mOcclusionStrengthProp : null);

            var hadEmissionTexture = mEmissionMapProp.textureValue != null;

            materialEditor.TexturePropertyWithHDRColor(Styles.Emission, mEmissionMapProp,
            mEmissionColorProp, false);

            var brightness = mEmissionColorProp.colorValue.maxColorComponent;

            if (mEmissionMapProp.textureValue != null && !hadEmissionTexture && brightness <= 0f)
            {
                mEmissionColorProp.colorValue = Color.white;
            }

            materialEditor.TextureScaleOffsetProperty(mBaseMapProp);
        }

        void DrawShadowProperties(MaterialEditor materialEditor)
        {
            var material = materialEditor.target as Material;

            EditorGUI.BeginChangeCheck();

            var ssao = EditorGUILayout.Slider(Styles.SSAOStrength, mSSAOStrengthProp.floatValue, 0f, 1f);
            
            if (EditorGUI.EndChangeCheck())
            {
                mSSAOStrengthProp.floatValue = ssao;
            }

            materialEditor.TexturePropertySingleLine(Styles.InShadowMap, mInShadowMapProp, mInShadowMapStrengthProp);

            if (material.HasProperty(MPropertyNames.ShadowType))
            {
                EditorGUI.showMixedValue = mSurfaceTypeProp.hasMixedValue;

                EditorGUI.BeginChangeCheck();
                
                var shadowType = EditorGUILayout.Popup(Styles.ShadowType, 
                (int)mShadowTypeProp.floatValue, Enum.GetNames(typeof(ShadowType)));
                
                if (EditorGUI.EndChangeCheck())
                {
                    materialEditor.RegisterPropertyChangeUndo(Styles.ShadowType.text);
                    
                    mShadowTypeProp.floatValue = shadowType;
                }

                EditorGUI.showMixedValue = false;

                if (mShadowTypeProp.floatValue == 1.0)
                {
                    materialEditor.TexturePropertySingleLine(Styles.DiffuseRampMap, 
                    mDiffuseRampMapProp, mDiffuseRampVProp);
                }

                else if(mShadowTypeProp.floatValue == 0)
                {
                    materialEditor.ColorProperty(mShadow1ColorProp, "Shadow1Color");

                    materialEditor.ColorProperty(mShadow2ColorProp, "Shadow2Color");
                    
                    EditorGUI.BeginChangeCheck();
                    
                    var step1 = EditorGUILayout.Slider(Styles.Shadow1Step, mShadow1StepProp.floatValue, 0f, 1f);
                    
                    var feather1 = EditorGUILayout.Slider(Styles.Shadow1Feather, mShadow1FeatherProp.floatValue, 0f, 1f);
                    
                    var step2 = EditorGUILayout.Slider(Styles.Shadow2Step, mShadow2StepProp.floatValue, 0f, 1f);
                    
                    var feather2 = EditorGUILayout.Slider(Styles.Shadow2Feather, mShadow2FeatherProp.floatValue, 0f, 1f);
                    
                    if (EditorGUI.EndChangeCheck())
                    {
                        mShadow1StepProp.floatValue = step1;
                        
                        mShadow1FeatherProp.floatValue = feather1;
                        
                        mShadow2StepProp.floatValue = step2;
                        
                        mShadow2FeatherProp.floatValue = feather2;
                    }
                }

                else
                {
                    if (material.HasProperty(MPropertyNames.SDFShadowMap))
                    {
                        materialEditor.TexturePropertySingleLine(Styles.SDFShadowMap, mSDFShadowMapProp);

                        materialEditor.ColorProperty(mShadow1ColorProp, "Shadow1Color");

                        EditorGUI.BeginChangeCheck();
                        
                        var step1 = EditorGUILayout.Slider(Styles.Shadow1Step, mShadow1StepProp.floatValue, 0f, 1f);
                        
                        var feather1 = EditorGUILayout.Slider(Styles.Shadow1Feather, 
                        mShadow1FeatherProp.floatValue, 0f, 1f);
                        
                        if (EditorGUI.EndChangeCheck())
                        {
                            mShadow1StepProp.floatValue = step1;
                            
                            mShadow1FeatherProp.floatValue = feather1;
                        }
                    }
                }
            }

            if (material.HasProperty(MPropertyNames.ReceiveShadows))
            {
                EditorGUI.BeginChangeCheck();

                var receiveShadows = EditorGUILayout.Toggle(Styles.ReceiveShadows, 
                mReceiveShadowsProp.floatValue == 1.0f);
                
                if (EditorGUI.EndChangeCheck())
                {
                    materialEditor.RegisterPropertyChangeUndo(Styles.ReceiveShadows.text);

                    mReceiveShadowsProp.floatValue = receiveShadows ? 1.0f : 0.0f;
                }
            }

            if (material.HasProperty(MPropertyNames.CastHairShadowMask))
            {
                EditorGUI.BeginChangeCheck();

                var castFhairShadows = EditorGUILayout.Toggle(Styles.CastHairShadowMask, 
                mCastHairShadowMaskProp.floatValue == 1.0f);
                
                if (EditorGUI.EndChangeCheck())
                {
                    materialEditor.RegisterPropertyChangeUndo(Styles.CastHairShadowMask.text);
                    
                    mCastHairShadowMaskProp.floatValue = castFhairShadows ? 1.0f : 0.0f;
                }
            }

            if (material.HasProperty(MPropertyNames.ReceiveHairShadowMask))
            {
                EditorGUI.BeginChangeCheck();

                var receiveFhairShadows = EditorGUILayout.Toggle(Styles.ReceiveHairShadowMask, 
                mReceiveHairShadowMaskProp.floatValue == 1.0f);
                
                if (EditorGUI.EndChangeCheck())
                {
                    materialEditor.RegisterPropertyChangeUndo(Styles.ReceiveHairShadowMask.text);

                    mReceiveHairShadowMaskProp.floatValue = receiveFhairShadows ? 1.0f : 0.0f;
                }

                if (receiveFhairShadows)
                {
                    EditorGUI.BeginChangeCheck();

                    var offset = EditorGUILayout.Slider(Styles.ReceiveHairShadowOffset, 
                    mReceiveHairShadowOffsetProp.floatValue, 0f, 5f);

                    if (EditorGUI.EndChangeCheck())
                    {
                        mReceiveHairShadowOffsetProp.floatValue = offset;
                    }
                }
            }
        }

        void DrawSpecularProperties(MaterialEditor materialEditor)
        {
            var material = materialEditor.target as Material;

            bool specularWork = material.GetFloat(MPropertyNames.WorkflowMode) == 0;

            if (specularWork)
            {
                materialEditor.TexturePropertySingleLine(Styles.Specular, mSpecGlossMapProp, mSpecColorProp);
            }

            else
            {
                materialEditor.TexturePropertySingleLine(Styles.Metallic, mMetallicGlossMapProp, mMetallicProp);
            }

            EditorGUI.BeginChangeCheck();

            EditorGUI.indentLevel += 2;
            
            var specStep = EditorGUILayout.Slider(Styles.SpecularStep, mSpecStepProp.floatValue, 0f, 1f);
            
            var specFeather = EditorGUILayout.Slider(Styles.SpecularFeather, mSpecFeatherProp.floatValue, 0f, 1f);
            
            EditorGUI.indentLevel -= 2;
            
            if (EditorGUI.EndChangeCheck())
            {
                mSpecStepProp.floatValue = specStep;

                mSpecFeatherProp.floatValue = specFeather;
            }

            EditorGUI.BeginChangeCheck();

            EditorGUI.indentLevel+=2;
            
            var smooth = EditorGUILayout.Slider(Styles.Smoothness, mSmoothnessProp.floatValue, 0f, 1f);
            
            EditorGUI.indentLevel-=2;
            
            if (EditorGUI.EndChangeCheck())
            {
                mSmoothnessProp.floatValue = smooth;
            }

            if (material.HasProperty(MPropertyNames.SpecularType))
            {
                EditorGUI.showMixedValue = mSpecularTypeProp.hasMixedValue;

                EditorGUI.BeginChangeCheck();
                
                var specularType = EditorGUILayout.Popup(Styles.SpecularType, 
                (int)mSpecularTypeProp.floatValue, Enum.GetNames(typeof(SpecularType)));
                
                if (EditorGUI.EndChangeCheck())
                {
                    materialEditor.RegisterPropertyChangeUndo(Styles.SpecularType.text);

                    mSpecularTypeProp.floatValue = specularType;
                }

                EditorGUI.showMixedValue = false;

                if (mSpecularTypeProp.floatValue == 2.0)
                {
                    materialEditor.TexturePropertySingleLine(Styles.SpecularShiftMap, mSpeculatShiftMapProp, 
                    mSpecularShiftIntensityProp);
                    
                    materialEditor.TextureScaleOffsetProperty(mSpeculatShiftMapProp);
                    
                    EditorGUI.BeginChangeCheck();
                    
                    EditorGUI.indentLevel += 2;
                    
                    var shift = EditorGUILayout.Slider(Styles.SpecularShift, mSpecularShiftProp.floatValue, -1f, 1f);
                    
                    if (EditorGUI.EndChangeCheck())
                    {
                        mSpecularShiftProp.floatValue = shift;
                    }

                    EditorGUI.indentLevel -= 2;
                }
            }

            if (material.HasProperty(MPropertyNames.SpecularHighlights))
            {
                materialEditor.ShaderProperty(mSpecularHighlightsProp, Styles.SpecularHighlights);
            }
        }

        void DrawRimProperties(MaterialEditor materialEditor)
        {
            materialEditor.ColorProperty(mRimColorProp, Styles.RimColor.text);

            materialEditor.ShaderProperty(mRimFlipProp, Styles.RimFlip);
            
            EditorGUI.BeginChangeCheck();
            
            EditorGUI.indentLevel += 2;
            
            var rimBlendShadow = EditorGUILayout.Slider(Styles.RimBlendShadow, mRimBlendShadowProp.floatValue, 0f, 1f);
            
            var rimBlendLdotV = EditorGUILayout.Slider(Styles.RimBlendLdotV, mRimBlendLdotVProp.floatValue, 0f, 1f);
            
            var rimStep = EditorGUILayout.Slider(Styles.RimStep, mRimStepProp.floatValue, 0f, 1f);
            
            var rimFeather = EditorGUILayout.Slider(Styles.RimFeather, mRimFeatherProp.floatValue, 0f, 1f);
            
            EditorGUI.indentLevel -= 2;
            
            if (EditorGUI.EndChangeCheck())
            {
                mRimBlendShadowProp.floatValue = rimBlendShadow;
                
                mRimBlendLdotVProp.floatValue = rimBlendLdotV;
                
                mRimStepProp.floatValue = rimStep;
                
                mRimFeatherProp.floatValue = rimFeather;
            }
        }

        void DrawOutlineProperties(MaterialEditor materialEditor)
        {
            materialEditor.ShaderProperty(mEnableOutlineProp, Styles.EnableOutline);

            if (mEnableOutlineProp.floatValue == 1.0)
            {
                materialEditor.ShaderProperty(mUseSmoothNormalProp, Styles.UseSmoothNormal);

                materialEditor.ColorProperty(mOutlineColorProp, "OutlineColor");
                
                EditorGUI.BeginChangeCheck();
                
                var OutlineWidth = EditorGUILayout.Slider(Styles.OutlineWidth, 
                mOutlineWidthProp.floatValue, 0f, 5f);
                
                if (EditorGUI.EndChangeCheck())
                {
                    mOutlineWidthProp.floatValue = OutlineWidth;
                }
            }
        }

        void DrawMatCapProperties(MaterialEditor materialEditor)
        {
            materialEditor.ShaderProperty(mEnableMatCapProp, Styles.MatCap);

            if (mEnableMatCapProp.floatValue == 1.0)
            {
                materialEditor.TexturePropertySingleLine(Styles.MatCap, mMatCapMapProp, mMatCapColorProp);

                EditorGUI.BeginChangeCheck();
                
                var matCapScale = EditorGUILayout.Slider(Styles.MatCapUVScale, 
                mMatCapUVScaleProp.floatValue, -0.5f, 0.5f);

                if (EditorGUI.EndChangeCheck())
                {
                    mMatCapUVScaleProp.floatValue = matCapScale;
                }
            }
        }

        void DrawAdvancedOptions(MaterialEditor materialEditor)
        {
            var material = materialEditor.target as Material;

            if (material.HasProperty(MPropertyNames.EnvironmentReflections))
            {
                materialEditor.ShaderProperty(mEnvironmentReflectionsProp, Styles.EnvironmentReflections);
            }

            materialEditor.EnableInstancingField();

            if (material.HasProperty(MPropertyNames.RenderQueue))
            {
                EditorGUI.BeginChangeCheck();

                var RenderQueue = EditorGUILayout.IntSlider(Styles.RenderQueue, 
                (int)mRenderQueueProp.floatValue, -1, 5000);

                if (EditorGUI.EndChangeCheck())
                {
                    mRenderQueueProp.floatValue = RenderQueue;
                }

                material.renderQueue = (int)mRenderQueueProp.floatValue;
            }
        }

        #endregion

        #region EditorPrefs

        bool GetFoldoutState(string name)
        {
            return EditorPrefs.GetBool($"{EditorPrefKey}.{name}");
        }

        void SetFoldoutState(string name, bool field, bool value)
        {
            if (field == value)
            {
                return;
            }
            
            EditorPrefs.SetBool($"{EditorPrefKey}.{name}", value);
        }

        #endregion
    }
}