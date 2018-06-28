namespace 同人誌管理 {
    partial class BookBase {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        protected System.ComponentModel.IContainer components = null;

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
        protected void InitializeComponent() {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(BookBase));
            this.pictureBox = new System.Windows.Forms.PictureBox();
            this.all = new System.Windows.Forms.RadioButton();
            this.r15 = new System.Windows.Forms.RadioButton();
            this.r18 = new System.Windows.Forms.RadioButton();
            this.house = new System.Windows.Forms.RadioButton();
            this.hometown = new System.Windows.Forms.RadioButton();
            this.label13 = new System.Windows.Forms.Label();
            this.dayForm = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.monthForm = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.yearForm = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.genreComboBox = new System.Windows.Forms.ComboBox();
            this.originComboBox = new System.Windows.Forms.ComboBox();
            this.place = new System.Windows.Forms.Panel();
            this.ageLimit = new System.Windows.Forms.Panel();
            this.close = new System.Windows.Forms.Button();
            this.dealing = new System.Windows.Forms.Button();
            this.idForm = new System.Windows.Forms.TextBox();
            this.mainChara = new System.Windows.Forms.TextBox();
            this.authorsForm = new System.Windows.Forms.TextBox();
            this.circleForm = new System.Windows.Forms.TextBox();
            this.titleForm = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.openThumbnailDialog = new System.Windows.Forms.OpenFileDialog();
            this.openThumbnailBottun = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).BeginInit();
            this.place.SuspendLayout();
            this.ageLimit.SuspendLayout();
            this.SuspendLayout();
            // 
            // pictureBox
            // 
            this.pictureBox.ErrorImage = null;
            this.pictureBox.Location = new System.Drawing.Point(30, 23);
            this.pictureBox.Name = "pictureBox";
            this.pictureBox.Size = new System.Drawing.Size(116, 135);
            this.pictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox.TabIndex = 91;
            this.pictureBox.TabStop = false;
            this.pictureBox.DragDrop += new System.Windows.Forms.DragEventHandler(this.pictureBox_DragDrop);
            this.pictureBox.DragEnter += new System.Windows.Forms.DragEventHandler(this.pictureBox_DragEnter);
            // 
            // all
            // 
            this.all.AutoSize = true;
            this.all.Checked = true;
            this.all.Font = new System.Drawing.Font("MS UI Gothic", 12F);
            this.all.Location = new System.Drawing.Point(14, 8);
            this.all.Name = "all";
            this.all.Size = new System.Drawing.Size(74, 20);
            this.all.TabIndex = 0;
            this.all.TabStop = true;
            this.all.Text = "全年齢";
            this.all.UseVisualStyleBackColor = true;
            // 
            // r15
            // 
            this.r15.AutoSize = true;
            this.r15.Font = new System.Drawing.Font("MS UI Gothic", 12F);
            this.r15.Location = new System.Drawing.Point(121, 8);
            this.r15.Name = "r15";
            this.r15.Size = new System.Drawing.Size(60, 20);
            this.r15.TabIndex = 1;
            this.r15.TabStop = true;
            this.r15.Text = "R-15";
            this.r15.UseVisualStyleBackColor = true;
            // 
            // r18
            // 
            this.r18.AutoSize = true;
            this.r18.Font = new System.Drawing.Font("MS UI Gothic", 12F);
            this.r18.Location = new System.Drawing.Point(225, 8);
            this.r18.Name = "r18";
            this.r18.Size = new System.Drawing.Size(60, 20);
            this.r18.TabIndex = 2;
            this.r18.TabStop = true;
            this.r18.Text = "R-18";
            this.r18.UseVisualStyleBackColor = true;
            // 
            // house
            // 
            this.house.AutoSize = true;
            this.house.Checked = true;
            this.house.Font = new System.Drawing.Font("MS UI Gothic", 12F);
            this.house.Location = new System.Drawing.Point(14, 3);
            this.house.Name = "house";
            this.house.Size = new System.Drawing.Size(74, 20);
            this.house.TabIndex = 0;
            this.house.TabStop = true;
            this.house.Text = "現住居";
            this.house.UseVisualStyleBackColor = true;
            // 
            // hometown
            // 
            this.hometown.AutoSize = true;
            this.hometown.Font = new System.Drawing.Font("MS UI Gothic", 12F);
            this.hometown.Location = new System.Drawing.Point(121, 3);
            this.hometown.Name = "hometown";
            this.hometown.Size = new System.Drawing.Size(58, 20);
            this.hometown.TabIndex = 1;
            this.hometown.TabStop = true;
            this.hometown.Text = "実家";
            this.hometown.UseVisualStyleBackColor = true;
            // 
            // label13
            // 
            this.label13.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("MS UI Gothic", 12F);
            this.label13.Location = new System.Drawing.Point(342, 264);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(24, 16);
            this.label13.TabIndex = 90;
            this.label13.Text = "日";
            // 
            // dayForm
            // 
            this.dayForm.Font = new System.Drawing.Font("MS UI Gothic", 12F);
            this.dayForm.Location = new System.Drawing.Point(303, 260);
            this.dayForm.Name = "dayForm";
            this.dayForm.Size = new System.Drawing.Size(33, 23);
            this.dayForm.TabIndex = 8;
            // 
            // label12
            // 
            this.label12.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("MS UI Gothic", 12F);
            this.label12.Location = new System.Drawing.Point(273, 265);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(24, 16);
            this.label12.TabIndex = 89;
            this.label12.Text = "月";
            // 
            // monthForm
            // 
            this.monthForm.Font = new System.Drawing.Font("MS UI Gothic", 12F);
            this.monthForm.Location = new System.Drawing.Point(234, 260);
            this.monthForm.Name = "monthForm";
            this.monthForm.Size = new System.Drawing.Size(33, 23);
            this.monthForm.TabIndex = 7;
            // 
            // label11
            // 
            this.label11.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("MS UI Gothic", 12F);
            this.label11.Location = new System.Drawing.Point(211, 264);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(24, 16);
            this.label11.TabIndex = 88;
            this.label11.Text = "年";
            // 
            // yearForm
            // 
            this.yearForm.Font = new System.Drawing.Font("MS UI Gothic", 12F);
            this.yearForm.Location = new System.Drawing.Point(132, 259);
            this.yearForm.Name = "yearForm";
            this.yearForm.Size = new System.Drawing.Size(73, 23);
            this.yearForm.TabIndex = 6;
            // 
            // label10
            // 
            this.label10.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("MS UI Gothic", 12F);
            this.label10.Location = new System.Drawing.Point(28, 264);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(88, 16);
            this.label10.TabIndex = 87;
            this.label10.Text = "頒布年月日";
            // 
            // genreComboBox
            // 
            this.genreComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.genreComboBox.Font = new System.Drawing.Font("MS UI Gothic", 12F);
            this.genreComboBox.FormattingEnabled = true;
            this.genreComboBox.Location = new System.Drawing.Point(373, 227);
            this.genreComboBox.Name = "genreComboBox";
            this.genreComboBox.Size = new System.Drawing.Size(169, 24);
            this.genreComboBox.TabIndex = 5;
            // 
            // originComboBox
            // 
            this.originComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.originComboBox.Font = new System.Drawing.Font("MS UI Gothic", 12F);
            this.originComboBox.FormattingEnabled = true;
            this.originComboBox.Location = new System.Drawing.Point(94, 228);
            this.originComboBox.Name = "originComboBox";
            this.originComboBox.Size = new System.Drawing.Size(169, 24);
            this.originComboBox.TabIndex = 4;
            // 
            // place
            // 
            this.place.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.place.Controls.Add(this.house);
            this.place.Controls.Add(this.hometown);
            this.place.Font = new System.Drawing.Font("MS UI Gothic", 12F);
            this.place.Location = new System.Drawing.Point(103, 323);
            this.place.Name = "place";
            this.place.Size = new System.Drawing.Size(295, 27);
            this.place.TabIndex = 10;
            // 
            // ageLimit
            // 
            this.ageLimit.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ageLimit.Controls.Add(this.all);
            this.ageLimit.Controls.Add(this.r15);
            this.ageLimit.Controls.Add(this.r18);
            this.ageLimit.Font = new System.Drawing.Font("MS UI Gothic", 12F);
            this.ageLimit.Location = new System.Drawing.Point(103, 287);
            this.ageLimit.Name = "ageLimit";
            this.ageLimit.Size = new System.Drawing.Size(412, 34);
            this.ageLimit.TabIndex = 9;
            // 
            // close
            // 
            this.close.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.close.Font = new System.Drawing.Font("MS UI Gothic", 12F);
            this.close.Location = new System.Drawing.Point(498, 524);
            this.close.Name = "close";
            this.close.Size = new System.Drawing.Size(75, 23);
            this.close.TabIndex = 13;
            this.close.Text = "閉じる";
            this.close.UseVisualStyleBackColor = true;
            this.close.Click += new System.EventHandler(this.close_Click);
            // 
            // dealing
            // 
            this.dealing.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.dealing.Font = new System.Drawing.Font("MS UI Gothic", 12F);
            this.dealing.Location = new System.Drawing.Point(392, 525);
            this.dealing.Name = "dealing";
            this.dealing.Size = new System.Drawing.Size(75, 23);
            this.dealing.TabIndex = 12;
            this.dealing.Text = "dealing";
            this.dealing.UseVisualStyleBackColor = true;
            // 
            // idForm
            // 
            this.idForm.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.idForm.Enabled = false;
            this.idForm.Font = new System.Drawing.Font("MS UI Gothic", 12F);
            this.idForm.Location = new System.Drawing.Point(52, 525);
            this.idForm.Name = "idForm";
            this.idForm.Size = new System.Drawing.Size(100, 23);
            this.idForm.TabIndex = 86;
            // 
            // mainChara
            // 
            this.mainChara.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.mainChara.Font = new System.Drawing.Font("MS UI Gothic", 12F);
            this.mainChara.Location = new System.Drawing.Point(30, 384);
            this.mainChara.Multiline = true;
            this.mainChara.Name = "mainChara";
            this.mainChara.Size = new System.Drawing.Size(552, 125);
            this.mainChara.TabIndex = 11;
            // 
            // authorsForm
            // 
            this.authorsForm.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.authorsForm.Font = new System.Drawing.Font("MS UI Gothic", 12F);
            this.authorsForm.Location = new System.Drawing.Point(30, 193);
            this.authorsForm.Name = "authorsForm";
            this.authorsForm.Size = new System.Drawing.Size(561, 23);
            this.authorsForm.TabIndex = 3;
            // 
            // circleForm
            // 
            this.circleForm.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.circleForm.Font = new System.Drawing.Font("MS UI Gothic", 12F);
            this.circleForm.Location = new System.Drawing.Point(154, 114);
            this.circleForm.Name = "circleForm";
            this.circleForm.Size = new System.Drawing.Size(437, 23);
            this.circleForm.TabIndex = 1;
            // 
            // titleForm
            // 
            this.titleForm.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.titleForm.Font = new System.Drawing.Font("MS UI Gothic", 15F);
            this.titleForm.Location = new System.Drawing.Point(224, 34);
            this.titleForm.Name = "titleForm";
            this.titleForm.Size = new System.Drawing.Size(367, 27);
            this.titleForm.TabIndex = 0;
            // 
            // label9
            // 
            this.label9.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("MS UI Gothic", 12F);
            this.label9.Location = new System.Drawing.Point(30, 526);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(22, 16);
            this.label9.TabIndex = 83;
            this.label9.Text = "ID";
            // 
            // label8
            // 
            this.label8.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("MS UI Gothic", 12F);
            this.label8.Location = new System.Drawing.Point(28, 360);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(78, 16);
            this.label8.TabIndex = 82;
            this.label8.Text = "メインキャラ";
            // 
            // label7
            // 
            this.label7.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("MS UI Gothic", 12F);
            this.label7.Location = new System.Drawing.Point(28, 326);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(72, 16);
            this.label7.TabIndex = 85;
            this.label7.Text = "保管場所";
            // 
            // label6
            // 
            this.label6.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("MS UI Gothic", 12F);
            this.label6.Location = new System.Drawing.Point(28, 293);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(72, 16);
            this.label6.TabIndex = 84;
            this.label6.Text = "対象年齢";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("MS UI Gothic", 12F);
            this.label5.Location = new System.Drawing.Point(298, 231);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(57, 16);
            this.label5.TabIndex = 81;
            this.label5.Text = "ジャンル";
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("MS UI Gothic", 12F);
            this.label4.Location = new System.Drawing.Point(28, 230);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(56, 16);
            this.label4.TabIndex = 80;
            this.label4.Text = "作品名";
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("MS UI Gothic", 12F);
            this.label3.Location = new System.Drawing.Point(28, 173);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(308, 16);
            this.label3.TabIndex = 79;
            this.label3.Text = "作者名　(複数人の場合は半角コンマで区切る)";
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("MS UI Gothic", 12F);
            this.label2.Location = new System.Drawing.Point(152, 95);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(289, 16);
            this.label2.TabIndex = 78;
            this.label2.Text = "サークル（合同の場合は半角コンマで区切る）";
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("MS UI Gothic", 15F);
            this.label1.Location = new System.Drawing.Point(152, 37);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(67, 20);
            this.label1.TabIndex = 77;
            this.label1.Text = "タイトル";
            // 
            // openThumbnailDialog
            // 
            this.openThumbnailDialog.Filter = "画像ファイル(*.BMP;*.JPG;*.GIF;*.PNG)|*.BMP;*.JPG;*.GIF;*.PNG";
            // 
            // openThumbnailBottun
            // 
            this.openThumbnailBottun.Location = new System.Drawing.Point(156, 141);
            this.openThumbnailBottun.Name = "openThumbnailBottun";
            this.openThumbnailBottun.Size = new System.Drawing.Size(75, 23);
            this.openThumbnailBottun.TabIndex = 2;
            this.openThumbnailBottun.Text = "サムネ設定";
            this.openThumbnailBottun.UseVisualStyleBackColor = true;
            this.openThumbnailBottun.Click += new System.EventHandler(this.openThumbnailBottun_Click);
            // 
            // BookBase
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(619, 571);
            this.Controls.Add(this.openThumbnailBottun);
            this.Controls.Add(this.pictureBox);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.dayForm);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.monthForm);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.yearForm);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.genreComboBox);
            this.Controls.Add(this.originComboBox);
            this.Controls.Add(this.place);
            this.Controls.Add(this.ageLimit);
            this.Controls.Add(this.close);
            this.Controls.Add(this.dealing);
            this.Controls.Add(this.idForm);
            this.Controls.Add(this.mainChara);
            this.Controls.Add(this.authorsForm);
            this.Controls.Add(this.circleForm);
            this.Controls.Add(this.titleForm);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(635, 610);
            this.Name = "BookBase";
            this.Text = "追加&更新_親フォーム";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).EndInit();
            this.place.ResumeLayout(false);
            this.place.PerformLayout();
            this.ageLimit.ResumeLayout(false);
            this.ageLimit.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        protected System.Windows.Forms.PictureBox pictureBox;
        protected System.Windows.Forms.RadioButton all;
        protected System.Windows.Forms.RadioButton r15;
        protected System.Windows.Forms.RadioButton r18;
        protected System.Windows.Forms.RadioButton house;
        protected System.Windows.Forms.RadioButton hometown;
        protected System.Windows.Forms.Label label13;
        protected System.Windows.Forms.TextBox dayForm;
        protected System.Windows.Forms.Label label12;
        protected System.Windows.Forms.TextBox monthForm;
        protected System.Windows.Forms.Label label11;
        protected System.Windows.Forms.TextBox yearForm;
        protected System.Windows.Forms.Label label10;
        protected System.Windows.Forms.ComboBox genreComboBox;
        protected System.Windows.Forms.ComboBox originComboBox;
        protected System.Windows.Forms.Panel place;
        protected System.Windows.Forms.Panel ageLimit;
        protected System.Windows.Forms.Button close;
        protected System.Windows.Forms.Button dealing;
        protected System.Windows.Forms.TextBox idForm;
        protected System.Windows.Forms.TextBox mainChara;
        protected System.Windows.Forms.TextBox authorsForm;
        protected System.Windows.Forms.TextBox circleForm;
        protected System.Windows.Forms.TextBox titleForm;
        protected System.Windows.Forms.Label label9;
        protected System.Windows.Forms.Label label8;
        protected System.Windows.Forms.Label label7;
        protected System.Windows.Forms.Label label6;
        protected System.Windows.Forms.Label label5;
        protected System.Windows.Forms.Label label4;
        protected System.Windows.Forms.Label label3;
        protected System.Windows.Forms.Label label2;
        protected System.Windows.Forms.Label label1;
        protected System.Windows.Forms.OpenFileDialog openThumbnailDialog;
        protected System.Windows.Forms.Button openThumbnailBottun;
    }
}