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

        string protoage_shaiping(bool[] checkbox_flag , params string[] checkbox_str) {
            string conditions = "(";
            bool check = false;
            bool mode = false ;
            int num = checkbox_str.Length;

            if (checkbox_str[0] == "house") mode = true;
            for (int cnt = 0; cnt < num; cnt++)
            {
                if (checkbox_flag[cnt] == true)
                {
                    //ORの有無チェック
                    if (check == true)
                        conditions += " OR ";
                    else
                        check = true;
                    conditions += "'" + checkbox_str[cnt] + "' = t_doujinshi.";
                    
                    //ageとplaseのどちらと比較するかの処理
                    if(mode == true)
                        conditions += "place";
                    else
                       conditions += "age_limit";
                }
            }
            conditions += ")";
            return conditions;
        }


        bool protoage_shaiping_check(params bool[] checkbox_flag)
        {
            bool check = false;
            int num = checkbox_flag.Length;
            for (int cnt = 0; cnt < num; cnt++)
            {
                if (checkbox_flag[cnt] == true)
                {
                    check = true;
                    break;
                }
            }
            return check;
        }

        string limit_shaiping(bool all_flag, bool r15_flag, bool r18_flag)
        {
            bool check = false;
            string conditions = "(";

            //全年齢チェック
            if (all_flag == true)
            {
                check = true;
                conditions += "'" + all.Checked + "'";
            }

            //R-15チェック
            if (r15_flag == true)
            {
                if (check == true)
                    conditions += " OR ";
                else
                    check = true;
                conditions += "'" + r15.Checked + "'";
            }

            //R-18チェック
            if (r18_flag == true)
            {
                if (check == true)
                    conditions += " OR ";
                else
                    check = true;
                conditions += "'" + r18.Checked + "'";
            }

            conditions += ")";
            return conditions;
        }
        //閉じるボタン
        private void close_Click(object sender, EventArgs e)
        {
            Visible = false;  
        }
        //検索ボタン
        private void search_Click(object sender, EventArgs e)
        {
            string conditions = "WHERE ";
            bool check = false;//記入チェック変数
            bool[] checkbox_flag = new bool[3];

            //誌名記入チェック
            if (bookName.Text != "")
            {
                check = true;
                conditions += "'" + bookName.Text + "' = t_origin.origin_title";
            }
            //作者名記入チェック
            if (bookAuthor.Text != "")
            {
                if (check == true)
                    conditions += " AND ";
                else
                    check = true;
                conditions += "'" +  bookAuthor.Text + "' = t_Author.Author";
            }
            //ジャンル記入チェック
            if (genreForm.Text != "") {
                if (check == true)
                    conditions = " AND ";
                else
                    check = true;
                conditions += "(SELECT genre_ID FROM t_genle ' ";
                conditions += genreForm.Text + "' = genre_title) = ";
                conditions += "t_doujinshi.genle_ID";
            }

            //過去の記入チェック及び年齢チェックボックスのチェックの有無判定
            if (check == true)
                conditions += " AND ";
            else
                check = protoage_shaiping_check(all.Checked, r15.Checked, r18.Checked);
            //年齢チェックボックス判定
            checkbox_flag[0] = all.Checked;
            checkbox_flag[1] = r15.Checked;
            checkbox_flag[2] = r18.Checked;
            conditions += protoage_shaiping(checkbox_flag,"all","r15","r18");
            //conditions += limit_shaiping(all.Checked, r15.Checked, r18.Checked);

            //保存場所チェックボックスのチェックの有無判定
            if(check == false)
                check = protoage_shaiping_check(house.Checked, hometown.Checked);
            conditions += " AND ";
            //保存場所チェックボックス判定
            checkbox_flag[0] = house.Checked;
            checkbox_flag[1] = hometown.Checked;
            conditions += protoage_shaiping(checkbox_flag,"house","hometown");

            //キャラ記入チェック
            if (charaForm.Text != "")
            {
                if (check == true)
                    conditions += " AND ";
                else
                    check = true;
                conditions += "'%" + charaForm.Text + "%' = t_doujinshi.main_chara";
            }

            //全項目記入チェック                         
            if (check == true)
                MessageBox.Show(conditions);
            Clipboard.SetText(conditions);
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
