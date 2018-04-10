namespace 同人誌管理 {
    partial class table_manage {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            this.originList = new System.Windows.Forms.ListBox();
            this.genreList = new System.Windows.Forms.ListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.originBox = new System.Windows.Forms.TextBox();
            this.genreBox = new System.Windows.Forms.TextBox();
            this.originChange = new System.Windows.Forms.Button();
            this.originDelete = new System.Windows.Forms.Button();
            this.genreChange = new System.Windows.Forms.Button();
            this.genreDelete = new System.Windows.Forms.Button();
            this.originAdd = new System.Windows.Forms.Button();
            this.genreAdd = new System.Windows.Forms.Button();
            this.close = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // originList
            // 
            this.originList.FormattingEnabled = true;
            this.originList.ItemHeight = 18;
            this.originList.Location = new System.Drawing.Point(12, 77);
            this.originList.Name = "originList";
            this.originList.Size = new System.Drawing.Size(479, 256);
            this.originList.TabIndex = 0;
            this.originList.SelectedIndexChanged += new System.EventHandler(this.originList_SelectedIndexChanged);
            // 
            // genreList
            // 
            this.genreList.FormattingEnabled = true;
            this.genreList.ItemHeight = 18;
            this.genreList.Location = new System.Drawing.Point(12, 411);
            this.genreList.Name = "genreList";
            this.genreList.Size = new System.Drawing.Size(479, 274);
            this.genreList.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("MS UI Gothic", 12F);
            this.label1.Location = new System.Drawing.Point(12, 50);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(58, 24);
            this.label1.TabIndex = 2;
            this.label1.Text = "作品";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("MS UI Gothic", 12F);
            this.label2.Location = new System.Drawing.Point(8, 384);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(84, 24);
            this.label2.TabIndex = 3;
            this.label2.Text = "ジャンル";
            // 
            // originBox
            // 
            this.originBox.Font = new System.Drawing.Font("MS UI Gothic", 12F);
            this.originBox.Location = new System.Drawing.Point(530, 77);
            this.originBox.Name = "originBox";
            this.originBox.Size = new System.Drawing.Size(310, 31);
            this.originBox.TabIndex = 4;
            // 
            // genreBox
            // 
            this.genreBox.Font = new System.Drawing.Font("MS UI Gothic", 12F);
            this.genreBox.Location = new System.Drawing.Point(531, 411);
            this.genreBox.Name = "genreBox";
            this.genreBox.Size = new System.Drawing.Size(309, 31);
            this.genreBox.TabIndex = 5;
            // 
            // originChange
            // 
            this.originChange.Location = new System.Drawing.Point(530, 144);
            this.originChange.Name = "originChange";
            this.originChange.Size = new System.Drawing.Size(125, 35);
            this.originChange.TabIndex = 6;
            this.originChange.Text = "変更";
            this.originChange.UseVisualStyleBackColor = true;
            // 
            // originDelete
            // 
            this.originDelete.Location = new System.Drawing.Point(715, 144);
            this.originDelete.Name = "originDelete";
            this.originDelete.Size = new System.Drawing.Size(125, 35);
            this.originDelete.TabIndex = 7;
            this.originDelete.Text = "削除";
            this.originDelete.UseVisualStyleBackColor = true;
            // 
            // genreChange
            // 
            this.genreChange.Location = new System.Drawing.Point(531, 474);
            this.genreChange.Name = "genreChange";
            this.genreChange.Size = new System.Drawing.Size(125, 35);
            this.genreChange.TabIndex = 8;
            this.genreChange.Text = "変更";
            this.genreChange.UseVisualStyleBackColor = true;
            // 
            // genreDelete
            // 
            this.genreDelete.Location = new System.Drawing.Point(715, 474);
            this.genreDelete.Name = "genreDelete";
            this.genreDelete.Size = new System.Drawing.Size(125, 35);
            this.genreDelete.TabIndex = 9;
            this.genreDelete.Text = "削除";
            this.genreDelete.UseVisualStyleBackColor = true;
            // 
            // originAdd
            // 
            this.originAdd.Location = new System.Drawing.Point(864, 77);
            this.originAdd.Name = "originAdd";
            this.originAdd.Size = new System.Drawing.Size(151, 31);
            this.originAdd.TabIndex = 10;
            this.originAdd.Text = "新規追加";
            this.originAdd.UseVisualStyleBackColor = true;
            // 
            // genreAdd
            // 
            this.genreAdd.Location = new System.Drawing.Point(864, 411);
            this.genreAdd.Name = "genreAdd";
            this.genreAdd.Size = new System.Drawing.Size(151, 31);
            this.genreAdd.TabIndex = 11;
            this.genreAdd.Text = "新規追加";
            this.genreAdd.UseVisualStyleBackColor = true;
            // 
            // close
            // 
            this.close.Location = new System.Drawing.Point(864, 647);
            this.close.Name = "close";
            this.close.Size = new System.Drawing.Size(135, 38);
            this.close.TabIndex = 12;
            this.close.Text = "閉じる";
            this.close.UseVisualStyleBackColor = true;
            this.close.Click += new System.EventHandler(this.close_Click);
            // 
            // table_manage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1042, 697);
            this.Controls.Add(this.close);
            this.Controls.Add(this.genreAdd);
            this.Controls.Add(this.originAdd);
            this.Controls.Add(this.genreDelete);
            this.Controls.Add(this.genreChange);
            this.Controls.Add(this.originDelete);
            this.Controls.Add(this.originChange);
            this.Controls.Add(this.genreBox);
            this.Controls.Add(this.originBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.genreList);
            this.Controls.Add(this.originList);
            this.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.Name = "table_manage";
            this.Text = "管理画面";
            this.Load += new System.EventHandler(this.table_manage_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox originList;
        private System.Windows.Forms.ListBox genreList;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox originBox;
        private System.Windows.Forms.TextBox genreBox;
        private System.Windows.Forms.Button originChange;
        private System.Windows.Forms.Button originDelete;
        private System.Windows.Forms.Button genreChange;
        private System.Windows.Forms.Button genreDelete;
        private System.Windows.Forms.Button originAdd;
        private System.Windows.Forms.Button genreAdd;
        private System.Windows.Forms.Button close;
    }
}