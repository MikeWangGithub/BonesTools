namespace WindowsFormsControlLibrary
{
    partial class UCBonePreview
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.lbBoneTranslateName = new System.Windows.Forms.Label();
            this.lbBoneName = new System.Windows.Forms.Label();
            this.lbScaling = new System.Windows.Forms.Label();
            this.lbRotation = new System.Windows.Forms.Label();
            this.lbPositioning = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lbBoneTranslateName
            // 
            this.lbBoneTranslateName.AutoSize = true;
            this.lbBoneTranslateName.Location = new System.Drawing.Point(4, 7);
            this.lbBoneTranslateName.Name = "lbBoneTranslateName";
            this.lbBoneTranslateName.Size = new System.Drawing.Size(83, 12);
            this.lbBoneTranslateName.TabIndex = 0;
            this.lbBoneTranslateName.Text = "TranslateName";
            // 
            // lbBoneName
            // 
            this.lbBoneName.AutoSize = true;
            this.lbBoneName.Location = new System.Drawing.Point(126, 7);
            this.lbBoneName.Name = "lbBoneName";
            this.lbBoneName.Size = new System.Drawing.Size(29, 12);
            this.lbBoneName.TabIndex = 1;
            this.lbBoneName.Text = "Name";
            // 
            // lbScaling
            // 
            this.lbScaling.AutoSize = true;
            this.lbScaling.Location = new System.Drawing.Point(200, 7);
            this.lbScaling.Name = "lbScaling";
            this.lbScaling.Size = new System.Drawing.Size(47, 12);
            this.lbScaling.TabIndex = 2;
            this.lbScaling.Text = "Scaling";
            // 
            // lbRotation
            // 
            this.lbRotation.AutoSize = true;
            this.lbRotation.Location = new System.Drawing.Point(268, 7);
            this.lbRotation.Name = "lbRotation";
            this.lbRotation.Size = new System.Drawing.Size(53, 12);
            this.lbRotation.TabIndex = 3;
            this.lbRotation.Text = "Rotation";
            // 
            // lbPositioning
            // 
            this.lbPositioning.AutoSize = true;
            this.lbPositioning.Location = new System.Drawing.Point(327, 7);
            this.lbPositioning.Name = "lbPositioning";
            this.lbPositioning.Size = new System.Drawing.Size(71, 12);
            this.lbPositioning.TabIndex = 4;
            this.lbPositioning.Text = "Positioning";
            // 
            // UCBonePreview
            // 
            this.Controls.Add(this.lbPositioning);
            this.Controls.Add(this.lbRotation);
            this.Controls.Add(this.lbScaling);
            this.Controls.Add(this.lbBoneName);
            this.Controls.Add(this.lbBoneTranslateName);
            this.Name = "UCBonePreview";
            this.Size = new System.Drawing.Size(403, 26);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbBoneTranslateName;
        private System.Windows.Forms.Label lbBoneName;
        private System.Windows.Forms.Label lbScaling;
        private System.Windows.Forms.Label lbRotation;
        private System.Windows.Forms.Label lbPositioning;
    }
}
