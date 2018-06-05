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
using System.IO;

namespace 同人誌管理 {
    public partial class top : Form {
        public top() {
            InitializeComponent();
        }

        //検索と結果読み込み処理
        private void RoadResult(string WHEREphrase) {
            const string seach_query = "SELECT t_doujinshi.ID, title AS タイトル,GROUP_CONCAT(circle) AS サークル, " +
                "GROUP_CONCAT(author) AS 作者, date AS 頒布日 " +
                "FROM(t_doujinshi LEFT OUTER JOIN t_author ON t_doujinshi.ID = t_author.ID)" +
                "LEFT OUTER JOIN t_circle ON t_doujinshi.ID = t_circle.ID ";
            const string group_by=" GROUP BY t_doujinshi.ID";
            //リストビューへの読み出し
            listView.Items.Clear();   //二回目以降の多重出力を回避
            SQLiteDataReader reader = null;
            SQLiteConnect.beResponse(seach_query + WHEREphrase + group_by, ref reader);
            while (reader.Read()) {
                string[] items = {reader["ID"].ToString(),
                        reader["タイトル"].ToString(),
                        reader["サークル"].ToString(),
                        reader["作者"].ToString(),
                        Date.insert_y_m_d(reader["頒布日"].ToString())
                };
                listView.Items.Add(new ListViewItem(items));
            }
            reader.Close();
            SQLiteConnect.conn.Close();
        }

        //ロード時の処理
        private void top_Load(object sender, EventArgs e) {
            //DBファイルが無い時にテーブル作成
            SQLiteConnect.make_db();
            //DB書き込み時に不要な領域自動解放するよう設定
            SQLiteConnect.nonResponse("PRAGMA auto_vacuum = FULL");
            
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

        //列クリックによるソート処理、サブアイテムでのソートは未実装
        private void listView_ColumnClick(object sender, ColumnClickEventArgs e) {
            //listView.ListViewItemSorter = new ListViewItemComparer(e.Column);
            //MessageBox.Show(e.Column.ToString()+"がクリックされました");
            if (e.Column.ToString() == "1") {   //タイトルカラムクリック時

            }
        }

        //
        //以下はファイルメニューの処理です
        //

        //終了処理
        private void quit_Click(object sender, EventArgs e) {
            close_Click(sender, e);
        }

        //インポート処理
        private void import_Click(object sender, EventArgs e) {
            //OKボタンがクリックされたときインポートする
            if (importFileDialog.ShowDialog() == DialogResult.OK) {
                var file = new StreamReader(importFileDialog.FileName, Encoding.GetEncoding("Shift_JIS"));
                string line;
                progress.Visible = true;    //プログレス可視化
                int cnt_record = 0;
                while ((line = file.ReadLine()) != null) {
                    //一行単位で配列に格納してINSERT文に埋め込み
                    string[] subWords = line.Split(',');
                    if (subWords.Length != 8) { //一行から取り出したカラム数が8個でない時は中断
                        MessageBox.Show("フォーマットが正しくありません\n処理を中断します"); break;
                    }
                    string ins_doujinshi = "INSERT INTO t_doujinshi (ID,title,origin_ID,genre_ID,age_limit,date,place) VALUES(" +
                        subWords[0] + "," +"'" + subWords[1] + "'," + subWords[2] +","+subWords[3] + "," +
                        "'" + subWords[4] + "',"+subWords[7]+",'house')";
                    SQLiteConnect.nonResponse(ins_doujinshi);

                    //subWords[5]=(サークル)とsubWords[6]=(作者)を全角スペースSplitして別レコードにしながら各テーブルに格納
                    string[] splited_circle = subWords[5].Split('　');
                    string[] splited_author = subWords[6].Split('　');
                    for(int cnt=0; cnt < splited_circle.Length; cnt++) {
                        string ins_circle = "INSERT INTO t_circle VALUES(" +
                        subWords[0] + ",'" + splited_circle[cnt] + "')";
                        SQLiteConnect.nonResponse(ins_circle);
                    }

                    for (int cnt = 0; cnt < splited_author.Length; cnt++) {
                        string ins_author = "INSERT INTO t_author VALUES(" +
                        subWords[0] + ",'" + splited_author[cnt] + "')";
                        SQLiteConnect.nonResponse(ins_author);
                    }
                    
                    progress.Text = ((++cnt_record).ToString() + "件読み込みました。");
                    Application.DoEvents();
                }
                file.Close();
                progress.Visible = false;
                RoadResult("");
            }
        }

        //エクスポート処理
        private void export_Click(object sender, EventArgs e) {
            //OKボタンがクリックされたときインポートする
            if (exportFileDialog.ShowDialog() == DialogResult.OK) {
                Stream stream = exportFileDialog.OpenFile();
                if (stream != null) { 
                    StreamWriter sw = new StreamWriter(stream, Encoding.GetEncoding("Shift_JIS"));
                    //ここで書き込み処理
                    //SELECT文で元の情報を集めてreaderを一行ずつ出力
                    //sw.WriteLine("初めてのファイル出力です");


                    sw.Close();
                    stream.Close();
                }
                    
            }
        }
    }
}
