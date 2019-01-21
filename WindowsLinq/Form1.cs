using System;
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

        private void dataGridView1_MouseClick(object sender, MouseEventArgs e)
        {
            string cusId = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            var order = from ord in db.Orders
                        where ord.CustomerID == cusId
                        select ord;
            OrderGrid.DataSource = order;
            int DetId = Convert.ToInt32(OrderGrid.CurrentRow.Cells[0].Value.ToString());
            var detail = from det in db.Order_Details where det.OrderID == DetId select det;
            OrderDetailGrid.DataSource = detail;
        }
    }
}
