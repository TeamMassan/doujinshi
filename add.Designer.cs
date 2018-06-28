namespace 同人誌管理 {
    partial class add {
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
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).BeginInit();
            this.place.SuspendLayout();
            this.ageLimit.SuspendLayout();
            this.SuspendLayout();
            // 
            // dealing
            // 
            this.dealing.Text = "登録";
            this.dealing.Click += new System.EventHandler(this.dealing_Click);
            // 
            // add
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.ClientSize = new System.Drawing.Size(619, 571);
            this.Name = "add";
            this.Text = "新規追加";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).EndInit();
            this.place.ResumeLayout(false);
            this.place.PerformLayout();
            this.ageLimit.ResumeLayout(false);
            this.ageLimit.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
    }
}
