namespace Umc.Core.Tools.VSGesture.OptionPages
{
	partial class OptionPageAboutControl
	{
		/// <summary> 
		/// 필수 디자이너 변수입니다.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary> 
		/// 사용 중인 모든 리소스를 정리합니다.
		/// </summary>
		/// <param name="disposing">관리되는 리소스를 삭제해야 하면 true이고, 그렇지 않으면 false입니다.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region 구성 요소 디자이너에서 생성한 코드

		/// <summary> 
		/// 디자이너 지원에 필요한 메서드입니다. 
		/// 이 메서드의 내용을 코드 편집기로 수정하지 마십시오.
		/// </summary>
		private void InitializeComponent()
		{
			this.label1 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.lnkBlog = new System.Windows.Forms.LinkLabel();
			this.label3 = new System.Windows.Forms.Label();
			this.lnkEmail = new System.Windows.Forms.LinkLabel();
			this.label4 = new System.Windows.Forms.Label();
			this.linkLabel1 = new System.Windows.Forms.LinkLabel();
			this.SuspendLayout();
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(47, 27);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(152, 12);
			this.label1.TabIndex = 0;
			this.label1.Text = "Author : Junil Um (엄준일)";
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(47, 58);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(42, 12);
			this.label2.TabIndex = 0;
			this.label2.Text = "Blog : ";
			// 
			// lnkBlog
			// 
			this.lnkBlog.AutoSize = true;
			this.lnkBlog.Location = new System.Drawing.Point(96, 57);
			this.lnkBlog.Name = "lnkBlog";
			this.lnkBlog.Size = new System.Drawing.Size(143, 12);
			this.lnkBlog.TabIndex = 1;
			this.lnkBlog.TabStop = true;
			this.lnkBlog.Text = "https://blog.powerumc.kr";
			this.lnkBlog.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkBlog_LinkClicked);
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(47, 87);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(45, 12);
			this.label3.TabIndex = 0;
			this.label3.Text = "Email :";
			// 
			// lnkEmail
			// 
			this.lnkEmail.AutoSize = true;
			this.lnkEmail.Location = new System.Drawing.Point(96, 87);
			this.lnkEmail.Name = "lnkEmail";
			this.lnkEmail.Size = new System.Drawing.Size(133, 12);
			this.lnkEmail.TabIndex = 1;
			this.lnkEmail.TabStop = true;
			this.lnkEmail.Text = "powerumc@gmail.com";
			this.lnkEmail.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkEmail_LinkClicked);
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Location = new System.Drawing.Point(47, 117);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(72, 12);
			this.label4.TabIndex = 0;
			this.label4.Text = "Company : ";
			// 
			// linkLabel1
			// 
			this.linkLabel1.AutoSize = true;
			this.linkLabel1.Location = new System.Drawing.Point(118, 117);
			this.linkLabel1.Name = "linkLabel1";
			this.linkLabel1.Size = new System.Drawing.Size(160, 12);
			this.linkLabel1.TabIndex = 1;
			this.linkLabel1.TabStop = true;
			//this.linkLabel1.Text = ".NETXPERT (닷넷엑스퍼트)";
			this.linkLabel1.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel1_LinkClicked);
			// 
			// OptionPageAboutControl
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this.linkLabel1);
			this.Controls.Add(this.lnkEmail);
			this.Controls.Add(this.lnkBlog);
			this.Controls.Add(this.label4);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.label1);
			this.Name = "OptionPageAboutControl";
			this.Size = new System.Drawing.Size(488, 330);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.LinkLabel lnkBlog;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.LinkLabel lnkEmail;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.LinkLabel linkLabel1;
	}
}
