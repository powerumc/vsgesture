//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.ComponentModel.Composition;
//using Microsoft.VisualStudio.Editor;
//using Microsoft.VisualStudio.Text.Editor;
//using Microsoft.VisualStudio.Utilities;
//using Microsoft.VisualStudio.TextManager.Interop;

//namespace Umc.Core.Tools.VSGesture
//{
//    [Export(typeof(IVsTextViewCreationListener))]
//    [ContentType("text")]
//    [TextViewRole(PredefinedTextViewRoles.Document)]
//    [Order(After = PredefinedAdornmentLayers.Caret)]
//    public class VSGestureVsTextViewCreationListner : IVsTextViewCreationListener
//    {
//        Dictionary<IWpfTextView, Shell.GestureWpfWindow> list = new Dictionary<IWpfTextView, Shell.GestureWpfWindow>();

//        public VSGestureVsTextViewCreationListner()
//        {
//        }

//        [Export(typeof(AdornmentLayerDefinition))]
//        [Order(After = PredefinedAdornmentLayers.Caret)]
//        [TextViewRole(PredefinedTextViewRoles.Interactive)]
//        [Name("VSGestureWindow")]
//        public AdornmentLayerDefinition editorAdornmentLayer;

//        [Import]
//        IVsEditorAdaptersFactoryService VsEditorAdaptersFactoryService { get; set; }


//        public void VsTextViewCreated(IVsTextView textViewAdapter)
//        {
//            IWpfTextView view = VsEditorAdaptersFactoryService.GetWpfTextView(textViewAdapter);
//            if (list.ContainsKey(view))
//            {
//            }
//            else
//            {
//                var doc = new Shell.GestureWpfWindow(view);
//                list.Add(view, doc);
//            }
//        }
//    }
//}