namespace 同人誌管理 {
    partial class detail_search {
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.all = new System.Windows.Forms.CheckBox();
            this.r15 = new System.Windows.Forms.CheckBox();
            this.r18 = new System.Windows.Forms.CheckBox();
            this.search = new System.Windows.Forms.Button();
            this.close = new System.Windows.Forms.Button();
            this.bookName = new System.Windows.Forms.TextBox();
            this.bookAuthor = new System.Windows.Forms.TextBox();
            this.charaForm = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.genreForm = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.originForm = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.bYear = new System.Windows.Forms.ComboBox();
            this.aYear = new System.Windows.Forms.ComboBox();
            this.bMonth = new System.Windows.Forms.ComboBox();
            this.aMonth = new System.Windows.Forms.ComboBox();
            this.bDay = new System.Windows.Forms.ComboBox();
            this.aDay = new System.Windows.Forms.ComboBox();
            this.label14 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.storage = new System.Windows.Forms.ComboBox();
            this.bookShelf = new System.Windows.Forms.ComboBox();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("MS UI Gothic", 12F);
            this.label1.Location = new System.Drawing.Point(28, 37);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(40, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "誌名";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("MS UI Gothic", 12F);
            this.label2.Location = new System.Drawing.Point(28, 74);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(56, 16);
            this.label2.TabIndex = 2;
            this.label2.Text = "作者名";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("MS UI Gothic", 12F);
            this.label3.Location = new System.Drawing.Point(28, 141);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(73, 16);
            this.label3.TabIndex = 6;
            this.label3.Text = "ジャンル名";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("MS UI Gothic", 12F);
            this.label4.Location = new System.Drawing.Point(28, 179);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(72, 16);
            this.label4.TabIndex = 8;
            this.label4.Text = "対象年齢";
            // 
            // all
            // 
            this.all.AutoSize = true;
            this.all.Font = new System.Drawing.Font("MS UI Gothic", 12F);
            this.all.Location = new System.Drawing.Point(22, 13);
            this.all.Name = "all";
            this.all.Size = new System.Drawing.Size(75, 20);
            this.all.TabIndex = 3;
            this.all.Tag = "all";
            this.all.Text = "全年齢";
            this.all.UseVisualStyleBackColor = true;
            // 
            // r15
            // 
            this.r15.AutoSize = true;
            this.r15.Font = new System.Drawing.Font("MS UI Gothic", 12F);
            this.r15.Location = new System.Drawing.Point(117, 12);
            this.r15.Name = "r15";
            this.r15.Size = new System.Drawing.Size(61, 20);
            this.r15.TabIndex = 4;
            this.r15.Tag = "r15";
            this.r15.Text = "R-15";
            this.r15.UseVisualStyleBackColor = true;
            // 
            // r18
            // 
            this.r18.AutoSize = true;
            this.r18.Font = new System.Drawing.Font("MS UI Gothic", 12F);
            this.r18.Location = new System.Drawing.Point(195, 13);
            this.r18.Name = "r18";
            this.r18.Size = new System.Drawing.Size(61, 20);
            this.r18.TabIndex = 5;
            this.r18.Tag = "r18";
            this.r18.Text = "R-18";
            this.r18.UseVisualStyleBackColor = true;
            // 
            // search
            // 
            this.search.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.search.Font = new System.Drawing.Font("MS UI Gothic", 12F);
            this.search.Location = new System.Drawing.Point(105, 378);
            this.search.Name = "search";
            this.search.Size = new System.Drawing.Size(75, 23);
            this.search.TabIndex = 29;
            this.search.Text = "検索";
            this.search.UseVisualStyleBackColor = true;
            this.search.Click += new System.EventHandler(this.search_Click);
            // 
            // close
            // 
            this.close.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.close.Font = new System.Drawing.Font("MS UI Gothic", 12F);
            this.close.Location = new System.Drawing.Point(319, 378);
            this.close.Name = "close";
            this.close.Size = new System.Drawing.Size(75, 23);
            this.close.TabIndex = 30;
            this.close.Text = "閉じる";
            this.close.UseVisualStyleBackColor = true;
            this.close.Click += new System.EventHandler(this.close_Click);
            // 
            // bookName
            // 
            this.bookName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.bookName.Font = new System.Drawing.Font("MS UI Gothic", 12F);
            this.bookName.Location = new System.Drawing.Point(103, 33);
            this.bookName.Name = "bookName";
            this.bookName.Size = new System.Drawing.Size(351, 23);
            this.bookName.TabIndex = 1;
            // 
            // bookAuthor
            // 
            this.bookAuthor.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.bookAuthor.Font = new System.Drawing.Font("MS UI Gothic", 12F);
            this.bookAuthor.Location = new System.Drawing.Point(103, 70);
            this.bookAuthor.Name = "bookAuthor";
            this.bookAuthor.Size = new System.Drawing.Size(351, 23);
            this.bookAuthor.TabIndex = 3;
            // 
            // charaForm
            // 
            this.charaForm.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.charaForm.Font = new System.Drawing.Font("MS UI Gothic", 12F);
            this.charaForm.Location = new System.Drawing.Point(103, 278);
            this.charaForm.MinimumSize = new System.Drawing.Size(10, 10);
            this.charaForm.Name = "charaForm";
            this.charaForm.Size = new System.Drawing.Size(351, 23);
            this.charaForm.TabIndex = 15;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("MS UI Gothic", 12F);
            this.label6.Location = new System.Drawing.Point(28, 283);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(43, 16);
            this.label6.TabIndex = 14;
            this.label6.Text = "キャラ";
            // 
            // genreForm
            // 
            this.genreForm.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.genreForm.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.genreForm.Font = new System.Drawing.Font("MS UI Gothic", 12F);
            this.genreForm.FormattingEnabled = true;
            this.genreForm.Location = new System.Drawing.Point(103, 140);
            this.genreForm.Name = "genreForm";
            this.genreForm.Size = new System.Drawing.Size(351, 24);
            this.genreForm.TabIndex = 7;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("MS UI Gothic", 12F);
            this.label7.Location = new System.Drawing.Point(28, 320);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(56, 16);
            this.label7.TabIndex = 16;
            this.label7.Text = "頒布日";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("MS UI Gothic", 12F);
            this.label8.Location = new System.Drawing.Point(169, 320);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(24, 16);
            this.label8.TabIndex = 18;
            this.label8.Text = "年";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("MS UI Gothic", 12F);
            this.label9.Location = new System.Drawing.Point(258, 320);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(24, 16);
            this.label9.TabIndex = 20;
            this.label9.Text = "月";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("MS UI Gothic", 12F);
            this.label10.Location = new System.Drawing.Point(345, 320);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(59, 16);
            this.label10.TabIndex = 22;
            this.label10.Text = "日　から";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("MS UI Gothic", 12F);
            this.label11.Location = new System.Drawing.Point(345, 352);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(60, 16);
            this.label11.TabIndex = 28;
            this.label11.Text = "日　まで";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("MS UI Gothic", 12F);
            this.label12.Location = new System.Drawing.Point(258, 354);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(24, 16);
            this.label12.TabIndex = 26;
            this.label12.Text = "月";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("MS UI Gothic", 12F);
            this.label13.Location = new System.Drawing.Point(169, 354);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(24, 16);
            this.label13.TabIndex = 24;
            this.label13.Text = "年";
            // 
            // originForm
            // 
            this.originForm.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.originForm.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.originForm.Font = new System.Drawing.Font("MS UI Gothic", 12F);
            this.originForm.FormattingEnabled = true;
            this.originForm.Location = new System.Drawing.Point(103, 105);
            this.originForm.Name = "originForm";
            this.originForm.Size = new System.Drawing.Size(351, 24);
            this.originForm.TabIndex = 5;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("MS UI Gothic", 12F);
            this.label5.Location = new System.Drawing.Point(28, 105);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(56, 16);
            this.label5.TabIndex = 4;
            this.label5.Text = "作品名";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.all);
            this.panel1.Controls.Add(this.r15);
            this.panel1.Controls.Add(this.r18);
            this.panel1.Location = new System.Drawing.Point(96, 166);
            this.panel1.Margin = new System.Windows.Forms.Padding(2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(272, 45);
            this.panel1.TabIndex = 9;
            // 
            // bYear
            // 
            this.bYear.Font = new System.Drawing.Font("MS UI Gothic", 12F);
            this.bYear.FormattingEnabled = true;
            this.bYear.Location = new System.Drawing.Point(103, 314);
            this.bYear.Name = "bYear";
            this.bYear.Size = new System.Drawing.Size(63, 24);
            this.bYear.TabIndex = 17;
            // 
            // aYear
            // 
            this.aYear.Font = new System.Drawing.Font("MS UI Gothic", 12F);
            this.aYear.FormattingEnabled = true;
            this.aYear.Location = new System.Drawing.Point(103, 348);
            this.aYear.Name = "aYear";
            this.aYear.Size = new System.Drawing.Size(63, 24);
            this.aYear.TabIndex = 23;
            // 
            // bMonth
            // 
            this.bMonth.Font = new System.Drawing.Font("MS UI Gothic", 12F);
            this.bMonth.FormattingEnabled = true;
            this.bMonth.Location = new System.Drawing.Point(202, 315);
            this.bMonth.Name = "bMonth";
            this.bMonth.Size = new System.Drawing.Size(50, 24);
            this.bMonth.TabIndex = 19;
            // 
            // aMonth
            // 
            this.aMonth.Font = new System.Drawing.Font("MS UI Gothic", 12F);
            this.aMonth.FormattingEnabled = true;
            this.aMonth.Location = new System.Drawing.Point(202, 348);
            this.aMonth.Name = "aMonth";
            this.aMonth.Size = new System.Drawing.Size(50, 24);
            this.aMonth.TabIndex = 25;
            // 
            // bDay
            // 
            this.bDay.Font = new System.Drawing.Font("MS UI Gothic", 12F);
            this.bDay.FormattingEnabled = true;
            this.bDay.Location = new System.Drawing.Point(289, 314);
            this.bDay.Name = "bDay";
            this.bDay.Size = new System.Drawing.Size(50, 24);
            this.bDay.TabIndex = 21;
            // 
            // aDay
            // 
            this.aDay.Font = new System.Drawing.Font("MS UI Gothic", 12F);
            this.aDay.FormattingEnabled = true;
            this.aDay.Location = new System.Drawing.Point(289, 348);
            this.aDay.Name = "aDay";
            this.aDay.Size = new System.Drawing.Size(50, 24);
            this.aDay.TabIndex = 27;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("MS UI Gothic", 12F);
            this.label14.Location = new System.Drawing.Point(28, 213);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(72, 16);
            this.label14.TabIndex = 10;
            this.label14.Text = "保管場所";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("MS UI Gothic", 12F);
            this.label15.Location = new System.Drawing.Point(28, 246);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(40, 16);
            this.label15.TabIndex = 12;
            this.label15.Text = "本棚";
            // 
            // storage
            // 
            this.storage.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.storage.Font = new System.Drawing.Font("MS UI Gothic", 12F);
            this.storage.FormattingEnabled = true;
            this.storage.Location = new System.Drawing.Point(103, 213);
            this.storage.Name = "storage";
            this.storage.Size = new System.Drawing.Size(197, 24);
            this.storage.TabIndex = 11;
            this.storage.SelectedIndexChanged += new System.EventHandler(this.storage_SelectedIndexChanged);
            // 
            // bookShelf
            // 
            this.bookShelf.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.bookShelf.Font = new System.Drawing.Font("MS UI Gothic", 12F);
            this.bookShelf.FormattingEnabled = true;
            this.bookShelf.Location = new System.Drawing.Point(103, 246);
            this.bookShelf.Name = "bookShelf";
            this.bookShelf.Size = new System.Drawing.Size(197, 24);
            this.bookShelf.TabIndex = 13;
            // 
            // detail_search
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(483, 414);
            this.Controls.Add(this.bookShelf);
            this.Controls.Add(this.storage);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.aDay);
            this.Controls.Add(this.bDay);
            this.Controls.Add(this.aMonth);
            this.Controls.Add(this.bMonth);
            this.Controls.Add(this.aYear);
            this.Controls.Add(this.bYear);
            this.Controls.Add(this.originForm);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.genreForm);
            this.Controls.Add(this.charaForm);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.bookAuthor);
            this.Controls.Add(this.bookName);
            this.Controls.Add(this.close);
            this.Controls.Add(this.search);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.panel1);
            this.MinimumSize = new System.Drawing.Size(488, 394);
            this.Name = "detail_search";
            this.Text = "詳細検索";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.CheckBox all;
        private System.Windows.Forms.CheckBox r15;
        private System.Windows.Forms.CheckBox r18;
        private System.Windows.Forms.Button search;
        private System.Windows.Forms.Button close;
        private System.Windows.Forms.TextBox bookName;
        private System.Windows.Forms.TextBox bookAuthor;
        private System.Windows.Forms.TextBox charaForm;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox genreForm;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.ComboBox originForm;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ComboBox bYear;
        private System.Windows.Forms.ComboBox aYear;
        private System.Windows.Forms.ComboBox bMonth;
        private System.Windows.Forms.ComboBox aMonth;
        private System.Windows.Forms.ComboBox bDay;
        private System.Windows.Forms.ComboBox aDay;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.ComboBox storage;
        private System.Windows.Forms.ComboBox bookShelf;
    }
}