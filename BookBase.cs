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
using System.Data.SQLite;
using System.Drawing.Imaging;

namespace 同人誌管理 {
    public partial class BookBase : Form {
        public BookBase() {
            InitializeComponent();

            //デザインモード中は実行しない
            if (this.IsDesignMode())
                return;

            string query;
            SQLiteDataReader reader = null;
            //作品一覧をロード
            query = "SELECT origin_title FROM t_origin";
            SQLiteConnect.Excute(query, ref reader);
            if (reader != null) {
                while (reader.Read())
                    originComboBox.Items.Add(reader["origin_title"].ToString());
                reader.Close();
                SQLiteConnect.conn.Close();
                originComboBox.SelectedIndex = 0;
            }

            //ジャンル一覧をロード
            query = "SELECT genre_title FROM t_genre";
            SQLiteConnect.Excute(query, ref reader);
            if (reader != null) {
                while (reader.Read())
                    genreComboBox.Items.Add(reader["genre_title"].ToString());
                reader.Close();
                SQLiteConnect.conn.Close();
                genreComboBox.SelectedIndex = 0;
            }

            //サムネのDrag&Dropを許可
            pictureBox.AllowDrop = true;
            //サムネイルの読み込み
            pictureBox.Image = Image.FromFile(@"Thumbnail\NoImage.jpg");
        }

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

        //登録データの空欄チェック(タイトル、頒布日)して、空欄があればtrueを返す
        protected bool checkNullForm() {
            string empty = "";
            bool empty_flag = false;
            if (titleForm.Text == "") {
                empty += "タイトル、";
                empty_flag = true;
            }

            //頒布日はnull可項目なので入力内容が存在する & 8桁でない時に注意を促す
            string date = Date.merge(yearForm.Text, monthForm.Text, dayForm.Text);
            if (yearForm.Text == "" || monthForm.Text == "" || dayForm.Text == "" || date.Length != 8) {
                empty += "頒布日、";
                empty_flag = true;
            }

            //記入漏れ箇所提言
            if (empty_flag)
                MessageBox.Show(empty + "が空白です。");

            return empty_flag;
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
