namespace Mercadito_Chavez_Sanabria
{
    partial class ComprasProveedor
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
            this.Reporte_ComprasPorProveedorBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.mercado_Chavez_SanabriaDataSet6local = new Mercadito_Chavez_Sanabria.Mercado_Chavez_SanabriaDataSet6local();
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.btnRegresar = new System.Windows.Forms.Button();
            this.reporteComprasPorProveedorBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.reporte_ComprasPorProveedorTableAdapter = new Mercadito_Chavez_Sanabria.Mercado_Chavez_SanabriaDataSet6localTableAdapters.Reporte_ComprasPorProveedorTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.Reporte_ComprasPorProveedorBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.mercado_Chavez_SanabriaDataSet6local)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.reporteComprasPorProveedorBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // Reporte_ComprasPorProveedorBindingSource
            // 
            this.Reporte_ComprasPorProveedorBindingSource.DataMember = "Reporte_ComprasPorProveedor";
            this.Reporte_ComprasPorProveedorBindingSource.DataSource = this.mercado_Chavez_SanabriaDataSet6local;
            // 
            // mercado_Chavez_SanabriaDataSet6local
            // 
            this.mercado_Chavez_SanabriaDataSet6local.DataSetName = "Mercado_Chavez_SanabriaDataSet6local";
            this.mercado_Chavez_SanabriaDataSet6local.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // reportViewer1
            // 
            reportDataSource1.Name = "DataSet1";
            reportDataSource1.Value = this.Reporte_ComprasPorProveedorBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "Mercadito_Chavez_Sanabria.ComprasProveedor.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(0, 49);
            this.reportViewer1.Margin = new System.Windows.Forms.Padding(2);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.ServerReport.BearerToken = null;
            this.reportViewer1.Size = new System.Drawing.Size(600, 317);
            this.reportViewer1.TabIndex = 0;
            // 
            // btnRegresar
            // 
            this.btnRegresar.BackColor = System.Drawing.Color.Lime;
            this.btnRegresar.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRegresar.Location = new System.Drawing.Point(209, 12);
            this.btnRegresar.Name = "btnRegresar";
            this.btnRegresar.Size = new System.Drawing.Size(177, 25);
            this.btnRegresar.TabIndex = 48;
            this.btnRegresar.Text = "Regresar al Menu";
            this.btnRegresar.UseVisualStyleBackColor = false;
            this.btnRegresar.Click += new System.EventHandler(this.btnRegresar_Click);
            // 
            // reporteComprasPorProveedorBindingSource
            // 
            this.reporteComprasPorProveedorBindingSource.DataMember = "Reporte_ComprasPorProveedor";
            this.reporteComprasPorProveedorBindingSource.DataSource = this.mercado_Chavez_SanabriaDataSet6local;
            // 
            // reporte_ComprasPorProveedorTableAdapter
            // 
            this.reporte_ComprasPorProveedorTableAdapter.ClearBeforeFill = true;
            // 
            // ComprasProveedor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(600, 366);
            this.Controls.Add(this.btnRegresar);
            this.Controls.Add(this.reportViewer1);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "ComprasProveedor";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ComprasProveedor";
            this.Load += new System.EventHandler(this.ComprasProveedor_Load);
            ((System.ComponentModel.ISupportInitialize)(this.Reporte_ComprasPorProveedorBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.mercado_Chavez_SanabriaDataSet6local)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.reporteComprasPorProveedorBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private System.Windows.Forms.Button btnRegresar;
        private Mercado_Chavez_SanabriaDataSet6local mercado_Chavez_SanabriaDataSet6local;
        private System.Windows.Forms.BindingSource reporteComprasPorProveedorBindingSource;
        private Mercado_Chavez_SanabriaDataSet6localTableAdapters.Reporte_ComprasPorProveedorTableAdapter reporte_ComprasPorProveedorTableAdapter;
        private System.Windows.Forms.BindingSource Reporte_ComprasPorProveedorBindingSource;
    }
}