// Amplify Shader Editor - Visual Shader Editing Tool
// Copyright (c) Amplify Creations, Lda <info@amplify.pt>
#if UNITY_POST_PROCESSING_STACK_V2
using System;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

[Serializable]
[PostProcess( typeof( ConvolutionFilterPPSRenderer ), PostProcessEvent.AfterStack, "ConvolutionFilter", true )]
public sealed class ConvolutionFilterPPSSettings : PostProcessEffectSettings
{
}

public sealed class ConvolutionFilterPPSRenderer : PostProcessEffectRenderer<ConvolutionFilterPPSSettings>
{
	public override void Render( PostProcessRenderContext context )
	{
		var sheet = context.propertySheets.Get( Shader.Find( "ConvolutionFilter" ) );
		context.command.BlitFullscreenTriangle( context.source, context.destination, sheet, 0 );
	}
}
#endif
