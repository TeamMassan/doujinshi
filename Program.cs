using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SQLite;

namespace 同人誌管理 {
    static class Program {
        /// <summary>
        /// アプリケーションのメイン エントリ ポイントです。
        /// </summary>
        [STAThread]
        static void Main() {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new top());
        }
    }

    //複数のフォームで使いたい自作関数はここに書いてね
    //使う時はインスタンスの生成をお忘れなく！

    //SQLiteへのコネクション周り    
    public class SQLiteConnct {

        public SQLiteConnection conn = new SQLiteConnection("Data Source = doujinshi.sqlite");
        //DBは実行ファイルと同じ場所にある

        //任意テーブルのレコード件数を取得
        public int checkRecord(string table_name) {
            int Rows=0;
            string query = "SELECT COUNT(*) FROM " + table_name;
            var cmd = new SQLiteCommand(query, conn);
            try {
                conn.Open();
                Rows = System.Convert.ToInt32(cmd.ExecuteScalar());
                conn.Close();
            }
            catch (Exception err){
                MessageBox.Show("指定したテーブルが見つかりません\n"+err.ToString());
            }
            return Rows;
        }
                        
        //SQL発行（レスポンスを必要としない場合）
        public void nonResponse(string SQLquery) {            
            var cmd = new SQLiteCommand(SQLquery, conn);
            try {
                conn.Open();
                cmd.ExecuteNonQuery();
                conn.Close();
            }
            catch (Exception err) {
                MessageBox.Show("エラー\n内容をクリップボードにコピーするよ\n"
                    + err.ToString());
                Clipboard.SetText(SQLquery + "\n\n" + err.ToString());
            }
        }

        //SQL発行（readerがある場合）
        //関数外でconn.Close()する必要アリ
        public void beResponse(string SQLquery ,ref SQLiteDataReader reader) {
            var cmd = new SQLiteCommand(SQLquery, conn);
            try {
                conn.Open();
                reader = cmd.ExecuteReader();
            }
            catch (Exception err){
                MessageBox.Show("SELECTの結果が取得出来ませんでした\n" + err.ToString() + "内容をコピーしました");
                Clipboard.SetText(SQLquery + "\n\n" + err.ToString());
            }
        }

        //テーブル自動作成
        public void make_db() {
            string setting = "CREATE TABLE IF NOT EXISTS t_doujinshi(" +
                                "ID INTEGER PRIMARY KEY NOT NULL," +
                                "title TEXT NOT NULL," +
                                "origin_ID INTEGER NOT NULL," +
                                "genre_ID INTEGER NOT NULL," +
                                "age_limit TEXT NOT NULL," +
                                "date INTEGER," +
                                "main_chara TEXT," +
                                "place TEXT" +
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
                             "); ";
            nonResponse(setting);

            //ジャンルコード・作品コード一覧初期設定
            if (checkRecord("t_origin") < 8) {
                string original = "INSERT INTO t_origin VALUES(1,'東方プロジェクト');" +
                         "INSERT INTO t_origin VALUES(2, '艦これ');" +
                         "INSERT INTO t_origin VALUES(3, 'オリジナル');" +
                         "INSERT INTO t_origin VALUES(4, 'グラブル');" +
                         "INSERT INTO t_origin VALUES(5, 'ATLUS系');" +
                         "INSERT INTO t_origin VALUES(6, 'ラブライブ');" +
                         "INSERT INTO t_origin VALUES(7, 'デレマス');" +
                         "INSERT INTO t_origin VALUES(8, 'その他');";
                nonResponse(original);
            }
            if (checkRecord("t_genre") < 13) {
                string genre = "INSERT INTO t_genre VALUES(1,'漫画');" +
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
                nonResponse(genre);
            }
        }
    }
}
