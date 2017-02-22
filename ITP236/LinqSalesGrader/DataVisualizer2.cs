using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using LinqSalesProjectGrader2;

namespace LinqSalesGrader
{
    public partial class DataVisualizer2 : Form
    {
        public ProjectData data { get; set; }
        public DataVisualizer2()
        {
            InitializeComponent();
        }
        internal void BindData()
        {
            CustomerView.DataSource = data.Customers.OrderBy(c => c.CustomerId).ToList();
            SalesOrderView.DataSource = data.SalesOrders.OrderBy(so => so.SalesOrderNumber).ToList();
            SopView.DataSource = data.SalesOrderParts.OrderBy(sop => sop.SalesOrderNumber).ThenBy(sop => sop.SalesOrderPartId).ToList();
            ShipmentView.DataSource = data.Shipments.OrderBy(s => s.ShipmentId).ToList();
            ShipmentPartView.DataSource = data.ShipmentParts.OrderBy(sp => sp.ShipmentId).ThenBy(sp => sp.ShipmentPartId).ToList();
        }
        private void DataVisualizer_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.Hide();
            e.Cancel = true;
        }

        private void DataVisualizer2_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.Hide();
            e.Cancel = true;
        }
    }
}
