namespace 同人誌管理 {
    partial class update2 {
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
            this.readRight = new System.Windows.Forms.Button();
            this.readLeft = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).BeginInit();
            this.place.SuspendLayout();
            this.ageLimit.SuspendLayout();
            this.SuspendLayout();
            // 
            // dealing
            // 
            this.dealing.Text = "更新";
            this.dealing.Click += new System.EventHandler(this.dealing_Click);
            // 
            // readRight
            // 
            this.readRight.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.readRight.Location = new System.Drawing.Point(249, 563);
            this.readRight.Name = "readRight";
            this.readRight.Size = new System.Drawing.Size(35, 23);
            this.readRight.TabIndex = 95;
            this.readRight.Text = "→";
            this.readRight.UseVisualStyleBackColor = true;
            this.readRight.Click += new System.EventHandler(this.readRight_Click);
            // 
            // readLeft
            // 
            this.readLeft.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.readLeft.Location = new System.Drawing.Point(208, 563);
            this.readLeft.Name = "readLeft";
            this.readLeft.Size = new System.Drawing.Size(35, 23);
            this.readLeft.TabIndex = 94;
            this.readLeft.Text = "←";
            this.readLeft.UseVisualStyleBackColor = true;
            this.readLeft.Click += new System.EventHandler(this.readLeft_Click);
            // 
            // update2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.ClientSize = new System.Drawing.Size(619, 607);
            this.Controls.Add(this.readRight);
            this.Controls.Add(this.readLeft);
            this.Name = "update2";
            this.Load += new System.EventHandler(this.update2_Load);
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
            this.Controls.SetChildIndex(this.place, 0);
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
            this.Controls.SetChildIndex(this.readLeft, 0);
            this.Controls.SetChildIndex(this.readRight, 0);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).EndInit();
            this.place.ResumeLayout(false);
            this.place.PerformLayout();
            this.ageLimit.ResumeLayout(false);
            this.ageLimit.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button readRight;
        private System.Windows.Forms.Button readLeft;
    }
}
