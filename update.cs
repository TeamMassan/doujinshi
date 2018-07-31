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
            this.genreComboBox.SelectedIndexChanged += new System.EventHandler(this.genreComboBox_SelectedIndexChanged);
            this.originComboBox.SelectedIndexChanged += new System.EventHandler(this.originComboBox_SelectedIndexChanged);
            this.mainChara.TextChanged += new System.EventHandler(this.mainChara_TextChanged);
            this.authorsForm.TextChanged += new System.EventHandler(this.authorsForm_TextChanged);
            this.circleForm.TextChanged += new System.EventHandler(this.circleForm_TextChanged);
            this.titleForm.TextChanged += new System.EventHandler(this.titleForm_TextChanged);
            this.bookShelf.SelectedIndexChanged += new System.EventHandler(this.bookShelf_SelectedIndexChanged);
            this.storage.SelectedIndexChanged += new System.EventHandler(this.storage_SelectedIndexChanged_1);
            this.yearForm.SelectedIndexChanged += new System.EventHandler(this.yearForm_SelectedIndexChanged);
            this.monthForm.SelectedIndexChanged += new System.EventHandler(this.monthForm_SelectedIndexChanged);
            this.dayForm.SelectedIndexChanged += new System.EventHandler(this.dayForm_SelectedIndexChanged);
            this.all.CheckedChanged += new System.EventHandler(this.all_CheckedChanged);
            this.r15.CheckedChanged += new System.EventHandler(this.r15_CheckedChanged);
        }

        public string[] resultArray = new string[0];
        public int currentIndex;
        private string beforeTitle;

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
            string select_all = "SELECT タイトル,サークル,作者,origin_title AS 作品,genre_title AS ジャンル, 頒布日, 対象年齢, place_ID, 場所, 本棚, キャラ ";
            //WHERE句記入
            string where = "WHERE t_doujinshi.ID = " + resultArray[currentIndex].ToString();

            //SQL発行
            query = select_all + SQLiteConnect.getFullInfoFrom + where + SQLiteConnect.getFullInfoLatter;
            SQLiteConnect.Excute(query, ref reader);
            if (reader != null) {
                reader.Read();
                titleForm.Text = beforeTitle = reader["タイトル"].ToString();
                circleForm.Text = reader["サークル"].ToString();
                authorsForm.Text = reader["作者"].ToString();
                originComboBox.Text = reader["作品"].ToString();
                genreComboBox.Text = reader["ジャンル"].ToString();
                date = reader["頒布日"].ToString();
                yearForm.Text = date.Substring(0, 4);
                monthForm.Text = date.Substring(4, 2);
                dayForm.Text = date.Substring(6, 2);
                foreach (RadioButton rb in ageLimit.Controls) {
                    if (rb.Tag.ToString() == reader["対象年齢"].ToString())
                        rb.Checked = true;
                }

                placeID = int.Parse(reader["place_ID"].ToString());
                //ここでstorage_SelectedIndexChangedが動いてしまうので処理先で無理矢理動かさない
                storage.Text = reader["場所"].ToString();
                bookShelf.Text = reader["本棚"].ToString();
                mainChara.Text = reader["キャラ"].ToString();
                reader.Close();
                SQLiteConnect.conn.Close();

                //場所名変更時に変更出来なかった本棚一覧を改めて動かす
                storage_SelectedIndexChanged(sender, e);

                //イメージ表示
                string imageFilePath = @"Thumbnail\" + idForm.Text + "_" + titleForm.Text + ".jpg";
                //MessageBox.Show(imageFilePath);
                if (File.Exists(imageFilePath)) {
                    pictureBox.Image = Image.FromFile(imageFilePath);
                }
                else {
                    pictureBox.Image = Image.FromFile(@"Thumbnail\NoImage.jpg");
                }
                restoreColors();
            }
        }

        private void dealing_Click(object sender, EventArgs e) {
            //空白箇所の提言
            if (checkNullForm()) return;

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
            query += "," + "place_ID = " + placeID;
            query += "," + "bookShelf_ID = (SELECT bookShelf_ID FROM t_house_shelf WHERE shelf_name = '" + bookShelf.Text + "' )";
            query += " WHERE " + resultArray[currentIndex] + " = ID";

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
                string imageFileNameBefore = @"Thumbnail\" + idForm + "_" + beforeTitle + ".jpg";
                string imageFileNameAfter = @"Thumbnail\" + idForm + "_" + titleForm.Text + ".jpg";
            //ファイル名変更判定
            if(File.Exists(imageFileNameBefore)){
                if (titleForm.BackColor == Color.Cyan) {
                    File.Move(imageFileNameBefore, imageFileNameAfter);
                }
            }

            MessageBox.Show("更新しました");
            restoreColors();
        }

        //色をデフォルトに戻す
        private void restoreColors() {
            foreach (Control item in this.Controls) {
                if (item.BackColor == Color.Cyan) {
                    if (item is TextBox)
                        item.BackColor = SystemColors.Window;
                    else if (item is Label)
                        item.BackColor = SystemColors.Control;
                    else if (item is ComboBox)
                        item.BackColor = SystemColors.Window;
                }
            }
        }

        private void titleForm_TextChanged(object sender, EventArgs e) {
            titleForm.BackColor = Color.Cyan;
        }

        private void circleForm_TextChanged(object sender, EventArgs e) {
            circleForm.BackColor = Color.Cyan;
        }

        private void authorsForm_TextChanged(object sender, EventArgs e) {
            authorsForm.BackColor = Color.Cyan;
        }

        private void originComboBox_SelectedIndexChanged(object sender, EventArgs e) {
            label4.BackColor = Color.Cyan;
        }

        private void genreComboBox_SelectedIndexChanged(object sender, EventArgs e) {
            label5.BackColor = Color.Cyan;
        }

        private void yearForm_SelectedIndexChanged(object sender, EventArgs e) {
            yearForm.BackColor = Color.Cyan;
        }

        private void monthForm_SelectedIndexChanged(object sender, EventArgs e) {
            monthForm.BackColor = Color.Cyan;
        }

        private void dayForm_SelectedIndexChanged(object sender, EventArgs e) {
            dayForm.BackColor = Color.Cyan;
        }

        private void storage_SelectedIndexChanged_1(object sender, EventArgs e) {
            label7.BackColor = Color.Cyan;
        }

        private void bookShelf_SelectedIndexChanged(object sender, EventArgs e) {
            label14.BackColor = Color.Cyan;
        }

        private void mainChara_TextChanged(object sender, EventArgs e) {
            mainChara.BackColor = Color.Cyan;
        }

        private void all_CheckedChanged(object sender, EventArgs e) {
            label6.BackColor = Color.Cyan;
        }

        private void r15_CheckedChanged(object sender, EventArgs e) {
            label6.BackColor = Color.Cyan;
        }
    }
}
