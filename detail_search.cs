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
    public partial class detail_search : Form {
        public detail_search() {
            InitializeComponent();
        }

        string protoage_shaiping(params bool[] checkbox_flag) {
            bool check = false;
            string sql = "(";
            for (int cnt = 0; cnt < checkbox_flag.Length; cnt++)
            {
                if (checkbox_flag[cnt] == true)
                {
                    if (check == true)
                        sql = " AND ";
                    else
                        check = true;
                    sql += "'" + checkbox_flag[cnt] + "'";
                }
            }
            sql += ")";
            return sql;
        }

        string limit_shaiping(bool all_flag, bool r15_flag, bool r18_flag)
        {
            bool check = false;
            string sql = "(";

            //全年齢チェック
            if (all_flag == true)
            {
                check = true;
                sql += "'" + all.Checked + "'";
            }

            //R-15チェック
            if (r15_flag == true)
            {
                if (check == true)
                    sql += " OR ";
                else
                    check = true;
                sql += "'" + r15.Checked + "'";
            }

            //R-18チェック
            if (r18_flag == true)
            {
                if (check == true)
                    sql += " OR ";
                else
                    check = true;
                sql += "'" + r18.Checked + "'";
            }

            sql += ")";
            return sql;
        }
        //閉じるボタン
        private void close_Click(object sender, EventArgs e)
        {
            Visible = false;  
        }
        //検索ボタン
        private void search_Click(object sender, EventArgs e)
        {
            string sql = "SELECT ID FROM t_table WHERE ";
            bool check = false;//記入チェック変数
            //誌名記入チェック
            if (bookName.Text != "")
            {
                check = true;
                sql += "'" + bookName.Text + "' = t_origin.origin_title";
            }
            //作者名記入チェック
            if (bookAuthor.Text != "")
            {
                if (check == true)
                    sql += " AND ";
                else
                    check = true;
                sql += "'" +  bookAuthor.Text + "' = t_Author.Author";
            }
            //ジャンル記入チェック
            if (genreForm.Text != "") {
                if (check == true)
                    sql = " AND ";
                else
                    check = true;
                sql += "(SELECT genre_ID FROM t_genle ' ";
                sql += genreForm.Text + "' = genre_title) = ";
                sql += "t_doujinshi.genle_ID";
            }

            //年齢チェックボックス判定
            if (check == true)
                sql += " AND ";
            sql += limit_shaiping(all.Checked, r15.Checked, r18.Checked);

            //保存場所チェックボックス判定
            if (check == true)
                sql += " AND ";

            //キャラ記入チェック
            if (charaForm.Text != "")
            {
                if (check == true)
                    sql += " AND ";
                else
                    check = true;
                sql += "'" + charaForm.Text + "' = t_doujinshi.main_chara";    //main_charaの所属テーブルが無いよ
            }

            //全項目記入チェック                         
            if (check == true)
                MessageBox.Show(sql);
            Clipboard.SetText(sql);
        }
        //ロード時の処理
        private void detail_search_Load(object sender, EventArgs e)
        {
            string query = "SELECT genre_title FROM t_genre";
            SQLiteConnection conn = new SQLiteConnection("Data Source = doujinshi.sqlite");
            conn.Open();
            SQLiteCommand cmd = new SQLiteCommand(query, conn);
            SQLiteDataReader reader = cmd.ExecuteReader();
            while (reader.Read()) {
                genreForm.Items.Add(reader["genre_title"].ToString());
            }
            reader.Close();
            conn.Close();
        }
    }
}
