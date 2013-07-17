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
			Process.Start("explorer", "http://www.powerumc.kr");
		}

		private void lnkEmail_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
		{
			Process.Start("explorer", "mailto:powerumc@gmail.com");
		}

        private void linkLabel1_LinkClicked_1(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start("explorer", "http://blog.powerumc.kr");
        }
	}
}
