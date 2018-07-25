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

namespace 同人誌管理
{
    public partial class manageBase : Form
    {
        public manageBase()
        {
            InitializeComponent();
        }
       protected int beforeListView1ID;
       protected int beforeListview2ID;
       protected string beforeListview1Title;
       protected string beforeListview2Title;

        protected void close_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        protected void Listview1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (Listview1.SelectedItems.Count > 0)
            {
               Textbox1.Text = Listview1.SelectedItems[0].SubItems[1].Text;
                beforeListView1ID = int.Parse(Listview1.SelectedItems[0].SubItems[0].Text);
                beforeListview1Title = Listview1.SelectedItems[0].SubItems[1].Text;
            }
        }

        protected void Listview2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (Listview2.SelectedItems.Count > 0)
            {
                Textbox2.Text = Listview2.SelectedItems[0].SubItems[1].Text;
                beforeListview2ID = int.Parse(Listview2.SelectedItems[0].SubItems[0].Text);
                beforeListview2Title = Listview2.SelectedItems[0].SubItems[1].Text;
            }
        }

    }
}
