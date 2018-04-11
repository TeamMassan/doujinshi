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
        SQLiteConnct DB = new SQLiteConnct();
        string detail_query = "SELECT t_doujinshi.ID,title,circle,author,date " +
                                "FROM(t_doujinshi LEFT OUTER JOIN t_author ON t_doujinshi.ID = t_author.ID)" +
                                "LEFT OUTER JOIN t_circle ON t_doujinshi.ID = t_circle.ID ";
        
        //SELECT文を引数にして検索結果を読み込む
        public static void road_result(string select_query) {
            //SQLConnectクラスを静的に書き直した後に書く
        }
        
        //ロード時の処理
        private void top_Load(object sender, EventArgs e) {
            //DBファイルが無い時にテーブル作成
            DB.make_db();
            //簡易検索のジャンルをロード
            searchKind.Items.Add("全て");
            searchKind.Items.Add("作品タイトル");
            searchKind.Items.Add("作家名");
            searchKind.Items.Add("サークル名");
        }

        //通常検索実行時の処理
        private void search_Click(object sender, EventArgs e) {
            //SELECTクエリ発行
            string search_query = "SELECT t_doujinshi.ID,title,circle,author,date " +
                                "FROM(t_doujinshi LEFT OUTER JOIN t_author ON t_doujinshi.ID = t_author.ID)" +
                                "LEFT OUTER JOIN t_circle ON t_doujinshi.ID = t_circle.ID ";
            string conditions = "";  //検索条件
            switch (searchKind.Text) {
                case "作品タイトル":
                    conditions = "WHERE title LIKE '%" + conditionWord.Text + "%'"; break;
                case "作家名":
                    conditions = "WHERE author LIKE '%" + conditionWord.Text + "%'"; break;
                case "サークル名":
                    conditions = "WHERE circle LIKE '%" + conditionWord.Text + "%'"; break;
                case "全て":
                    conditions = "WHERE title LIKE '%" + conditionWord.Text + "%' OR " +
                        "author LIKE '%" + conditionWord.Text + "%' OR " +
                        "circle LIKE '%" + conditionWord.Text + "%'";
                    break;
                default: break;
            }
            search_query += conditions;
            SQLiteDataReader reader = null;
            DB.beResponse(search_query, ref reader);

            //リストボックスへの読み出し
            listView.Items.Clear();   //二回目以降の多重出力を回避
            string[] items = new string[5];
            while (reader.Read()) {
                //サークル・作者が複数レコードの場合、同一IDから検出して複数レコードを同一カラムに納めたい
                items[0] = reader["ID"].ToString();
                items[1] = reader["title"].ToString();
                items[2] = reader["circle"].ToString();
                items[3] = reader["author"].ToString();
                items[4] = DB.format_date(reader["date"].ToString());
                listView.Items.Add(new ListViewItem(items));
            }
            /*
            while (reader.Read()) {
                items[0] = reader["ID"].ToString();
                items[1] = reader["title"].ToString();
                items[2] = reader["circle"].ToString();
                items[3] = reader["author"].ToString();
                items[4] = DB.format_date(reader["date"].ToString());
                listView.Items.Add(new ListViewItem(items));
            }
            */
            reader.Close();
            DB.conn.Close();
        }
        //詳細検索実行時の処理
        private void detailSearch_Click(object sender, EventArgs e) {
            var detail = new detail_search();
            string search_query = "SELECT t_doujinshi.ID,title,circle,author,date " +
                                "FROM(t_doujinshi LEFT OUTER JOIN t_author ON t_doujinshi.ID = t_author.ID)" +
                                "LEFT OUTER JOIN t_circle ON t_doujinshi.ID = t_circle.ID ";
            detail.ShowDialog();
            //search_query += detail.conditions;
            //Clipboard.SetText(search_query);
        }

        //閉じるボタンの処理
        private void close_Click(object sender, EventArgs e) {
            this.Close();
        }

        //新規追加ボタンの処理
        private void add_Click(object sender, EventArgs e) {
            var add = new add();
            add.ShowDialog();
        }

        //属性管理ボタンの処理
        private void tableManage_Click(object sender, EventArgs e) {
            var table_manege = new table_manage();
            table_manege.ShowDialog();
        }

        //リストビューアイテムの選択時の処理
        private void listView_SelectedIndexChanged(object sender, EventArgs e) {
            if (listView.SelectedItems.Count > 0)
                //二回目クリック以降にヘッダを除外してIDを取り出したい
                checkForm.Text = listView.SelectedItems[0].SubItems[1].Text;
        }
    }
}
