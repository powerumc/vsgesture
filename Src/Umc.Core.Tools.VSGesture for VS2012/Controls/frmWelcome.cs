using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using Microsoft.VisualStudio.Shell;

namespace Umc.Core.Tools.VSGesture.Controls
{
	public partial class frmWelcome : Form
	{
		public enum FadeAction
		{
			FadeIn,
			FadeOut
		}

		private readonly static double FADE_COUNT = 0.05;
		private delegate void Action();
		private FadeAction fadeMode;
		public FadeAction FadeMode
		{
			get { return fadeMode; }
			set { fadeMode = value; }
		}

		private System.Timers.Timer timer1;

		public frmWelcome()
		{
			InitializeComponent();

			this.pictureBox1.Image = VSPackage._400.ToBitmap();
		}

		private void button1_Click(object sender, EventArgs e)
		{
			SetClose();
		}

		private void frmWelcome_Load(object sender, EventArgs e)
		{
			timer1 = new System.Timers.Timer();
			timer1.Interval	= 30;
			timer1.Elapsed += new System.Timers.ElapsedEventHandler(timer1_Elapsed);

			this.lblLicense.Text	= ". Umc.Core 의 모든 저작권은 www.powerumc.kr 에 있습니다.\r\n"
									+ ". Umc.Core 는 개인적인 용도로 사용 가능합니다.\r\n"
									+ ". 본 프로그램은 다른 곳에서 재배포를 할 수 없습니다.\r\n"
									+ ". 상업적인 목적으로 사용할 수 없습니다.\r\n";

			Action<FadeAction> fadeInHandler = new Action<FadeAction>(Fade);
			IAsyncResult result = fadeInHandler.BeginInvoke(FadeAction.FadeIn, null, fadeInHandler);
		}

		private void Fade(FadeAction mode)
		{
			this.FadeMode = mode;
			timer1.Start();
		}

		private double formOpacity	= 0;
		void timer1_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
		{
			switch (FadeMode)
			{
				case FadeAction.FadeIn:
					if (this.formOpacity >= 1)
					{
						timer1.Stop();

						Thread.Sleep(5000);

						Action<FadeAction> fadeInHandler = new Action<FadeAction>(Fade);
						IAsyncResult result = fadeInHandler.BeginInvoke(FadeAction.FadeOut, null, fadeInHandler);
						return;
					}
					else
					{
						this.formOpacity += FADE_COUNT;
						SetOpacity(formOpacity);
					}

					break;


				case FadeAction.FadeOut:
					if (this.formOpacity <= 0)
					{
						timer1.Stop();
						SetClose();
						return;
					}
					else
					{
						this.formOpacity -= FADE_COUNT;
						SetOpacity(formOpacity);
					}

					break;
			}
		}

		private void SetOpacity(double opacity)
		{
			if (this.InvokeRequired)
			{
				try
				{
					Invoke(new Action<double>(SetOpacity), opacity);
				}
				catch { }
			}
			else
			{
				this.Opacity	= opacity;
			}
		}

		private void SetClose()
		{
			if (this.InvokeRequired)
			{
				try
				{
					Invoke(new Action(SetClose));
				}
				catch { }
			}
			else
			{
				this.Close();
			}
		}

		private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
		{
			VSGesture.Services.VSGestureService.Current.ShowOptionPage();
		}
	}
}
