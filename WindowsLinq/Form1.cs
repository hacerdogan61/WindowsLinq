﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsLinq
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        DataNorthWindDataContext db = new DataNorthWindDataContext();
        private void Form1_Load(object sender, EventArgs e)
        {

            var sales = db.Sales_by_Year(new DateTime(1990,1,1),new DateTime(2000,1,1));
            SalesGrid.DataSource = sales;
            var q = from c in db.Customers  select new { c.CustomerID, c.CompanyName };
            dataGridView1.DataSource = q;
        }
    }
}
