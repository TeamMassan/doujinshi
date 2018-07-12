﻿using System;
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

        //保管先が変更された時に書棚を当該場所の内容に変える
        private void storage_SelectedIndexChanged(object sender, EventArgs e) {
            //保管場所IDの変更
            SQLiteDataReader reader = null;
            string query = "SELECT place FROM t_storage WHERE  place_name = '" + storage.Text + "'";
            SQLiteConnect.Excute(query, ref reader);
            if (reader != null) {
                reader.Read();
                placeID = Convert.ToInt32(reader["place"]);
                reader.Close();
            }
            SQLiteConnect.conn.Close();

            //本棚の内容変更
            query = "SELECT shelf_name FROM t_house_shelf WHERE "+
                "(SELECT place FROM t_storage WHERE place_name = '"+storage.Text+"') = t_house_shelf.place";
            bookShelf.Items.Clear();
            SQLiteConnect.ComboBoxLoad(ref bookShelf, query, "shelf_name");
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
