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
        SQLiteConnct connect = new SQLiteConnct();

        //登録ボタンの処理
        private void insert_Click(object sender, EventArgs e) {
            //SQL文組み立て
            string INSERTquery= "INSERT INTO t_doujinshi(ID,title,origin_ID,genre_ID,age_limit,date,main_chara,place";
            //テスト用のINSERT文
            INSERTquery = "INSERT INTO t_doujinshi(ID,title,origin_ID,genre_ID,age_limit,date,"+
                "main_chara,place)VALUES("+idForm.Text.ToString()+",'慧音先生の情報リテラシー講座',1,1,1,'20180205','上白沢慧音',1); ";
            //SQLiteへのコネクト
            SQLiteConnection conn = new SQLiteConnection("Data Source = doujinshi.sqlite"); //カレントディレクトリに置く
            SQLiteCommand cmd = new SQLiteCommand(INSERTquery, conn);
            //クエリ発行
            conn.Open();
            try {
                cmd.ExecuteNonQuery();
                conn.Close();
                MessageBox.Show("登録しました");
                //ID連番を回す
                idForm.Text = ((int.Parse(idForm.Text.ToString())) + 1).ToString();
            } catch(Exception err) {
                MessageBox.Show(err.ToString());
                Clipboard.SetText(INSERTquery);   //SQL文をクリップボードにコピー
            }

            //テキストの全初期化
            titleForm.Text = "";
            circleForm.Text = "";
            orijinComboBox.Text = "";
            genreComboBox.Text = "";
            mainChara.Text = "";

            
        }

        //閉じるボタンの処理
        private void close_Click(object sender, EventArgs e) {
            Visible = false;
        }

        //ロード時の処理
        private void add_Load(object sender, EventArgs e) {
            //IDの最大値を取得
            string query = "SELECT MAX(ID)FROM t_doujinshi";
            SQLiteConnection conn = new SQLiteConnection("Data Source = doujinshi.sqlite");
            SQLiteCommand cmd = new SQLiteCommand(query, conn);
            conn.Open();
            SQLiteDataReader reader = cmd.ExecuteReader();
            int ID_max = 0;    //データが空の時は0で初期化される
            if (reader.Read()) {
                ID_max = int.Parse(reader["Max(ID)"].ToString());
            }
            reader.Close();
            conn.Close();
            //新規IDをidに格納
            ID_max++;
            idForm.Text = ID_max.ToString();            
        }
    }
}
