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
    public partial class DataVisualizer3 : Form
    {
        public ProjectData data { get; set; }

        public DataVisualizer3()
        {
            InitializeComponent();
        }

        internal void BindData()
        {
            VendorView.DataSource = data.Vendors.OrderBy(v => v.VendorId).ToList();
            PurchaseOrderView.DataSource = data.PurchaseOrders.OrderBy(po => po.PurchaseOrderNumber);
            PoPartView.DataSource = data.PurchaseOrderParts
                .OrderBy(pop => pop.PurchaseOrderNumber)
                .ThenBy(pop => pop.PurchaseOrderPartId)
                .ToList();
            ReceiptView.DataSource = data.Receipts.OrderBy(r => r.PurchaseOrderPartId).ToList();
        }
        private void DataVisualizer3_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.Hide();
            e.Cancel = true;
        }

    }
}
