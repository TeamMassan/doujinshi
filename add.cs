﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Text;
using System.Windows.Forms;
using System.Data.SQLite;

namespace 同人誌管理 {
    public partial class add : BookBase {
        public add() {
            InitializeComponent();
            this.Text = "新規追加";

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
                newID = int.Parse(reader["Max(ID)"].ToString()) + 1;
                reader.Close();
                SQLiteConnect.conn.Close();
            }

            //新規IDをidFormに格納
            idForm.Text = newID.ToString();
        }

        //登録ボタンの処理
        private void dealing_Click(object sender, EventArgs e) {
            //必須箇所が抜けていれば埋めるように促す
            if (checkNullForm())
                return;

            //チェックボタンの結果格納
            string agelimit = null;
            foreach (RadioButton rb in ageLimit.Controls) {
                if (rb.Checked)
                    agelimit=rb.Tag.ToString();
            }

            //SQL文組み立て
            //作品IDとジャンルIDはコンボボックスの値からSQLの副問合せを利用
            string insert_doujinshi = "INSERT INTO t_doujinshi(ID,title,origin_ID,genre_ID,age_limit,date,place_ID,bookShelf_ID,main_chara)" +
                "VALUES(" + idForm.Text + ","   //ID
                + "'" + titleForm.Text + "',"   //タイトル
                + "(SELECT origin_ID FROM t_origin WHERE '" + originComboBox.Text + "' = origin_title),"  //作品ID
                + "(SELECT genre_ID FROM t_genre WHERE '" + genreComboBox.Text + "' = genre_title),"      //ジャンルID
                + "'" + agelimit + "',"         //対象年齢ID
                + Date.merge(yearForm.Text, monthForm.Text, dayForm.Text) + ","                           //頒布年月日
                + placeID +","                   //場所
                + "(SELECT bookShelf_ID FROM t_house_shelf WHERE place_ID = "+ placeID +" AND shelf_name = '" + bookShelf.Text + "'),"    //本棚ID
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
    }
}
