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
    public partial class add : Form {
        public add() {
            InitializeComponent();
        }

        //登録ボタンの処理
        private void insert_Click(object sender, EventArgs e) {
            //登録データの空白チェック
            string empty = "";
            bool empty_flag = false;
            if (titleForm.Text == "") {
                empty += "タイトル、";
                empty_flag = true;
            }
            if (originComboBox.Text == "") {
                empty += "作品、";
                empty_flag = true;
            }
            if (yearForm.Text == "" || monthForm.Text == "" || dayForm.Text == "") {
                empty += "頒布日、";
                empty_flag = true;
            }
            //対象年齢もチェック

            //空白提言
            if (empty_flag == true) {
                MessageBox.Show(empty + "が空白です。");
                empty_flag = false;
            }
            //SQL文組み立て
            /*string INSERTquery = "INSERT INTO t_doujinshi(ID,title,origin_ID,genre_ID,age_limit,date,main_chara,place)VALUES("
                + idForm.Text.ToString() + ",'"     //ID
                + titleForm.Text.ToString()+",'"    //タイトル
                +                                  //作品ID
                +                                   //ジャンルID
                +                                  //対象年齢ID
                +                                   //頒布年月日
                +                                   //場所
                */
            //テスト用のINSERT文
            string INSERTquery = "INSERT INTO t_doujinshi(ID,title,origin_ID,genre_ID,age_limit,date," +
                "main_chara,place)VALUES(" + idForm.Text.ToString() + ",'慧音先生の情報リテラシー講座',1,1,'all','20180205','上白沢慧音','house');";
            //SQLiteへのコネクト
            SQLiteConnection conn = new SQLiteConnection("Data Source = doujinshi.sqlite"); //カレントディレクトリに置く
            SQLiteCommand cmd = new SQLiteCommand(INSERTquery, conn);
            //クエリ発行
            try {
                conn.Open();
                cmd.ExecuteNonQuery();
                conn.Close();
                MessageBox.Show("登録しました");
                //ID連番を回す
                idForm.Text = ((int.Parse(idForm.Text.ToString())) + 1).ToString();
            }
            catch (Exception err) {
                MessageBox.Show(err.ToString());
                Clipboard.SetText(INSERTquery);   //SQL文をクリップボードにコピー
            }

            //テキストの一部初期化
            titleForm.Text = "";
            circleForm.Text = "";
            mainChara.Text = "";
        }

        //閉じるボタンの処理
        private void close_Click(object sender, EventArgs e) {
            Visible = false;
        }

        //ロード時の処理
        private void add_Load(object sender, EventArgs e) {

            //作品一覧をロード
            string query = "SELECT origin_title FROM t_origin";
            SQLiteConnection conn = new SQLiteConnection("Data Source = doujinshi.sqlite");
            conn.Open();
            SQLiteCommand cmd = new SQLiteCommand(query, conn);
            SQLiteDataReader reader = cmd.ExecuteReader();
            while (reader.Read()) {
                originComboBox.Items.Add(reader["origin_title"].ToString());
            }
            reader.Close();

            //ジャンル一覧をロード
            query = "SELECT genre_title FROM t_genre";
            cmd = new SQLiteCommand(query, conn);
            reader = cmd.ExecuteReader();
            while (reader.Read()) {
                genreComboBox.Items.Add(reader["genre_title"].ToString());
            }
            reader.Close();

            //IDの最大値を取得
            query = "SELECT MAX(ID) FROM t_doujinshi";
            cmd = new SQLiteCommand(query, conn);
            reader = cmd.ExecuteReader();
            int ID_max = 0;
            if (reader.Read()) {
                try {
                    ID_max = int.Parse(reader["Max(ID)"].ToString());
                }
                catch {     //データ無い時は0を最大値扱い
                    ID_max = 0;
                }
            }
            reader.Close();
            conn.Close();
            //新規IDをidFormに格納
            ID_max++;
            idForm.Text = ID_max.ToString();
        }
    }
}
