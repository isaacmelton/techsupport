namespace WindowsFormsApplication4.View
{
    partial class IncidentReport
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
            this.incidentsBindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.techSupportDataSetBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.techSupportDataSet = new WindowsFormsApplication4.TechSupportDataSet();
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.IncidentsBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.incidentsTableAdapter = new WindowsFormsApplication4.TechSupportDataSetTableAdapters.IncidentsTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.incidentsBindingSource1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.techSupportDataSetBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.techSupportDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.IncidentsBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // incidentsBindingSource1
            // 
            this.incidentsBindingSource1.DataMember = "Incidents";
            this.incidentsBindingSource1.DataSource = this.techSupportDataSetBindingSource;
            // 
            // techSupportDataSetBindingSource
            // 
            this.techSupportDataSetBindingSource.DataSource = this.techSupportDataSet;
            this.techSupportDataSetBindingSource.Position = 0;
            // 
            // techSupportDataSet
            // 
            this.techSupportDataSet.DataSetName = "TechSupportDataSet";
            this.techSupportDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // reportViewer1
            // 
            this.reportViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource1.Name = "OpenByProducts";
            reportDataSource1.Value = this.incidentsBindingSource1;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "WindowsFormsApplication4.IncidentReport.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(0, 0);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.Size = new System.Drawing.Size(714, 442);
            this.reportViewer1.TabIndex = 0;
            // 
            // IncidentsBindingSource
            // 
            this.IncidentsBindingSource.DataMember = "Incidents";
            this.IncidentsBindingSource.DataSource = this.techSupportDataSet;
            // 
            // incidentsTableAdapter
            // 
            this.incidentsTableAdapter.ClearBeforeFill = true;
            // 
            // IncidentReport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(714, 442);
            this.Controls.Add(this.reportViewer1);
            this.Name = "IncidentReport";
            this.Text = "Open Incident Report";
            this.Load += new System.EventHandler(this.IncidentReport_Load);
            ((System.ComponentModel.ISupportInitialize)(this.incidentsBindingSource1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.techSupportDataSetBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.techSupportDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.IncidentsBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private System.Windows.Forms.BindingSource techSupportDataSetBindingSource;
        private TechSupportDataSet techSupportDataSet;
        private System.Windows.Forms.BindingSource IncidentsBindingSource;
        private System.Windows.Forms.BindingSource incidentsBindingSource1;
        private TechSupportDataSetTableAdapters.IncidentsTableAdapter incidentsTableAdapter;

    }
}