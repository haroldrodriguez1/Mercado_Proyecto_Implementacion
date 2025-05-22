namespace Mercadito_Chavez_Sanabria
{
    partial class FacturasAnuladas
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
            this.reporteFacturasAnuladasBindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.mercado_Chavez_SanabriaDataSet6local = new Mercadito_Chavez_Sanabria.Mercado_Chavez_SanabriaDataSet6local();
            this.reporteFacturasAnuladasBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.mercado_Chavez_SanabriaDataSet6 = new Mercadito_Chavez_Sanabria.Mercado_Chavez_SanabriaDataSet6();
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.reporte_FacturasAnuladasTableAdapter = new Mercadito_Chavez_Sanabria.Mercado_Chavez_SanabriaDataSet6TableAdapters.Reporte_FacturasAnuladasTableAdapter();
            this.btnRegresar = new System.Windows.Forms.Button();
            this.reporte_FacturasAnuladasTableAdapter1 = new Mercadito_Chavez_Sanabria.Mercado_Chavez_SanabriaDataSet6localTableAdapters.Reporte_FacturasAnuladasTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.reporteFacturasAnuladasBindingSource1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.mercado_Chavez_SanabriaDataSet6local)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.reporteFacturasAnuladasBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.mercado_Chavez_SanabriaDataSet6)).BeginInit();
            this.SuspendLayout();
            // 
            // reporteFacturasAnuladasBindingSource1
            // 
            this.reporteFacturasAnuladasBindingSource1.DataMember = "Reporte_FacturasAnuladas";
            this.reporteFacturasAnuladasBindingSource1.DataSource = this.mercado_Chavez_SanabriaDataSet6local;
            // 
            // mercado_Chavez_SanabriaDataSet6local
            // 
            this.mercado_Chavez_SanabriaDataSet6local.DataSetName = "Mercado_Chavez_SanabriaDataSet6local";
            this.mercado_Chavez_SanabriaDataSet6local.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // reporteFacturasAnuladasBindingSource
            // 
            this.reporteFacturasAnuladasBindingSource.DataMember = "Reporte_FacturasAnuladas";
            this.reporteFacturasAnuladasBindingSource.DataSource = this.mercado_Chavez_SanabriaDataSet6;
            // 
            // mercado_Chavez_SanabriaDataSet6
            // 
            this.mercado_Chavez_SanabriaDataSet6.DataSetName = "Mercado_Chavez_SanabriaDataSet6";
            this.mercado_Chavez_SanabriaDataSet6.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // reportViewer1
            // 
            reportDataSource1.Name = "DataSetFacturasAnuladaslocal";
            reportDataSource1.Value = this.reporteFacturasAnuladasBindingSource1;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "Mercadito_Chavez_Sanabria.FacturasAnuladas.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(0, 47);
            this.reportViewer1.Margin = new System.Windows.Forms.Padding(2);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.ServerReport.BearerToken = null;
            this.reportViewer1.Size = new System.Drawing.Size(600, 319);
            this.reportViewer1.TabIndex = 0;
            // 
            // reporte_FacturasAnuladasTableAdapter
            // 
            this.reporte_FacturasAnuladasTableAdapter.ClearBeforeFill = true;
            // 
            // btnRegresar
            // 
            this.btnRegresar.BackColor = System.Drawing.Color.Lime;
            this.btnRegresar.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRegresar.Location = new System.Drawing.Point(217, 12);
            this.btnRegresar.Name = "btnRegresar";
            this.btnRegresar.Size = new System.Drawing.Size(177, 25);
            this.btnRegresar.TabIndex = 48;
            this.btnRegresar.Text = "Regresar al Menu";
            this.btnRegresar.UseVisualStyleBackColor = false;
            this.btnRegresar.Click += new System.EventHandler(this.btnRegresar_Click);
            // 
            // reporte_FacturasAnuladasTableAdapter1
            // 
            this.reporte_FacturasAnuladasTableAdapter1.ClearBeforeFill = true;
            // 
            // FacturasAnuladas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(600, 366);
            this.Controls.Add(this.btnRegresar);
            this.Controls.Add(this.reportViewer1);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "FacturasAnuladas";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FacturasAnuladas";
            this.Load += new System.EventHandler(this.FacturasAnuladas_Load);
            ((System.ComponentModel.ISupportInitialize)(this.reporteFacturasAnuladasBindingSource1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.mercado_Chavez_SanabriaDataSet6local)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.reporteFacturasAnuladasBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.mercado_Chavez_SanabriaDataSet6)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private Mercado_Chavez_SanabriaDataSet6 mercado_Chavez_SanabriaDataSet6;
        private System.Windows.Forms.BindingSource reporteFacturasAnuladasBindingSource;
        private Mercado_Chavez_SanabriaDataSet6TableAdapters.Reporte_FacturasAnuladasTableAdapter reporte_FacturasAnuladasTableAdapter;
        private System.Windows.Forms.Button btnRegresar;
        private Mercado_Chavez_SanabriaDataSet6local mercado_Chavez_SanabriaDataSet6local;
        private System.Windows.Forms.BindingSource reporteFacturasAnuladasBindingSource1;
        private Mercado_Chavez_SanabriaDataSet6localTableAdapters.Reporte_FacturasAnuladasTableAdapter reporte_FacturasAnuladasTableAdapter1;
    }
}