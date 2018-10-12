namespace 同人誌管理
{
    partial class manageBase
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(manageBase));
            this.coumn2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Listview2 = new System.Windows.Forms.ListView();
            this.ID2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.column1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ID = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Listview1 = new System.Windows.Forms.ListView();
            this.close = new System.Windows.Forms.Button();
            this.Add2 = new System.Windows.Forms.Button();
            this.Add1 = new System.Windows.Forms.Button();
            this.Delete2 = new System.Windows.Forms.Button();
            this.Change2 = new System.Windows.Forms.Button();
            this.Delete1 = new System.Windows.Forms.Button();
            this.Change1 = new System.Windows.Forms.Button();
            this.Textbox2 = new System.Windows.Forms.TextBox();
            this.Textbox1 = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // coumn2
            // 
            this.coumn2.Text = "column2";
            this.coumn2.Width = 200;
            // 
            // Listview2
            // 
            this.Listview2.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.ID2,
            this.coumn2});
            this.Listview2.Font = new System.Drawing.Font("MS UI Gothic", 12F);
            this.Listview2.FullRowSelect = true;
            this.Listview2.Location = new System.Drawing.Point(41, 380);
            this.Listview2.MultiSelect = false;
            this.Listview2.Name = "Listview2";
            this.Listview2.Size = new System.Drawing.Size(482, 274);
            this.Listview2.TabIndex = 5;
            this.Listview2.UseCompatibleStateImageBehavior = false;
            this.Listview2.View = System.Windows.Forms.View.Details;
            this.Listview2.SelectedIndexChanged += new System.EventHandler(this.Listview2_SelectedIndexChanged);
            // 
            // ID2
            // 
            this.ID2.Text = "ID";
            this.ID2.Width = 47;
            // 
            // column1
            // 
            this.column1.Text = "column2";
            this.column1.Width = 200;
            // 
            // ID
            // 
            this.ID.Text = "ID";
            this.ID.Width = 40;
            // 
            // Listview1
            // 
            this.Listview1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.ID,
            this.column1});
            this.Listview1.Font = new System.Drawing.Font("MS UI Gothic", 12F);
            this.Listview1.FullRowSelect = true;
            this.Listview1.Location = new System.Drawing.Point(41, 43);
            this.Listview1.MultiSelect = false;
            this.Listview1.Name = "Listview1";
            this.Listview1.Size = new System.Drawing.Size(487, 292);
            this.Listview1.TabIndex = 0;
            this.Listview1.UseCompatibleStateImageBehavior = false;
            this.Listview1.View = System.Windows.Forms.View.Details;
            this.Listview1.SelectedIndexChanged += new System.EventHandler(this.Listview1_SelectedIndexChanged);
            // 
            // close
            // 
            this.close.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.close.Font = new System.Drawing.Font("MS UI Gothic", 12F);
            this.close.Location = new System.Drawing.Point(884, 600);
            this.close.Name = "close";
            this.close.Size = new System.Drawing.Size(135, 50);
            this.close.TabIndex = 10;
            this.close.Text = "閉じる";
            this.close.UseVisualStyleBackColor = true;
            this.close.Click += new System.EventHandler(this.close_Click);
            // 
            // Add2
            // 
            this.Add2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.Add2.Font = new System.Drawing.Font("MS UI Gothic", 12F);
            this.Add2.Location = new System.Drawing.Point(867, 370);
            this.Add2.Name = "Add2";
            this.Add2.Size = new System.Drawing.Size(152, 44);
            this.Add2.TabIndex = 7;
            this.Add2.Text = "新規追加";
            this.Add2.UseVisualStyleBackColor = true;
            // 
            // Add1
            // 
            this.Add1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.Add1.Font = new System.Drawing.Font("MS UI Gothic", 12F);
            this.Add1.Location = new System.Drawing.Point(867, 36);
            this.Add1.Name = "Add1";
            this.Add1.Size = new System.Drawing.Size(152, 44);
            this.Add1.TabIndex = 2;
            this.Add1.Text = "新規追加";
            this.Add1.UseVisualStyleBackColor = true;
            // 
            // Delete2
            // 
            this.Delete2.Font = new System.Drawing.Font("MS UI Gothic", 12F);
            this.Delete2.Location = new System.Drawing.Point(719, 440);
            this.Delete2.Name = "Delete2";
            this.Delete2.Size = new System.Drawing.Size(125, 45);
            this.Delete2.TabIndex = 9;
            this.Delete2.Text = "削除";
            this.Delete2.UseVisualStyleBackColor = true;
            // 
            // Change2
            // 
            this.Change2.Font = new System.Drawing.Font("MS UI Gothic", 12F);
            this.Change2.Location = new System.Drawing.Point(536, 440);
            this.Change2.Name = "Change2";
            this.Change2.Size = new System.Drawing.Size(125, 45);
            this.Change2.TabIndex = 8;
            this.Change2.Text = "変更";
            this.Change2.UseVisualStyleBackColor = true;
            // 
            // Delete1
            // 
            this.Delete1.Font = new System.Drawing.Font("MS UI Gothic", 12F);
            this.Delete1.Location = new System.Drawing.Point(729, 110);
            this.Delete1.Name = "Delete1";
            this.Delete1.Size = new System.Drawing.Size(125, 50);
            this.Delete1.TabIndex = 4;
            this.Delete1.Text = "削除";
            this.Delete1.UseVisualStyleBackColor = true;
            // 
            // Change1
            // 
            this.Change1.Font = new System.Drawing.Font("MS UI Gothic", 12F);
            this.Change1.Location = new System.Drawing.Point(534, 110);
            this.Change1.Name = "Change1";
            this.Change1.Size = new System.Drawing.Size(125, 50);
            this.Change1.TabIndex = 3;
            this.Change1.Text = "変更";
            this.Change1.UseVisualStyleBackColor = true;
            // 
            // Textbox2
            // 
            this.Textbox2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Textbox2.Font = new System.Drawing.Font("MS UI Gothic", 12F);
            this.Textbox2.Location = new System.Drawing.Point(536, 377);
            this.Textbox2.Name = "Textbox2";
            this.Textbox2.Size = new System.Drawing.Size(309, 31);
            this.Textbox2.TabIndex = 6;
            // 
            // Textbox1
            // 
            this.Textbox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Textbox1.Font = new System.Drawing.Font("MS UI Gothic", 12F);
            this.Textbox1.Location = new System.Drawing.Point(534, 42);
            this.Textbox1.Name = "Textbox1";
            this.Textbox1.Size = new System.Drawing.Size(311, 31);
            this.Textbox1.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("MS UI Gothic", 12F);
            this.label2.Location = new System.Drawing.Point(12, 350);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(67, 24);
            this.label2.TabIndex = 16;
            this.label2.Text = "label2";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("MS UI Gothic", 12F);
            this.label1.Location = new System.Drawing.Point(16, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(67, 24);
            this.label1.TabIndex = 15;
            this.label1.Text = "label1";
            // 
            // manageBase
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1030, 666);
            this.Controls.Add(this.Listview2);
            this.Controls.Add(this.Listview1);
            this.Controls.Add(this.close);
            this.Controls.Add(this.Add2);
            this.Controls.Add(this.Add1);
            this.Controls.Add(this.Delete2);
            this.Controls.Add(this.Change2);
            this.Controls.Add(this.Delete1);
            this.Controls.Add(this.Change1);
            this.Controls.Add(this.Textbox2);
            this.Controls.Add(this.Textbox1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(1052, 722);
            this.Name = "manageBase";
            this.Text = "manageBase";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        protected System.Windows.Forms.ColumnHeader coumn2;
        protected System.Windows.Forms.ListView Listview2;
        protected System.Windows.Forms.ColumnHeader ID2;
        protected System.Windows.Forms.ColumnHeader column1;
        protected System.Windows.Forms.ColumnHeader ID;
        protected System.Windows.Forms.ListView Listview1;
        protected System.Windows.Forms.Button close;
        protected System.Windows.Forms.Button Add2;
        protected System.Windows.Forms.Button Add1;
        protected System.Windows.Forms.Button Delete2;
        protected System.Windows.Forms.Button Change2;
        protected System.Windows.Forms.Button Delete1;
        protected System.Windows.Forms.Button Change1;
        protected System.Windows.Forms.TextBox Textbox2;
        protected System.Windows.Forms.TextBox Textbox1;
        protected System.Windows.Forms.Label label2;
        protected System.Windows.Forms.Label label1;

    }
}