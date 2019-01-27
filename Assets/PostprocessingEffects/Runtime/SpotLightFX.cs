using System;
using UnityEditor;

namespace UnityEngine.Rendering.PostProcessing
{
    [Serializable]
    [PostProcess(typeof(SpotLightFXRenderer), PostProcessEvent.AfterStack, "Custom/SpotLightFX")]
    public sealed class SpotLightFX : PostProcessEffectSettings
    {
        [Range(0f, 1f), Tooltip("Grayscale effect intensity.")]
        public FloatParameter blend = new FloatParameter { value = 0.5f };
    }

    public sealed class SpotLightFXRenderer : PostProcessEffectRenderer<SpotLightFX>
    {
        public override void Render(PostProcessRenderContext context)
        {
            var sheet = context.propertySheets.Get(Shader.Find("SpotLightFX"));
            sheet.properties.SetFloat("_Blend", settings.blend);
            context.command.BlitFullscreenTriangle(context.source, context.destination, sheet, 0);
        }
    }
}