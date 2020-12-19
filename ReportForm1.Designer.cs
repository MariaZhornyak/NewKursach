
namespace NewKursach
{
    partial class ReportForm1
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
            this.KursachDataSet2 = new NewKursach.KursachDataSet2();
            this.Информация_про_сотрудниковBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.Информация_про_сотрудниковTableAdapter = new NewKursach.KursachDataSet2TableAdapters.Информация_про_сотрудниковTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.KursachDataSet2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Информация_про_сотрудниковBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // reportViewer1
            // 
            reportDataSource1.Name = "DataSet1";
            reportDataSource1.Value = this.Информация_про_сотрудниковBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "NewKursach.Report3.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(-1, 0);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.ServerReport.BearerToken = null;
            this.reportViewer1.Size = new System.Drawing.Size(781, 452);
            this.reportViewer1.TabIndex = 0;
            // 
            // KursachDataSet2
            // 
            this.KursachDataSet2.DataSetName = "KursachDataSet2";
            this.KursachDataSet2.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // Информация_про_сотрудниковBindingSource
            // 
            this.Информация_про_сотрудниковBindingSource.DataMember = "Информация про сотрудников";
            this.Информация_про_сотрудниковBindingSource.DataSource = this.KursachDataSet2;
            // 
            // Информация_про_сотрудниковTableAdapter
            // 
            this.Информация_про_сотрудниковTableAdapter.ClearBeforeFill = true;
            // 
            // ReportForm1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(778, 450);
            this.Controls.Add(this.reportViewer1);
            this.Name = "ReportForm1";
            this.Text = "ReportForm1";
            this.Load += new System.EventHandler(this.ReportForm1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.KursachDataSet2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Информация_про_сотрудниковBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private System.Windows.Forms.BindingSource Информация_про_сотрудниковBindingSource;
        private KursachDataSet2 KursachDataSet2;
        private KursachDataSet2TableAdapters.Информация_про_сотрудниковTableAdapter Информация_про_сотрудниковTableAdapter;
    }
}