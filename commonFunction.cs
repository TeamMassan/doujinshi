﻿using System;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Data.SQLite;

namespace 同人誌管理 {
    //SQLite関連の操作
    public static class SQLiteConnect {
        //DBの場所をexeファイルから相対パス指定
        public static SQLiteConnection conn = new SQLiteConnection("Data Source = doujinshi.sqlite");

        //全テーブル結合した上で情報取得したいとき用のSQL文
        //SELECT句、WHERE句は自作すること。SELECT句 + getFullInfoFrom + WHERE句 + getFullInfoLatter でつなげて発行
        //WHERE句に指定出来るのは同人誌テーブルのIDだけ
        public const string getFullInfoFrom = "FROM((SELECT main.ID, タイトル, origin_ID, genre_ID, 対象年齢, 頒布日, キャラ, "+
            "場所, 本棚, サークル, GROUP_CONCAT(author) AS 作者, main.place_ID FROM(SELECT t_doujinshi.ID, title AS タイトル, "+
            "origin_ID, genre_ID, age_limit AS 対象年齢, date AS 頒布日, main_chara AS キャラ,place_name AS 場所, "+
            "shelf_name AS 本棚, GROUP_CONCAT(circle) AS サークル, t_doujinshi.place_ID FROM t_doujinshi "+
            "INNER JOIN t_storage ON t_doujinshi.place_ID = t_storage.place_ID INNER JOIN t_house_shelf ON "+
            "t_doujinshi.place_ID = t_house_shelf.place_ID AND t_doujinshi.bookShelf_ID = t_house_shelf.bookShelf_ID "+
            "LEFT OUTER JOIN t_circle ON t_doujinshi.ID = t_circle.ID ";
        public const string getFullInfoLatter = " GROUP BY t_doujinshi.ID) AS main LEFT OUTER JOIN t_author ON main.ID = t_author.ID "+
            "GROUP BY main.ID) AS main LEFT OUTER JOIN t_origin ON main.origin_ID = t_origin.origin_ID) "+
            "LEFT OUTER JOIN t_genre ON main.genre_ID = t_genre.genre_ID ";
        
        //任意テーブルのレコード件数を取得
        public static int checkRecord(string table_name) {
            int Rows = 0;
            string query = "SELECT COUNT(*) FROM " + table_name;
            var cmd = new SQLiteCommand(query, conn);
            try {
                conn.Open();
                Rows = System.Convert.ToInt32(cmd.ExecuteScalar());
                conn.Close();
            }
            catch (Exception err) {
                MessageBox.Show("指定したテーブルが見つかりません\n" + err.ToString());
            }
            return Rows;
        }
        public static int checkRecord2(string table_name,string where,int whereID)
            //ID条件指定付き、テーブルのレコード取得
        {
            int Rows = 0;
            string query = "select count(*) from " + table_name + " where " + where +" = "+ whereID;
            var cmd = new SQLiteCommand(query, conn);
            try
            {
                conn.Open();
                Rows = System.Convert.ToInt32(cmd.ExecuteScalar());
                conn.Close();
            }
            catch (Exception err)
            {
                MessageBox.Show("指定したテーブルが見つかりません\n" + err.ToString());
            }
            return Rows;
        }


        //IDカウンター
        public static int counterID(string str, int ID) {
            string query;
            int count = 0;
            query = "select count(*) from t_doujinshi where " + str + "_ID=" + ID;
            var cmd = new SQLiteCommand(query, conn);
            try {
                conn.Open();
                count = Convert.ToInt32(cmd.ExecuteScalar());
                conn.Close();

            }
            catch (Exception err) {
                MessageBox.Show("指定したテーブルが見つかりません\n" + err.ToString());
            }
            return count;
        }
        public static int counterID2(string str, int ID,string str2,int ID2) //条件指定付きIDカウンタ
        {
            string query;
            int count = 0;
            query = "select count(*) from t_doujinshi where " + str + "_ID =" + ID 
                + " and " + str2 +"_ID ="+ID2;
            var cmd = new SQLiteCommand(query, conn);
            try
            {
                conn.Open();
                count = Convert.ToInt32(cmd.ExecuteScalar());
                conn.Close();

            }
            catch (Exception err)
            {
                MessageBox.Show("指定したテーブルが見つかりません\n" + err.ToString());
            }
            return count;
        }

        //SQL発行（readerを必要としない場合）
        public static void Excute(string SQLquery) {
            var cmd = new SQLiteCommand(SQLquery, conn);
            try {
                conn.Open();
                cmd.ExecuteNonQuery();
                conn.Close();
            }
            catch (Exception err) {
                MessageBox.Show("内容をクリップボードにコピーします\n\n" +
                     SQLquery + "\n" + err.ToString(), "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Logging(SQLquery + "\n\n" + err.Message + err.Source);
            }
        }
        
        //SQL発行（readerがある場合）
        //関数外でreader.Close()とconn.Close()する必要アリ
        public static void Excute(string SQLquery, ref SQLiteDataReader reader) {
            var cmd = new SQLiteCommand(SQLquery, conn);
            try {
                conn.Open();
                reader = cmd.ExecuteReader();
            }
            catch (Exception err) {
                MessageBox.Show("SELECTの結果が取得出来ませんでした\n" + SQLquery + "\n" +
                    err.Message + "\n" + err.ToString() + "\nログを取得しました",
                    "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Logging(SQLquery + "\n" + err.Message + err.Source);
            }
        }

        //エラー内容をテキストで吐く
        public static void Logging(string ErrMessage) {
            DateTime dt = DateTime.Now;
            StreamWriter StreamWriter = new StreamWriter("ErrorLog.txt", true, Encoding.GetEncoding("Shift_JIS"));
            StreamWriter.WriteLine(dt + "\n" + ErrMessage);
            StreamWriter.Close();
        }

        //クエリから一つのカラムをコンボボックスに全部追加
        //ジャンル、作品、本棚などのコンボボックスのロード時に多用出来る
        public static void ComboBoxLoad(ref ComboBox comboBox, string query, string columnName) {
            SQLiteDataReader reader = null;
            Excute(query, ref reader);
            if (reader != null) {
                while (reader.Read())
                    comboBox.Items.Add(reader[columnName].ToString());
                reader.Close();
                conn.Close();
            }
            reader.Close();
            conn.Close();
        }
        public static void lording(ref ListView listview, string query, string column1, string column2)//ロード処理、リストビュー版
        {
            SQLiteDataReader reader = null;
            SQLiteConnect.Excute(query, ref reader);
            if (reader != null)
            {
                while (reader.Read())
                {
                    string[] item = { (reader[column1].ToString()), (reader[column2].ToString()) };
                    listview.Items.Add(new ListViewItem(item));
                }
                reader.Close();
                SQLiteConnect.conn.Close();
            }
        }

        //テーブル自動作成
        public static void make_db() {
            const string setting = "CREATE TABLE IF NOT EXISTS t_doujinshi(" +
                                "ID INTEGER PRIMARY KEY NOT NULL," +
                                "title TEXT NOT NULL," +
                                "origin_ID INTEGER NOT NULL," +
                                "genre_ID INTEGER NOT NULL," +
                                "age_limit TEXT NOT NULL," +
                                "date INTEGER," +
                                "main_chara TEXT," +
                                "place_ID INTEGER NOT NULL," +
                                "bookShelf_ID INTEGER" +
                             ");" +
                             "CREATE TABLE IF NOT EXISTS t_origin(" +
                                "origin_ID INTEGER PRIMARY KEY NOT NULL," +
                                "origin_title TEXT NOT NULL" +
                                 "); " +
                             "CREATE TABLE IF NOT EXISTS t_genre(" +
                                "genre_ID INTEGER PRIMARY KEY NOT NULL, " +
                                "genre_title TEXT NOT NULL" +
                             "); " +
                             "CREATE TABLE IF NOT EXISTS t_author(" +
                                "ID INTEGER NOT NULL, " +
                                "author TEXT, " +
                                "FOREIGN KEY(ID) REFERENCES t_doujinshi(ID) ON DELETE CASCADE" +
                             "); " +
                             "CREATE TABLE IF NOT EXISTS t_circle(" +
                                "ID INTEGER NOT NULL, " +
                                "circle TEXT, " +
                                "FOREIGN KEY(ID) REFERENCES t_doujinshi(ID) ON DELETE CASCADE" +
                             "); " +
                             "CREATE TABLE IF NOT EXISTS t_storage("+
                                "place_ID INTEGER NOT NULL, "+
                                "place_name TEXT, "+
                                "FOREIGN KEY(place_ID) REFERENCES t_doujinshi(place_ID) ON DELETE CASCADE" +
                            "); "+
                             "CREATE TABLE IF NOT EXISTS t_house_shelf(" +
                                "place_ID INTEGER NOT NULL, " +
                                "bookShelf_ID INTEGER," +
                                "shelf_name TEXT," +
                                "FOREIGN KEY(place_ID) REFERENCES t_doujinshi(place_ID) ON DELETE CASCADE" +
                             "); ";
            Excute(setting);

            //ジャンルコード・作品コード一覧初期設定
            //DBを0から設定し直す時の保険で残してるので完全リリース後は消します。
            if (checkRecord("t_origin") < 8) {
                const string original = "INSERT INTO t_origin VALUES(1,'東方Project');" +
                         "INSERT INTO t_origin VALUES(2, '艦これ');" +
                         "INSERT INTO t_origin VALUES(3, 'オリジナル');" +
                         "INSERT INTO t_origin VALUES(4, 'グラブル');" +
                         "INSERT INTO t_origin VALUES(5, 'ATLUS系');" +
                         "INSERT INTO t_origin VALUES(6, 'ラブライブ');" +
                         "INSERT INTO t_origin VALUES(7, 'デレマス');" +
                         "INSERT INTO t_origin VALUES(8, 'その他');";
                Excute(original);
            }
            if (checkRecord("t_genre") < 13) {
                const string genre = "INSERT INTO t_genre VALUES(1,'漫画');" +
                        "INSERT INTO t_genre VALUES(2, 'イラスト集'); " +
                        "INSERT INTO t_genre VALUES(3, '成人向け'); " +
                        "INSERT INTO t_genre VALUES(4, 'コピ本'); " +
                        "INSERT INTO t_genre VALUES(5, 'シリアス');" +
                        "INSERT INTO t_genre VALUES(6, 'ほのぼの');" +
                        "INSERT INTO t_genre VALUES(7, 'ラフ画集');" +
                        "INSERT INTO t_genre VALUES(8, '日常');" +
                        "INSERT INTO t_genre VALUES(9, 'ソムリエ天龍');" +
                        "INSERT INTO t_genre VALUES(10, '4コマ');" +
                        "INSERT INTO t_genre VALUES(11, '設定資料集');" +
                        "INSERT INTO t_genre VALUES(12, '合同本');" +
                        "INSERT INTO t_genre VALUES(13, 'その他');";
                Excute(genre);
            }
            if (checkRecord("t_storage") < 2) {
                const string storage = "INSERT INTO t_storage VALUES(1, '下宿');" +
                    "INSERT INTO t_storage VALUES(2, '実家');";
                Excute(storage);
            }
            if (checkRecord("t_house_shelf") < 8) {
                const string bookShelf = "INSERT INTO t_house_shelf VALUES(1, 1 ,'棚A - 1段目');" +
                    "INSERT INTO t_house_shelf VALUES(1, 2 ,'棚A - 2段目');" +
                    "INSERT INTO t_house_shelf VALUES(1, 3 ,'棚B - 1段目');" +
                    "INSERT INTO t_house_shelf VALUES(1, 4 ,'棚B - 2段目');" +

                    "INSERT INTO t_house_shelf VALUES(2, 1 ,'棚 - 1段目');" +
                    "INSERT INTO t_house_shelf VALUES(2, 2 ,'棚 - 2段目');" +
                    "INSERT INTO t_house_shelf VALUES(2, 3 ,'棚 - 3段目');" +
                    "INSERT INTO t_house_shelf VALUES(2, 4 ,'棚 - 4段目');";
                Excute(bookShelf);
            }
        }
    }

    //日付情報の整形
    public static class Date {
        //個別UIの日付情報を統一する
        public static string merge(string year, string month,string day) {
            //頒布年月日整形
            //十の位補足と連結で8桁のstringに収める
            string merged = year;
            if (month.Length < 2)
                month = "0" + month;
            merged += month;
            if (day.Length < 2)
                day = "0" + day;
            merged += day;
            return merged;
        }
        
        //DBから取得した日付列に単位を挟む
        public static string insert_y_m_d(string date) {
            string distribution = "";
            distribution += date.Substring(0, 4) + "年";
            if (date.Substring(4, 1) == "0")
                distribution += " " + date.Substring(5, 1) + "月";
            else
                distribution += date.Substring(4, 2) + "月";
            if (date.Substring(6, 1) == "0")
                distribution += " " + date.Substring(7, 1) + "日";
            else
                distribution += date.Substring(6, 2) + "日";
            return distribution;
        }
    }
}
