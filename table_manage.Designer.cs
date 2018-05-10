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
            this.originList = new System.Windows.Forms.ListView();
            this.originID = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.originName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.genreList = new System.Windows.Forms.ListView();
            this.genreID = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.genreName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.SuspendLayout();
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
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
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
            this.originBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.originBox.Font = new System.Drawing.Font("MS UI Gothic", 12F);
            this.originBox.Location = new System.Drawing.Point(530, 77);
            this.originBox.Name = "originBox";
            this.originBox.Size = new System.Drawing.Size(310, 31);
            this.originBox.TabIndex = 4;
            // 
            // genreBox
            // 
            this.genreBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.genreBox.Font = new System.Drawing.Font("MS UI Gothic", 12F);
            this.genreBox.Location = new System.Drawing.Point(531, 411);
            this.genreBox.Name = "genreBox";
            this.genreBox.Size = new System.Drawing.Size(309, 31);
            this.genreBox.TabIndex = 5;
            // 
            // originChange
            // 
            this.originChange.Font = new System.Drawing.Font("MS UI Gothic", 12F);
            this.originChange.Location = new System.Drawing.Point(530, 144);
            this.originChange.Name = "originChange";
            this.originChange.Size = new System.Drawing.Size(125, 49);
            this.originChange.TabIndex = 6;
            this.originChange.Text = "変更";
            this.originChange.UseVisualStyleBackColor = true;
            this.originChange.Click += new System.EventHandler(this.originChange_Click);
            // 
            // originDelete
            // 
            this.originDelete.Font = new System.Drawing.Font("MS UI Gothic", 12F);
            this.originDelete.Location = new System.Drawing.Point(715, 144);
            this.originDelete.Name = "originDelete";
            this.originDelete.Size = new System.Drawing.Size(125, 49);
            this.originDelete.TabIndex = 7;
            this.originDelete.Text = "削除";
            this.originDelete.UseVisualStyleBackColor = true;
            this.originDelete.Click += new System.EventHandler(this.originDelete_Click);
            // 
            // genreChange
            // 
            this.genreChange.Font = new System.Drawing.Font("MS UI Gothic", 12F);
            this.genreChange.Location = new System.Drawing.Point(531, 474);
            this.genreChange.Name = "genreChange";
            this.genreChange.Size = new System.Drawing.Size(125, 45);
            this.genreChange.TabIndex = 8;
            this.genreChange.Text = "変更";
            this.genreChange.UseVisualStyleBackColor = true;
            this.genreChange.Click += new System.EventHandler(this.genreChange_Click);
            // 
            // genreDelete
            // 
            this.genreDelete.Font = new System.Drawing.Font("MS UI Gothic", 12F);
            this.genreDelete.Location = new System.Drawing.Point(715, 474);
            this.genreDelete.Name = "genreDelete";
            this.genreDelete.Size = new System.Drawing.Size(125, 45);
            this.genreDelete.TabIndex = 9;
            this.genreDelete.Text = "削除";
            this.genreDelete.UseVisualStyleBackColor = true;
            this.genreDelete.Click += new System.EventHandler(this.genreDelete_Click);
            // 
            // originAdd
            // 
            this.originAdd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.originAdd.Font = new System.Drawing.Font("MS UI Gothic", 12F);
            this.originAdd.Location = new System.Drawing.Point(864, 70);
            this.originAdd.Name = "originAdd";
            this.originAdd.Size = new System.Drawing.Size(151, 44);
            this.originAdd.TabIndex = 10;
            this.originAdd.Text = "新規追加";
            this.originAdd.UseVisualStyleBackColor = true;
            this.originAdd.Click += new System.EventHandler(this.originAdd_Click);
            // 
            // genreAdd
            // 
            this.genreAdd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.genreAdd.Font = new System.Drawing.Font("MS UI Gothic", 12F);
            this.genreAdd.Location = new System.Drawing.Point(864, 404);
            this.genreAdd.Name = "genreAdd";
            this.genreAdd.Size = new System.Drawing.Size(151, 44);
            this.genreAdd.TabIndex = 11;
            this.genreAdd.Text = "新規追加";
            this.genreAdd.UseVisualStyleBackColor = true;
            this.genreAdd.Click += new System.EventHandler(this.genreAdd_Click);
            // 
            // close
            // 
            this.close.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.close.Font = new System.Drawing.Font("MS UI Gothic", 12F);
            this.close.Location = new System.Drawing.Point(880, 635);
            this.close.Name = "close";
            this.close.Size = new System.Drawing.Size(135, 50);
            this.close.TabIndex = 12;
            this.close.Text = "閉じる";
            this.close.UseVisualStyleBackColor = true;
            this.close.Click += new System.EventHandler(this.close_Click);
            // 
            // originList
            // 
            this.originList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.originID,
            this.originName});
            this.originList.Font = new System.Drawing.Font("MS UI Gothic", 12F);
            this.originList.FullRowSelect = true;
            this.originList.Location = new System.Drawing.Point(26, 77);
            this.originList.MultiSelect = false;
            this.originList.Name = "originList";
            this.originList.Size = new System.Drawing.Size(487, 292);
            this.originList.TabIndex = 13;
            this.originList.UseCompatibleStateImageBehavior = false;
            this.originList.View = System.Windows.Forms.View.Details;
            this.originList.SelectedIndexChanged += new System.EventHandler(this.origin_List_SelectedIndexChanged);
            // 
            // originID
            // 
            this.originID.Text = "ID";
            this.originID.Width = 40;
            // 
            // originName
            // 
            this.originName.Text = "作品名";
            this.originName.Width = 415;
            // 
            // genreList
            // 
            this.genreList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.genreID,
            this.genreName});
            this.genreList.Font = new System.Drawing.Font("MS UI Gothic", 12F);
            this.genreList.FullRowSelect = true;
            this.genreList.Location = new System.Drawing.Point(26, 411);
            this.genreList.MultiSelect = false;
            this.genreList.Name = "genreList";
            this.genreList.Size = new System.Drawing.Size(483, 274);
            this.genreList.TabIndex = 14;
            this.genreList.UseCompatibleStateImageBehavior = false;
            this.genreList.View = System.Windows.Forms.View.Details;
            this.genreList.SelectedIndexChanged += new System.EventHandler(this.genreList_SelectedIndexChanged);
            // 
            // genreID
            // 
            this.genreID.Text = "ID";
            this.genreID.Width = 47;
            // 
            // genreName
            // 
            this.genreName.Text = "ジャンル名";
            this.genreName.Width = 417;
            // 
            // table_manage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1042, 697);
            this.Controls.Add(this.genreList);
            this.Controls.Add(this.originList);
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
            this.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.Name = "table_manage";
            this.Text = "管理画面";
            this.Load += new System.EventHandler(this.table_manage_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

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
        private System.Windows.Forms.ListView originList;
        private System.Windows.Forms.ListView genreList;
        private System.Windows.Forms.ColumnHeader originID;
        private System.Windows.Forms.ColumnHeader originName;
        private System.Windows.Forms.ColumnHeader genreID;
        private System.Windows.Forms.ColumnHeader genreName;
    }
}