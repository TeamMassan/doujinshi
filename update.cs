using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data.SQLite;
using System.IO;

namespace 同人誌管理 {
    public partial class update : 同人誌管理.BookBase {
        public update() {
            InitializeComponent();
            this.Text = "更新";
        }

        public string[] resultArray = new string[0];
        public int currentIndex;
        private string fileTitle;

        private void readUp_Click(object sender, EventArgs e) {
            if (currentIndex > 0) {
                currentIndex--;
                update_Load(sender, e);
            }
        }

        private void readDown_Click(object sender, EventArgs e) {
            if (currentIndex < resultArray.Length - 1) {
                currentIndex++;
                update_Load(sender, e);
            }
        }

        //ロード処理
        private void update_Load(object sender, EventArgs e) {
            //ロード時のID表示
            idForm.Text = resultArray[currentIndex];
            string date;//分布日を挿入する
            string query;
            SQLiteDataReader reader = null;
            string select_all = "SELECT title AS タイトル,サークル,作者,origin_title AS 作品,genre_title AS ジャンル, date AS 年月日, age_limit AS 年齢, place_ID, 場所, 本棚, main_chara AS メインキャラ ";
            //WHERE句記入
            string where = "WHERE t_doujinshi.ID = " + resultArray[currentIndex].ToString();

            //SQL発行
            query = select_all + SQLiteConnect.getFullInfoFrom + where + SQLiteConnect.getFullInfoLatter;
            SQLiteConnect.Excute(query, ref reader);
            if (reader != null) {
                reader.Read();
                titleForm.Text = reader["タイトル"].ToString();
                fileTitle = reader["タイトル"].ToString();
                circleForm.Text = reader["サークル"].ToString();
                authorsForm.Text = reader["作者"].ToString();
                originComboBox.Text = reader["作品"].ToString();
                genreComboBox.Text = reader["ジャンル"].ToString();
                date = reader["年月日"].ToString();
                yearForm.Text = date.Substring(0, 4);
                monthForm.Text = date.Substring(4, 2);
                dayForm.Text = date.Substring(6, 2);
                switch (reader["年齢"].ToString()) {
                    case "all": all.Checked = true; break;
                    case "r15": r15.Checked = true; break;
                    case "r18": r18.Checked = true; break;
                }
                placeID = int.Parse(reader["place_ID"].ToString());
                //ここでstorage_SelectedIndexChangedが動いてしまうので処理先で無理矢理動かさない
                storage.Text = reader["場所"].ToString();
                bookShelf.Text = reader["本棚"].ToString();
                mainChara.Text = reader["メインキャラ"].ToString();
                reader.Close();
                SQLiteConnect.conn.Close();

                //場所名変更時に変更出来なかった本棚一覧を改めて動かす
                storage_SelectedIndexChanged(sender, e);

                /*
                query = "SELECT place_name FROM t_storage WHERE place_ID = " + placeID;
                SQLiteConnect.Excute(query, ref reader);
                storage.Text = reader["place_name"].ToString();
                /*  場所の仕様変更の為一時コメントアウト
                switch (reader[].ToString()) {
                    case "house": house.Checked = true; break;
                    case "hometown": hometown.Checked = true; break;
                }
                */

                //イメージ表示
                string imageFilePath = @"Thumbnail\" + idForm.Text + "_" + titleForm.Text + ".jpg";
                //MessageBox.Show(imageFilePath);
                if (File.Exists(imageFilePath)) {
                    pictureBox.Image = Image.FromFile(imageFilePath);
                    imageFilePath = "処理済み";
                }
                
                reader.Close();
                SQLiteConnect.conn.Close();
            }
        }

        private void dealing_Click(object sender, EventArgs e) {
            string query;

            //UPDATE処理
            query = "UPDATE t_doujinshi ";
            query += "SET ";
            query += "title = '" + titleForm.Text + "'," +
                "origin_ID  = (SELECT origin_ID FROM t_origin WHERE '" + originComboBox.Text + "' = origin_title)," +
                "genre_ID = (SELECT genre_ID FROM t_genre WHERE '" + genreComboBox.Text + "' = genre_title)," +
                "date = " + Date.merge(yearForm.Text, monthForm.Text, dayForm.Text) + "," +
                "age_limit = '";
            foreach (RadioButton rb in ageLimit.Controls) {
                if (rb.Checked)
                    query += rb.Tag.ToString();
            }
            query += "',main_chara = '" + mainChara.Text + "'";
            query += "," + "place = '";
            /*  場所の仕様変更の為一時コメントアウト
            if (house.Checked == true) {
                query += "house";
            } else if (hometown.Checked == true) {
                query += "hometown";
            }
            */
            query += "' WHERE " + resultArray[currentIndex] + " = ID";

            //t_doujinshi更新
            SQLiteConnect.Excute(query);

            //サークルテーブル処理
            //DERETE文処理
            query = "DELETE FROM t_circle ";
            query += "WHERE " + resultArray[currentIndex] + " = ID";
            SQLiteConnect.Excute(query);
            if (circleForm.Text != "") {
                string[] circle = circleForm.Text.Split(',');
                for (int cnt = 0; cnt < circle.Length; cnt++) {
                    //INSERT文処理
                    query = "INSERT INTO t_circle ";
                    query += "VALUES (" + resultArray[currentIndex] + ",'" + circle[cnt] + "')";
                    SQLiteConnect.Excute(query);
                }
            }

            //作者名テーブル処理
            //DERETE文
            query = "DELETE FROM t_author ";
            query += "WHERE " + resultArray[currentIndex] + " = ID";
            SQLiteConnect.Excute(query);
            if (authorsForm.Text != "") {
                string[] authors = authorsForm.Text.Split(',');
                for (int cnt = 0; cnt < authors.Length; cnt++) {
                    query = "INSERT INTO t_author ";
                    query += "VALUES (" + resultArray[currentIndex] + ",'" + authors[cnt] + "')";
                    SQLiteConnect.Excute(query);
                }
            }

            //書き込み処理
                string imageFileNameBefore = @"Thumbnail\" + idForm + "_" + fileTitle + ".jpg";
                string imageFileNameAfter = @"Thumbnail\" + idForm + "_" + titleForm.Text + ".jpg";
            //ファイル名変更判定
            if (titleForm.BackColor == Color.Cyan) {
                    File.Move(imageFileNameBefore, imageFileNameAfter);
            }

            MessageBox.Show("更新しました");
        }
    }
}
