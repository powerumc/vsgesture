using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.VisualStudio.Shell;
using System.Drawing;
using Umc.Core.Tools.VSGesture.Controls;
using Umc.Core.Tools.VSGesture.Services;
using Umc.Core.Tools.VSGesture.Actions;

namespace Umc.Core.Tools.VSGesture.OptionPages
{
	public class OptionPageDefault : DialogPage
	{
		private OptionPageDefaultControl control;

		public OptionPageDefault()
		{
			control = new OptionPageDefaultControl();
		}

		protected override System.Windows.Forms.IWin32Window Window
		{
			get
			{
				return control;
			}
		}

		protected override void OnApply(PageApplyEventArgs e)
		{
			base.OnApply(e);

			try
			{
				Color color = this.control.colorPicker.Value;
				string colorString = string.Format("{0},{1},{2}", color.R, color.G, color.B);

				VSGestureInfo info = VSGestureService.Current.VSGestureInfo;
				info.UserSettings.LineColor = colorString;
				info.UserSettings.LineThickness = this.control.lineWeightPicker.Value.ToString();

				info.UserSettings.EnableVSGesture = this.control.chkEnabled.Checked;
				info.UserSettings.EnableVSGestureAlram = this.control.chkAlarm.Checked;

				VSGestureService.Current.VSGestureInfo = info;
			}
			catch (Exception ex)
			{
			}
		}

		protected override void OnActivate(System.ComponentModel.CancelEventArgs e)
		{
			base.OnActivate(e);

			try
			{
				string[] rgb = VSGestureService.Current.VSGestureInfo.UserSettings.LineColor.Split(',');
				Color lineColor = Color.FromArgb(int.Parse(rgb[0]),
													int.Parse(rgb[1]),
													int.Parse(rgb[2]));
				string lineThicknessString = VSGestureService.Current.VSGestureInfo.UserSettings.LineThickness;
				LineThicknessStyle lineThickness = (LineThicknessStyle)Enum.Parse(typeof(LineThicknessStyle), lineThicknessString);

				this.control.colorPicker.Value = lineColor;
				this.control.lineWeightPicker.Value = lineThickness;
				this.control.chkEnabled.Checked = VSGestureService.Current.VSGestureInfo.UserSettings.EnableVSGesture;
				this.control.chkAlarm.Checked	= VSGestureService.Current.VSGestureInfo.UserSettings.EnableVSGestureAlram;
			}
			catch (Exception ex)
			{
				
			}
		}
	}
}
