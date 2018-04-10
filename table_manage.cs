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

        SQLiteConnct connect = new SQLiteConnct();

        private void table_manage_Load(object sender, EventArgs e)
        {
            //Dbからlistboxに値を格納、作品
            string query; 
            SQLiteDataReader reader = null;
            query = "SELECT origin_title FROM t_origin";
            connect.beResponse(query, ref reader);
            while (reader.Read())            
                originList.Items.Add(reader["origin_title"].ToString());
            reader.Close();
            connect.conn.Close();
            //Dbからlistboxに値を格納、ジャンル
            query = "SELECT genre_title FROM t_genre";
            connect.beResponse(query, ref reader);
            while (reader.Read())
                genreList.Items.Add(reader["genre_title"].ToString());
            reader.Close();
            connect.conn.Close();
        }

        private void close_Click(object sender, EventArgs e)
        {
            Visible = false;

        }

        private void originList_SelectedIndexChanged(object sender, EventArgs e)
        {
            //textboxに項目を表示
            originBox.Text = originList.SelectedItem.ToString();
        }

       
    }
}
