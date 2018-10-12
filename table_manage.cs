using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data.SQLite;


namespace 同人誌管理
{
    public partial class table_manage : 同人誌管理.manageBase
    {
        public table_manage()
        {
            InitializeComponent();
        }

        private void table_manage2_Load(object sender, EventArgs e)//フォームロード時の処理
        {
            SQLiteConnect.lording(ref Listview1, "select origin_ID,origin_title from t_origin", "origin_ID", "origin_title");
            SQLiteConnect.lording(ref Listview2, "select genre_ID,genre_title from t_genre", "genre_ID", "genre_title");
        }

        private void Add1_Click(object sender, EventArgs e)//追加ボタンの処理　作品
        {
            string addquery;
            string IDquery;
            string addtitle;
            int ID;
            SQLiteDataReader reader = null;//リフレッシュ用
            addtitle = Textbox1.Text;//textboxから追加したい文言の取得

            if (Textbox1.TextLength == 0) //中身が空の時の処理
            {
                return;
            }

            DialogResult res = MessageBox.Show(addtitle + "　を登録しますか？",//確認処理
                "追加確認", MessageBoxButtons.YesNo);
            if (res == DialogResult.Yes)
            {

                IDquery = "select max(origin_ID) from t_origin";//現在のID最大値取得sql
                //追加作業部分

                if (SQLiteConnect.checkRecord("t_origin") == 0)//レコードない時の処理
                    ID = 1;
                else
                {
                    SQLiteConnect.Excute(IDquery, ref reader);
                    reader.Read();
                    ID = int.Parse(reader["max(origin_ID)"].ToString()) + 1; //追加用の新規ID生成
                    reader.Close();
                    SQLiteConnect.conn.Close();
                }

                addquery = "INSERT into t_origin(origin_ID,origin_title)VALUES(" + ID + ","
                    + "'" + Textbox1.Text + "')";//追加用sql組み立て
                SQLiteConnect.Excute(addquery);//登録作業

                Listview1.Items.Clear();
                SQLiteConnect.lording(ref Listview1, "select origin_ID,origin_title from t_origin", "origin_ID", "origin_title");
            }
        }

        private void Change1_Click(object sender, EventArgs e)//変更ボタンの処理　作品
        {
            string changequery;
            string changetitle;
            changetitle = Textbox1.Text;//変更する内容の取得
            if (Textbox1.TextLength == 0) 
            {
                return;
            }
            DialogResult res = MessageBox.Show(beforeListview1Title+ "を" + changetitle + "に変更しますか？", "変更確認", MessageBoxButtons.YesNo);
            if (res == DialogResult.Yes)
            {
                changequery = "update t_origin set origin_title = '" + changetitle + "'"
                    + "where origin_id = " + beforeListView1ID;//クエリ組み立て
                SQLiteConnect.Excute(changequery);//SQL文実行
                Listview1.Items.Clear();
                SQLiteConnect.lording(ref Listview1, "select origin_ID,origin_title from t_origin", "origin_ID", "origin_title");
                //リフレッシュ処理
            }
        }

        private void Delete1_Click(object sender, EventArgs e)//削除ボタンの処理　作品
        {
            string deletequery;
            int counter = 0;
            counter = SQLiteConnect.counterID("origin", beforeListView1ID);
            if (counter != 0)
            {
                MessageBox.Show("データが" + counter + "件存在するため、削除できません。", "警告", MessageBoxButtons.OK);
                return;
            }
            DialogResult res = MessageBox.Show(beforeListview1Title + "を削除しますか？", "削除確認", MessageBoxButtons.YesNo);
            if (res == DialogResult.Yes)
            {

                deletequery = "delete from t_origin where origin_id =" + beforeListView1ID;
                SQLiteConnect.Excute(deletequery);
                Listview1.Items.Clear();
                SQLiteConnect.lording(ref Listview1, "select origin_ID,origin_title from t_origin", "origin_ID", "origin_title");
                Textbox1.Clear();
            }
        }

        private void Add2_Click(object sender, EventArgs e)//追加ボタンの処理　ジャンル
        {
            string addquery;
            string IDquery;
            string addtitle;
            int ID;
            SQLiteDataReader reader = null;//リフレッシュ用
            addtitle = Textbox2.Text;//textboxから追加したい文言の取得

            if (Textbox2.TextLength == 0)
            {
                return;
            }
            DialogResult res = MessageBox.Show(addtitle + "　を登録しますか？",//確認処理
                "追加確認", MessageBoxButtons.YesNo);
            if (res == DialogResult.Yes)
            {

                IDquery = "select max(genre_ID) from t_genre";//現在のID最大値取得sql
                //追加作業部分
                if (SQLiteConnect.checkRecord("t_genre") == 0)//レコードない時の処理
                    ID = 1;
                else
                {
                    SQLiteConnect.Excute(IDquery, ref reader);
                    reader.Read();
                    ID = int.Parse(reader["max(genre_ID)"].ToString()) + 1; //追加用の新規ID生成
                    reader.Close();
                    SQLiteConnect.conn.Close();
                }

                addquery = "INSERT into t_genre(genre_ID,genre_title)VALUES(" + ID + ","
                    + "'" + Textbox2.Text + "')";//追加用sql組み立て
                SQLiteConnect.Excute(addquery);//登録作業

                Listview2.Items.Clear();
                SQLiteConnect.lording(ref Listview2, "select genre_ID,genre_title from t_genre", "genre_ID", "genre_title");
                //リフレッシュ処理
            }
        }

        private void Change2_Click(object sender, EventArgs e)//変更ボタンの処理　ジャンル
        {
            string changequery;
            string changetitle;
            changetitle = Textbox2.Text;//変更する内容の取得
            if (Textbox2.TextLength == 0)
            {
                return;
            }
            DialogResult res = MessageBox.Show(beforeListview2Title + "を" + changetitle + "に変更しますか？", "変更確認", MessageBoxButtons.YesNo);
            if (res == DialogResult.Yes)
            {
                changequery = "update t_genre set genre_title = '" + changetitle + "'"
                    + "where genre_id = " + beforeListview2ID;
                SQLiteConnect.Excute(changequery);
                Listview2.Items.Clear();
                SQLiteConnect.lording(ref Listview2, "select genre_ID,genre_title from t_genre", "genre_ID", "genre_title");
                //リフレッシュ処理
            }
        }

        private void Delete2_Click(object sender, EventArgs e)
        {
            int counter = 0;
            counter = SQLiteConnect.counterID("genre", beforeListview2ID);
            if (counter != 0)
            {
                MessageBox.Show("データが" + counter + "件存在するため、削除できません。", "警告", MessageBoxButtons.OK);
                return;
            }
            string deletequery;
            DialogResult res = MessageBox.Show(beforeListview2Title + "を削除しますか？", "削除確認", MessageBoxButtons.YesNo);
            if (res == DialogResult.Yes)
            {
                deletequery = "delete from t_genre where genre_id =" + beforeListview2ID;
                SQLiteConnect.Excute(deletequery);
                Listview2.Items.Clear();
                SQLiteConnect.lording(ref Listview2, "select genre_ID,genre_title from t_genre", "genre_ID", "genre_title");
                Textbox2.Clear(); //リフレッシュ処理
            }
        }
    }
}
