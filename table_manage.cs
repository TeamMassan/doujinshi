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
    public partial class table_manage : Form {
        public table_manage() {
            InitializeComponent();
        }
        int o_baseID;
        int g_baseID;
        string o_basetitle;
        string g_basetitle;
        private void originset()//リストボックス取得
        {
             string query; 
            SQLiteDataReader reader = null;
            query = "SELECT * FROM t_origin";
            SQLiteConnect.beResponse(query, ref reader);
            while (reader.Read())
            {
                string[] origin = { (reader["origin_ID"].ToString()),(reader["origin_title"].ToString()) };
                originList.Items.Add(new ListViewItem(origin));
            }
            reader.Close();
            SQLiteConnect.conn.Close();
        }
        private void genreset()//リストボックス取得
        {
            string query;
            SQLiteDataReader reader = null;
            query = "SELECT genre_title,genre_ID FROM t_genre";
            SQLiteConnect.beResponse(query, ref reader);
            while (reader.Read())
            {
                string[] genre = { (reader["genre_ID"].ToString()), (reader["genre_title"].ToString()) };
                genreList.Items.Add(new ListViewItem(genre));
            }
            reader.Close();
            SQLiteConnect.conn.Close();
        }
        private void table_manage_Load(object sender, EventArgs e)
        {
            //Dbからlistboxに値を格納、作品
            originset();
            //Dbからlistboxに値を格納、ジャンル
            genreset();
        }
        private void close_Click(object sender, EventArgs e)
        {
            Visible = false;

        }
        private void origin_List_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (originList.SelectedItems.Count > 0)
            {
                originBox.Text = originList.SelectedItems[0].SubItems[1].Text;
                o_baseID = int.Parse(originList.SelectedItems[0].SubItems[0].Text);
                o_basetitle = originList.SelectedItems[0].SubItems[1].Text;
            }
       
        }
        private void genreList_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (genreList.SelectedItems.Count > 0)
            {
                genreBox.Text = genreList.SelectedItems[0].SubItems[1].Text;
                g_baseID = int.Parse(genreList.SelectedItems[0].SubItems[0].Text);
                g_basetitle = genreList.SelectedItems[0].SubItems[1].Text;
            }
        }
        private void originAdd_Click(object sender, EventArgs e)//追加ボタン
        {
            string addquery;
            string IDquery;
            string addtitle;
            int ID;
            SQLiteDataReader reader = null;//リフレッシュ用
            addtitle = originBox.Text;//textboxから追加したい文言の取得
          
                DialogResult res = MessageBox.Show(addtitle + "　を登録しますか？",//確認処理
                    "追加確認", MessageBoxButtons.YesNo);
                if (res == DialogResult.Yes)
                {
                   
                    IDquery = "select max(origin_ID) from t_origin";//現在のID最大値取得sql
                    //追加作業部分
                    SQLiteConnect.beResponse(IDquery, ref reader);
                    reader.Read();
                    ID = int.Parse(reader["max(origin_ID)"].ToString()) + 1; //追加用の新規ID生成
                    reader.Close();
                    SQLiteConnect.conn.Close();

                    if (SQLiteConnect.checkRecord("t_origin") == 0)//レコードない時の処理
                        ID = 1;

                    addquery = "INSERT into t_origin(origin_ID,origin_title)VALUES(" + ID + ","
                        + "'" + originBox.Text + "')";//追加用sql組み立て
                    SQLiteConnect.nonResponse(addquery);//登録作業

                    originList.Items.Clear();
                    originset();
                }

         }
        private void genreAdd_Click(object sender, EventArgs e)//追加ボタン
        {
            string addquery;
            string IDquery;
            string addtitle;
            int ID;
            SQLiteDataReader reader = null;//リフレッシュ用
            addtitle = genreBox.Text;//textboxから追加したい文言の取得

            DialogResult res = MessageBox.Show(addtitle + "　を登録しますか？",//確認処理
                "追加確認", MessageBoxButtons.YesNo);
            if (res == DialogResult.Yes)
            {

                IDquery = "select max(genre_ID) from t_genre";//現在のID最大値取得sql
                //追加作業部分
                SQLiteConnect.beResponse(IDquery, ref reader);
                reader.Read();
                ID = int.Parse(reader["max(genre_ID)"].ToString()) + 1; //追加用の新規ID生成
                reader.Close();
                SQLiteConnect.conn.Close();

                if (SQLiteConnect.checkRecord("t_genre") == 0)//レコードない時の処理
                    ID = 1;

                addquery = "INSERT into t_genre(genre_ID,genre_title)VALUES(" + ID + ","
                    + "'" + genreBox.Text + "')";//追加用sql組み立て
                SQLiteConnect.nonResponse(addquery);//登録作業

                genreList.Items.Clear();
                genreset();
            }

        }

        private void originChange_Click(object sender, EventArgs e)//内容変更
        {
            string changequery;
            string changetitle;
            changetitle = originBox.Text;//変更する内容の取得
            DialogResult res = MessageBox.Show(o_basetitle+"を"+ changetitle + "に変更しますか？","変更確認",MessageBoxButtons.YesNo);
            if (res == DialogResult.Yes)
            {
                changequery = "update t_origin set origin_title = '" + changetitle + "'"
                    + "where origin_id = " + o_baseID;//クエリ組み立て
                SQLiteConnect.nonResponse(changequery);//SQL文実行
                originList.Items.Clear();
                originset();//リフレッシュ処理
            }
            
        }

        private void genreChange_Click(object sender, EventArgs e)
        {
            string changequery;
            string changetitle;
            changetitle = genreBox.Text;//変更する内容の取得
            DialogResult res = MessageBox.Show(g_basetitle + "を" + changetitle + "に変更しますか？", "変更確認", MessageBoxButtons.YesNo);
            if (res == DialogResult.Yes)
            {
                changequery = "update t_genre set genre_title = '" + changetitle + "'"
                    + "where genre_id = " + g_baseID;
                SQLiteConnect.nonResponse(changequery);
                genreList.Items.Clear();
                genreset();
            }
        }

        private void originDelete_Click(object sender, EventArgs e)//項目削除
        {
            string deletequery;
            DialogResult res = MessageBox.Show(o_basetitle + "を削除しますか？", "削除確認", MessageBoxButtons.YesNo);
            if (res == DialogResult.Yes)
            {
                deletequery = "delete from t_origin where origin_id =" + o_baseID;
                SQLiteConnect.nonResponse(deletequery);
                originList.Items.Clear();
                originset();
            }
        }

        private void genreDelete_Click(object sender, EventArgs e)
        {
            string deletequery;
            DialogResult res = MessageBox.Show(g_basetitle + "を削除しますか？", "削除確認", MessageBoxButtons.YesNo);
            if (res == DialogResult.Yes)
            {
                deletequery = "delete from t_genre where genre_id =" + g_baseID;
                SQLiteConnect.nonResponse(deletequery);
                genreList.Items.Clear();
                genreset();
            }
        }

       
    }
}
