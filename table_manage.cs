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

        private void table_manage_Load(object sender, EventArgs e)
        {
            //Dbからlistboxに値を格納、作品
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
            //Dbからlistboxに値を格納、ジャンル
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

        private void close_Click(object sender, EventArgs e)
        {
            Visible = false;

        }


        private void origin_List_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(originList.SelectedItems.Count>0)
            originBox.Text = originList.SelectedItems[0].SubItems[1].Text;
        }

        private void originAdd_Click(object sender, EventArgs e)//追加ボタン
        {
            string addquery;
            string IDquery;
            string addtitle;
            string query;
            int ID;
            SQLiteDataReader reader = null;//リフレッシュ用
            addtitle = originBox.Text;//textboxから追加したい文言の取得
           /* if (originBox.Text == originList.SelectedItems[0].SubItems[1].Text)//エラー処理
            {
                DialogResult err = MessageBox.Show(addtitle + "はもうすでに存在していますが、作業を強行しますか？",
                      "重複確認", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            }
            要考察、エラー吐く
            for-ifで頭悪く総当たり？非現実的*/
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
                    query = "SELECT * FROM t_origin";
                    SQLiteConnect.beResponse(query, ref reader);
                    while (reader.Read())
                    {
                        string[] origin = { (reader["origin_ID"].ToString()), (reader["origin_title"].ToString()) };
                        originList.Items.Add(new ListViewItem(origin));
                    }
                    reader.Close();
                    SQLiteConnect.conn.Close();
                }

         }
        

        private void genreList_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (genreList.SelectedItems.Count > 0)
                genreBox.Text = genreList.SelectedItems[0].SubItems[1].Text;
        }

       
    }
}
