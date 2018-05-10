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
        //データベースの場所を指定
        SQLiteConnection conn = new SQLiteConnection("Data Source = doujinshi.sqlite");

        //ロード処理
        private void update_Load(object sender, EventArgs e) {
            string date;//分布日を挿入する
            idForm.Text = selected_ID;

            //作品名コンボボックスの中身の読み込み
            SQLiteDataReader reader = null;
            string query = "SELECT origin_title FROM t_origin";
            SQLiteConnect.beResponse(query, ref reader);
            while (reader.Read())
            {
                originComboBox.Items.Add(reader["origin_title"].ToString());
            }
            reader.Close();
            SQLiteConnect.conn.Close();

            //ジャンル名コンボボックスの中身の読み込み
            reader = null;
            query = "SELECT genre_title FROM t_genre";
            SQLiteConnect.beResponse(query,ref reader);
            while(reader.Read()) {
                genreComboBox.Items.Add(reader["genre_title"].ToString());
            }
            reader.Close();
            SQLiteConnect.conn.Close();

            //テキスト読み込み
            reader = null;
            query = "SELECT * " + 
                "FROM(t_doujinshi LEFT OUTER JOIN t_author ON t_doujinshi.ID = t_author.ID)" +
                "LEFT OUTER JOIN t_circle ON t_doujinshi.ID = t_circle.ID ";
            //WHERE句記入
            query += "WHERE " + selected_ID + " = t_doujinshi.ID　"; //全角スペース混じってるよ by マッサン

            //SQL発行
            SQLiteConnect.beResponse(query, ref reader);
            while (reader.Read())
            {
                titleForm.Text = reader["title"].ToString();
                circleForm.Text = reader["circle"].ToString();
                authorsForm.Text = reader["author"].ToString();
                //originComboBox.Text = reader["origin_title"].ToString();
                //genreComboBox.Text = reader["ジャンル"].ToString();
                date = Date.insert_y_m_d(reader["date"].ToString());    //年月日追加メソッドで整形する必要が無いよ
                yearForm.Text = date.Substring(0,4);
                monthForm.Text = date.Substring(5,2);
                dayForm.Text = date.Substring(8,2);
                //mainChara.Text = reader["mainchara"].ToString();

            }
            reader.Close();
            SQLiteConnect.conn.Close();
        }

        //閉じるボタン処理
        private void close_Click(object sender, EventArgs e) {
            Visible = false;
        }
    }
}
