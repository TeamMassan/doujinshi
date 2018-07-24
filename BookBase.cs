using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Imaging;
using System.Data.SQLite;

namespace 同人誌管理 {
    public partial class BookBase : Form {
        public BookBase() {
            InitializeComponent();

            //継承先フォームではデザインビュー閲覧時にコンストラクタが実行されてしまう
            //回避策としてデザインモード中は実行しない
            if (this.IsDesignMode())
                return;
            string query;
            //作品一覧をロード
            query = "SELECT origin_title FROM t_origin";
            SQLiteConnect.ComboBoxLoad(ref originComboBox, query, "origin_title");

            //ジャンル一覧をロード
            query = "SELECT genre_title FROM t_genre";
            SQLiteConnect.ComboBoxLoad(ref genreComboBox, query, "genre_title");

            //保管場所一覧をロード
            query = "SELECT place_name FROM t_storage";
            SQLiteConnect.ComboBoxLoad(ref storage, query, "place_name");
            //storage.Textがchangedするので本棚一覧もロードされる
            placeID = 1;    //保管場所を最初の項目で初期化

            //西暦にローカルタイムから過去15年分を追加
            DateTime dt = DateTime.Today;
            for (int cnt = 0; cnt < 15; cnt++) 
                yearForm.Items.Add(dt.Year - cnt);
            for (int cnt = 1; cnt <= 12; cnt++)
                monthForm.Items.Add(cnt);
            for (int cnt = 1; cnt <= 31; cnt++)
                dayForm.Items.Add(cnt);

            //サムネのDrag&Dropを許可
            pictureBox.AllowDrop = true;

            //サムネイルの読み込み
            pictureBox.Image = Image.FromFile(@"Thumbnail\NoImage.jpg");
        }

        //保管場所のplace_ID
        protected int placeID;

        //サムネイル変更フラグ
        //trueになったらサムネを保存してfalseに戻す
        protected bool changedThumbnail = false;

        protected void openThumbnailBottun_Click(object sender, EventArgs e) {
            if (openThumbnailDialog.ShowDialog() == DialogResult.OK) {
                pictureBox.Image = Image.FromFile(openThumbnailDialog.FileName);
                changedThumbnail = true;
            }
        }

        //ファイルをドラッグした状態で入ったときにマウスアイコン変更
        protected void pictureBox_DragEnter(object sender, DragEventArgs e) {
            if (e.Data.GetDataPresent(DataFormats.FileDrop) ||
                e.Data.GetDataPresent(DataFormats.Text))
                e.Effect = DragDropEffects.Copy;
        }

        protected void pictureBox_DragDrop(object sender, DragEventArgs e) {
            string dragDropPath = null;

            //D&Dされたデータがファイルであることを確認
            if (e.Data.GetDataPresent(DataFormats.FileDrop)) {
                //Dragされたファイル名は配列で格納されているので頭だけ取る
                dragDropPath = ((string[])e.Data.GetData(DataFormats.FileDrop))[0];
            }
            //ブラウザからDragなら画像URLを取得
            else if (e.Data.GetDataPresent(DataFormats.Text)) {
                dragDropPath = e.Data.GetData(DataFormats.Text).ToString();
            } else {
                MessageBox.Show("ファイルパスが取得出来ないか、ファイルが未対応です。");
                return;
            }
            pictureBox.Image = Image.FromFile(dragDropPath);
            changedThumbnail = true;
        }

        //閉じるボタンの処理
        protected void close_Click(object sender, EventArgs e) {
            this.Close();
        }

        //登録データの空欄チェック(タイトル、頒布日等)して
        //空欄があればユーザーに指摘してtrueを返す
        protected bool checkNullForm() {
            string empty = "";
            bool empty_flag = false;
            if (titleForm.Text.Length == 0) {
                empty += "タイトル、";
                empty_flag = true;
            }
            if (circleForm.Text.Length == 0) {
                empty += "サークル名、";
                empty_flag = true;
            }
            if (authorsForm.Text.Length == 0) {
                empty += "作者名、";
                empty_flag = true;
            }

            //頒布日はnull可項目なので入力内容が存在する & 8桁でない時に注意を促す
            string date = Date.merge(yearForm.Text, monthForm.Text, dayForm.Text);
            if (yearForm.Text.Length == 0 || monthForm.Text.Length == 0 || dayForm.Text.Length == 0 || date.Length != 8) {
                empty += "頒布日、";
                empty_flag = true;
            }

            //記入漏れ箇所提言
            if (empty_flag)
                MessageBox.Show(empty + "が空白です。");

            return empty_flag;
        }

        //保管先が変更された時に書棚を当該場所の内容に変える
        protected void storage_SelectedIndexChanged(object sender, EventArgs e) {
            //別のreader読み込み処理中にconn.Close()してしまう減少を回避する
            if (SQLiteConnect.conn.State == ConnectionState.Open)
                return;
            SQLiteDataReader reader = null;
            string query = "SELECT place_ID FROM t_storage WHERE  place_name = '" + storage.Text + "'";
            SQLiteConnect.Excute(query, ref reader);
            if (reader != null) {
                reader.Read();
                // 保管場所IDの変更
                placeID = Convert.ToInt32(reader["place_ID"]);
                reader.Close();
            }
            SQLiteConnect.conn.Close();

            //本棚の内容変更
            query = "SELECT shelf_name FROM t_house_shelf WHERE "+
                "(SELECT place_ID FROM t_storage WHERE place_name = '"+storage.Text+"') = t_house_shelf.place_ID";
            bookShelf.Items.Clear();
            SQLiteConnect.ComboBoxLoad(ref bookShelf, query, "shelf_name");
        }

        protected void yearForm_Enter(object sender, EventArgs e) {
            yearForm.SelectAll();
        }

        protected void yearForm_TextChanged(object sender, EventArgs e) {
            if (yearForm.Text.Length > 4)
                yearForm.Text = yearForm.Text.Substring(0, 4);
        }

        protected void monthForm_Enter(object sender, EventArgs e) {
            monthForm.SelectAll();
        }

        protected void monthForm_TextChanged(object sender, EventArgs e) {
            if (monthForm.Text.Length > 2)
                monthForm.Text = monthForm.Text.Substring(0, 2);
        }

        protected void dayForm_Enter(object sender, EventArgs e) {
            dayForm.SelectAll();
        }
        
        protected void dayForm_TextChanged(object sender, EventArgs e) {
            if (dayForm.Text.Length > 2)
                dayForm.Text = dayForm.Text.Substring(0, 2);
        }

        //入力中にEnterで既存のサークル名を補完
        protected void circleForm_KeyDown(object sender, KeyEventArgs e) {
            Suggest(circleForm, e, "circle");
        }

        //既存の作者名を補完
        protected void authorsForm_KeyDown(object sender, KeyEventArgs e) {
            Suggest(authorsForm, e, "author");
        }

        //既存サークルや作者の候補を提案する
        protected void Suggest(TextBox textbox, KeyEventArgs e, string column_name) {
            string inputtingWord = textbox.Text.Split(',').Last();
            //,より後の入力文字が2文字以上の時のみ候補をサジェストする
            if (inputtingWord.Length < 2 || e.KeyCode != Keys.Enter)
                return;
            string query = "SELECT DISTINCT " + column_name + " FROM t_" + column_name + " WHERE " + column_name + " LIKE '" + inputtingWord + "%' LIMIT 1";
            SQLiteDataReader reader = null;
            SQLiteConnect.Excute(query, ref reader);
            if (reader != null) {
                if (reader.HasRows) {
                    reader.Read();
                    string remnant = reader[column_name].ToString();
                    //未入力の文字列を差分としてremnantに取得
                    if (inputtingWord.CompareTo(remnant) != 0) {
                        remnant = remnant.Substring(inputtingWord.Length);
                        int currentEnd = textbox.Text.Length;
                        textbox.AppendText(remnant);
                        textbox.Select(currentEnd, textbox.Text.Length - 1);
                    }
                }
            }
            reader.Close();
            SQLiteConnect.conn.Close();
        }

        //サークルが入力済みの場合、作者候補を自動で入れる
        private void authorsForm_Enter(object sender, EventArgs e) {
            if (circleForm.Text.Length > 0 && authorsForm.Text.Length == 0) {
                string inputtedCircle = circleForm.Text.Split(',').First();
                string query = "SELECT author FROM t_author WHERE " +
                    "(SELECT ID FROM t_circle WHERE circle = '" + inputtedCircle + "') = ID LIMIT 1";
                SQLiteDataReader reader = null;
                SQLiteConnect.Excute(query, ref reader);
                if (reader != null) {
                    if (reader.HasRows) {
                        reader.Read();
                        string candidate = reader["author"].ToString();
                        authorsForm.AppendText(candidate);
                        authorsForm.SelectAll();
                    }
                }
                reader.Close();
                SQLiteConnect.conn.Close();
            }
        }
    }

    //デザインモード中かどうか判断
    public static class ControlExtensions {
        public static bool IsDesignMode(this Control ctrl) {
            bool returnFlag = false;
            if (LicenseManager.UsageMode == LicenseUsageMode.Designtime)
                returnFlag = true;
            else if (Process.GetCurrentProcess().ProcessName.ToUpper().Equals("DEVENV")
                || Process.GetCurrentProcess().ProcessName.ToUpper().Equals("VCSEXPRESS"))
                returnFlag = true;
            else if (AppDomain.CurrentDomain.FriendlyName == "DefaultDomain")
                returnFlag = true;

            return returnFlag;
        }
    }
}
