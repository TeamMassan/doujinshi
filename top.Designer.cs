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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(top));
            this.searchKind = new System.Windows.Forms.ComboBox();
            this.conditionWord = new System.Windows.Forms.TextBox();
            this.search = new System.Windows.Forms.Button();
            this.detailSearch = new System.Windows.Forms.Button();
            this.listView = new System.Windows.Forms.ListView();
            this.ID = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.title = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.circle = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.author = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.origin = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.date = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.add = new System.Windows.Forms.Button();
            this.tableManage = new System.Windows.Forms.Button();
            this.close = new System.Windows.Forms.Button();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.FileMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.FileMenuItemImport = new System.Windows.Forms.ToolStripMenuItem();
            this.FileMenuItemExport = new System.Windows.Forms.ToolStripMenuItem();
            this.FileMenuItemSeparator = new System.Windows.Forms.ToolStripSeparator();
            this.FileMenuItemQuit = new System.Windows.Forms.ToolStripMenuItem();
            this.progress = new System.Windows.Forms.Label();
            this.exportFileDialog = new System.Windows.Forms.SaveFileDialog();
            this.importFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.extendBookBase = new System.Windows.Forms.Button();
            this.bookShelfManage = new System.Windows.Forms.Button();
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
            this.searchKind.TabIndex = 1;
            // 
            // conditionWord
            // 
            this.conditionWord.AccessibleDescription = "";
            this.conditionWord.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.conditionWord.Font = new System.Drawing.Font("MS UI Gothic", 12F);
            this.conditionWord.Location = new System.Drawing.Point(192, 42);
            this.conditionWord.Name = "conditionWord";
            this.conditionWord.Size = new System.Drawing.Size(659, 23);
            this.conditionWord.TabIndex = 2;
            this.conditionWord.KeyDown += new System.Windows.Forms.KeyEventHandler(this.conditionWord_KeyDown);
            // 
            // search
            // 
            this.search.Font = new System.Drawing.Font("MS UI Gothic", 12F);
            this.search.Location = new System.Drawing.Point(25, 76);
            this.search.Name = "search";
            this.search.Size = new System.Drawing.Size(86, 23);
            this.search.TabIndex = 3;
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
            this.detailSearch.TabIndex = 4;
            this.detailSearch.Text = "詳細検索";
            this.detailSearch.UseVisualStyleBackColor = true;
            this.detailSearch.Click += new System.EventHandler(this.detailSearch_Click);
            // 
            // listView
            // 
            this.listView.AllowColumnReorder = true;
            this.listView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.listView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.ID,
            this.title,
            this.circle,
            this.author,
            this.origin,
            this.date});
            this.listView.Font = new System.Drawing.Font("MS UI Gothic", 12F);
            this.listView.FullRowSelect = true;
            this.listView.HideSelection = false;
            this.listView.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.listView.Location = new System.Drawing.Point(25, 108);
            this.listView.MultiSelect = false;
            this.listView.Name = "listView";
            this.listView.Size = new System.Drawing.Size(826, 312);
            this.listView.TabIndex = 5;
            this.listView.UseCompatibleStateImageBehavior = false;
            this.listView.View = System.Windows.Forms.View.Details;
            this.listView.ColumnClick += new System.Windows.Forms.ColumnClickEventHandler(this.listView_ColumnClick);
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
            // origin
            // 
            this.origin.Text = "作品";
            this.origin.Width = 110;
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
            this.add.Location = new System.Drawing.Point(25, 449);
            this.add.Name = "add";
            this.add.Size = new System.Drawing.Size(99, 51);
            this.add.TabIndex = 6;
            this.add.Text = "新規追加";
            this.add.UseVisualStyleBackColor = true;
            this.add.Click += new System.EventHandler(this.add_Click);
            // 
            // tableManage
            // 
            this.tableManage.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.tableManage.Font = new System.Drawing.Font("MS UI Gothic", 12F);
            this.tableManage.Location = new System.Drawing.Point(192, 449);
            this.tableManage.Name = "tableManage";
            this.tableManage.Size = new System.Drawing.Size(100, 51);
            this.tableManage.TabIndex = 7;
            this.tableManage.Text = "属性管理";
            this.tableManage.UseVisualStyleBackColor = true;
            this.tableManage.Click += new System.EventHandler(this.tableManage_Click);
            // 
            // close
            // 
            this.close.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.close.Font = new System.Drawing.Font("MS UI Gothic", 12F);
            this.close.Location = new System.Drawing.Point(751, 449);
            this.close.Name = "close";
            this.close.Size = new System.Drawing.Size(100, 51);
            this.close.TabIndex = 9;
            this.close.Text = "閉じる";
            this.close.UseVisualStyleBackColor = true;
            this.close.Click += new System.EventHandler(this.close_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.FileMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(879, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // FileMenuItem
            // 
            this.FileMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.FileMenuItemImport,
            this.FileMenuItemExport,
            this.FileMenuItemSeparator,
            this.FileMenuItemQuit});
            this.FileMenuItem.Name = "FileMenuItem";
            this.FileMenuItem.Size = new System.Drawing.Size(67, 20);
            this.FileMenuItem.Text = "ファイル(&F)";
            // 
            // FileMenuItemImport
            // 
            this.FileMenuItemImport.Name = "FileMenuItemImport";
            this.FileMenuItemImport.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.I)));
            this.FileMenuItemImport.Size = new System.Drawing.Size(234, 22);
            this.FileMenuItemImport.Text = "CSV形式でインポート(&I)";
            this.FileMenuItemImport.Click += new System.EventHandler(this.import_Click);
            // 
            // FileMenuItemExport
            // 
            this.FileMenuItemExport.Name = "FileMenuItemExport";
            this.FileMenuItemExport.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.E)));
            this.FileMenuItemExport.Size = new System.Drawing.Size(234, 22);
            this.FileMenuItemExport.Text = "CSV形式でエクスポート(&E)";
            this.FileMenuItemExport.Click += new System.EventHandler(this.export_Click);
            // 
            // FileMenuItemSeparator
            // 
            this.FileMenuItemSeparator.Name = "FileMenuItemSeparator";
            this.FileMenuItemSeparator.Size = new System.Drawing.Size(231, 6);
            // 
            // FileMenuItemQuit
            // 
            this.FileMenuItemQuit.Name = "FileMenuItemQuit";
            this.FileMenuItemQuit.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.F4)));
            this.FileMenuItemQuit.Size = new System.Drawing.Size(234, 22);
            this.FileMenuItemQuit.Text = "終了(&X)";
            this.FileMenuItemQuit.Click += new System.EventHandler(this.quit_Click);
            // 
            // progress
            // 
            this.progress.AutoSize = true;
            this.progress.Font = new System.Drawing.Font("MS UI Gothic", 12F);
            this.progress.Location = new System.Drawing.Point(380, 262);
            this.progress.Name = "progress";
            this.progress.Size = new System.Drawing.Size(127, 16);
            this.progress.TabIndex = 9;
            this.progress.Text = "progress_message";
            this.progress.Visible = false;
            // 
            // exportFileDialog
            // 
            this.exportFileDialog.Filter = "csvファイル (*.csv)|*.csv|すべてのファイル|*.*";
            this.exportFileDialog.RestoreDirectory = true;
            this.exportFileDialog.Title = "保存先を選択してください";
            // 
            // importFileDialog
            // 
            this.importFileDialog.Filter = "csvファイル (*.csv)|*.csv|テキストファイル(*.txt)|*.txt";
            this.importFileDialog.Title = "開くファイルを選択してください";
            // 
            // extendBookBase
            // 
            this.extendBookBase.Location = new System.Drawing.Point(530, 449);
            this.extendBookBase.Name = "extendBookBase";
            this.extendBookBase.Size = new System.Drawing.Size(96, 51);
            this.extendBookBase.TabIndex = 10;
            this.extendBookBase.Text = "親クラス生成";
            this.extendBookBase.UseVisualStyleBackColor = true;
            this.extendBookBase.Click += new System.EventHandler(this.extendBookBase_Click);
            // 
            // bookShelfManage
            // 
            this.bookShelfManage.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.bookShelfManage.Font = new System.Drawing.Font("MS UI Gothic", 12F);
            this.bookShelfManage.Location = new System.Drawing.Point(329, 449);
            this.bookShelfManage.Name = "bookShelfManage";
            this.bookShelfManage.Size = new System.Drawing.Size(131, 51);
            this.bookShelfManage.TabIndex = 8;
            this.bookShelfManage.Text = "本棚番号管理";
            this.bookShelfManage.UseVisualStyleBackColor = true;
            // 
            // top
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(879, 528);
            this.Controls.Add(this.bookShelfManage);
            this.Controls.Add(this.extendBookBase);
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
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.MinimumSize = new System.Drawing.Size(890, 565);
            this.Name = "top";
            this.Text = "同人誌管理";
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
        private System.Windows.Forms.ToolStripMenuItem FileMenuItem;
        private System.Windows.Forms.ToolStripMenuItem FileMenuItemImport;
        private System.Windows.Forms.ToolStripMenuItem FileMenuItemExport;
        private System.Windows.Forms.ToolStripMenuItem FileMenuItemQuit;
        private System.Windows.Forms.Label progress;
        private System.Windows.Forms.SaveFileDialog exportFileDialog;
        private System.Windows.Forms.OpenFileDialog importFileDialog;
        private System.Windows.Forms.ColumnHeader origin;
        private System.Windows.Forms.ToolStripSeparator FileMenuItemSeparator;
        private System.Windows.Forms.Button extendBookBase;
        private System.Windows.Forms.Button bookShelfManage;
    }
}

