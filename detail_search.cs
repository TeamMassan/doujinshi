using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace 同人誌管理 {
    public partial class detail_search : Form {
        public detail_search() {
            InitializeComponent();
        }
        //閉じるボタン
        private void close_Click(object sender, EventArgs e)
        {
            Visible = false;  
        }
        //検索ボタン
        private void search_Click(object sender, EventArgs e)
        {
            string sql = "SELECT ID FROM t_doujinshi WHERE ";
            int check = 0;//記入チェック変数
            //誌名記入チェック
            if (bookName.Text != "")
            {
                check = 1;
                sql += "'" + bookName.Text + "' = t_doujinshi.title";
            }
            //作者名記入チェック
            if (bookAuthor.Text != "")
            {
                if (check == 1)
                    sql += " AND ";
                else
                    check = 1;
                sql += "'" + bookAuthor.Text + "' = t_author.author";
            }
            //ジャンル記入チェック
            if (genreForm.Text != "")
            {
                if (check == 1)
                    sql += " AND ";
                else
                    check = 1;
                sql += "'" + genreForm.Text + "' = t_genre.genre_name";
            }
            //キャラ記入チェック
            if(charaForm.Text != "")
            {
                if (check == 1)
                    sql += " AND ";
                else
                    check = 1;
                sql += "'" + charaForm.Text + "' = t_doujinshi.main_chara";
            }

            //全項目記入チェック
            if (check == 1)
                MessageBox.Show(sql);
            Clipboard.SetText(sql);
        }
    }
}
