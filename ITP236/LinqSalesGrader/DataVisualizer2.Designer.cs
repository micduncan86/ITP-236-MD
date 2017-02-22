namespace LinqSalesGrader
{
    partial class DataVisualizer2
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.CustomerView = new System.Windows.Forms.DataGridView();
            this.SalesOrderView = new System.Windows.Forms.DataGridView();
            this.SopView = new System.Windows.Forms.DataGridView();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.groupBoxSalesOrder = new System.Windows.Forms.GroupBox();
            this.groupBoxCustomer = new System.Windows.Forms.GroupBox();
            this.shipmentPartBox = new System.Windows.Forms.GroupBox();
            this.ShipmentView = new System.Windows.Forms.DataGridView();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.ShipmentPartView = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.CustomerView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SalesOrderView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SopView)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.groupBoxSalesOrder.SuspendLayout();
            this.groupBoxCustomer.SuspendLayout();
            this.shipmentPartBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ShipmentView)).BeginInit();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ShipmentPartView)).BeginInit();
            this.SuspendLayout();
            // 
            // CustomerView
            // 
            this.CustomerView.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.CustomerView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.CustomerView.Location = new System.Drawing.Point(7, 20);
            this.CustomerView.Name = "CustomerView";
            this.CustomerView.Size = new System.Drawing.Size(1111, 98);
            this.CustomerView.TabIndex = 0;
            // 
            // SalesOrderView
            // 
            this.SalesOrderView.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.SalesOrderView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.SalesOrderView.Location = new System.Drawing.Point(7, 20);
            this.SalesOrderView.Name = "SalesOrderView";
            this.SalesOrderView.Size = new System.Drawing.Size(1111, 98);
            this.SalesOrderView.TabIndex = 0;
            // 
            // SopView
            // 
            this.SopView.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.SopView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.SopView.Location = new System.Drawing.Point(7, 20);
            this.SopView.Name = "SopView";
            this.SopView.Size = new System.Drawing.Size(1111, 98);
            this.SopView.TabIndex = 0;
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.Controls.Add(this.SopView);
            this.groupBox2.Location = new System.Drawing.Point(-3, 266);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(1124, 134);
            this.groupBox2.TabIndex = 6;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Sales Order Part";
            // 
            // groupBoxSalesOrder
            // 
            this.groupBoxSalesOrder.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBoxSalesOrder.Controls.Add(this.SalesOrderView);
            this.groupBoxSalesOrder.Location = new System.Drawing.Point(-3, 138);
            this.groupBoxSalesOrder.Name = "groupBoxSalesOrder";
            this.groupBoxSalesOrder.Size = new System.Drawing.Size(1124, 134);
            this.groupBoxSalesOrder.TabIndex = 5;
            this.groupBoxSalesOrder.TabStop = false;
            this.groupBoxSalesOrder.Text = "Sales Order";
            // 
            // groupBoxCustomer
            // 
            this.groupBoxCustomer.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBoxCustomer.Controls.Add(this.CustomerView);
            this.groupBoxCustomer.Location = new System.Drawing.Point(-3, 14);
            this.groupBoxCustomer.Name = "groupBoxCustomer";
            this.groupBoxCustomer.Size = new System.Drawing.Size(1124, 134);
            this.groupBoxCustomer.TabIndex = 4;
            this.groupBoxCustomer.TabStop = false;
            this.groupBoxCustomer.Text = "Customer";
            // 
            // shipmentPartBox
            // 
            this.shipmentPartBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.shipmentPartBox.Controls.Add(this.ShipmentPartView);
            this.shipmentPartBox.Location = new System.Drawing.Point(-1, 519);
            this.shipmentPartBox.Name = "shipmentPartBox";
            this.shipmentPartBox.Size = new System.Drawing.Size(1124, 134);
            this.shipmentPartBox.TabIndex = 8;
            this.shipmentPartBox.TabStop = false;
            this.shipmentPartBox.Text = "Shipment Part";
            // 
            // ShipmentView
            // 
            this.ShipmentView.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ShipmentView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.ShipmentView.Location = new System.Drawing.Point(8, 17);
            this.ShipmentView.Name = "ShipmentView";
            this.ShipmentView.Size = new System.Drawing.Size(1111, 98);
            this.ShipmentView.TabIndex = 0;
            // 
            // groupBox3
            // 
            this.groupBox3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox3.Controls.Add(this.ShipmentView);
            this.groupBox3.Location = new System.Drawing.Point(-5, 392);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(1124, 134);
            this.groupBox3.TabIndex = 7;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Shipment";
            // 
            // ShipmentPartView
            // 
            this.ShipmentPartView.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ShipmentPartView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.ShipmentPartView.Location = new System.Drawing.Point(7, 18);
            this.ShipmentPartView.Name = "ShipmentPartView";
            this.ShipmentPartView.Size = new System.Drawing.Size(1111, 98);
            this.ShipmentPartView.TabIndex = 7;
            // 
            // DataVisualizer2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1119, 665);
            this.Controls.Add(this.shipmentPartBox);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBoxSalesOrder);
            this.Controls.Add(this.groupBoxCustomer);
            this.Name = "DataVisualizer2";
            this.Text = "Customer / Sales Order";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.DataVisualizer2_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.CustomerView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SalesOrderView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SopView)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBoxSalesOrder.ResumeLayout(false);
            this.groupBoxCustomer.ResumeLayout(false);
            this.shipmentPartBox.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ShipmentView)).EndInit();
            this.groupBox3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ShipmentPartView)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView CustomerView;
        private System.Windows.Forms.DataGridView SalesOrderView;
        private System.Windows.Forms.DataGridView SopView;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBoxSalesOrder;
        private System.Windows.Forms.GroupBox groupBoxCustomer;
        private System.Windows.Forms.GroupBox shipmentPartBox;
        private System.Windows.Forms.DataGridView ShipmentView;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.DataGridView ShipmentPartView;
    }
}