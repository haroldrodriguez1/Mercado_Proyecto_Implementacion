namespace Mercadito_Chavez_Sanabria
{
    partial class ImprimirCompra
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
            this.sp_ImprimirCompraBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.mercado_Chavez_SanabriaDataSet6local = new Mercadito_Chavez_Sanabria.Mercado_Chavez_SanabriaDataSet6local();
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.spImprimirCompraBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.sp_ImprimirCompraTableAdapter = new Mercadito_Chavez_Sanabria.Mercado_Chavez_SanabriaDataSet6localTableAdapters.sp_ImprimirCompraTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.sp_ImprimirCompraBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.mercado_Chavez_SanabriaDataSet6local)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.spImprimirCompraBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // sp_ImprimirCompraBindingSource
            // 
            this.sp_ImprimirCompraBindingSource.DataMember = "sp_ImprimirCompra";
            this.sp_ImprimirCompraBindingSource.DataSource = this.mercado_Chavez_SanabriaDataSet6local;
            // 
            // mercado_Chavez_SanabriaDataSet6local
            // 
            this.mercado_Chavez_SanabriaDataSet6local.DataSetName = "Mercado_Chavez_SanabriaDataSet6local";
            this.mercado_Chavez_SanabriaDataSet6local.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // reportViewer1
            // 
            this.reportViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource1.Name = "ImprimirCompra";
            reportDataSource1.Value = this.sp_ImprimirCompraBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "Mercadito_Chavez_Sanabria.ImprimirCompra.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(0, 0);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.ServerReport.BearerToken = null;
            this.reportViewer1.Size = new System.Drawing.Size(800, 450);
            this.reportViewer1.TabIndex = 0;
            // 
            // spImprimirCompraBindingSource
            // 
            this.spImprimirCompraBindingSource.DataMember = "sp_ImprimirCompra";
            this.spImprimirCompraBindingSource.DataSource = this.mercado_Chavez_SanabriaDataSet6local;
            // 
            // sp_ImprimirCompraTableAdapter
            // 
            this.sp_ImprimirCompraTableAdapter.ClearBeforeFill = true;
            // 
            // ImprimirCompra
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.reportViewer1);
            this.Name = "ImprimirCompra";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ImprimirCompra";
            this.Load += new System.EventHandler(this.ImprimirCompra_Load);
            ((System.ComponentModel.ISupportInitialize)(this.sp_ImprimirCompraBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.mercado_Chavez_SanabriaDataSet6local)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.spImprimirCompraBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private System.Windows.Forms.BindingSource sp_ImprimirCompraBindingSource;
        private Mercado_Chavez_SanabriaDataSet6local mercado_Chavez_SanabriaDataSet6local;
        private System.Windows.Forms.BindingSource spImprimirCompraBindingSource;
        private Mercado_Chavez_SanabriaDataSet6localTableAdapters.sp_ImprimirCompraTableAdapter sp_ImprimirCompraTableAdapter;
    }
}