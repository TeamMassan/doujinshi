﻿using System;
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
            bookName.Focus();
            //ジャンルのコンボボックスの中身の読み込み
            string query = "SELECT genre_title FROM t_genre";
            SQLiteConnect.ComboBoxLoad(ref genreForm, query, "genre_title");
            query = "SELECT origin_title FROM t_origin";
            SQLiteConnect.ComboBoxLoad(ref originForm, query, "origin_title");
            
            //保管場所一覧をロード
            query = "SELECT place_name FROM t_storage";
            SQLiteConnect.ComboBoxLoad(ref storage, query, "place_name");

            DateTime dt = DateTime.Today;
            for (int cnt=0; cnt < 15; cnt++) {
                bYear.Items.Add(dt.Year - cnt);
                aYear.Items.Add(dt.Year - cnt);
            }
            for(int cnt = 1; cnt <= 12; cnt++) {
                bMonth.Items.Add(cnt);
                aMonth.Items.Add(cnt);
            }
            for(int cnt = 1; cnt <= 31; cnt++) {
                bDay.Items.Add(cnt);
                aDay.Items.Add(cnt);
            }

        }

        public string conditions = "";
        public bool searchRun = false;

        string protoage_shaiping(bool checkbox) {
            string part_where = "(";
            
            return part_where;
        }

        
        string protoage_shaiping(bool[] checkbox_flag , params string[] checkbox_str) {
            string part_where = "(";
            bool check = false;
            bool mode = false ;
            int num = checkbox_str.Length;
            if (checkbox_str[0] == "house") mode = true;
            for (int cnt = 0; cnt < num; cnt++)
            {
                if (checkbox_flag[cnt])
                {
                    //ORの有無チェック
                    if (check)
                        part_where += " OR ";
                    else
                        check = true;
                    part_where += "'" + checkbox_str[cnt] + "' = t_doujinshi.";
                    
                    //ageとplaseのどちらと比較するかの処理
                    if(mode)
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
                if (checkbox_flag[cnt])
                {
                    check = true;
                    break;
                }
            }
            return check;
        }

        void exist_conditions(ref string conditions, ref bool check) {
            if (check)
                conditions += " AND ";
            else
                check = true;
        }

        
        //閉じるボタン
        private void close_Click(object sender, EventArgs e)
        {
            Visible = false;  
        }
        //検索ボタン
        private void search_Click(object sender, EventArgs e) {
            conditions = "";
            bool check = false;//記入チェック変数
            bool[] checkbox_flag = new bool[3];

            //誌名記入チェック
            if (bookName.Text != "") {
                check = true;
                conditions += "タイトル LIKE '%" + bookName.Text + "%'";
            }
            //作者名記入チェック
            if (bookAuthor.Text != "") {
                exist_conditions(ref conditions, ref check);
                conditions += "作者 LIKE '%" + bookAuthor.Text + "%'";
            }

            //作品名記入チェック
            if (originForm.Text != "") {
                exist_conditions(ref conditions, ref check);
                conditions += "(SELECT origin_ID FROM t_origin ";
                conditions += "WHERE '" + originForm.Text + "' = origin_title) ";
                conditions += " = main.origin_ID";
            }

            //ジャンル記入チェック
            if (genreForm.Text != "") {
                exist_conditions(ref conditions, ref check);
                conditions += "(SELECT genre_ID FROM t_genre ";
                conditions += "WHERE '" + genreForm.Text + "' = genre_title)";
                conditions += " = main.genre_ID";
            }
            
            //年齢チェックボックスの有無判定
            foreach (CheckBox cb in panel1.Controls) {
                if (cb.Checked) {
                    bool orCheck = false;
                    //過去の記入チェックの有無判定
                    exist_conditions(ref conditions, ref check);

                    conditions += "(";
                    foreach (CheckBox incb in panel1.Controls) {
                        if (incb.Checked) {
                            //ORの有無チェック
                            if (orCheck)
                                conditions += " OR ";
                            else
                                orCheck = true;
                            conditions += "'" + incb.Tag + "' = 対象年齢";
                        }
                    }
                    conditions += ")";
                    break;
                }
            }

            //保管場所記入チェック
            if (storage.Text.Length != 0) {
                exist_conditions(ref conditions, ref check);
                conditions += "場所 = '" + storage.Text + "'";
            }

            //本棚記入チェック
            if (bookShelf.Text.Length != 0) {
                exist_conditions(ref conditions, ref check);
                conditions += "本棚 = '" + bookShelf.Text + "'";
            }

            //キャラ記入チェック
            if (charaForm.Text != "") {
                exist_conditions(ref conditions, ref check);
                conditions += "キャラ LIKE '%" + charaForm.Text + "%'";
            }

            //分布日記入チェック
            string date = Date.merge(bYear.Text, bMonth.Text, bDay.Text);
            if (bYear.Text != "" && bMonth.Text != "" && bDay.Text != "" && date.Length == 8) {
                exist_conditions(ref conditions, ref check);
                conditions += date + " <= 頒布日";
            }

            date = Date.merge(aYear.Text, aMonth.Text, aDay.Text);
            if (aYear.Text != "" && aMonth.Text != "" && aDay.Text != "" && date.Length == 8) {
                exist_conditions(ref conditions, ref check);
                conditions += date + " >= 頒布日";
            }

            //全項目記入チェック                         
            if (check) {
                conditions = "WHERE " + conditions;
                searchRun = true;
            }
            this.Close();
        }

        //保管先が変更された時に書棚を当該場所の内容に変える
        private void storage_SelectedIndexChanged(object sender, EventArgs e) {
            SQLiteDataReader reader = null;
            string query = "SELECT place_ID FROM t_storage WHERE  place_name = '" + storage.Text + "'";
            SQLiteConnect.Excute(query, ref reader);
            if (reader != null) {
                reader.Read();
                reader.Close();
            }
            SQLiteConnect.conn.Close();

            //本棚の内容変更
            query = "SELECT shelf_name FROM t_house_shelf WHERE " +
                "(SELECT place_ID FROM t_storage WHERE place_name = '" + storage.Text + "') = t_house_shelf.place_ID";
            bookShelf.Items.Clear();
            SQLiteConnect.ComboBoxLoad(ref bookShelf, query, "shelf_name");
        }
    }
}
