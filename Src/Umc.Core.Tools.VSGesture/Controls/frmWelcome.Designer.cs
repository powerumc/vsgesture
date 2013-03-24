namespace Umc.Core.Tools.VSGesture.Controls
{
	partial class frmWelcome
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.button1 = new System.Windows.Forms.Button();
			this.lblTitle = new System.Windows.Forms.Label();
			this.pictureBox1 = new System.Windows.Forms.PictureBox();
			this.linkLabel1 = new System.Windows.Forms.LinkLabel();
			this.lblLicense = new System.Windows.Forms.Label();
			((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
			this.SuspendLayout();
			// 
			// button1
			// 
			this.button1.Location = new System.Drawing.Point(354, 247);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(75, 23);
			this.button1.TabIndex = 1;
			this.button1.Text = "Close";
			this.button1.UseVisualStyleBackColor = true;
			this.button1.Click += new System.EventHandler(this.button1_Click);
			// 
			// lblTitle
			// 
			this.lblTitle.AutoSize = true;
			this.lblTitle.BackColor = System.Drawing.Color.Transparent;
			this.lblTitle.Font = new System.Drawing.Font("굴림", 15F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))));
			this.lblTitle.ForeColor = System.Drawing.Color.Red;
			this.lblTitle.Location = new System.Drawing.Point(189, 26);
			this.lblTitle.Name = "lblTitle";
			this.lblTitle.Size = new System.Drawing.Size(115, 20);
			this.lblTitle.TabIndex = 2;
			this.lblTitle.Text = "VSGesture";
			// 
			// pictureBox1
			// 
			this.pictureBox1.Location = new System.Drawing.Point(152, 20);
			this.pictureBox1.Name = "pictureBox1";
			this.pictureBox1.Size = new System.Drawing.Size(40, 36);
			this.pictureBox1.TabIndex = 0;
			this.pictureBox1.TabStop = false;
			// 
			// linkLabel1
			// 
			this.linkLabel1.AutoSize = true;
			this.linkLabel1.Location = new System.Drawing.Point(1, 252);
			this.linkLabel1.Name = "linkLabel1";
			this.linkLabel1.Size = new System.Drawing.Size(79, 12);
			this.linkLabel1.TabIndex = 3;
			this.linkLabel1.TabStop = true;
			this.linkLabel1.Text = "Click for help";
			this.linkLabel1.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel1_LinkClicked);
			// 
			// lblLicense
			// 
			this.lblLicense.AutoSize = true;
			this.lblLicense.Font = new System.Drawing.Font("굴림", 10F);
			this.lblLicense.Location = new System.Drawing.Point(12, 110);
			this.lblLicense.Name = "lblLicense";
			this.lblLicense.Size = new System.Drawing.Size(45, 14);
			this.lblLicense.TabIndex = 4;
			this.lblLicense.Text = "label1";
			// 
			// frmWelcome
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.Color.Pink;
			this.ClientSize = new System.Drawing.Size(429, 273);
			this.Controls.Add(this.lblLicense);
			this.Controls.Add(this.linkLabel1);
			this.Controls.Add(this.pictureBox1);
			this.Controls.Add(this.lblTitle);
			this.Controls.Add(this.button1);
			this.DoubleBuffered = true;
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
			this.Name = "frmWelcome";
			this.Opacity = 0.5;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.TopMost = true;
			this.Load += new System.EventHandler(this.frmWelcome_Load);
			((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Button button1;
		private System.Windows.Forms.Label lblTitle;
		private System.Windows.Forms.PictureBox pictureBox1;
		private System.Windows.Forms.LinkLabel linkLabel1;
		private System.Windows.Forms.Label lblLicense;
	}
}