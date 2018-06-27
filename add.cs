using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
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
            if (genreComboBox.Text == "") {
                empty += "ジャンル、";
                empty_flag = true;
            }
            //頒布日はnull可項目なので入力内容が存在する & 8桁でない時に注意を促す
            if (yearForm.Text == "" || monthForm.Text == "" || dayForm.Text == "" || 
                    Date.merge(yearForm.Text, monthForm.Text, dayForm.Text).Length != 8) {
                empty += "頒布日、";
                empty_flag = true;
            }

            //記入漏れ箇所提言
            if (empty_flag) {
                MessageBox.Show(empty + "が空白です。");
                return;     //必須項目が抜けていたら処理を抜けて中断
            }

            //チェックボタンの結果格納（暫定処理）
            //foreach使ってコレクションからchecked==trueの対象年齢と保管場所を取得したい
            string agelimit, place;
            if (all.Checked)
                agelimit = "all";
            else if (r15.Checked)
                agelimit = "r15";
            else
                agelimit = "r18";
            if (house.Checked)
                place = "house";
            else
                place = "hometown";
            //SQL文組み立て
            //作品IDとジャンルIDはコンボボックスの値からSQLの副問合せを利用
            string insert_doujinshi = "INSERT INTO t_doujinshi(ID,title,origin_ID,genre_ID,age_limit,date,place,main_chara)" +
                "VALUES(" + idForm.Text + ","   //ID
                + "'" + titleForm.Text + "',"   //タイトル
                + "(SELECT origin_ID FROM t_origin WHERE '" + originComboBox.Text + "' = origin_title),"  //作品ID
                + "(SELECT genre_ID FROM t_genre WHERE '" + genreComboBox.Text + "' = genre_title),"      //ジャンルID
                + "'" + agelimit + "',"         //対象年齢ID
                + Date.merge(dayForm.Text, monthForm.Text, dayForm.Text) + ","    //頒布年月日
                + "'" + place + "',"            //場所
                + "'" + mainChara.Text + "')";  //メインキャラ                

            //t_doujinshi登録
            SQLiteConnect.Excute(insert_doujinshi);

            //t_author登録
            if (authorsForm.Text.Length != 0) {
                string[] authors = authorsForm.Text.Split(',');
                for (int cnt = 0; cnt < authors.Length; cnt++) {
                    string insert_author = "INSERT INTO t_author(ID,author)" +
                        "VALUES(" + idForm.Text + ", '" + authors[cnt] + "')";
                    SQLiteConnect.Excute(insert_author);
                }
            }

            //t_circle登録
            if (circleForm.Text.Length != 0) {
                string[] circles = circleForm.Text.Split(',');
                for (int cnt = 0; cnt < circles.Length; cnt++) {
                    string insert_circle = "INSERT INTO t_circle(ID,circle)" +
                        "VALUES(" + idForm.Text + ", '" + circles[cnt] + "')";
                    SQLiteConnect.Excute(insert_circle);
                }
            }

            //サムネイル登録
            if (changedThumbnail) {
                pictureBox.Image.Save(@"Thumbnail\" + idForm.Text + "_" + titleForm.Text + ".jpg", ImageFormat.Jpeg);
                changedThumbnail = false;
            }

            MessageBox.Show("登録しました");

            //連続登録し易いようにフォーカスを戻す
            this.titleForm.Focus();

            //ID連番を回す
            idForm.Text = ((int.Parse(idForm.Text)) + 1).ToString();

            //登録後のフォーム初期化
            //連続登録時に重複しやすい年月日は残しておく
            pictureBox.Image = Image.FromFile(@"Thumbnail\NoImage.jpg");
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
            if (SQLiteConnect.checkRecord("t_doujinshi") == 0)    
                newID = 1;
            //レコードが存在する場合は新規IDをアサイン
            else {  
                query = "SELECT MAX(ID) FROM t_doujinshi";
                SQLiteConnect.Excute(query, ref reader);
                reader.Read();
                newID = int.Parse(reader["Max(ID)"].ToString())+1;
                reader.Close();
                SQLiteConnect.conn.Close();
            }
            
            //新規IDをidFormに格納
            idForm.Text = newID.ToString();

            //作品一覧をロード
            query = "SELECT origin_ID,origin_title FROM t_origin";
            SQLiteConnect.Excute(query, ref reader);
            while(reader.Read())
                originComboBox.Items.Add(reader["origin_title"].ToString());          
            reader.Close();
            SQLiteConnect.conn.Close();

            //ジャンル一覧をロード
            query = "SELECT genre_title FROM t_genre";
            SQLiteConnect.Excute(query, ref reader);
            while (reader.Read())
                genreComboBox.Items.Add(reader["genre_title"].ToString());
            reader.Close();
            SQLiteConnect.conn.Close();
            
            //サムネのDrag&Dropを許可
            pictureBox.AllowDrop = true;

            //サムネイルの読み込み
            string filePath = @"Thumbnail\"+idForm.Text + "_" + titleForm.Text + ".jpg";
            pictureBox.Image = Image.FromFile(@"Thumbnail\NoImage.jpg");
        }

        bool changedThumbnail = false;

        //サムネを設定
        private void assignThumbnail(string imageFilePath) {
            changedThumbnail = true;
            pictureBox.Image = Image.FromFile(imageFilePath);
        }

        private void openThumbnailBottun_Click(object sender, EventArgs e) {
            if (openThumbnailDialog.ShowDialog() == DialogResult.OK) {
                pictureBox.Image = Image.FromFile(openThumbnailDialog.FileName);
            }
            
        }

        //ファイルをドラッグした状態で入ったときにマウスアイコン変更
        private void pictureBox_DragEnter(object sender, DragEventArgs e) {
            if (e.Data.GetDataPresent(DataFormats.FileDrop) ||
                e.Data.GetDataPresent(DataFormats.Text))
                e.Effect = DragDropEffects.Copy;
        }

        private void pictureBox_DragDrop(object sender, DragEventArgs e) {
            string filePath = null;

            //D&Dされたデータがファイルであることを確認
            if (e.Data.GetDataPresent(DataFormats.FileDrop)) {
                //Dragされたファイル名は配列で格納されているので頭だけ取る
                filePath = ((string[])e.Data.GetData(DataFormats.FileDrop))[0];
            } 
            //ブラウザからならばURLを取得
            else if (e.Data.GetDataPresent(DataFormats.Text)) {
                filePath = e.Data.GetData(DataFormats.Text).ToString();
            } else {
                MessageBox.Show("ファイルパスが取得出来ないか、ファイルが未対応です。");
                return;
            }
            pictureBox.Image = Image.FromFile(filePath);
        }
    }
}
