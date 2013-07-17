using System;
using System.Drawing;
using System.Text;

namespace Umc.Core.Tools.VSGesture.Controls
{
    /// <summary>
    /// Represents a Windows picker box that displays Color values.
    /// </summary>
    public class ColorPicker : PickerBase
    {
        /// <summary>
        /// Constructor
        /// </summary>
        public ColorPicker()
            : base(typeof(Color))
        {
            Value = Color.White;
        }

        /// <summary>
        /// Value
        /// </summary>
        public new Color Value
        {
            get
            {
                return (Color)base.Value;
            }
            set
            {
                base.Value = value;
            }
        }
    }
}
