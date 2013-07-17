using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.VisualStudio.Text.Editor;
using Microsoft.VisualStudio.Utilities;
using System.ComponentModel.Composition;

namespace Umc.Core.Tools.VSGesture
{
	[Export(typeof(global::Microsoft.VisualStudio.Text.Editor.IMouseProcessorProvider))]
	[ContentType("text")]
	[TextViewRole(PredefinedTextViewRoles.Interactive)]
    [Order(Before = "VisualStudioMouseProcessor")]
	[Name("VSGesture Mouse Gesturing")]
	public class VSGestureMouseProcessorProvider : global::Microsoft.VisualStudio.Text.Editor.IMouseProcessorProvider
	{
	    [Export(typeof(AdornmentLayerDefinition))]
		[Order(Before = PredefinedAdornmentLayers.Selection)]
		[TextViewRole(PredefinedTextViewRoles.Interactive)]
		[Name("VSGestureWindow")]
		public AdornmentLayerDefinition EditorAdornmentLayer;

		//[ImportMany(typeof(IMouseProcessorProvider))]
		//public IEnumerable<IMouseProcessorProvider> Providers { get; set; }

		public IMouseProcessor GetAssociatedProcessor(IWpfTextView wpfTextView)
		{
			return new Shell.GestureWpfWindow(wpfTextView);
		}
	}
}
