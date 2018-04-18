using System;

namespace 同人誌管理 {
    partial class top {
        /// <summary>
        /// 必要なデザイナー変数です。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

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
        private void InitializeComponent() {
            this.searchKind = new System.Windows.Forms.ComboBox();
            this.conditionWord = new System.Windows.Forms.TextBox();
            this.search = new System.Windows.Forms.Button();
            this.detailSearch = new System.Windows.Forms.Button();
            this.listView = new System.Windows.Forms.ListView();
            this.ID = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.title = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.circle = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.author = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.date = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.add = new System.Windows.Forms.Button();
            this.tableManage = new System.Windows.Forms.Button();
            this.close = new System.Windows.Forms.Button();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.ファイルFToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.import = new System.Windows.Forms.ToolStripMenuItem();
            this.export = new System.Windows.Forms.ToolStripMenuItem();
            this.quit = new System.Windows.Forms.ToolStripMenuItem();
            this.progress = new System.Windows.Forms.Label();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // searchKind
            // 
            this.searchKind.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.searchKind.Font = new System.Drawing.Font("MS UI Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.searchKind.FormattingEnabled = true;
            this.searchKind.Location = new System.Drawing.Point(25, 42);
            this.searchKind.Name = "searchKind";
            this.searchKind.Size = new System.Drawing.Size(121, 24);
            this.searchKind.TabIndex = 0;
            // 
            // conditionWord
            // 
            this.conditionWord.AccessibleDescription = "";
            this.conditionWord.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.conditionWord.Font = new System.Drawing.Font("MS UI Gothic", 12F);
            this.conditionWord.Location = new System.Drawing.Point(192, 42);
            this.conditionWord.Name = "conditionWord";
            this.conditionWord.Size = new System.Drawing.Size(522, 23);
            this.conditionWord.TabIndex = 1;
            // 
            // search
            // 
            this.search.Font = new System.Drawing.Font("MS UI Gothic", 12F);
            this.search.Location = new System.Drawing.Point(25, 76);
            this.search.Name = "search";
            this.search.Size = new System.Drawing.Size(86, 23);
            this.search.TabIndex = 2;
            this.search.Text = "検索";
            this.search.UseVisualStyleBackColor = true;
            this.search.Click += new System.EventHandler(this.search_Click);
            // 
            // detailSearch
            // 
            this.detailSearch.Font = new System.Drawing.Font("MS UI Gothic", 12F);
            this.detailSearch.Location = new System.Drawing.Point(152, 76);
            this.detailSearch.Name = "detailSearch";
            this.detailSearch.Size = new System.Drawing.Size(91, 23);
            this.detailSearch.TabIndex = 3;
            this.detailSearch.Text = "詳細検索";
            this.detailSearch.UseVisualStyleBackColor = true;
            this.detailSearch.Click += new System.EventHandler(this.detailSearch_Click);
            // 
            // listView
            // 
            this.listView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.listView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.ID,
            this.title,
            this.circle,
            this.author,
            this.date});
            this.listView.Font = new System.Drawing.Font("MS UI Gothic", 12F);
            this.listView.FullRowSelect = true;
            this.listView.Location = new System.Drawing.Point(25, 108);
            this.listView.MultiSelect = false;
            this.listView.Name = "listView";
            this.listView.Size = new System.Drawing.Size(689, 303);
            this.listView.TabIndex = 4;
            this.listView.UseCompatibleStateImageBehavior = false;
            this.listView.View = System.Windows.Forms.View.Details;
            this.listView.DoubleClick += new System.EventHandler(this.listView_DoubleClick);
            // 
            // ID
            // 
            this.ID.Text = "ID";
            this.ID.Width = 34;
            // 
            // title
            // 
            this.title.Text = "タイトル";
            this.title.Width = 188;
            // 
            // circle
            // 
            this.circle.Text = "サークル";
            this.circle.Width = 170;
            // 
            // author
            // 
            this.author.Text = "作者";
            this.author.Width = 124;
            // 
            // date
            // 
            this.date.Text = "頒布日";
            this.date.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.date.Width = 143;
            // 
            // add
            // 
            this.add.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.add.Font = new System.Drawing.Font("MS UI Gothic", 12F);
            this.add.Location = new System.Drawing.Point(25, 440);
            this.add.Name = "add";
            this.add.Size = new System.Drawing.Size(99, 51);
            this.add.TabIndex = 5;
            this.add.Text = "新規追加";
            this.add.UseVisualStyleBackColor = true;
            this.add.Click += new System.EventHandler(this.add_Click);
            // 
            // tableManage
            // 
            this.tableManage.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.tableManage.Font = new System.Drawing.Font("MS UI Gothic", 12F);
            this.tableManage.Location = new System.Drawing.Point(192, 440);
            this.tableManage.Name = "tableManage";
            this.tableManage.Size = new System.Drawing.Size(100, 51);
            this.tableManage.TabIndex = 6;
            this.tableManage.Text = "属性管理";
            this.tableManage.UseVisualStyleBackColor = true;
            this.tableManage.Click += new System.EventHandler(this.tableManage_Click);
            // 
            // close
            // 
            this.close.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.close.Font = new System.Drawing.Font("MS UI Gothic", 12F);
            this.close.Location = new System.Drawing.Point(614, 440);
            this.close.Name = "close";
            this.close.Size = new System.Drawing.Size(100, 51);
            this.close.TabIndex = 7;
            this.close.Text = "閉じる";
            this.close.UseVisualStyleBackColor = true;
            this.close.Click += new System.EventHandler(this.close_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ファイルFToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(742, 24);
            this.menuStrip1.TabIndex = 8;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // ファイルFToolStripMenuItem
            // 
            this.ファイルFToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.import,
            this.export,
            this.quit});
            this.ファイルFToolStripMenuItem.Name = "ファイルFToolStripMenuItem";
            this.ファイルFToolStripMenuItem.Size = new System.Drawing.Size(67, 20);
            this.ファイルFToolStripMenuItem.Text = "ファイル(&F)";
            // 
            // import
            // 
            this.import.Name = "import";
            this.import.Size = new System.Drawing.Size(195, 22);
            this.import.Text = "CSV形式でインポート(&I)";
            this.import.Click += new System.EventHandler(this.import_Click);
            // 
            // export
            // 
            this.export.Name = "export";
            this.export.Size = new System.Drawing.Size(195, 22);
            this.export.Text = "CSV形式でエクスポート(&E)";
            this.export.Click += new System.EventHandler(this.export_Click);
            // 
            // quit
            // 
            this.quit.Name = "quit";
            this.quit.Size = new System.Drawing.Size(195, 22);
            this.quit.Text = "終了(&X)";
            this.quit.Click += new System.EventHandler(this.quit_Click);
            // 
            // progress
            // 
            this.progress.AutoSize = true;
            this.progress.Font = new System.Drawing.Font("MS UI Gothic", 12F);
            this.progress.Location = new System.Drawing.Point(350, 452);
            this.progress.Name = "progress";
            this.progress.Size = new System.Drawing.Size(127, 16);
            this.progress.TabIndex = 9;
            this.progress.Text = "progress_message";
            this.progress.Visible = false;
            // 
            // top
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(742, 519);
            this.Controls.Add(this.progress);
            this.Controls.Add(this.listView);
            this.Controls.Add(this.close);
            this.Controls.Add(this.tableManage);
            this.Controls.Add(this.add);
            this.Controls.Add(this.detailSearch);
            this.Controls.Add(this.search);
            this.Controls.Add(this.conditionWord);
            this.Controls.Add(this.searchKind);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "top";
            this.Text = "同人誌管理";
            this.Load += new System.EventHandler(this.top_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        #endregion
        private System.Windows.Forms.TextBox conditionWord;
        private System.Windows.Forms.Button search;
        private System.Windows.Forms.Button detailSearch;
        private System.Windows.Forms.ListView listView;
        private System.Windows.Forms.Button add;
        private System.Windows.Forms.Button tableManage;
        private System.Windows.Forms.Button close;
        public System.Windows.Forms.ComboBox searchKind;
        private System.Windows.Forms.ColumnHeader ID;
        private System.Windows.Forms.ColumnHeader title;
        private System.Windows.Forms.ColumnHeader circle;
        private System.Windows.Forms.ColumnHeader author;
        private System.Windows.Forms.ColumnHeader date;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem ファイルFToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem import;
        private System.Windows.Forms.ToolStripMenuItem export;
        private System.Windows.Forms.ToolStripMenuItem quit;
        private System.Windows.Forms.Label progress;
    }
}

