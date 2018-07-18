using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

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
    }
}
