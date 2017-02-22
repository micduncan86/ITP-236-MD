namespace LinqSalesGrader
{
    partial class Form1
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
            this.ResultsView = new System.Windows.Forms.DataGridView();
            this.ProjectName = new System.Windows.Forms.Label();
            this.StudentName = new System.Windows.Forms.Label();
            this.GradeSummary = new System.Windows.Forms.Label();
            this.Percentage = new System.Windows.Forms.Label();
            this.TestView = new System.Windows.Forms.DataGridView();
            this.ProgressIndicator = new System.Windows.Forms.ProgressBar();
            this.HeaderPanel = new System.Windows.Forms.Panel();
            this.AnswerView = new System.Windows.Forms.DataGridView();
            this.StudentView = new System.Windows.Forms.DataGridView();
            this.AnswerPanel = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.StudentPanel = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.DataVisualize = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.ResultsView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TestView)).BeginInit();
            this.HeaderPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.AnswerView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.StudentView)).BeginInit();
            this.AnswerPanel.SuspendLayout();
            this.StudentPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // ResultsView
            // 
            this.ResultsView.AllowUserToAddRows = false;
            this.ResultsView.AllowUserToDeleteRows = false;
            this.ResultsView.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.ResultsView.BackgroundColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.ResultsView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.ResultsView.Location = new System.Drawing.Point(73, 128);
            this.ResultsView.Name = "ResultsView";
            this.ResultsView.ReadOnly = true;
            this.ResultsView.Size = new System.Drawing.Size(810, 194);
            this.ResultsView.TabIndex = 0;
            this.ResultsView.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.ResultsView_CellClick);
            this.ResultsView.ColumnAdded += new System.Windows.Forms.DataGridViewColumnEventHandler(this.ResultsView_ColumnAdded);
            // 
            // ProjectName
            // 
            this.ProjectName.AutoSize = true;
            this.ProjectName.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ProjectName.Location = new System.Drawing.Point(17, 11);
            this.ProjectName.Name = "ProjectName";
            this.ProjectName.Size = new System.Drawing.Size(66, 24);
            this.ProjectName.TabIndex = 1;
            this.ProjectName.Text = "label1";
            this.ProjectName.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // StudentName
            // 
            this.StudentName.AutoSize = true;
            this.StudentName.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.StudentName.Location = new System.Drawing.Point(17, 35);
            this.StudentName.Name = "StudentName";
            this.StudentName.Size = new System.Drawing.Size(66, 24);
            this.StudentName.TabIndex = 2;
            this.StudentName.Text = "label1";
            this.StudentName.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // GradeSummary
            // 
            this.GradeSummary.AutoSize = true;
            this.GradeSummary.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.GradeSummary.Location = new System.Drawing.Point(17, 59);
            this.GradeSummary.Name = "GradeSummary";
            this.GradeSummary.Size = new System.Drawing.Size(66, 24);
            this.GradeSummary.TabIndex = 3;
            this.GradeSummary.Text = "label1";
            this.GradeSummary.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // Percentage
            // 
            this.Percentage.AutoSize = true;
            this.Percentage.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Percentage.ForeColor = System.Drawing.Color.Blue;
            this.Percentage.Location = new System.Drawing.Point(17, 83);
            this.Percentage.Name = "Percentage";
            this.Percentage.Size = new System.Drawing.Size(66, 24);
            this.Percentage.TabIndex = 4;
            this.Percentage.Text = "label1";
            this.Percentage.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // TestView
            // 
            this.TestView.AllowUserToAddRows = false;
            this.TestView.AllowUserToDeleteRows = false;
            this.TestView.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.TestView.BackgroundColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.TestView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.TestView.Location = new System.Drawing.Point(73, 328);
            this.TestView.Name = "TestView";
            this.TestView.ReadOnly = true;
            this.TestView.Size = new System.Drawing.Size(810, 216);
            this.TestView.TabIndex = 5;
            this.TestView.Visible = false;
            this.TestView.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.TestView_CellClick);
            this.TestView.ColumnAdded += new System.Windows.Forms.DataGridViewColumnEventHandler(this.TestView_ColumnAdded);
            this.TestView.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.TestView_DataBindingComplete);
            // 
            // ProgressIndicator
            // 
            this.ProgressIndicator.Location = new System.Drawing.Point(119, 83);
            this.ProgressIndicator.Name = "ProgressIndicator";
            this.ProgressIndicator.Size = new System.Drawing.Size(236, 23);
            this.ProgressIndicator.Step = 5;
            this.ProgressIndicator.TabIndex = 6;
            // 
            // HeaderPanel
            // 
            this.HeaderPanel.Controls.Add(this.ProjectName);
            this.HeaderPanel.Controls.Add(this.StudentName);
            this.HeaderPanel.Controls.Add(this.ProgressIndicator);
            this.HeaderPanel.Controls.Add(this.GradeSummary);
            this.HeaderPanel.Controls.Add(this.Percentage);
            this.HeaderPanel.Location = new System.Drawing.Point(150, 12);
            this.HeaderPanel.Name = "HeaderPanel";
            this.HeaderPanel.Size = new System.Drawing.Size(505, 110);
            this.HeaderPanel.TabIndex = 8;
            // 
            // AnswerView
            // 
            this.AnswerView.AllowUserToAddRows = false;
            this.AnswerView.AllowUserToDeleteRows = false;
            this.AnswerView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.AnswerView.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.AnswerView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.AnswerView.Location = new System.Drawing.Point(3, 15);
            this.AnswerView.Name = "AnswerView";
            this.AnswerView.ReadOnly = true;
            this.AnswerView.Size = new System.Drawing.Size(421, 181);
            this.AnswerView.TabIndex = 9;
            this.AnswerView.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.AnswerView_DataBindingComplete);
            // 
            // StudentView
            // 
            this.StudentView.AllowUserToAddRows = false;
            this.StudentView.AllowUserToDeleteRows = false;
            this.StudentView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.StudentView.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.StudentView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.StudentView.Location = new System.Drawing.Point(4, 20);
            this.StudentView.Name = "StudentView";
            this.StudentView.ReadOnly = true;
            this.StudentView.Size = new System.Drawing.Size(493, 183);
            this.StudentView.TabIndex = 10;
            // 
            // AnswerPanel
            // 
            this.AnswerPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.AnswerPanel.Controls.Add(this.label1);
            this.AnswerPanel.Controls.Add(this.AnswerView);
            this.AnswerPanel.Location = new System.Drawing.Point(12, 540);
            this.AnswerPanel.Margin = new System.Windows.Forms.Padding(2);
            this.AnswerPanel.Name = "AnswerPanel";
            this.AnswerPanel.Size = new System.Drawing.Size(427, 200);
            this.AnswerPanel.TabIndex = 11;
            this.AnswerPanel.Visible = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(2, 0);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(42, 13);
            this.label1.TabIndex = 10;
            this.label1.Text = "Answer";
            // 
            // StudentPanel
            // 
            this.StudentPanel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.StudentPanel.Controls.Add(this.label2);
            this.StudentPanel.Controls.Add(this.StudentView);
            this.StudentPanel.Location = new System.Drawing.Point(443, 540);
            this.StudentPanel.Margin = new System.Windows.Forms.Padding(2);
            this.StudentPanel.Name = "StudentPanel";
            this.StudentPanel.Size = new System.Drawing.Size(501, 203);
            this.StudentPanel.TabIndex = 12;
            this.StudentPanel.Visible = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(2, 0);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(77, 13);
            this.label2.TabIndex = 11;
            this.label2.Text = "Student Result";
            // 
            // DataVisualize
            // 
            this.DataVisualize.Location = new System.Drawing.Point(707, 71);
            this.DataVisualize.Name = "DataVisualize";
            this.DataVisualize.Size = new System.Drawing.Size(176, 46);
            this.DataVisualize.TabIndex = 13;
            this.DataVisualize.Text = "Visualize Data";
            this.DataVisualize.UseVisualStyleBackColor = true;
            this.DataVisualize.Click += new System.EventHandler(this.DataVisualize_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(954, 750);
            this.Controls.Add(this.DataVisualize);
            this.Controls.Add(this.StudentPanel);
            this.Controls.Add(this.AnswerPanel);
            this.Controls.Add(this.HeaderPanel);
            this.Controls.Add(this.TestView);
            this.Controls.Add(this.ResultsView);
            this.Name = "Form1";
            this.Text = "ITP-236 OOP Project Grader";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.ResultsView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TestView)).EndInit();
            this.HeaderPanel.ResumeLayout(false);
            this.HeaderPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.AnswerView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.StudentView)).EndInit();
            this.AnswerPanel.ResumeLayout(false);
            this.AnswerPanel.PerformLayout();
            this.StudentPanel.ResumeLayout(false);
            this.StudentPanel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView ResultsView;
        private System.Windows.Forms.Label ProjectName;
        private System.Windows.Forms.Label StudentName;
        private System.Windows.Forms.Label GradeSummary;
        private System.Windows.Forms.Label Percentage;
        private System.Windows.Forms.DataGridView TestView;
        private System.Windows.Forms.ProgressBar ProgressIndicator;
        private System.Windows.Forms.Panel HeaderPanel;
        private System.Windows.Forms.DataGridView AnswerView;
        private System.Windows.Forms.DataGridView StudentView;
        private System.Windows.Forms.Panel AnswerPanel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel StudentPanel;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button DataVisualize;
    }
}

