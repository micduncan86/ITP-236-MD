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
using LinqSalesStudent;

namespace LinqSalesGrader
{
    public partial class DataVisualizer : Form
    {
        public ProjectData data { get; set; }
        public DataVisualizer()
        {
            InitializeComponent();
        }
        internal void BindData()
        {
            PartView.DataSource = data.Parts.OrderBy(p => p.PartId).ToList();
            SpoilageView.DataSource = data.Spoilages.OrderBy(s => s.SpoilageId).ToList().ToList();
        }
        private void DataVisualizer_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.Hide();
            e.Cancel = true;
        }
    }
}
