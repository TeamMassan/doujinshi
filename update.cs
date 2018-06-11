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

namespace 同人誌管理
{
    public partial class update : Form
    {
        public update()
        {
            InitializeComponent();
        }
        
        //リストビューから選択されたt_doujinshi.ID
        public string selected_ID;

        //ロード処理
        private void update_Load(object sender, EventArgs e) {
            string date;//分布日を挿入する
            idForm.Text = selected_ID;

            //作品名コンボボックスの中身の読み込み
            SQLiteDataReader reader = null;
            string query = "SELECT origin_title FROM t_origin";
            SQLiteConnect.Excute(query, ref reader);
            while (reader.Read())
            {
                originComboBox.Items.Add(reader["origin_title"].ToString());
            }
            reader.Close();
            SQLiteConnect.conn.Close();

            //ジャンル名コンボボックスの中身の読み込み
            reader = null;
            query = "SELECT genre_title FROM t_genre";
            SQLiteConnect.Excute(query, ref reader);
            while (reader.Read())
            {
                genreComboBox.Items.Add(reader["genre_title"].ToString());
            }
            reader.Close();
            SQLiteConnect.conn.Close();

            //テキスト読み込み
            reader = null;
    
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
            date = Date.insert_y_m_d(reader["年月日"].ToString());    //年月日追加メソッドで整形する必要が無いよ
            yearForm.Text = date.Substring(0, 4);
            monthForm.Text = date.Substring(5, 2);
            dayForm.Text = date.Substring(8, 2);
            switch (reader["年齢"].ToString()) {
                case "all": all.Checked = true; break;
                case "r15": r15.Checked = true; break;
                case "r18": r18.Checked = true; break;
            }
            switch (reader["場所"].ToString())
            {
                case "house": house.Checked = true; break;
                case "hometown": hometown.Checked = true; break;
            }
            mainChara.Text = reader["メインキャラ"].ToString();

            reader.Close();
            SQLiteConnect.conn.Close();
        }

        //閉じるボタン処理
        private void close_Click(object sender, EventArgs e) {
            Visible = false;
        }

        private void readLeft_Click(object sender, EventArgs e) {
            selected_ID = (int.Parse(selected_ID) - 1).ToString();
            update_Load(sender, e);
        }

        private void readRight_Click(object sender, EventArgs e) {
            selected_ID = (int.Parse(selected_ID) + 1).ToString();
            update_Load(sender, e);
        }
    }
}
