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

        //検索と結果読み込み処理
        private void RoadResult(string WHEREphrase) {
            string seach_query = "SELECT t_doujinshi.ID,title,circle,author,date " +
                                "FROM(t_doujinshi LEFT OUTER JOIN t_author ON t_doujinshi.ID = t_author.ID)" +
                                "LEFT OUTER JOIN t_circle ON t_doujinshi.ID = t_circle.ID ";

            //全レコード検出するSELECTにWHERE句を連結
            seach_query += WHEREphrase;

            //リストボックスへの読み出し
            listView.Items.Clear();   //二回目以降の多重出力を回避
            SQLiteDataReader reader = null;
            SQLiteConnect.beResponse(seach_query, ref reader);
            string[] items = new string[5];
            string LastId=null;
            while (reader.Read()) {
                //合同本の場合、同一IDから検出して複数レコードは同一カラムに納める
                if (LastId == reader["ID"].ToString()) {
                    if (items[2] != reader["circle"].ToString())
                        items[2] += " , " + reader["circle"].ToString();
                    if (items[3] != reader["author"].ToString())
                        items[3] += " , " + reader["author"].ToString();
                    //直前の追加済みレコードを削除
                    listView.Items.RemoveAt(int.Parse(LastId)-1);
                } else {
                    items[0] = reader["ID"].ToString();
                    LastId = items[0];
                    items[1] = reader["title"].ToString();
                    items[2] = reader["circle"].ToString();
                    items[3] = reader["author"].ToString();
                    items[4] = Date.insert_y_m_d(reader["date"].ToString());
                }
                listView.Items.Add(new ListViewItem(items));
            }
            reader.Close();
            SQLiteConnect.conn.Close();
        }

        //ロード時の処理
        private void top_Load(object sender, EventArgs e) {
            //DBファイルが無い時にテーブル作成
            SQLiteConnect.make_db();
            //簡易検索のジャンルをロード
            searchKind.Items.Add("全て");
            searchKind.Items.Add("作品タイトル");
            searchKind.Items.Add("作家名");
            searchKind.Items.Add("サークル名");
            searchKind.Items.Add("キャラ名");
        }

        //通常検索実行時の処理
        private void search_Click(object sender, EventArgs e) {
            string conditions = "";  //検索条件
            switch (searchKind.Text) {
                case "作品タイトル":
                    conditions = "WHERE title LIKE '%" + conditionWord.Text + "%'"; break;
                case "作家名":
                    conditions = "WHERE author LIKE '%" + conditionWord.Text + "%'"; break;
                case "サークル名":
                    conditions = "WHERE circle LIKE '%" + conditionWord.Text + "%'"; break;
                case "キャラ名":
                    conditions = "WHERE main_chara LIKE '%" + conditionWord.Text + "%'"; break;
                case "全て":
                    conditions = "WHERE title LIKE '%" + conditionWord.Text + "%' OR " +
                        "author LIKE '%" + conditionWord.Text + "%' OR " +
                        "circle LIKE '%" + conditionWord.Text + "%'";
                    break;
                default: break;
            }
            //検索結果を表示
            RoadResult(conditions);
        }

        //詳細検索実行時の処理
        private void detailSearch_Click(object sender, EventArgs e) {
            var detail = new detail_search();
            detail.ShowDialog();
            //詳細検索WHERE句を得て結果表示する
            if (detail.search_flag == true)
                RoadResult(detail.conditions);
        }

        //アイテムをダブルクリック選択時に更新フォームを開く
        private void listView_DoubleClick(object sender, EventArgs e) {
            var update = new update();
            update.selected_ID = listView.SelectedItems[0].SubItems[0].Text;
            update.ShowDialog();
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

        //
        //以下はファイルメニューの処理です
        //
        private void quit_Click(object sender, EventArgs e) {
            close_Click(sender, e);
        }

        //インポート処理
        private void import_Click(object sender, EventArgs e) {
            //ファイルダイアログを開く
            var importFile = new OpenFileDialog();
            importFile.Filter = "csvファイル (*.csv)|*.csv|テキストファイル(*.txt)|*.txt";
            importFile.Title = "開くファイルを選択してください";

            //OKボタンがクリックされたとき、選択されたファイルを読み取り専用で開く
            if (importFile.ShowDialog() == DialogResult.OK) {
                System.IO.Stream stream = importFile.OpenFile();
                if (stream != null) {
                    //内容を読み込み、表示する
                    var cursor = new System.IO.StreamReader(stream);
                    
                    //各レコードの行を,や\nで判断しながらfor文で見てインポートしたい

                    //とりあえず内容見てみる
                    MessageBox.Show(cursor.ReadToEnd());
                    //閉じる
                    cursor.Close();
                    stream.Close();
                }
            }
        }

        //エクスポート処理
        private void export_Click(object sender, EventArgs e) {
            //全レコードを適切な形でcsv出力したい
        }
    }
}
