﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace 同人誌管理 {
    public partial class table_manage : Form {
        public table_manage() {
            InitializeComponent();
        }

        private void table_manage_Load(object sender, EventArgs e)
        {
            //どっかからlistboxに値を格納
        }

        private void close_Click(object sender, EventArgs e)
        {
            Visible = false;

        }
    }
}
