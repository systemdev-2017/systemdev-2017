﻿namespace WindowsFormsApplication1
{
    partial class MemberMgt
    {
        /// <summary> 
        /// 必要なデザイナー変数です。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// 使用中のリソースをすべてクリーンアップします。
        /// </summary>
        /// <param name="disposing">マネージ リソースが破棄される場合 true、破棄されない場合は false です。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region コンポーネント デザイナーで生成されたコード

        /// <summary> 
        /// デザイナー サポートに必要なメソッドです。このメソッドの内容を 
        /// コード エディターで変更しないでください。
        /// </summary>
        private void InitializeComponent()
        {
            this.MemberEditBtn = new System.Windows.Forms.Button();
            this.MemberUpdateBtn = new System.Windows.Forms.Button();
            this.MemberDataGridView = new System.Windows.Forms.DataGridView();
            this.MemberDisBtn = new System.Windows.Forms.Button();
            this.MemberDisLbl = new System.Windows.Forms.Label();
            this.MemberNameTBox = new System.Windows.Forms.TextBox();
            this.MemberNameLbl = new System.Windows.Forms.Label();
            this.PrintBtn = new System.Windows.Forms.Button();
            this.MemberEditLbl = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.MemberDataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // MemberEditBtn
            // 
            this.MemberEditBtn.Location = new System.Drawing.Point(621, 437);
            this.MemberEditBtn.Name = "MemberEditBtn";
            this.MemberEditBtn.Size = new System.Drawing.Size(122, 36);
            this.MemberEditBtn.TabIndex = 55;
            this.MemberEditBtn.Text = "編集";
            this.MemberEditBtn.UseVisualStyleBackColor = true;
            this.MemberEditBtn.Click += new System.EventHandler(this.MemberEditBtn_Click_1);
            // 
            // MemberUpdateBtn
            // 
            this.MemberUpdateBtn.Location = new System.Drawing.Point(621, 395);
            this.MemberUpdateBtn.Name = "MemberUpdateBtn";
            this.MemberUpdateBtn.Size = new System.Drawing.Size(122, 36);
            this.MemberUpdateBtn.TabIndex = 56;
            this.MemberUpdateBtn.Text = "更新";
            this.MemberUpdateBtn.UseVisualStyleBackColor = true;
            this.MemberUpdateBtn.Visible = false;
            this.MemberUpdateBtn.Click += new System.EventHandler(this.MemberUpdateBtn_Click_1);
            // 
            // MemberDataGridView
            // 
            this.MemberDataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.MemberDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.MemberDataGridView.Location = new System.Drawing.Point(20, 88);
            this.MemberDataGridView.Name = "MemberDataGridView";
            this.MemberDataGridView.ReadOnly = true;
            this.MemberDataGridView.RowTemplate.Height = 21;
            this.MemberDataGridView.Size = new System.Drawing.Size(723, 286);
            this.MemberDataGridView.TabIndex = 57;
            this.MemberDataGridView.TabStop = false;
            // 
            // MemberDisBtn
            // 
            this.MemberDisBtn.Location = new System.Drawing.Point(493, 438);
            this.MemberDisBtn.Name = "MemberDisBtn";
            this.MemberDisBtn.Size = new System.Drawing.Size(122, 36);
            this.MemberDisBtn.TabIndex = 53;
            this.MemberDisBtn.Text = "検索";
            this.MemberDisBtn.UseVisualStyleBackColor = true;
            this.MemberDisBtn.Click += new System.EventHandler(this.MemberDisBtn_Click_1);
            // 
            // MemberDisLbl
            // 
            this.MemberDisLbl.AutoSize = true;
            this.MemberDisLbl.Font = new System.Drawing.Font("MS UI Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.MemberDisLbl.ForeColor = System.Drawing.Color.Red;
            this.MemberDisLbl.Location = new System.Drawing.Point(55, 403);
            this.MemberDisLbl.Name = "MemberDisLbl";
            this.MemberDisLbl.Size = new System.Drawing.Size(103, 16);
            this.MemberDisLbl.TabIndex = 66;
            this.MemberDisLbl.Text = "エラーメッセージ";
            // 
            // MemberNameTBox
            // 
            this.MemberNameTBox.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.MemberNameTBox.Location = new System.Drawing.Point(140, 447);
            this.MemberNameTBox.MaxLength = 30;
            this.MemberNameTBox.Name = "MemberNameTBox";
            this.MemberNameTBox.Size = new System.Drawing.Size(149, 19);
            this.MemberNameTBox.TabIndex = 64;
            // 
            // MemberNameLbl
            // 
            this.MemberNameLbl.AutoSize = true;
            this.MemberNameLbl.Location = new System.Drawing.Point(94, 449);
            this.MemberNameLbl.Name = "MemberNameLbl";
            this.MemberNameLbl.Size = new System.Drawing.Size(42, 12);
            this.MemberNameLbl.TabIndex = 65;
            this.MemberNameLbl.Text = "ﾌﾘｶﾞﾅ：";
            // 
            // PrintBtn
            // 
            this.PrintBtn.Location = new System.Drawing.Point(621, 40);
            this.PrintBtn.Name = "PrintBtn";
            this.PrintBtn.Size = new System.Drawing.Size(122, 36);
            this.PrintBtn.TabIndex = 67;
            this.PrintBtn.Text = "印刷";
            this.PrintBtn.UseVisualStyleBackColor = true;
            this.PrintBtn.Click += new System.EventHandler(this.PrintBtn_Click);
            // 
            // MemberEditLbl
            // 
            this.MemberEditLbl.AutoSize = true;
            this.MemberEditLbl.Font = new System.Drawing.Font("MS UI Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.MemberEditLbl.ForeColor = System.Drawing.Color.Red;
            this.MemberEditLbl.Location = new System.Drawing.Point(528, 403);
            this.MemberEditLbl.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.MemberEditLbl.Name = "MemberEditLbl";
            this.MemberEditLbl.Size = new System.Drawing.Size(56, 16);
            this.MemberEditLbl.TabIndex = 68;
            this.MemberEditLbl.Text = "編集中";
            this.MemberEditLbl.Visible = false;
            // 
            // MemberMgt
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.MemberEditLbl);
            this.Controls.Add(this.PrintBtn);
            this.Controls.Add(this.MemberDisLbl);
            this.Controls.Add(this.MemberNameTBox);
            this.Controls.Add(this.MemberNameLbl);
            this.Controls.Add(this.MemberEditBtn);
            this.Controls.Add(this.MemberUpdateBtn);
            this.Controls.Add(this.MemberDataGridView);
            this.Controls.Add(this.MemberDisBtn);
            this.Name = "MemberMgt";
            this.Size = new System.Drawing.Size(760, 515);
            this.VisibleChanged += new System.EventHandler(this.MemberMgt_VisibleChanged);
            ((System.ComponentModel.ISupportInitialize)(this.MemberDataGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button MemberEditBtn;
        private System.Windows.Forms.Button MemberUpdateBtn;
        private System.Windows.Forms.DataGridView MemberDataGridView;
        private System.Windows.Forms.Button MemberDisBtn;
        private System.Windows.Forms.Label MemberDisLbl;
        private System.Windows.Forms.TextBox MemberNameTBox;
        private System.Windows.Forms.Label MemberNameLbl;
        private System.Windows.Forms.Button PrintBtn;
        private System.Windows.Forms.Label MemberEditLbl;
    }
}
