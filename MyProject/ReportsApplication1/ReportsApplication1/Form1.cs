﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ReportsApplication1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // TODO:  这行代码将数据加载到表“DataSet.ItemTableView”中。您可以根据需要移动或删除它。
            this.ItemTableViewTableAdapter.Fill(this.DataSet.ItemTableView);
            this.reportViewer1.RefreshReport();
        }
    }
}