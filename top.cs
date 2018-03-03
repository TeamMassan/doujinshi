using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SQLite;

namespace 同人誌管理 {
    public partial class top : Form {
        public top() {
            InitializeComponent();
        }

        //ロード時の処理
        private void top_Load(object sender, EventArgs e) {
            //簡易検索のジャンルをロード
            searchKind.Items.Add("全て");
            searchKind.Items.Add("作品タイトル");
            searchKind.Items.Add("作家名");
            searchKind.Items.Add("サークル名");
        }

        //通常検索実行時の処理
        private void search_Click(object sender, EventArgs e) {

        }
        //詳細検索実行時の処理
        private void detailSearch_Click(object sender, EventArgs e) {
            detail_search detail = new detail_search();
            detail.ShowDialog();
        }

        //閉じるボタンの処理
        private void close_Click(object sender, EventArgs e) {
            this.Close();
        }

        //新規追加ボタンの処理
        private void add_Click(object sender, EventArgs e) {
            add add = new add();
            add.ShowDialog();
        }

        //属性管理ボタンの処理
        private void tableManage_Click(object sender, EventArgs e) {
            table_manage table_manege = new table_manage();
            table_manege.ShowDialog();
        }
    }
}
