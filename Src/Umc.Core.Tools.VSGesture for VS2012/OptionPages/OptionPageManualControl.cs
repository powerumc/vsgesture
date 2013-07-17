using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Reflection;
using System.Resources;

namespace Umc.Core.Tools.VSGesture.OptionPages
{
	public partial class OptionPageManualControl : UserControl
	{
		public OptionPageManualControl()
		{
			InitializeComponent();
		}

		protected override void OnLoad(EventArgs e)
		{
			base.OnLoad(e);

			Assembly assem = Assembly.GetExecutingAssembly();
			
			picSample.Image			= ImageResources.Sample;

			picRight.Image			= ImageResources.Right;
			picLeft.Image			= ImageResources.Left;
			picUp.Image				= ImageResources.Up;
			picDown.Image			= ImageResources.Down;
			picDownRight.Image		= ImageResources.DownRight;
			picUpRight.Image		= ImageResources.UpRight;
			picScratch.Image		= ImageResources.ScratchOut;
			picCircle.Image			= ImageResources.Circle;
			picDoubleCircle.Image	= ImageResources.DoubleCircle;
		}
	}
}
