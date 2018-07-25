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
    public partial class shelf_manage : 同人誌管理.manageBase
    {
        public shelf_manage()
        {
            InitializeComponent();
        }

        private void shelf_manage_Load(object sender, EventArgs e)
        {
            SQLiteConnect.lording(ref Listview1, "select place_ID,place_name from t_storage", "place_ID", "place_name");

        }

        private void Listview1_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            Listview2.Items.Clear();
            SQLiteConnect.lording(ref Listview2, "select bookShelf_ID,shelf_name from t_house_shelf where place_ID = " + beforeListView1ID, "bookShelf_ID", "shelf_name");
        }

        private void Add1_Click(object sender, EventArgs e) //新規追加　保管場所
        {
            string addquery;
            string IDquery;
            string addtitle;
            int ID;
            SQLiteDataReader reader = null;//リフレッシュ用
            addtitle = Textbox1.Text;//textboxから追加したい文言の取得

            DialogResult res = MessageBox.Show(addtitle + "　を登録しますか？",//確認処理
                "追加確認", MessageBoxButtons.YesNo);
            if (res == DialogResult.Yes)
            {

                IDquery = "select max(place_ID) from t_storage";//現在のID最大値取得sql
                //追加作業部分

                if (SQLiteConnect.checkRecord("t_storage") == 0)//レコードない時の処理
                    ID = 1;
                else
                {
                    SQLiteConnect.Excute(IDquery, ref reader);
                    reader.Read();
                    ID = int.Parse(reader["max(place_ID)"].ToString()) + 1; //追加用の新規ID生成
                    reader.Close();
                    SQLiteConnect.conn.Close();
                }

                addquery = "INSERT into t_storage(place_ID,place_name)VALUES(" + ID + ","
                    + "'" + Textbox1.Text + "')";//追加用sql組み立て
                SQLiteConnect.Excute(addquery);//登録作業
                Listview1.Items.Clear();
                SQLiteConnect.lording(ref Listview1, "select place_ID,place_name from t_storage", "place_ID", "place_name");
            }
        }

        private void Change1_Click(object sender, EventArgs e)//要素変更　保管場所
        {
            string changequery;
            string changetitle;
            changetitle = Textbox1.Text;//変更する内容の取得
            DialogResult res = MessageBox.Show(beforeListview1Title + "を" + changetitle + "に変更しますか？", "変更確認", MessageBoxButtons.YesNo);
            if (res == DialogResult.Yes)
            {
                changequery = "update t_storage set place_name = '" + changetitle + "'"
                    + "where place_ID = " + beforeListView1ID;//クエリ組み立て
                SQLiteConnect.Excute(changequery);//SQL文実行
                Listview1.Items.Clear();
                SQLiteConnect.lording(ref Listview1, "select place_ID,place_name from t_storage", "place_ID", "place_name");
                //リフレッシュ処理
            }
        }

        private void Delete1_Click(object sender, EventArgs e)//要素削除　保管場所
        {
            string deletequery;
            int counter = 0;
            counter = SQLiteConnect.counterID("place", beforeListView1ID);
            if (counter != 0)
            {
                MessageBox.Show("データが" + counter + "件存在するため、削除できません。", "警告", MessageBoxButtons.OK);
                return;
            }
            DialogResult res = MessageBox.Show(beforeListview1Title + "を削除しますか？", "削除確認", MessageBoxButtons.YesNo);
            if (res == DialogResult.Yes)
            {

                deletequery = "delete from t_storage where place_ID =" + beforeListView1ID;
                SQLiteConnect.Excute(deletequery);
                Listview1.Items.Clear();
                SQLiteConnect.lording(ref Listview1, "select place_ID,place_name from t_storage", "place_ID", "place_name");
                Textbox1.Clear();
            }
        }

        private void Add2_Click(object sender, EventArgs e)//新規追加　本棚の場所
        {
            string addquery;
            string IDquery;
            string addtitle;
            int ID;
            SQLiteDataReader reader = null;//リフレッシュ用
            addtitle = Textbox2.Text;//textboxから追加したい文言の取得

            DialogResult res = MessageBox.Show(addtitle + "　を登録しますか？",//確認処理
                "追加確認", MessageBoxButtons.YesNo);
            if (res == DialogResult.Yes)
            {

                IDquery = "select max(bookShelf_ID) from t_house_shelf where place_ID = "+beforeListView1ID;//現在のID最大値取得sql
                //追加作業部分

                if (SQLiteConnect.checkRecord2("t_house_shelf","place_ID",beforeListView1ID) == 0)//レコードない時の処理
                    ID = 1;
                else
                {
                    SQLiteConnect.Excute(IDquery, ref reader);
                    reader.Read();
                    ID = int.Parse(reader["max(bookShelf_ID)"].ToString()) + 1; //追加用の新規ID生成
                    reader.Close();
                    SQLiteConnect.conn.Close();
                }

                addquery = "INSERT into t_house_shelf(place_ID,bookShelf_ID,shelf_name)VALUES(" + beforeListView1ID + ","
                 + ID + "," + "'" + Textbox2.Text + "')";//追加用sql組み立て
                SQLiteConnect.Excute(addquery);//登録作業
                Listview2.Items.Clear();
                SQLiteConnect.lording(ref Listview2, "select bookShelf_ID,shelf_name from t_house_shelf where place_ID = " + beforeListView1ID, "bookShelf_ID", "shelf_name");

            }
        }

        private void Change2_Click(object sender, EventArgs e)//要素変更　本棚の場所
        {
            string changequery;
            string changetitle;
            changetitle = Textbox2.Text;//変更する内容の取得
            DialogResult res = MessageBox.Show(beforeListview2Title + "を" + changetitle + "に変更しますか？", "変更確認", MessageBoxButtons.YesNo);
            if (res == DialogResult.Yes)
            {
                changequery = "update t_house_shelf set shelf_name = '" + changetitle + "'"
                    + "where place_ID = " + beforeListView1ID +" and bookShelf_ID = "+beforeListview2ID;//クエリ組み立て
                SQLiteConnect.Excute(changequery);//SQL文実行
                Listview2.Items.Clear();
                SQLiteConnect.lording(ref Listview2, "select bookShelf_ID,shelf_name from t_house_shelf where place_ID = " + beforeListView1ID, "bookShelf_ID", "shelf_name");

                //リフレッシュ処理
            }
        }

        private void Delete2_Click(object sender, EventArgs e)//要素削除　本棚の場所
        {
            string deletequery;
            int counter = 0;
            counter = SQLiteConnect.counterID2("place", beforeListView1ID,"bookShelf",beforeListview2ID);
            if (counter != 0)
            {
                MessageBox.Show("データが" + counter + "件存在するため、削除できません。", "警告", MessageBoxButtons.OK);
                return;
            }
            DialogResult res = MessageBox.Show(beforeListview2Title + "を削除しますか？", "削除確認", MessageBoxButtons.YesNo);
            if (res == DialogResult.Yes)
            {

                deletequery = "delete from t_house_shelf where place_ID =" + beforeListView1ID
                    +" and bookShelf_ID = "+beforeListview2ID;
                SQLiteConnect.Excute(deletequery);
                Listview2.Items.Clear();
                SQLiteConnect.lording(ref Listview2, "select bookShelf_ID,shelf_name from t_house_shelf where place_ID = " + beforeListView1ID, "bookShelf_ID", "shelf_name");
                Textbox2.Clear();
            }
        }
    }
}
