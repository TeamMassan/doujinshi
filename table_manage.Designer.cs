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
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.listBox2 = new System.Windows.Forms.ListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.bookChange = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.genreChange = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.bookAdd = new System.Windows.Forms.Button();
            this.genreAdd = new System.Windows.Forms.Button();
            this.close = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // listBox1
            // 
            this.listBox1.FormattingEnabled = true;
            this.listBox1.ItemHeight = 18;
            this.listBox1.Location = new System.Drawing.Point(12, 77);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(479, 256);
            this.listBox1.TabIndex = 0;
            // 
            // listBox2
            // 
            this.listBox2.FormattingEnabled = true;
            this.listBox2.ItemHeight = 18;
            this.listBox2.Location = new System.Drawing.Point(12, 411);
            this.listBox2.Name = "listBox2";
            this.listBox2.Size = new System.Drawing.Size(479, 274);
            this.listBox2.TabIndex = 1;
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
            // textBox1
            // 
            this.textBox1.Font = new System.Drawing.Font("MS UI Gothic", 12F);
            this.textBox1.Location = new System.Drawing.Point(530, 77);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(310, 31);
            this.textBox1.TabIndex = 4;
            // 
            // textBox2
            // 
            this.textBox2.Font = new System.Drawing.Font("MS UI Gothic", 12F);
            this.textBox2.Location = new System.Drawing.Point(531, 411);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(309, 31);
            this.textBox2.TabIndex = 5;
            // 
            // bookChange
            // 
            this.bookChange.Location = new System.Drawing.Point(530, 144);
            this.bookChange.Name = "bookChange";
            this.bookChange.Size = new System.Drawing.Size(125, 35);
            this.bookChange.TabIndex = 6;
            this.bookChange.Text = "変更";
            this.bookChange.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(715, 144);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(125, 35);
            this.button2.TabIndex = 7;
            this.button2.Text = "削除";
            this.button2.UseVisualStyleBackColor = true;
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
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(715, 474);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(125, 35);
            this.button4.TabIndex = 9;
            this.button4.Text = "削除";
            this.button4.UseVisualStyleBackColor = true;
            // 
            // bookAdd
            // 
            this.bookAdd.Location = new System.Drawing.Point(864, 77);
            this.bookAdd.Name = "bookAdd";
            this.bookAdd.Size = new System.Drawing.Size(151, 31);
            this.bookAdd.TabIndex = 10;
            this.bookAdd.Text = "新規追加";
            this.bookAdd.UseVisualStyleBackColor = true;
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
            this.Controls.Add(this.bookAdd);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.genreChange);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.bookChange);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.listBox2);
            this.Controls.Add(this.listBox1);
            this.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.Name = "table_manage";
            this.Text = "管理画面";
            this.Load += new System.EventHandler(this.table_manage_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.ListBox listBox2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Button bookChange;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button genreChange;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button bookAdd;
        private System.Windows.Forms.Button genreAdd;
        private System.Windows.Forms.Button close;
    }
}