namespace WindowsFormsControlLibrary
{
    partial class UCBoneEdit
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

        #region 组件设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.Button btnPX;
            this.label1 = new System.Windows.Forms.Label();
            this.lbBoneName = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.NudSX = new System.Windows.Forms.NumericUpDown();
            this.NudSY = new System.Windows.Forms.NumericUpDown();
            this.NudSZ = new System.Windows.Forms.NumericUpDown();
            this.NudRZ = new System.Windows.Forms.NumericUpDown();
            this.NudRY = new System.Windows.Forms.NumericUpDown();
            this.NudRX = new System.Windows.Forms.NumericUpDown();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.NudPZ = new System.Windows.Forms.NumericUpDown();
            this.NudPY = new System.Windows.Forms.NumericUpDown();
            this.NudPX = new System.Windows.Forms.NumericUpDown();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.lbBoneTranslateName = new System.Windows.Forms.Label();
            this.rTxtDes = new System.Windows.Forms.RichTextBox();
            this.btnSX = new System.Windows.Forms.Button();
            this.btnSZ = new System.Windows.Forms.Button();
            this.btnSY = new System.Windows.Forms.Button();
            this.btnRY = new System.Windows.Forms.Button();
            this.btnRZ = new System.Windows.Forms.Button();
            this.btnRX = new System.Windows.Forms.Button();
            this.btnPY = new System.Windows.Forms.Button();
            this.btnPZ = new System.Windows.Forms.Button();
            btnPX = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.NudSX)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.NudSY)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.NudSZ)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.NudRZ)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.NudRY)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.NudRX)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.NudPZ)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.NudPY)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.NudPX)).BeginInit();
            this.SuspendLayout();
            // 
            // btnPX
            // 
            btnPX.Location = new System.Drawing.Point(169, 209);
            btnPX.Name = "btnPX";
            btnPX.Size = new System.Drawing.Size(37, 23);
            btnPX.TabIndex = 31;
            btnPX.Text = "默认";
            btnPX.UseVisualStyleBackColor = true;
            btnPX.Click += new System.EventHandler(this.BtnPX_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(27, 45);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(29, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "缩放";
            // 
            // lbBoneName
            // 
            this.lbBoneName.AutoSize = true;
            this.lbBoneName.Location = new System.Drawing.Point(3, 0);
            this.lbBoneName.Name = "lbBoneName";
            this.lbBoneName.Size = new System.Drawing.Size(65, 12);
            this.lbBoneName.TabIndex = 1;
            this.lbBoneName.Text = "lbBoneName";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(62, 46);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(11, 12);
            this.label2.TabIndex = 2;
            this.label2.Text = "x";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(62, 75);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(11, 12);
            this.label3.TabIndex = 3;
            this.label3.Text = "y";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(62, 104);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(11, 12);
            this.label4.TabIndex = 4;
            this.label4.Text = "z";
            // 
            // NudSX
            // 
            this.NudSX.DecimalPlaces = 3;
            this.NudSX.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.NudSX.Location = new System.Drawing.Point(75, 37);
            this.NudSX.Minimum = new decimal(new int[] {
            100,
            0,
            0,
            -2147483648});
            this.NudSX.Name = "NudSX";
            this.NudSX.Size = new System.Drawing.Size(79, 21);
            this.NudSX.TabIndex = 6;
            this.NudSX.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.NudSX.ValueChanged += new System.EventHandler(this.NudSX_ValueChanged);
            // 
            // NudSY
            // 
            this.NudSY.DecimalPlaces = 3;
            this.NudSY.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.NudSY.Location = new System.Drawing.Point(75, 66);
            this.NudSY.Minimum = new decimal(new int[] {
            100,
            0,
            0,
            -2147483648});
            this.NudSY.Name = "NudSY";
            this.NudSY.Size = new System.Drawing.Size(79, 21);
            this.NudSY.TabIndex = 7;
            this.NudSY.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.NudSY.ValueChanged += new System.EventHandler(this.NudSY_ValueChanged);
            // 
            // NudSZ
            // 
            this.NudSZ.DecimalPlaces = 3;
            this.NudSZ.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.NudSZ.Location = new System.Drawing.Point(75, 95);
            this.NudSZ.Minimum = new decimal(new int[] {
            100,
            0,
            0,
            -2147483648});
            this.NudSZ.Name = "NudSZ";
            this.NudSZ.Size = new System.Drawing.Size(79, 21);
            this.NudSZ.TabIndex = 8;
            this.NudSZ.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.NudSZ.ValueChanged += new System.EventHandler(this.NudSZ_ValueChanged);
            // 
            // NudRZ
            // 
            this.NudRZ.DecimalPlaces = 2;
            this.NudRZ.Increment = new decimal(new int[] {
            5,
            0,
            0,
            65536});
            this.NudRZ.Location = new System.Drawing.Point(75, 181);
            this.NudRZ.Maximum = new decimal(new int[] {
            360,
            0,
            0,
            0});
            this.NudRZ.Minimum = new decimal(new int[] {
            360,
            0,
            0,
            -2147483648});
            this.NudRZ.Name = "NudRZ";
            this.NudRZ.Size = new System.Drawing.Size(79, 21);
            this.NudRZ.TabIndex = 15;
            this.NudRZ.ValueChanged += new System.EventHandler(this.NudRZ_ValueChanged);
            // 
            // NudRY
            // 
            this.NudRY.DecimalPlaces = 2;
            this.NudRY.Increment = new decimal(new int[] {
            5,
            0,
            0,
            65536});
            this.NudRY.Location = new System.Drawing.Point(75, 152);
            this.NudRY.Maximum = new decimal(new int[] {
            360,
            0,
            0,
            0});
            this.NudRY.Minimum = new decimal(new int[] {
            360,
            0,
            0,
            -2147483648});
            this.NudRY.Name = "NudRY";
            this.NudRY.Size = new System.Drawing.Size(79, 21);
            this.NudRY.TabIndex = 14;
            this.NudRY.ValueChanged += new System.EventHandler(this.NudRY_ValueChanged);
            // 
            // NudRX
            // 
            this.NudRX.DecimalPlaces = 2;
            this.NudRX.Increment = new decimal(new int[] {
            5,
            0,
            0,
            65536});
            this.NudRX.Location = new System.Drawing.Point(75, 125);
            this.NudRX.Maximum = new decimal(new int[] {
            360,
            0,
            0,
            0});
            this.NudRX.Minimum = new decimal(new int[] {
            360,
            0,
            0,
            -2147483648});
            this.NudRX.Name = "NudRX";
            this.NudRX.Size = new System.Drawing.Size(79, 21);
            this.NudRX.TabIndex = 13;
            this.NudRX.ValueChanged += new System.EventHandler(this.NudRX_ValueChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(62, 190);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(11, 12);
            this.label5.TabIndex = 12;
            this.label5.Text = "z";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(62, 161);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(11, 12);
            this.label6.TabIndex = 11;
            this.label6.Text = "y";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(62, 134);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(11, 12);
            this.label7.TabIndex = 10;
            this.label7.Text = "x";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(27, 133);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(29, 12);
            this.label8.TabIndex = 9;
            this.label8.Text = "旋转";
            // 
            // NudPZ
            // 
            this.NudPZ.DecimalPlaces = 3;
            this.NudPZ.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.NudPZ.Location = new System.Drawing.Point(75, 269);
            this.NudPZ.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.NudPZ.Minimum = new decimal(new int[] {
            10000,
            0,
            0,
            -2147483648});
            this.NudPZ.Name = "NudPZ";
            this.NudPZ.Size = new System.Drawing.Size(79, 21);
            this.NudPZ.TabIndex = 22;
            this.NudPZ.ValueChanged += new System.EventHandler(this.NudPZ_ValueChanged);
            // 
            // NudPY
            // 
            this.NudPY.DecimalPlaces = 3;
            this.NudPY.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.NudPY.Location = new System.Drawing.Point(75, 240);
            this.NudPY.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.NudPY.Minimum = new decimal(new int[] {
            10000,
            0,
            0,
            -2147483648});
            this.NudPY.Name = "NudPY";
            this.NudPY.Size = new System.Drawing.Size(79, 21);
            this.NudPY.TabIndex = 21;
            this.NudPY.ValueChanged += new System.EventHandler(this.NudPY_ValueChanged);
            // 
            // NudPX
            // 
            this.NudPX.DecimalPlaces = 3;
            this.NudPX.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.NudPX.Location = new System.Drawing.Point(75, 211);
            this.NudPX.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.NudPX.Minimum = new decimal(new int[] {
            10000,
            0,
            0,
            -2147483648});
            this.NudPX.Name = "NudPX";
            this.NudPX.Size = new System.Drawing.Size(79, 21);
            this.NudPX.TabIndex = 20;
            this.NudPX.ValueChanged += new System.EventHandler(this.NudPX_ValueChanged);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(62, 278);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(11, 12);
            this.label9.TabIndex = 19;
            this.label9.Text = "z";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(62, 249);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(11, 12);
            this.label10.TabIndex = 18;
            this.label10.Text = "y";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(62, 220);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(11, 12);
            this.label11.TabIndex = 17;
            this.label11.Text = "x";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(31, 219);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(29, 12);
            this.label12.TabIndex = 16;
            this.label12.Text = "位移";
            // 
            // lbBoneTranslateName
            // 
            this.lbBoneTranslateName.AutoSize = true;
            this.lbBoneTranslateName.Location = new System.Drawing.Point(3, 19);
            this.lbBoneTranslateName.Name = "lbBoneTranslateName";
            this.lbBoneTranslateName.Size = new System.Drawing.Size(119, 12);
            this.lbBoneTranslateName.TabIndex = 23;
            this.lbBoneTranslateName.Text = "lbBoneTranslateName";
            // 
            // rTxtDes
            // 
            this.rTxtDes.BackColor = System.Drawing.SystemColors.Control;
            this.rTxtDes.Location = new System.Drawing.Point(5, 296);
            this.rTxtDes.Name = "rTxtDes";
            this.rTxtDes.ReadOnly = true;
            this.rTxtDes.Size = new System.Drawing.Size(228, 246);
            this.rTxtDes.TabIndex = 24;
            this.rTxtDes.Text = "";
            // 
            // btnSX
            // 
            this.btnSX.Location = new System.Drawing.Point(169, 37);
            this.btnSX.Name = "btnSX";
            this.btnSX.Size = new System.Drawing.Size(37, 23);
            this.btnSX.TabIndex = 25;
            this.btnSX.Text = "默认";
            this.btnSX.UseVisualStyleBackColor = true;
            this.btnSX.Click += new System.EventHandler(this.BtnSX_Click);
            // 
            // btnSZ
            // 
            this.btnSZ.Location = new System.Drawing.Point(169, 95);
            this.btnSZ.Name = "btnSZ";
            this.btnSZ.Size = new System.Drawing.Size(37, 23);
            this.btnSZ.TabIndex = 26;
            this.btnSZ.Text = "默认";
            this.btnSZ.UseVisualStyleBackColor = true;
            this.btnSZ.Click += new System.EventHandler(this.BtnSZ_Click);
            // 
            // btnSY
            // 
            this.btnSY.Location = new System.Drawing.Point(169, 66);
            this.btnSY.Name = "btnSY";
            this.btnSY.Size = new System.Drawing.Size(37, 23);
            this.btnSY.TabIndex = 27;
            this.btnSY.Text = "默认";
            this.btnSY.UseVisualStyleBackColor = true;
            this.btnSY.Click += new System.EventHandler(this.BtnSY_Click);
            // 
            // btnRY
            // 
            this.btnRY.Location = new System.Drawing.Point(169, 151);
            this.btnRY.Name = "btnRY";
            this.btnRY.Size = new System.Drawing.Size(37, 23);
            this.btnRY.TabIndex = 30;
            this.btnRY.Text = "默认";
            this.btnRY.UseVisualStyleBackColor = true;
            this.btnRY.Click += new System.EventHandler(this.BtnRY_Click);
            // 
            // btnRZ
            // 
            this.btnRZ.Location = new System.Drawing.Point(169, 180);
            this.btnRZ.Name = "btnRZ";
            this.btnRZ.Size = new System.Drawing.Size(37, 23);
            this.btnRZ.TabIndex = 29;
            this.btnRZ.Text = "默认";
            this.btnRZ.UseVisualStyleBackColor = true;
            this.btnRZ.Click += new System.EventHandler(this.BtnRZ_Click);
            // 
            // btnRX
            // 
            this.btnRX.Location = new System.Drawing.Point(169, 124);
            this.btnRX.Name = "btnRX";
            this.btnRX.Size = new System.Drawing.Size(37, 23);
            this.btnRX.TabIndex = 28;
            this.btnRX.Text = "默认";
            this.btnRX.UseVisualStyleBackColor = true;
            this.btnRX.Click += new System.EventHandler(this.BtnRX_Click);
            // 
            // btnPY
            // 
            this.btnPY.Location = new System.Drawing.Point(169, 238);
            this.btnPY.Name = "btnPY";
            this.btnPY.Size = new System.Drawing.Size(37, 23);
            this.btnPY.TabIndex = 33;
            this.btnPY.Text = "默认";
            this.btnPY.UseVisualStyleBackColor = true;
            this.btnPY.Click += new System.EventHandler(this.BtnPY_Click);
            // 
            // btnPZ
            // 
            this.btnPZ.Location = new System.Drawing.Point(169, 267);
            this.btnPZ.Name = "btnPZ";
            this.btnPZ.Size = new System.Drawing.Size(37, 23);
            this.btnPZ.TabIndex = 32;
            this.btnPZ.Text = "默认";
            this.btnPZ.UseVisualStyleBackColor = true;
            this.btnPZ.Click += new System.EventHandler(this.BtnPZ_Click);
            // 
            // UCBoneEdit
            // 
            this.Controls.Add(this.btnPY);
            this.Controls.Add(this.btnPZ);
            this.Controls.Add(btnPX);
            this.Controls.Add(this.btnRY);
            this.Controls.Add(this.btnRZ);
            this.Controls.Add(this.btnRX);
            this.Controls.Add(this.btnSY);
            this.Controls.Add(this.btnSZ);
            this.Controls.Add(this.btnSX);
            this.Controls.Add(this.rTxtDes);
            this.Controls.Add(this.lbBoneTranslateName);
            this.Controls.Add(this.NudPZ);
            this.Controls.Add(this.NudPY);
            this.Controls.Add(this.NudPX);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.NudRZ);
            this.Controls.Add(this.NudRY);
            this.Controls.Add(this.NudRX);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.NudSZ);
            this.Controls.Add(this.NudSY);
            this.Controls.Add(this.NudSX);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lbBoneName);
            this.Controls.Add(this.label1);
            this.Name = "UCBoneEdit";
            this.Size = new System.Drawing.Size(252, 572);
            ((System.ComponentModel.ISupportInitialize)(this.NudSX)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.NudSY)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.NudSZ)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.NudRZ)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.NudRY)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.NudRX)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.NudPZ)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.NudPY)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.NudPX)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lbBoneName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.NumericUpDown NudSX;
        private System.Windows.Forms.NumericUpDown NudSY;
        private System.Windows.Forms.NumericUpDown NudSZ;
        private System.Windows.Forms.NumericUpDown NudRZ;
        private System.Windows.Forms.NumericUpDown NudRY;
        private System.Windows.Forms.NumericUpDown NudRX;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.NumericUpDown NudPZ;
        private System.Windows.Forms.NumericUpDown NudPY;
        private System.Windows.Forms.NumericUpDown NudPX;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label lbBoneTranslateName;
        private System.Windows.Forms.RichTextBox rTxtDes;
        private System.Windows.Forms.Button btnSX;
        private System.Windows.Forms.Button btnSZ;
        private System.Windows.Forms.Button btnSY;
        private System.Windows.Forms.Button btnRY;
        private System.Windows.Forms.Button btnRZ;
        private System.Windows.Forms.Button btnRX;
        private System.Windows.Forms.Button btnPY;
        private System.Windows.Forms.Button btnPZ;
    }
}
