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

        SQLiteConnct connect = new SQLiteConnct();  //SQL操作を簡易化するインスタンス

        //作品、ジャンルの対応を構造体の配列で格納
        public struct id_to_data {
            public string ID;
            public string title;
        }
        id_to_data[] origin = new id_to_data[1];
        id_to_data[] genre = new id_to_data[1];

        //登録ボタンの処理
        private void insert_Click(object sender, EventArgs e) {
            //頒布年月日整形
            //十の位補足と連結で8桁のstringに収める
            string date = yearForm.Text;
            if (monthForm.Text.Length < 2)
                monthForm.Text = "0" + monthForm.Text;
            date += monthForm.Text;
            if (dayForm.Text.Length < 2)
                dayForm.Text = "0" + dayForm.Text;
            date += dayForm.Text;
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
            if (genreComboBox.Text == "") {
                empty += "ジャンル、";
                empty_flag = true;
            }
            if ((yearForm.Text != "" || monthForm.Text != "" || dayForm.Text != "") && date.Length != 8) {
                //頒布日はnull可項目なので入力内容が存在し、8桁でない時のみ注意を促す
                empty += "頒布日、";
                empty_flag = true;
            }

            //記入漏れ箇所提言
            if (empty_flag == true) {
                MessageBox.Show(empty + "が空白です。");
                return;     //必須項目が抜けていたら処理を中断
            }
            
            //チェックボタンの結果格納
            //foreach使ってコレクションからchecked==trueの対象年齢と保管場所を取得

            //SQL文組み立て
            //作品IDとジャンルIDはSQLの副問合せを利用したい
            /*string insert_doujinshi = "INSERT INTO t_doujinshi(ID,title,origin_ID,genre_ID,age_limit,date,main_chara,place)"+
                "VALUES(" + idForm.Text + ","    //ID
                + "'"+titleForm.Text+"','"       //タイトル
                +                                //作品ID
                +                                //ジャンルID
                +                                //対象年齢ID
                + date+","                       //頒布年月日
                +                                //場所
            */
                
            //テスト用のINSERT文
            string insert_doujinshi = "INSERT INTO t_doujinshi(ID,title,origin_ID,genre_ID,age_limit,date," +
                "main_chara,place)VALUES(" + idForm.Text + ",'慧音先生の情報リテラシー講座',1,1,'all','20180205','上白沢慧音','house')";
            string insert_author = "INSERT INTO t_author(ID,author)" +
                "VALUES(" + idForm.Text + ",'" + authorsForm.Text + "')";
            string insert_circle = "INSERT INTO t_circle(ID,circle)" +
                "VALUES(" + idForm.Text + ",'" + circleForm.Text + "')";

            //クエリ発行
            connect.nonResponse(insert_doujinshi);
            if (authorsForm.Text != "")
                connect.nonResponse(insert_author);
            if (circleForm.Text != "")
                connect.nonResponse(insert_circle);
            MessageBox.Show("登録しました");

            //ID連番を回す
            idForm.Text = ((int.Parse(idForm.Text)) + 1).ToString();

            //登録後のフォーム初期化
            //登録時に重複しやすい年月日は残しておく
            titleForm.Clear();
            authorsForm.Clear();
            circleForm.Clear();
            mainChara.Clear();
        }

        //閉じるボタンの処理
        private void close_Click(object sender, EventArgs e) {
            Visible = false;
        }

        //ロード時の処理
        private void add_Load(object sender, EventArgs e) {
            string query;
            SQLiteDataReader reader = null;
            int newID;
            //レコードが0件の場合は1に設定
            if (connect.checkRecord("t_doujinshi") == 0)    
                newID = 1;
            //レコードが存在する場合は新規IDをアサイン
            else {  
                query = "SELECT MAX(ID) FROM t_doujinshi";
                connect.beResponse(query, ref reader);
                reader.Read();
                newID = int.Parse(reader["Max(ID)"].ToString())+1;
                reader.Close();
                connect.conn.Close();
            }
            
            //新規IDをidFormに格納
            idForm.Text = newID.ToString();

            //作品一覧をロード
            //構造体にIDとタイトルセットで格納し、INSERTの時に対応するIDを利用したい
            //
            query = "SELECT origin_ID,origin_title FROM t_origin";
            connect.beResponse(query, ref reader);
            for(int cnt = 0; reader.Read();cnt++) {
                origin[cnt].ID = reader["origin_id"].ToString();
                origin[cnt].title = reader["origin_title"].ToString();
                originComboBox.Items.Add(reader["origin_title"].ToString());
                Array.Resize(ref origin, cnt + 2);
            }
            reader.Close();
            connect.conn.Close();

            //ジャンル一覧をロード
            query = "SELECT genre_title FROM t_genre";
            connect.beResponse(query, ref reader);
            while (reader.Read()) {
                genreComboBox.Items.Add(reader["genre_title"].ToString());
            }
            reader.Close();
            connect.conn.Close();

        }
    }
}
