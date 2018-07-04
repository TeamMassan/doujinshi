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
        public string conditions = "";

        string protoage_shaiping(bool[] checkbox_flag , params string[] checkbox_str) {
            string part_where = "(";
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
                        part_where += " OR ";
                    else
                        check = true;
                    part_where += "'" + checkbox_str[cnt] + "' = t_doujinshi.";
                    
                    //ageとplaseのどちらと比較するかの処理
                    if(mode == true)
                        part_where += "place";
                    else
                        part_where += "age_limit";
                }
            }
            part_where += ")";
            return part_where;
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
            string part_where = "(";

            //全年齢チェック(用済み)
            if (all_flag == true)
            {
                check = true;
                part_where += "'" + all.Checked + "'";
            }

            //R-15チェック
            if (r15_flag == true)
            {
                if (check == true)
                    part_where += " OR ";
                else
                    check = true;
                part_where += "'" + r15.Checked + "'";
            }

            //R-18チェック
            if (r18_flag == true)
            {
                if (check == true)
                    part_where += " OR ";
                else
                    check = true;
                part_where += "'" + r18.Checked + "'";
            }

            part_where += ")";
            return part_where;
        }
        //閉じるボタン
        private void close_Click(object sender, EventArgs e)
        {
            Visible = false;  
        }
        //検索ボタン
        private void search_Click(object sender, EventArgs e)
        {
            conditions = "";
            bool check = false;//記入チェック変数
            bool[] checkbox_flag = new bool[3];

            //誌名記入チェック
            if (bookName.Text != "")
            {
                check = true;
                conditions += "t_doujinshi.title LIKE '%" + bookName.Text + "%'";
            }
            //作者名記入チェック
            if (bookAuthor.Text != "")
            {
                if (check == true)
                    conditions += " AND ";
                else
                    check = true;
                conditions += "作者 LIKE '%" +  bookAuthor.Text + "%'";
            }
            //ジャンル記入チェック
            if (genreForm.Text != "") {
                if (check == true)
                    conditions += " AND ";
                else
                    check = true;
                conditions += "(SELECT genre_ID FROM t_genre WHERE '";
                conditions += genreForm.Text + "' = genre_title) = ";
                conditions += "t_doujinshi.genre_ID";
            }
            
            //年齢チェックボックスの有無判定
            if (protoage_shaiping_check(all.Checked, r15.Checked, r18.Checked) == true)
            {
                //過去の記入チェックの有無判定
                if (check == true) conditions += " AND ";
                check = true;

                checkbox_flag[0] = all.Checked;
                checkbox_flag[1] = r15.Checked;
                checkbox_flag[2] = r18.Checked;
                conditions += protoage_shaiping(checkbox_flag, "all", "r15", "r18");
                //conditions += limit_shaiping(all.Checked, r15.Checked, r18.Checked);
            }

            //保存場所チェックボックスのチェックの有無判定
            //保存場所チェックボックス判定
            if (protoage_shaiping_check(house.Checked, hometown.Checked) == true)
            {
                if (check == true) conditions += " AND ";
                check = true;
                checkbox_flag[0] = house.Checked;
                checkbox_flag[1] = hometown.Checked;
                conditions += protoage_shaiping(checkbox_flag, "house", "hometown");
            }

            //キャラ記入チェック
            if (charaForm.Text != "")
            {
                if (check == true)
                    conditions += " AND ";
                else
                    check = true;
                conditions += "t_doujinshi.main_chara LIKE '%" + charaForm.Text + "%'";
            }

            //全項目記入チェック                         
            if (check == true)
                conditions = "WHERE " + conditions;
                //return;
            //search_flag = true;
            Visible = false;
        }
        //ロード時の処理
        private void detail_search_Load(object sender, EventArgs e)
        {
            bookName.Focus();

            //ジャンルのコンボボックスの中身の読み込み
            SQLiteDataReader reader = null;
            string query = "SELECT genre_title FROM t_genre";
            SQLiteConnect.Excute(query, ref reader);
            if (reader != null) {
                while (reader.Read()) {
                    genreForm.Items.Add(reader["genre_title"].ToString());
                }
                reader.Close();
                SQLiteConnect.conn.Close();
            }
        }
    }
}
