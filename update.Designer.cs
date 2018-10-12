namespace 同人誌管理 {
    partial class update {
        /// <summary>
        /// 必要なデザイナー変数です。
        /// </summary>
        private new System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 使用中のリソースをすべてクリーンアップします。
        /// </summary>
        /// <param name="disposing">マネージ リソースを破棄する場合は true を指定し、その他の場合は false を指定します。</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows フォーム デザイナーで生成されたコード

        /// <summary>
        /// デザイナー サポートに必要なメソッドです。このメソッドの内容を
        /// コード エディターで変更しないでください。
        /// </summary>
        private new void InitializeComponent() {
            this.readDown = new System.Windows.Forms.Button();
            this.readUp = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).BeginInit();
            this.ageLimit.SuspendLayout();
            this.SuspendLayout();
            // 
            // label13
            // 
            this.label13.TabIndex = 17;
            // 
            // ageLimit
            // 
            this.ageLimit.TabIndex = 19;
            // 
            // close
            // 
            this.close.TabIndex = 31;
            // 
            // dealing
            // 
            this.dealing.TabIndex = 30;
            this.dealing.Text = "更新";
            this.dealing.Click += new System.EventHandler(this.dealing_Click);
            // 
            // label6
            // 
            this.label6.TabIndex = 18;
            // 
            // readDown
            // 
            this.readDown.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.readDown.Location = new System.Drawing.Point(249, 563);
            this.readDown.Name = "readDown";
            this.readDown.Size = new System.Drawing.Size(35, 23);
            this.readDown.TabIndex = 29;
            this.readDown.Text = "↓";
            this.readDown.UseVisualStyleBackColor = true;
            this.readDown.Click += new System.EventHandler(this.readDown_Click);
            // 
            // readUp
            // 
            this.readUp.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.readUp.Location = new System.Drawing.Point(208, 563);
            this.readUp.Name = "readUp";
            this.readUp.Size = new System.Drawing.Size(35, 23);
            this.readUp.TabIndex = 28;
            this.readUp.Text = "↑";
            this.readUp.UseVisualStyleBackColor = true;
            this.readUp.Click += new System.EventHandler(this.readUp_Click);
            // 
            // update
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.ClientSize = new System.Drawing.Size(619, 607);
            this.Controls.Add(this.readDown);
            this.Controls.Add(this.readUp);
            this.Name = "update";
            this.Load += new System.EventHandler(this.update_Load);
            this.Controls.SetChildIndex(this.storage, 0);
            this.Controls.SetChildIndex(this.label1, 0);
            this.Controls.SetChildIndex(this.label2, 0);
            this.Controls.SetChildIndex(this.label3, 0);
            this.Controls.SetChildIndex(this.label4, 0);
            this.Controls.SetChildIndex(this.label5, 0);
            this.Controls.SetChildIndex(this.label6, 0);
            this.Controls.SetChildIndex(this.label7, 0);
            this.Controls.SetChildIndex(this.label8, 0);
            this.Controls.SetChildIndex(this.label9, 0);
            this.Controls.SetChildIndex(this.titleForm, 0);
            this.Controls.SetChildIndex(this.circleForm, 0);
            this.Controls.SetChildIndex(this.authorsForm, 0);
            this.Controls.SetChildIndex(this.mainChara, 0);
            this.Controls.SetChildIndex(this.idForm, 0);
            this.Controls.SetChildIndex(this.dealing, 0);
            this.Controls.SetChildIndex(this.close, 0);
            this.Controls.SetChildIndex(this.ageLimit, 0);
            this.Controls.SetChildIndex(this.originComboBox, 0);
            this.Controls.SetChildIndex(this.genreComboBox, 0);
            this.Controls.SetChildIndex(this.label10, 0);
            this.Controls.SetChildIndex(this.yearForm, 0);
            this.Controls.SetChildIndex(this.label11, 0);
            this.Controls.SetChildIndex(this.monthForm, 0);
            this.Controls.SetChildIndex(this.label12, 0);
            this.Controls.SetChildIndex(this.dayForm, 0);
            this.Controls.SetChildIndex(this.label13, 0);
            this.Controls.SetChildIndex(this.pictureBox, 0);
            this.Controls.SetChildIndex(this.openThumbnailBottun, 0);
            this.Controls.SetChildIndex(this.label14, 0);
            this.Controls.SetChildIndex(this.bookShelf, 0);
            this.Controls.SetChildIndex(this.readUp, 0);
            this.Controls.SetChildIndex(this.readDown, 0);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).EndInit();
            this.ageLimit.ResumeLayout(false);
            this.ageLimit.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button readDown;
        private System.Windows.Forms.Button readUp;
    }
}
