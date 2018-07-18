﻿using System;
using System.Collections;
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
            const string seach_query = "SELECT t_doujinshi.ID,title AS タイトル,サークル,作者,origin_title AS 作品,date AS 頒布日 "+
                "FROM(SELECT main.ID, title, origin_ID, genre_ID, age_limit, date, main_chara, place_ID, サークル, GROUP_CONCAT(author) AS 作者 "+
                "FROM(SELECT t_doujinshi.ID, title, origin_ID, genre_ID, age_limit, date, main_chara, place_ID, GROUP_CONCAT(circle) AS サークル "+
                "FROM t_doujinshi LEFT OUTER JOIN t_circle ON t_doujinshi.ID = t_circle.ID GROUP BY t_doujinshi.ID) AS main "+
                "LEFT OUTER JOIN t_author ON main.ID = t_author.ID GROUP BY main.ID) AS t_doujinshi "+
                "LEFT OUTER JOIN t_origin ON t_doujinshi.origin_ID = t_origin.origin_ID ";
            //リストビューへの読み出し
            listView.Items.Clear();   //二回目以降の多重出力を回避
            SQLiteDataReader reader = null;
            SQLiteConnect.Excute(seach_query + WHEREphrase, ref reader);
            if (reader == null) {
                MessageBox.Show("結果を取得出来ませんでした");
                return;
            }
            while (reader.Read()) {
                string[] items = { reader["ID"].ToString(),
                        reader["タイトル"].ToString(),
                        reader["サークル"].ToString(),
                        reader["作者"].ToString(),
                        reader["作品"].ToString(),
                        Date.insert_y_m_d(reader["頒布日"].ToString())
                };
                listView.Items.Add(new ListViewItem(items));
            }
            reader.Close();
            SQLiteConnect.conn.Close();
        }


        //ListViewItemSorterに指定するフィールド
        ListViewItemComparer listViewItemSorter;

        //ロード時の処理
        private void top_Load(object sender, EventArgs e) {
            //DBファイルが無い時にテーブル作成
            SQLiteConnect.make_db();
            //DB書き込み時に不要な領域自動解放するよう設定
            SQLiteConnect.Excute("PRAGMA auto_vacuum = FULL");
            //外部キー設定の有効化
            SQLiteConnect.Excute("PRAGMA foreign_keys = true");

            //簡易検索のジャンルをロード
            searchKind.Items.Add("全て");
            searchKind.Items.Add("作品タイトル");
            searchKind.Items.Add("作家名");
            searchKind.Items.Add("サークル名");
            searchKind.Items.Add("キャラ名");
            searchKind.SelectedIndex = 0;

            //ListViewItemComparerの作成と設定
            listViewItemSorter = new ListViewItemComparer();
            listViewItemSorter.ColumnModes = new ListViewItemComparer.ComparerMode[]{
                ListViewItemComparer.ComparerMode.String,
                ListViewItemComparer.ComparerMode.Integer
            };
        }

        //通常検索実行時の処理
        private void search_Click(object sender, EventArgs e) {
            string conditions = "";  //検索条件
            switch (searchKind.Text) {
                case "作品タイトル":
                    conditions = "WHERE title LIKE '%" + conditionWord.Text + "%'"; break;
                case "作家名":
                    conditions = "WHERE 作者 LIKE '%" + conditionWord.Text + "%'"; break;
                case "サークル名":
                    conditions = "WHERE サークル LIKE '%" + conditionWord.Text + "%'"; break;
                case "キャラ名":
                    conditions = "WHERE main_chara LIKE '%" + conditionWord.Text + "%'"; break;
                case "全て":
                    conditions = "WHERE title LIKE '%" + conditionWord.Text + "%' OR " +
                        "作者 LIKE '%" + conditionWord.Text + "%' OR " +
                        "サークル LIKE '%" + conditionWord.Text + "%'";
                    break;
                default: break;
            }
            //検索結果を表示
            RoadResult(conditions);
        }
        //Enterが押されても検索処理を行う
        private void conditionWord_KeyDown(object sender, KeyEventArgs e) {
            if (e.KeyCode == Keys.Enter)
                search_Click(sender, e);
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
            //update呼び出し時に選択IDを渡す
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

        //列クリックによるソート処理
        private void listView_ColumnClick(object sender, ColumnClickEventArgs e) {
            listView.ListViewItemSorter = listViewItemSorter;
            listViewItemSorter.Column = e.Column;
            listView.Sort();
            listView.ListViewItemSorter = null;
        }

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
                progress.Visible = true;    //インポート状況可視化
                int cnt_record = 0;
                while ((line = file.ReadLine()) != null) {
                    //一行単位で配列に格納してINSERT文に埋め込み
                    string[] subWords = line.Split(',');
                    if (subWords.Length != 8) { //一行から取り出したカラム数が8個でない時は中断
                        MessageBox.Show("フォーマットが正しくありません\n処理を中断します"); break;
                    }
                    string ins_doujinshi = "INSERT INTO t_doujinshi (ID,title,origin_ID,genre_ID,age_limit,date,place_ID) VALUES(" +
                        subWords[0] + "," +"'" + subWords[1] + "'," + subWords[2] +","+subWords[3] + "," +
                        "'" + subWords[4] + "',"+subWords[7]+",1)";
                    SQLiteConnect.Excute(ins_doujinshi);

                    //subWords[5]=(サークル)とsubWords[6]=(作者)を全角スペースSplitして別レコードにしながら各テーブルに格納
                    string[] splited_circle = subWords[5].Split('　');
                    string[] splited_author = subWords[6].Split('　');
                    for(int cnt=0; cnt < splited_circle.Length; cnt++) {
                        string ins_circle = "INSERT INTO t_circle VALUES(" +
                        subWords[0] + ",'" + splited_circle[cnt] + "')";
                        SQLiteConnect.Excute(ins_circle);
                    }

                    for (int cnt = 0; cnt < splited_author.Length; cnt++) {
                        string ins_author = "INSERT INTO t_author VALUES(" +
                        subWords[0] + ",'" + splited_author[cnt] + "')";
                        SQLiteConnect.Excute(ins_author);
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
                    //全情報を連結したSQLクエリの作成
                    const string select = "SELECT main.ID,title AS タイトル,origin_title,genre_title,age_limit,サークル,作者,date,main_chara ";
                    string query = select + SQLiteConnect.getFullInfoFrom + SQLiteConnect.getFullInfoLatter;
                    SQLiteDataReader reader = null;
                    SQLiteConnect.Excute(query, ref reader);
                    if (reader == null) { 
                        MessageBox.Show("SELECT結果が取得できませんでした");
                        return;
                    }
                    StreamWriter sw = new StreamWriter(stream, Encoding.GetEncoding("Shift_JIS"));
                    //ここで書き込み処理
                    while (reader.Read()) {
                        string[] items = {reader["ID"].ToString(),
                            reader["タイトル"].ToString(),
                            reader["origin_title"].ToString(),
                            reader["genre_title"].ToString(),
                            reader["age_limit"].ToString(),
                            //複数サークル等を繋ぐカンマがcsvのカンマと誤認されないように置き換える
                            reader["サークル"].ToString().Replace(',',' '),
                            reader["作者"].ToString().Replace(',',' '),
                            reader["date"].ToString(),
                            reader["main_chara"].ToString() };
                        for (int cnt = 0; cnt < items.Length; cnt++) {
                            sw.Write(items[cnt] + ',');
                        }
                        sw.Write('\n');
                    }
                    SQLiteConnect.conn.Close();
                    sw.Close();
                    stream.Close();
                    MessageBox.Show("エクスポートが完了しました");
                }             
            }
        }

        private void abstractedUpdate_Click(object sender, EventArgs e) {
            //BookBaseを継承したupdateクラスのインスタンスをここで作成
            var update = new update2();
            update.ShowDialog();
        }

        private void extendBookBase_Click(object sender, EventArgs e) {
            BookBase bookBase = new BookBase();
            bookBase.ShowDialog();
        }

        private void test_Click(object sender, EventArgs e)
        {
            var table_manage2 = new table_manage();
            table_manage2.ShowDialog();
        }

        private void bookShelfManage_Click(object sender, EventArgs e)
        {
            var shelf_manage = new shelf_manage();
            shelf_manage.ShowDialog();
        }
    }

    //リストビューのカラムクリックによるソートに使うクラス
    public class ListViewItemComparer : IComparer {
        /// <summary>
        /// 比較する方法
        /// </summary>
        public enum ComparerMode {
            /// <summary>
            /// 文字列として比較
            /// </summary>
            String,
            /// <summary>
            /// 数値（Int32型）として比較
            /// </summary>
            Integer,
            /// <summary>
            /// 日時（DataTime型）として比較
            /// </summary>
            DateTime
        };

        private int _column;
        private SortOrder _order;
        private ComparerMode _mode;
        private ComparerMode[] _columnModes;

        /// <summary>
        /// 並び替えるListView列の番号
        /// </summary>
        public int Column {
            set {
                //現在と同じ列の時は、昇順降順を切り替える
                if (_column == value) {
                    if (_order == SortOrder.Ascending) {
                        _order = SortOrder.Descending;
                    } else if (_order == SortOrder.Descending) {
                        _order = SortOrder.Ascending;
                    }
                }
                _column = value;
            }
            get {
                return _column;
            }
        }
        /// <summary>
        /// 昇順か降順か
        /// </summary>
        public SortOrder Order {
            set {
                _order = value;
            }
            get {
                return _order;
            }
        }
        /// <summary>
        /// 並び替えの方法
        /// </summary>
        public ComparerMode Mode {
            set {
                _mode = value;
            }
            get {
                return _mode;
            }
        }
        /// <summary>
        /// 列ごとの並び替えの方法
        /// </summary>
        public ComparerMode[] ColumnModes {
            set {
                _columnModes = value;
            }
        }

        /// <summary>
        /// ListViewItemComparerクラスのコンストラクタ
        /// </summary>
        /// <param name="col">並び替える列の番号</param>
        /// <param name="ord">昇順か降順か</param>
        /// <param name="cmod">並び替えの方法</param>
        public ListViewItemComparer(
            int col, SortOrder ord, ComparerMode cmod) {
            _column = col;
            _order = ord;
            _mode = cmod;
        }
        public ListViewItemComparer() {
            _column = 0;
            _order = SortOrder.Ascending;
            _mode = ComparerMode.String;
        }

        //xがyより小さいときはマイナスの数、大きいときはプラスの数、
        //同じときは0を返す
        public int Compare(object x, object y) {
            if (_order == SortOrder.None) {
                //並び替えない時
                return 0;
            }

            int result = 0;
            //ListViewItemの取得
            ListViewItem itemx = (ListViewItem)x;
            ListViewItem itemy = (ListViewItem)y;

            //並べ替えの方法を決定
            if (_columnModes != null && _columnModes.Length > _column) {
                _mode = _columnModes[_column];
            }
            //並び替えの方法別に、xとyを比較する
            switch (_mode) {
                case ComparerMode.String:
                    //文字列をとして比較
                    result = string.Compare(itemx.SubItems[_column].Text,
                        itemy.SubItems[_column].Text);
                    break;
                case ComparerMode.Integer:
                    //Int32に変換して比較
                    //.NET Framework 2.0からは、TryParseメソッドを使うこともできる
                    int itemX, itemY;
                    if (int.TryParse(itemx.SubItems[_column].Text, out itemX) && 
                        int.TryParse(itemy.SubItems[_column].Text, out itemY))
                        result = itemX.CompareTo(itemY);
                    else result =string.Compare(itemx.SubItems[_column].Text,itemy.SubItems[_column].Text);
                    break;
                    
                case ComparerMode.DateTime:
                    //DateTimeに変換して比較
                    //.NET Framework 2.0からは、TryParseメソッドを使うこともできる
                    result = DateTime.Compare(
                        DateTime.Parse(itemx.SubItems[_column].Text),
                        DateTime.Parse(itemy.SubItems[_column].Text));
                    break;
            }

            //降順の時は結果を+-逆にする
            if (_order == SortOrder.Descending) {
                result = -result;
            }

            //結果を返す
            return result;
        }
    }
}
