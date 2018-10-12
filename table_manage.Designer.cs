namespace 同人誌管理
{
    partial class table_manage
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

        #region Windows フォーム デザイナーで生成されたコード

        /// <summary>
        /// デザイナー サポートに必要なメソッドです。このメソッドの内容を
        /// コード エディターで変更しないでください。
        /// </summary>
        private void InitializeComponent()
        {
            this.SuspendLayout();
            // 
            // coumn2
            // 
            this.coumn2.Text = "ジャンル名";
            // 
            // column1
            // 
            this.column1.Text = "作品名";
            // 
            // Add2
            // 
            this.Add2.Click += new System.EventHandler(this.Add2_Click);
            // 
            // Add1
            // 
            this.Add1.Click += new System.EventHandler(this.Add1_Click);
            // 
            // Delete2
            // 
            this.Delete2.Click += new System.EventHandler(this.Delete2_Click);
            // 
            // Change2
            // 
            this.Change2.Click += new System.EventHandler(this.Change2_Click);
            // 
            // Delete1
            // 
            this.Delete1.Click += new System.EventHandler(this.Delete1_Click);
            // 
            // Change1
            // 
            this.Change1.Click += new System.EventHandler(this.Change1_Click);
            // 
            // label2
            // 
            this.label2.Size = new System.Drawing.Size(84, 24);
            this.label2.Text = "ジャンル";
            // 
            // label1
            // 
            this.label1.Size = new System.Drawing.Size(58, 24);
            this.label1.Text = "作品";
            // 
            // table_manage2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 18F);
            this.ClientSize = new System.Drawing.Size(1030, 666);
            this.Name = "table_manage2";
            this.Text = "属性管理";
            this.Load += new System.EventHandler(this.table_manage_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
    }
}
