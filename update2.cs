using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data.SQLite;

namespace 同人誌管理 {
    public partial class update2 : 同人誌管理.BookBase {
        public update2() {
            InitializeComponent();
            this.Text = "更新";
        }

        private string selected_ID = "1";   //まだ仮処理なので1を入れてるよ

        private void readLeft_Click(object sender, EventArgs e) {
            SQLiteDataReader reader = null;
            string minquery = "select min(ID) from t_doujinshi";
            SQLiteConnect.Excute(minquery, ref reader);
            reader.Read();
            int minID = int.Parse(reader["min(ID)"].ToString());
            reader.Close();
            SQLiteConnect.conn.Close();
            if (int.Parse(selected_ID) != minID) {
                selected_ID = (int.Parse(selected_ID) - 1).ToString();
                update2_Load(sender, e);
            } else return;
        }

        private void readRight_Click(object sender, EventArgs e) {
            SQLiteDataReader reader = null;
            string maxquery = "select max(ID) from t_doujinshi";
            SQLiteConnect.Excute(maxquery, ref reader);
            reader.Read();
            int minID = int.Parse(reader["max(ID)"].ToString());
            reader.Close();
            SQLiteConnect.conn.Close();
            if (int.Parse(selected_ID) != minID) {
                selected_ID = (int.Parse(selected_ID) + 1).ToString();
                update2_Load(sender, e);
            } else return;
        }

        private void update2_Load(object sender, EventArgs e) {
            string date;//分布日を挿入する
            string query;
            SQLiteDataReader reader = null;
            string select_all = "SELECT title AS タイトル,サークル,作者,origin_title AS 作品,genre_title AS ジャンル, date AS 年月日, age_limit AS 年齢, place AS 場所, main_chara AS メインキャラ ";
            //WHERE句記入
            string where = "WHERE t_doujinshi.ID = " + selected_ID;

            //SQL発行
            query = select_all + SQLiteConnect.getFullInfoFrom + where + SQLiteConnect.getFullInfoLatter;
            SQLiteConnect.Excute(query, ref reader);
            reader.Read();
            titleForm.Text = reader["タイトル"].ToString();
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
            switch (reader["場所"].ToString()) {
                case "house": house.Checked = true; break;
                case "hometown": hometown.Checked = true; break;
            }
            mainChara.Text = reader["メインキャラ"].ToString();

            reader.Close();
            SQLiteConnect.conn.Close();
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
            if (all.Checked == true) {
                query += "all";
            } else if (r15.Checked == true) {
                query += "r15";
            } else if (all.Checked == true) {
                query += "all";
            }
            query += "',main_chara = '" + mainChara.Text + "'";
            query += "," + "place = '";
            if (house.Checked == true) {
                query += "house";
            } else if (hometown.Checked == true) {
                query += "hometown";
            }
            query += "' WHERE " + selected_ID + " = ID";

            //t_doujinshi更新
            SQLiteConnect.Excute(query);

            //サークルテーブル処理
            //DERETE文処理
            query = "DELETE FROM t_circle ";
            query += "WHERE " + selected_ID + " = ID";
            SQLiteConnect.Excute(query);
            if (circleForm.Text != "") {
                string[] circle = circleForm.Text.Split(',');
                for (int cnt = 0; cnt < circle.Length; cnt++) {
                    //INSERT文処理
                    query = "INSERT INTO t_circle ";
                    query += "VALUES (" + selected_ID + ",'" + circle[cnt] + "')";
                    SQLiteConnect.Excute(query);
                }
            }

            //作者名テーブル処理
            //DERETE文
            query = "DELETE FROM t_author ";
            query += "WHERE " + selected_ID + " = ID";
            SQLiteConnect.Excute(query);
            if (authorsForm.Text != "") {
                string[] authors = authorsForm.Text.Split(',');
                for (int cnt = 0; cnt < authors.Length; cnt++) {
                    query = "INSERT INTO t_author ";
                    query += "VALUES (" + selected_ID + ",'" + authors[cnt] + "')";
                    SQLiteConnect.Excute(query);
                }
            }

            MessageBox.Show("更新しました");
        }
    }
}
