namespace Umc.Core.Tools.VSGesture.OptionPages
{
	partial class OptionPageDefaultControl
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
			this.lineWeightPicker = new Umc.Core.Tools.VSGesture.Controls.LineWeightPicker();
			this.colorPicker = new Umc.Core.Tools.VSGesture.Controls.ColorPicker();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.label2 = new System.Windows.Forms.Label();
			this.label1 = new System.Windows.Forms.Label();
			this.chkEnabled = new System.Windows.Forms.CheckBox();
			this.label3 = new System.Windows.Forms.Label();
			this.chkAlarm = new System.Windows.Forms.CheckBox();
			this.groupBox1.SuspendLayout();
			this.SuspendLayout();
			// 
			// lineWeightPicker
			// 
			this.lineWeightPicker.BackColor = System.Drawing.SystemColors.Window;
			this.lineWeightPicker.Context = null;
			this.lineWeightPicker.ForeColor = System.Drawing.SystemColors.WindowText;
			this.lineWeightPicker.Location = new System.Drawing.Point(133, 53);
			this.lineWeightPicker.Name = "lineWeightPicker";
			this.lineWeightPicker.ReadOnly = false;
			this.lineWeightPicker.Size = new System.Drawing.Size(172, 21);
			this.lineWeightPicker.TabIndex = 0;
			this.lineWeightPicker.Text = "Thickness5";
			this.lineWeightPicker.Value = Umc.Core.Tools.VSGesture.Controls.LineThicknessStyle.Thickness5;
			// 
			// colorPicker
			// 
			this.colorPicker.BackColor = System.Drawing.SystemColors.Window;
			this.colorPicker.Context = null;
			this.colorPicker.ForeColor = System.Drawing.SystemColors.WindowText;
			this.colorPicker.Location = new System.Drawing.Point(133, 17);
			this.colorPicker.Name = "colorPicker";
			this.colorPicker.ReadOnly = false;
			this.colorPicker.Size = new System.Drawing.Size(172, 21);
			this.colorPicker.TabIndex = 1;
			this.colorPicker.Text = "White";
			this.colorPicker.Value = System.Drawing.Color.White;
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.label2);
			this.groupBox1.Controls.Add(this.label1);
			this.groupBox1.Controls.Add(this.lineWeightPicker);
			this.groupBox1.Controls.Add(this.colorPicker);
			this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
			this.groupBox1.Location = new System.Drawing.Point(0, 0);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(508, 91);
			this.groupBox1.TabIndex = 2;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "Draw Mode";
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(7, 56);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(114, 12);
			this.label2.TabIndex = 2;
			this.label2.Text = "Drawing Thickness";
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(7, 21);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(85, 12);
			this.label1.TabIndex = 2;
			this.label1.Text = "Drawing Color";
			// 
			// chkEnabled
			// 
			this.chkEnabled.AutoSize = true;
			this.chkEnabled.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
			this.chkEnabled.Location = new System.Drawing.Point(9, 108);
			this.chkEnabled.Name = "chkEnabled";
			this.chkEnabled.Size = new System.Drawing.Size(127, 16);
			this.chkEnabled.TabIndex = 3;
			this.chkEnabled.Text = "Enable VSGesture";
			this.chkEnabled.UseVisualStyleBackColor = true;
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(7, 276);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(389, 12);
			this.label3.TabIndex = 2;
			this.label3.Text = "Notice: If it change enable property, apply new documents instants.";
			// 
			// chkAlarm
			// 
			this.chkAlarm.AutoSize = true;
			this.chkAlarm.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
			this.chkAlarm.Location = new System.Drawing.Point(9, 130);
			this.chkAlarm.Name = "chkAlarm";
			this.chkAlarm.Size = new System.Drawing.Size(164, 16);
			this.chkAlarm.TabIndex = 3;
			this.chkAlarm.Text = "Enable VSGesture Alarm";
			this.chkAlarm.UseVisualStyleBackColor = true;
			// 
			// OptionPageDefaultControl
			// 
			this.Controls.Add(this.label3);
			this.Controls.Add(this.chkAlarm);
			this.Controls.Add(this.chkEnabled);
			this.Controls.Add(this.groupBox1);
			this.Name = "OptionPageDefaultControl";
			this.Size = new System.Drawing.Size(508, 318);
			this.groupBox1.ResumeLayout(false);
			this.groupBox1.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

}

		#endregion

		internal Umc.Core.Tools.VSGesture.Controls.LineWeightPicker lineWeightPicker;
		internal Umc.Core.Tools.VSGesture.Controls.ColorPicker colorPicker;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label1;
		internal System.Windows.Forms.CheckBox chkEnabled;
		private System.Windows.Forms.Label label3;
		internal System.Windows.Forms.CheckBox chkAlarm;

	}
}
