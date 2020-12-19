
namespace NewKursach
{
    partial class ReportForm
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
            this.components = new System.ComponentModel.Container();
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource1 = new Microsoft.Reporting.WinForms.ReportDataSource();
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.KursachDataSet1 = new NewKursach.KursachDataSet1();
            this.Доходы_сотрудниковBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.Доходы_сотрудниковTableAdapter = new NewKursach.KursachDataSet1TableAdapters.Доходы_сотрудниковTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.KursachDataSet1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Доходы_сотрудниковBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // reportViewer1
            // 
            reportDataSource1.Name = "DataSet1";
            reportDataSource1.Value = this.Доходы_сотрудниковBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "NewKursach.Report2.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(0, -1);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.ServerReport.BearerToken = null;
            this.reportViewer1.Size = new System.Drawing.Size(658, 451);
            this.reportViewer1.TabIndex = 0;
            // 
            // KursachDataSet1
            // 
            this.KursachDataSet1.DataSetName = "KursachDataSet1";
            this.KursachDataSet1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // Доходы_сотрудниковBindingSource
            // 
            this.Доходы_сотрудниковBindingSource.DataMember = "Доходы сотрудников";
            this.Доходы_сотрудниковBindingSource.DataSource = this.KursachDataSet1;
            // 
            // Доходы_сотрудниковTableAdapter
            // 
            this.Доходы_сотрудниковTableAdapter.ClearBeforeFill = true;
            // 
            // ReportForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(657, 450);
            this.Controls.Add(this.reportViewer1);
            this.Name = "ReportForm";
            this.Text = "ReportForm";
            this.Load += new System.EventHandler(this.ReportForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.KursachDataSet1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Доходы_сотрудниковBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private System.Windows.Forms.BindingSource Доходы_сотрудниковBindingSource;
        private KursachDataSet1 KursachDataSet1;
        private KursachDataSet1TableAdapters.Доходы_сотрудниковTableAdapter Доходы_сотрудниковTableAdapter;
    }
}