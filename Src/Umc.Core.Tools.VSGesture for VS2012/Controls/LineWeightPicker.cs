using System;
using System.Collections;
using System.Text;
using System.Drawing;
using System.Drawing.Design;
using System.Drawing.Drawing2D;
using System.ComponentModel;

namespace Umc.Core.Tools.VSGesture.Controls
{
	public enum LineThicknessStyle
	{
		Thickness1 = 1,
		Thickness3 = 3,
		Thickness5 = 5,
		Thickness7 = 7,
		Thickness9 = 9
	}

	public class LineWeightPicker : PickerBase
	{
		/// <summary>
        /// Constructor
        /// </summary>
        public LineWeightPicker()
            : base(typeof(LineThicknessStyle))
        {
            Value = LineThicknessStyle.Thickness5;
            Editor = new LineThicknessStyleEditor();
            TextEditable = false;
            PaintValueFrame = false;
            PaintValueWidth = 40;
        }

        /// <summary>
        /// Value
        /// </summary>
        public new LineThicknessStyle Value
        {
            get
            {
                return (LineThicknessStyle)base.Value;
            }
            set
            {
                base.Value = value;
            }
        }

		private class LineThicknessStyleEditor : UITypeEditor
        {
            /// <summary>
            /// Constructor
            /// </summary>
            public LineThicknessStyleEditor()
            {
            }
            
            /// <summary>
            /// Overloaded. Gets the editor style used by the EditValue method.
            /// </summary>
            /// <param name="context">An ITypeDescriptorContext that can be used to gain additional context information.</param>
            /// <returns>A UITypeEditorEditStyle value that indicates the style of editor used by the EditValue method.</returns>
            public override UITypeEditorEditStyle GetEditStyle(ITypeDescriptorContext context)
            {
                return UITypeEditorEditStyle.None;
            }

            /// <summary>
            /// Indicates whether the specified context supports painting a representation of an object's value within the specified context.
            /// </summary>
            /// <param name="context">An ITypeDescriptorContext that can be used to gain additional context information.</param>
            /// <returns>true if PaintValue is implemented; otherwise, false.</returns>
            public override bool GetPaintValueSupported(ITypeDescriptorContext context)
            {
                return true;
            }

            /// <summary>
            /// Paints a representation of the value of an object using the specified PaintValueEventArgs.
            /// </summary>
            /// <param name="e">A PaintValueEventArgs that indicates what to paint and where to paint it.</param>
            public override void PaintValue(PaintValueEventArgs e)
            {
				if (e.Value != null)
				{
					int thickness = (int)e.Value;
				    Rectangle bounds = e.Bounds;

				    int y = bounds.Y + bounds.Height / 2;
				    Point start = new Point(bounds.Left, y);
				    Point end = new Point(bounds.Right, y);

				    Pen pen = new Pen(SystemColors.WindowText, thickness);

				    Brush brush = new SolidBrush(SystemColors.Window);
				    try
				    {
				        GraphicsState state = e.Graphics.Save();
				        //e.Graphics.FillRectangle(brush, bounds);
				        e.Graphics.DrawLine(pen, start, end);
				        e.Graphics.Restore(state);
				    }
				    finally
				    {
				        pen.Dispose();
				        brush.Dispose();
				    }
				}
            }

        }
	}
}
