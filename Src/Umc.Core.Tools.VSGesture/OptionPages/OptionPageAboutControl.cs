using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;

namespace Umc.Core.Tools.VSGesture.OptionPages
{
	public partial class OptionPageAboutControl : UserControl
	{
		public OptionPageAboutControl()
		{
			InitializeComponent();
		}

		private void lnkBlog_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
		{
			Process.Start("explorer", "http://blog.powerumc.kr");
		}

		private void lnkEmail_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
		{
			Process.Start("explorer", "mailto:umc@dotnetxpert.com");
		}

		private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
		{
			Process.Start("explorer", "http://dotnetxpert.com");
		}
	}
}
