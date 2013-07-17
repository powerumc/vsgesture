namespace Umc.Core.Tools.VSGesture.OptionPages
{
	partial class OptionPageMouseActionControl
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
			this.SuspendLayout();
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(124, 77);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(256, 12);
			this.label1.TabIndex = 0;
			this.label1.Text = "This function will be supported next version.";
			// 
			// OptionPageMouseActionControl
			// 
			this.Controls.Add(this.label1);
			this.Name = "OptionPageMouseActionControl";
			this.Size = new System.Drawing.Size(499, 295);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Label label1;



	}
}
